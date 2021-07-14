using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ResourcePackUtils
{
    public partial class ResourcePackUtils : Form
    {
        private string _jarPath, _mcVer, _rpPath, _multiMcPath;
        private Settings _settings = new Settings();

        public ResourcePackUtils(string path)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(path))
                _rpPath = Environment.CurrentDirectory;
            else
                _rpPath = path;

            Init();
            SetPaths();
        }

        private void Init()
        {
            mcVerTextBox.Text = _settings.GetLastEnteredVersion();
            multimcRadioButton.Checked = _settings.GetUseMultiMC();
            _multiMcPath = _settings.GetMultiMCPath();
            includeRealms.Checked = _settings.GetIncludeRealmsMT();

            if (!String.IsNullOrWhiteSpace(mcVerTextBox.Text))
                locateButton_Click(null, null);
        }

        public void SetMultiMcPath(string path)
        {
            _multiMcPath = path;
            _settings.SetMultiMCPath(_multiMcPath);
        }

        private void GetJarAndPackFiles(out string[] jarFiles, out string[] packFiles)
        {
            string[] jarFilesL = new string[] { };
            string[] packFilesL = new string[] { };

            Thread jarThread = new Thread(() =>
            {
                jarFilesL = GetFileListFromJar();
            });

            Thread packThread = new Thread(() =>
            {
                packFilesL = GetFileListFromPack();
            });

            jarThread.Start();
            packThread.Start();

            while (jarThread.IsAlive || packThread.IsAlive)
                Thread.Sleep(10);

            jarFiles = jarFilesL;
            packFiles = packFilesL;
        }

        private string[] GetFileListFromPack()
        {
            string[] allFiles = Directory.GetFiles(_rpPath, "*.png", SearchOption.AllDirectories);
            List<string> usefulFiles = new List<string>();
            foreach (string file in allFiles)
            {
                if (file.Contains("font"))
                    continue;

                if (!includeRealms.Checked && file.Contains("realms"))
                    continue;

                string path = file.Replace(_rpPath, string.Empty).TrimStart('\\', '/').Replace('\\', '/');
                usefulFiles.Add(path);
            }

            return usefulFiles.ToArray();
        }

        private string[] GetFileListFromJar()
        {
            List<string> usefulFiles = new List<string>();
            using (ZipArchive zip = ZipFile.OpenRead(_jarPath))
            {
                int totalEntries = zip.Entries.Count;
                foreach (ZipArchiveEntry file in zip.Entries)
                {
                    if (file.FullName.EndsWith("png"))
                    {
                        if (file.FullName.Contains("font"))
                            continue;

                        if (!includeRealms.Checked && file.FullName.Contains("realms"))
                            continue;

                        usefulFiles.Add(file.FullName);
                    }
                }
            }
            return usefulFiles.ToArray();
        }

        private bool IsPackPathValid()
        {
            try
            {
                return File.Exists(Path.Combine(_rpPath, "pack.mcmeta"));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void changeMultiMCPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMultiMCPath setPath = new SetMultiMCPath(this, _multiMcPath);
            setPath.StartPosition = FormStartPosition.CenterParent;
            setPath.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Resource Pack Utils {0}\r\nby mullak99", Program.GetVersion()), "About", MessageBoxButtons.OK);
        }

        private void mtSearchButton_Click(object sender, EventArgs e)
        {
            _settings.SetIncludeRealmsMT(includeRealms.Checked);

            int missing = 0;
            int missingItems = 0;
            int missingBlocks = 0;

            int total = 0;
            int totalItems = 0;
            int totalBlocks = 0;

            missingTexturesTextBox.Text = string.Empty;

            Thread searchThread = new Thread(() =>
            {
                GetJarAndPackFiles(out var jarFiles, out var packFiles);

                if (jarFiles != null && packFiles != null)
                {
                    foreach (string file in jarFiles)
                    {
                        total++;

                        if (file.Contains("/minecraft/textures/item/"))
                            totalItems++;
                        else if (file.Contains("/minecraft/textures/block/"))
                            totalBlocks++;

                        if (packFiles.Contains(file))
                            continue;

                        if (file.Contains("/minecraft/textures/item/"))
                            missingItems++;
                        else if (file.Contains("/minecraft/textures/block/"))
                            missingBlocks++;

                        missing++;
                        missingTexturesTextBox.AppendText(file + Environment.NewLine);
                    }

                    missingTextures.Text = String.Format("Items: {0}\r\nBlocks: {1}\r\nTotal: {2}", missingItems, missingBlocks, missing);
                    totalStats.Text = String.Format("Items: {0}/{1}\r\nBlocks: {2}/{3}\r\nTotal: {4}/{5}", totalItems - missingItems, totalItems, totalBlocks - missingBlocks, totalBlocks, total - missing, total);
                    mtExportButton.Enabled = true;
                }
            });
            searchThread.Start();
        }

        private void searchButtonUT_Click(object sender, EventArgs e)
        {
            _settings.SetIncludeRealmsUT(includeRealmsUT.Checked);

            int unused = 0;
            int unusedItems = 0;
            int unusedBlocks = 0;

            unusedTexturesTextBox.Text = string.Empty;

            Thread searchThread = new Thread(() =>
            {
                GetJarAndPackFiles(out var jarFiles, out var packFiles);

                if (jarFiles != null && packFiles != null)
                {
                    foreach (string file in packFiles)
                    {
                        if (!file.Contains("/minecraft/") || file.Contains("/optifine/") || file.Contains("/ctm/") || file.Contains("/custom/"))
                            continue;

                        if (jarFiles.Contains(file))
                            continue;

                        if (file.Contains("/minecraft/textures/item/"))
                            unusedItems++;
                        else if (file.Contains("/minecraft/textures/block/"))
                            unusedBlocks++;

                        unused++;
                        unusedTexturesTextBox.AppendText(file + Environment.NewLine);
                    }

                    unusedStats.Text = String.Format("Items: {0}\r\nBlocks: {1}\r\nTotal: {2}", unusedItems, unusedBlocks, unused);
                    exportButtonUT.Enabled = true;
                }
            });
            searchThread.Start();
        }

        private void exportButtonUT_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(_rpPath, "UnusedTextures.log"), unusedTexturesTextBox.Text);
        }

        private void mtExportButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(_rpPath, "MissingTextures.log"), missingTexturesTextBox.Text);
        }

        private void SetPaths()
        {
            if (!String.IsNullOrWhiteSpace(_jarPath))
            {
                jarLocPath.Text = "MC Jar: " + _jarPath;
                toolTip.SetToolTip(jarLocPath, _jarPath);
            }
            else
            {
                jarLocPath.Text = "MC Jar: (Not Located)";
                toolTip.SetToolTip(jarLocPath, "(Not Located)");
            }

            if (!String.IsNullOrWhiteSpace(_rpPath))
            {
                rpLocPath.Text = "Resource Pack: " + _rpPath;
                toolTip.SetToolTip(rpLocPath, _rpPath);
            }
            else
            {
                rpLocPath.Text = "Resource Pack: (Not Located)";
                toolTip.SetToolTip(rpLocPath, "(Not Located)");
            }

            _settings.SetLastEnteredVersion(_mcVer);
            _settings.SetUseMultiMC(multimcRadioButton.Checked);
        }

        private void locateButton_Click(object sender, EventArgs e)
        {
            if (vanillaRadioButtom.Checked)
            {
                //Vanilla
                _mcVer = mcVerTextBox.Text;
                _jarPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft", "versions", _mcVer, String.Format("{0}.jar", _mcVer));
            }
            else
            {
                //MultiMC
                if (String.IsNullOrWhiteSpace(_multiMcPath))
                {
                    changeMultiMCPathToolStripMenuItem_Click(sender, e);
                    return;
                }
                else
                {
                    _mcVer = mcVerTextBox.Text;
                    _jarPath = Path.Combine(_multiMcPath.Replace("MultiMC.exe", string.Empty).TrimEnd('\\', '/'), 
                        "libraries", "com", "mojang", "minecraft", _mcVer, String.Format("minecraft-{0}-client.jar", _mcVer));
                }
            }

            try
            {
                if (!File.Exists(_jarPath)) throw new FileNotFoundException("Jar file not found!");
                if (!IsPackPathValid()) throw new FileNotFoundException("Pack not found!");

                tabControl.Enabled = true;
                locatedLabel.Text = "Located!";
                locatedLabel.ForeColor = Color.LimeGreen;
            }
            catch (FileNotFoundException ex)
            {
                if (ex.Message == "Jar file not found!")
                    MessageBox.Show("This version does not exist! Are you sure it is installed?", "Error locating jar", MessageBoxButtons.OK);
                else if (ex.Message == "Pack not found!")
                    MessageBox.Show("Invalid resource pack! pack.mcmeta could not be found.", "Error locating pack.mcmeta", MessageBoxButtons.OK);

                locatedLabel.Text = "Not Located!";
                locatedLabel.ForeColor = Color.Red;
                tabControl.Enabled = false;
                _jarPath = string.Empty;
            }
            SetPaths();
        }
    }
}

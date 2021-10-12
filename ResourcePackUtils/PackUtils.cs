using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ResourcePackUtils.Utils;

namespace ResourcePackUtils
{
    public partial class ResourcePackUtils : Form
    {
        private string _jarPath, _mcVer;
        private readonly string _rpPath;
        private string _multiMcPath;
        private readonly Settings _settings = new Settings();
        private readonly List<Thread> compressThreads = new List<Thread>();
        public ResourcePackUtils(string path)
        {
            InitializeComponent();
            _rpPath = string.IsNullOrWhiteSpace(path) ? Environment.CurrentDirectory : path;
            Init();
            SetPaths();
        }

        private void Init()
        {
            mcVerTextBox.Text = _settings.GetLastEnteredVersion();
            multimcRadioButton.Checked = _settings.GetUseMultiMC();
            _multiMcPath = _settings.GetMultiMCPath();
            includeRealmsMT.Checked = _settings.GetIncludeRealmsMT();
            includeRealmsUT.Checked = _settings.GetIncludeRealmsUT();

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

        private string[] GetFileListFromPack(bool includeOriginalPath = false)
        {
            string[] allFiles = Directory.GetFiles(_rpPath, "*.png", SearchOption.AllDirectories);
            List<string> usefulFiles = new List<string>();
            foreach (string file in allFiles)
            {
                if (file.Contains("font"))
                    continue;

                if (!includeRealmsMT.Checked && file.Contains("realms"))
                    continue;

                string path = file.Replace(_rpPath, string.Empty).TrimStart('\\', '/').Replace('\\', '/');
                usefulFiles.Add(includeOriginalPath ? Path.Combine(_rpPath, path).Replace('\\', '/') : path);
            }

            return usefulFiles.ToArray();
        }

        private string[] GetFileListFromJar()
        {
            List<string> usefulFiles = new List<string>();
            using (ZipArchive zip = ZipFile.OpenRead(_jarPath))
            {
                foreach (ZipArchiveEntry file in zip.Entries)
                {
                    if (file.FullName.EndsWith("png"))
                    {
                        if (file.FullName.Contains("font"))
                            continue;

                        if (!includeRealmsMT.Checked && file.FullName.Contains("realms"))
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

        private void exportFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread exportThread = new Thread(() =>
            {
                List<PackFileInfo> packFiles = new List<PackFileInfo>();

                string[] allFiles = Directory.GetFiles(_rpPath, "*.png", SearchOption.AllDirectories);
                foreach (string file in allFiles)
                {
                    string path = file.Replace(_rpPath, string.Empty).TrimStart('\\', '/').Replace('\\', '/');

                    PackFileInfo pFile = new PackFileInfo
                    {
                        Path = path.Replace('\\', '/'),
                        Name = Path.GetFileName(path)
                    };

                    if (path.Contains("assets/minecraft/"))
                    {
                        if (path.Contains("/textures/block"))
                            pFile.FileType = PackFileType.BLOCK;
                        else if (path.Contains("/textures/colormap"))
                            pFile.FileType = PackFileType.COLORMAP;
                        else if (path.Contains("/textures/ctm"))
                            pFile.FileType = PackFileType.CTM;
                        else if (path.Contains("/textures/effect"))
                            pFile.FileType = PackFileType.EFFECT;
                        else if (path.Contains("/textures/entity"))
                            pFile.FileType = PackFileType.ENTITY;
                        else if (path.Contains("/textures/environment"))
                            pFile.FileType = PackFileType.ENVIRONMENT;
                        else if (path.Contains("/textures/font"))
                            pFile.FileType = PackFileType.FONT;
                        else if (path.Contains("/textures/gui"))
                            pFile.FileType = PackFileType.GUI;
                        else if (path.Contains("/textures/item"))
                            pFile.FileType = PackFileType.ITEM;
                        else if (path.Contains("/textures/map"))
                            pFile.FileType = PackFileType.MAP;
                        else if (path.Contains("/textures/misc"))
                            pFile.FileType = PackFileType.MISC;
                        else if (path.Contains("/textures/mob_effect"))
                            pFile.FileType = PackFileType.MOB_EFFECT;
                        else if (path.Contains("/textures/models"))
                            pFile.FileType = PackFileType.MODELS;
                        else if (path.Contains("/textures/painting"))
                            pFile.FileType = PackFileType.PAINTING;
                        else if (path.Contains("/textures/particle"))
                            pFile.FileType = PackFileType.PARTICLE;
                        else if (path.Contains("/optifine/ctm"))
                            pFile.FileType = PackFileType.OPTIFINE_CTM;
                        else
                            pFile.FileType = PackFileType.OTHER_MC;
                    }
                    else if (path.Contains("assets/realms/textures/"))
                    {
                        pFile.FileType = PackFileType.REALMS;
                    }
                    else
                        pFile.FileType = PackFileType.OTHER;

                    packFiles.Add(pFile);
                }

                // TODO: This is messy. Needs redoing in a better way
                string rawText = "== Minecraft [Block] (/assets/minecraft/textures/block) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.BLOCK).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Item] (/assets/minecraft/textures/item) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.ITEM).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Entity] (/assets/minecraft/textures/entity) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.ENTITY).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [GUI] (/assets/minecraft/textures/gui) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.GUI).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [CTM] (/assets/minecraft/textures/ctm) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.CTM).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Particle] (/assets/minecraft/textures/particle) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.PARTICLE).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Font] (/assets/minecraft/textures/font) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.FONT).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Colormap] (/assets/minecraft/textures/colormap) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.COLORMAP).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Effect] (/assets/minecraft/textures/effect) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.EFFECT).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Environment] (/assets/minecraft/textures/environment): ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.ENVIRONMENT).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Map] (/assets/minecraft/textures/map) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.MAP).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Misc] (/assets/minecraft/textures/misc) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.MISC).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Mob Effect] (/assets/minecraft/textures/mob_effect) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.MOB_EFFECT).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Models] (/assets/minecraft/textures/models) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.MODELS).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Painting] (/assets/minecraft/textures/painting) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.PAINTING).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/textures/", "")})\n";

                rawText += "\n== Minecraft [Optifine] (/assets/minecraft/optifine/ctm) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.OPTIFINE_CTM).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/minecraft/optifine/ctm/", "")})\n";

                rawText += "\n== Minecraft [Realms] (/assets/realms/textures) ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.REALMS).ToList())
                    rawText += $"{p.Name} ({p.Path.Replace("assets/realms/textures/gui/", "")})\n";

                rawText += "\n== Minecraft [OTHER (MC)] ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.OTHER_MC).ToList())
                    rawText += $"{p.Name} ({p.Path})\n";

                rawText += "\n== Minecraft [OTHER (Unknown)] ==\n";
                foreach (PackFileInfo p in packFiles.FindAll(p => p.FileType == PackFileType.OTHER).ToList())
                    rawText += $"{p.Name} ({p.Path})\n";

                File.WriteAllText(Path.Combine(_rpPath, "Export.txt"), rawText); // TODO: Allow user to change filename?
            });
            exportThread.Start();
        }

        private void mtSearchButton_Click(object sender, EventArgs e)
        {
            _settings.SetIncludeRealmsMT(includeRealmsMT.Checked);

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

        private void compressButton_Click(object sender, EventArgs e)
        {
            compressButton.Enabled = false;
            threadCount.Enabled = false;
            compLevel.Enabled = false;

            int compressedFiles = 0;
            int threads = (int)threadCount.Value;
            int comp = (int)compLevel.Value;
            long totalSizeSave = 0;

            Thread compressThread = new Thread(() =>
            {
                List<string> packFiles = GetFileListFromPack(true).ToList();

                if (packFiles.Count > 0)
                {
                    compressBasicStats.Invoke((MethodInvoker)(() => compressBasicStats.Text = String.Format("Total: 0/{0}", packFiles.Count)));
                    threadStatsLabel.Invoke((MethodInvoker)(() => threadStatsLabel.Text = String.Format("Threads: 0/{0}", threads)));
                    int noOfFilesEach = Convert.ToInt32(Math.Ceiling((double)packFiles.Count / threads));
                    List<List<string>> listsToProcess = SplitIntoChunks(packFiles, noOfFilesEach);

                    foreach (List<string> list in listsToProcess)
                    {
                        Thread workThread = new Thread(() =>
                        {
                            foreach (string file in list)
                            {
                                long initFileSize = new FileInfo(file).Length;

                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                    startInfo.FileName = "cmd.exe";
                                    startInfo.Arguments = $"/C optipng -o{comp} -fix -silent \"{file}\""; // TODO: Add check to see if optipng exists before running it
                                    startInfo.UseShellExecute = true;
                                    startInfo.CreateNoWindow = true;
                                    process.StartInfo = startInfo;
                                    process.Start();
                                    process.WaitForExit();

                                    compressedFiles++;
                                    int files = compressedFiles;
                                    compressBasicStats.Invoke((MethodInvoker)(() => compressBasicStats.Text = $"Total: {files}/{packFiles.Count}"));
                                }
                                catch (Exception ex)
                                {
                                    compressTextBox.Invoke((MethodInvoker)(() => compressTextBox.AppendText($"Exception: {ex.Message}" + Environment.NewLine)));
                                }

                                long finalFileSize = new FileInfo(file).Length;
                                long fileSizeSave = initFileSize - finalFileSize;
                                totalSizeSave += fileSizeSave;
                                string sizeSaved = SizeSuffix(totalSizeSave);
                                compressTextBox.Invoke((MethodInvoker)(() => compressTextBox.AppendText($"Compressed '{file}'. Saved {fileSizeSave} bytes!" + Environment.NewLine)));
                                compressTextBox.Invoke((MethodInvoker)(() => compressTextBox.ScrollToCaret()));
                                fileSizeSaveLabel.Invoke((MethodInvoker)(() => fileSizeSaveLabel.Text = $"Saved: {sizeSaved}"));
                                this.Invoke((MethodInvoker)(() => toolTip.SetToolTip(fileSizeSaveLabel, $"Total filesize saved: {sizeSaved}")));
                            }
                        });
                        compressThreads.Add(workThread);
                        workThread.Start();
                    }

                    Thread.Sleep(100);
                    bool[] threadDone = new bool[compressThreads.Count];
                    int threadsRunning = compressThreads.Count;
                    while (compressThreads.Any(t => t.IsAlive) || threadDone.Any(d => d == false))
                    {
                        for (int i = 0; i < compressThreads.Count; i++)
                        {
                            if (!threadDone[i] && !compressThreads[i].IsAlive)
                            {
                                threadsRunning--;
                                threadDone[i] = true;
                                int threadNo = i;
                                compressTextBox.Invoke((MethodInvoker)(() => compressTextBox.AppendText($"Thread {threadNo} has finished!" + Environment.NewLine)));
                            }
                        }
                        int running = threadsRunning;
                        threadStatsLabel.Invoke((MethodInvoker)(() => threadStatsLabel.Text = $"Threads: {running}/{threads}"));
                        this.Invoke((MethodInvoker)(() => toolTip.SetToolTip(threadStatsLabel, $"Threads running: {running}")));
                        Thread.Sleep(1000);
                    }
                    compressTextBox.Invoke((MethodInvoker)(() => compressTextBox.AppendText("All threads finished!" + Environment.NewLine)));
                    compressButton.Enabled = true;
                    threadCount.Enabled = true;
                    compLevel.Enabled = true;
                }
            });
            compressThread.Start();
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

        private static List<List<T>> SplitIntoChunks<T>(List<T> list, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("chunkSize must be greater than 0.");
            }

            List<List<T>> retVal = new List<List<T>>();
            int index = 0;
            while (index < list.Count)
            {
                int count = list.Count - index > chunkSize ? chunkSize : list.Count - index;
                retVal.Add(list.GetRange(index, count));

                index += chunkSize;
            }

            return retVal;
        }

        private static readonly string[] SizeSuffixes =
            { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        private static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }

            int i = 0;
            decimal dValue = value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }
            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                if (compressThreads.Count > 0 && compressThreads.Any(t => t.IsAlive))
                    foreach (Thread t in compressThreads) t.Abort();
                return;
            }

            if (compressThreads.Count > 0 && compressThreads.Any(t => t.IsAlive))
            {
                switch (MessageBox.Show(this, "An operation is currently running, are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        if (compressThreads.Count > 0 && compressThreads.Any(t => t.IsAlive)) // Ensure the tasks are still running after user input
                            foreach (Thread t in compressThreads) t.Abort();
                        break;
                }
            }
        }
    }
}

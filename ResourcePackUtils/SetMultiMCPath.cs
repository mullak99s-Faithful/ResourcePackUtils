using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourcePackUtils
{
    public partial class SetMultiMCPath : Form
    {
        private readonly ResourcePackUtils _parent;

        public SetMultiMCPath(ResourcePackUtils parentForm, string path)
        {
            InitializeComponent();

            _parent = parentForm;
            multiMcPath.Text = path;
        }

        private void multiMcPath_TextChanged(object sender, EventArgs e)
        {
            confirmButton.Enabled = File.Exists(multiMcPath.Text);
        }

        private void openFileDiag_Click(object sender, EventArgs e)
        {
            Thread fileThread = new Thread(() =>
            {
                using (OpenFileDialog fileDiag = new OpenFileDialog
                {
                    Filter = "MultiMC|MultiMC.exe"
                })
                {

                    if (fileDiag.ShowDialog() == DialogResult.OK)
                    {
                        string path = fileDiag.FileName;
                        Invoke(new Action(() =>
                        {
                            multiMcPath.Text = Path.GetFullPath(path);
                        }));
                    }
                }
            });
            fileThread.SetApartmentState(ApartmentState.STA);
            fileThread.Start();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            _parent.SetMultiMcPath(multiMcPath.Text);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

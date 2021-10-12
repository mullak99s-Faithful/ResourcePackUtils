
namespace ResourcePackUtils
{
    partial class ResourcePackUtils
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourcePackUtils));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMultiMCPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.typeMcInstallLabel = new System.Windows.Forms.Label();
            this.vanillaRadioButtom = new System.Windows.Forms.RadioButton();
            this.multimcRadioButton = new System.Windows.Forms.RadioButton();
            this.mcVersionLabel = new System.Windows.Forms.Label();
            this.mcVerTextBox = new System.Windows.Forms.TextBox();
            this.locateButton = new System.Windows.Forms.Button();
            this.jarLocPath = new System.Windows.Forms.Label();
            this.rpLocPath = new System.Windows.Forms.Label();
            this.locatedLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.includeRealmsMT = new System.Windows.Forms.CheckBox();
            this.missingTextures = new System.Windows.Forms.Label();
            this.mtExportButton = new System.Windows.Forms.Button();
            this.mtSearchButton = new System.Windows.Forms.Button();
            this.missingLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalStats = new System.Windows.Forms.Label();
            this.unusedLabel = new System.Windows.Forms.Label();
            this.includeRealmsUT = new System.Windows.Forms.CheckBox();
            this.unusedStats = new System.Windows.Forms.Label();
            this.exportButtonUT = new System.Windows.Forms.Button();
            this.searchButtonUT = new System.Windows.Forms.Button();
            this.compStatsLabel = new System.Windows.Forms.Label();
            this.compressBasicStats = new System.Windows.Forms.Label();
            this.compressButton = new System.Windows.Forms.Button();
            this.compConfLabel = new System.Windows.Forms.Label();
            this.threadCount = new System.Windows.Forms.NumericUpDown();
            this.threadLabel = new System.Windows.Forms.Label();
            this.compLevel = new System.Windows.Forms.NumericUpDown();
            this.compLevelLabel = new System.Windows.Forms.Label();
            this.fileSizeSaveLabel = new System.Windows.Forms.Label();
            this.threadStatsLabel = new System.Windows.Forms.Label();
            this.missingTexturesTab = new System.Windows.Forms.TabPage();
            this.missingTexturesTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.unusedTexturesTab = new System.Windows.Forms.TabPage();
            this.unusedTexturesTextBox = new System.Windows.Forms.RichTextBox();
            this.compressionTab = new System.Windows.Forms.TabPage();
            this.compressTextBox = new System.Windows.Forms.RichTextBox();
            this.exportFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compLevel)).BeginInit();
            this.missingTexturesTab.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.unusedTexturesTab.SuspendLayout();
            this.compressionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(524, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFileListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeMultiMCPathToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // changeMultiMCPathToolStripMenuItem
            // 
            this.changeMultiMCPathToolStripMenuItem.Name = "changeMultiMCPathToolStripMenuItem";
            this.changeMultiMCPathToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.changeMultiMCPathToolStripMenuItem.Text = "Change MultiMC Path";
            this.changeMultiMCPathToolStripMenuItem.Click += new System.EventHandler(this.changeMultiMCPathToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.typeMcInstallLabel);
            this.flowLayoutPanel1.Controls.Add(this.vanillaRadioButtom);
            this.flowLayoutPanel1.Controls.Add(this.multimcRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.mcVersionLabel);
            this.flowLayoutPanel1.Controls.Add(this.mcVerTextBox);
            this.flowLayoutPanel1.Controls.Add(this.locateButton);
            this.flowLayoutPanel1.Controls.Add(this.jarLocPath);
            this.flowLayoutPanel1.Controls.Add(this.rpLocPath);
            this.flowLayoutPanel1.Controls.Add(this.locatedLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(524, 75);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // typeMcInstallLabel
            // 
            this.typeMcInstallLabel.Location = new System.Drawing.Point(3, 0);
            this.typeMcInstallLabel.Name = "typeMcInstallLabel";
            this.typeMcInstallLabel.Padding = new System.Windows.Forms.Padding(2);
            this.typeMcInstallLabel.Size = new System.Drawing.Size(106, 22);
            this.typeMcInstallLabel.TabIndex = 0;
            this.typeMcInstallLabel.Text = "Vanilla or MultiMC:";
            this.typeMcInstallLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.typeMcInstallLabel, "Whether to seach within a vanilla launcher install, or within a MultiMC install, " +
        "for the appropriate Minecraft JAR");
            // 
            // vanillaRadioButtom
            // 
            this.vanillaRadioButtom.Checked = true;
            this.vanillaRadioButtom.Location = new System.Drawing.Point(3, 25);
            this.vanillaRadioButtom.Name = "vanillaRadioButtom";
            this.vanillaRadioButtom.Size = new System.Drawing.Size(106, 20);
            this.vanillaRadioButtom.TabIndex = 1;
            this.vanillaRadioButtom.TabStop = true;
            this.vanillaRadioButtom.Text = "Vanilla";
            this.toolTip.SetToolTip(this.vanillaRadioButtom, "Search within a vanilla launcher install for the appropriate Minecraft JAR\r\n");
            this.vanillaRadioButtom.UseVisualStyleBackColor = true;
            // 
            // multimcRadioButton
            // 
            this.multimcRadioButton.Location = new System.Drawing.Point(3, 51);
            this.multimcRadioButton.Name = "multimcRadioButton";
            this.multimcRadioButton.Size = new System.Drawing.Size(106, 20);
            this.multimcRadioButton.TabIndex = 2;
            this.multimcRadioButton.Text = "MultiMC";
            this.toolTip.SetToolTip(this.multimcRadioButton, "Search within a MultiMC install for the appropriate Minecraft JAR");
            this.multimcRadioButton.UseVisualStyleBackColor = true;
            // 
            // mcVersionLabel
            // 
            this.mcVersionLabel.Location = new System.Drawing.Point(115, 0);
            this.mcVersionLabel.Name = "mcVersionLabel";
            this.mcVersionLabel.Padding = new System.Windows.Forms.Padding(2);
            this.mcVersionLabel.Size = new System.Drawing.Size(106, 20);
            this.mcVersionLabel.TabIndex = 3;
            this.mcVersionLabel.Text = "Version:";
            this.mcVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.mcVersionLabel, "Minecraft version (e.g. 1.16.5, 1.17)\r\n");
            // 
            // mcVerTextBox
            // 
            this.mcVerTextBox.Location = new System.Drawing.Point(115, 23);
            this.mcVerTextBox.Name = "mcVerTextBox";
            this.mcVerTextBox.Size = new System.Drawing.Size(106, 20);
            this.mcVerTextBox.TabIndex = 4;
            this.toolTip.SetToolTip(this.mcVerTextBox, "Minecraft version (e.g. 1.16.5, 1.17)");
            // 
            // locateButton
            // 
            this.locateButton.Location = new System.Drawing.Point(115, 49);
            this.locateButton.Name = "locateButton";
            this.locateButton.Size = new System.Drawing.Size(106, 23);
            this.locateButton.TabIndex = 5;
            this.locateButton.Text = "Locate";
            this.toolTip.SetToolTip(this.locateButton, "Locate the appropriate Minecraft JAR");
            this.locateButton.UseVisualStyleBackColor = true;
            this.locateButton.Click += new System.EventHandler(this.locateButton_Click);
            // 
            // jarLocPath
            // 
            this.jarLocPath.AutoEllipsis = true;
            this.jarLocPath.Location = new System.Drawing.Point(227, 0);
            this.jarLocPath.Name = "jarLocPath";
            this.jarLocPath.Padding = new System.Windows.Forms.Padding(2);
            this.jarLocPath.Size = new System.Drawing.Size(293, 20);
            this.jarLocPath.TabIndex = 6;
            this.jarLocPath.Text = "MC Jar:";
            // 
            // rpLocPath
            // 
            this.rpLocPath.AutoEllipsis = true;
            this.rpLocPath.Location = new System.Drawing.Point(227, 20);
            this.rpLocPath.Name = "rpLocPath";
            this.rpLocPath.Padding = new System.Windows.Forms.Padding(2);
            this.rpLocPath.Size = new System.Drawing.Size(293, 20);
            this.rpLocPath.TabIndex = 7;
            this.rpLocPath.Text = "Resource Pack: ";
            // 
            // locatedLabel
            // 
            this.locatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locatedLabel.ForeColor = System.Drawing.Color.Red;
            this.locatedLabel.Location = new System.Drawing.Point(227, 40);
            this.locatedLabel.Name = "locatedLabel";
            this.locatedLabel.Size = new System.Drawing.Size(293, 23);
            this.locatedLabel.TabIndex = 9;
            this.locatedLabel.Text = "Not Located!";
            this.locatedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // includeRealmsMT
            // 
            this.includeRealmsMT.AutoSize = true;
            this.includeRealmsMT.Checked = true;
            this.includeRealmsMT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeRealmsMT.Location = new System.Drawing.Point(417, 170);
            this.includeRealmsMT.Name = "includeRealmsMT";
            this.includeRealmsMT.Size = new System.Drawing.Size(99, 17);
            this.includeRealmsMT.TabIndex = 5;
            this.includeRealmsMT.Text = "Include Realms";
            this.toolTip.SetToolTip(this.includeRealmsMT, "Whether the realms textures should be checked");
            this.includeRealmsMT.UseVisualStyleBackColor = true;
            // 
            // missingTextures
            // 
            this.missingTextures.Location = new System.Drawing.Point(422, 26);
            this.missingTextures.Name = "missingTextures";
            this.missingTextures.Size = new System.Drawing.Size(91, 46);
            this.missingTextures.TabIndex = 4;
            this.missingTextures.Text = "Items: 0\r\nBlocks: 0\r\nTotal: 0\r\n";
            this.toolTip.SetToolTip(this.missingTextures, "Number of textures missing from the resourcepack");
            // 
            // mtExportButton
            // 
            this.mtExportButton.Enabled = false;
            this.mtExportButton.Location = new System.Drawing.Point(419, 222);
            this.mtExportButton.Name = "mtExportButton";
            this.mtExportButton.Size = new System.Drawing.Size(91, 23);
            this.mtExportButton.TabIndex = 3;
            this.mtExportButton.Text = "Export";
            this.toolTip.SetToolTip(this.mtExportButton, "Export list of missing textures to a file");
            this.mtExportButton.UseVisualStyleBackColor = true;
            this.mtExportButton.Click += new System.EventHandler(this.mtExportButton_Click);
            // 
            // mtSearchButton
            // 
            this.mtSearchButton.Location = new System.Drawing.Point(419, 193);
            this.mtSearchButton.Name = "mtSearchButton";
            this.mtSearchButton.Size = new System.Drawing.Size(91, 23);
            this.mtSearchButton.TabIndex = 2;
            this.mtSearchButton.Text = "Search";
            this.toolTip.SetToolTip(this.mtSearchButton, "Check for missing textures");
            this.mtSearchButton.UseVisualStyleBackColor = true;
            this.mtSearchButton.Click += new System.EventHandler(this.mtSearchButton_Click);
            // 
            // missingLabel
            // 
            this.missingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingLabel.Location = new System.Drawing.Point(422, 3);
            this.missingLabel.Name = "missingLabel";
            this.missingLabel.Size = new System.Drawing.Size(91, 23);
            this.missingLabel.TabIndex = 6;
            this.missingLabel.Text = "Missing";
            this.toolTip.SetToolTip(this.missingLabel, "Number of textures missing from the resourcepack");
            // 
            // totalLabel
            // 
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(422, 72);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(91, 23);
            this.totalLabel.TabIndex = 8;
            this.totalLabel.Text = "Total";
            this.toolTip.SetToolTip(this.totalLabel, "Number of textures within the resourcepack, and how many should exist");
            // 
            // totalStats
            // 
            this.totalStats.Location = new System.Drawing.Point(422, 95);
            this.totalStats.Name = "totalStats";
            this.totalStats.Size = new System.Drawing.Size(91, 46);
            this.totalStats.TabIndex = 7;
            this.totalStats.Text = "Items: 0/0\r\nBlocks: 0/0\r\nTotal: 0/0\r\n";
            this.toolTip.SetToolTip(this.totalStats, "Number of textures within the resourcepack, and how many should exist");
            // 
            // unusedLabel
            // 
            this.unusedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unusedLabel.Location = new System.Drawing.Point(419, 3);
            this.unusedLabel.Name = "unusedLabel";
            this.unusedLabel.Size = new System.Drawing.Size(91, 23);
            this.unusedLabel.TabIndex = 12;
            this.unusedLabel.Text = "Unused";
            this.toolTip.SetToolTip(this.unusedLabel, "Number of textures missing from the resourcepack");
            // 
            // includeRealmsUT
            // 
            this.includeRealmsUT.AutoSize = true;
            this.includeRealmsUT.Checked = true;
            this.includeRealmsUT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeRealmsUT.Location = new System.Drawing.Point(417, 170);
            this.includeRealmsUT.Name = "includeRealmsUT";
            this.includeRealmsUT.Size = new System.Drawing.Size(99, 17);
            this.includeRealmsUT.TabIndex = 11;
            this.includeRealmsUT.Text = "Include Realms";
            this.toolTip.SetToolTip(this.includeRealmsUT, "Whether the realms textures should be checked");
            this.includeRealmsUT.UseVisualStyleBackColor = true;
            // 
            // unusedStats
            // 
            this.unusedStats.Location = new System.Drawing.Point(422, 26);
            this.unusedStats.Name = "unusedStats";
            this.unusedStats.Size = new System.Drawing.Size(91, 46);
            this.unusedStats.TabIndex = 10;
            this.unusedStats.Text = "Items: 0\r\nBlocks: 0\r\nTotal: 0\r\n";
            this.toolTip.SetToolTip(this.unusedStats, "Number of textures missing from the resourcepack");
            // 
            // exportButtonUT
            // 
            this.exportButtonUT.Enabled = false;
            this.exportButtonUT.Location = new System.Drawing.Point(419, 222);
            this.exportButtonUT.Name = "exportButtonUT";
            this.exportButtonUT.Size = new System.Drawing.Size(91, 23);
            this.exportButtonUT.TabIndex = 9;
            this.exportButtonUT.Text = "Export";
            this.toolTip.SetToolTip(this.exportButtonUT, "Export list of missing textures to a file");
            this.exportButtonUT.UseVisualStyleBackColor = true;
            this.exportButtonUT.Click += new System.EventHandler(this.exportButtonUT_Click);
            // 
            // searchButtonUT
            // 
            this.searchButtonUT.Location = new System.Drawing.Point(419, 193);
            this.searchButtonUT.Name = "searchButtonUT";
            this.searchButtonUT.Size = new System.Drawing.Size(91, 23);
            this.searchButtonUT.TabIndex = 8;
            this.searchButtonUT.Text = "Search";
            this.toolTip.SetToolTip(this.searchButtonUT, "Check for missing textures");
            this.searchButtonUT.UseVisualStyleBackColor = true;
            this.searchButtonUT.Click += new System.EventHandler(this.searchButtonUT_Click);
            // 
            // compStatsLabel
            // 
            this.compStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compStatsLabel.Location = new System.Drawing.Point(419, 3);
            this.compStatsLabel.Name = "compStatsLabel";
            this.compStatsLabel.Size = new System.Drawing.Size(91, 23);
            this.compStatsLabel.TabIndex = 16;
            this.compStatsLabel.Text = "Stats";
            this.toolTip.SetToolTip(this.compStatsLabel, "Number of textures missing from the resourcepack");
            // 
            // compressBasicStats
            // 
            this.compressBasicStats.Location = new System.Drawing.Point(422, 26);
            this.compressBasicStats.Name = "compressBasicStats";
            this.compressBasicStats.Size = new System.Drawing.Size(91, 19);
            this.compressBasicStats.TabIndex = 15;
            this.compressBasicStats.Text = "Total: 0/0";
            this.toolTip.SetToolTip(this.compressBasicStats, "Number of textures compressed");
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(419, 222);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(91, 23);
            this.compressButton.TabIndex = 14;
            this.compressButton.Text = "Compress";
            this.toolTip.SetToolTip(this.compressButton, "Compress all textures within the resourcepack");
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // compConfLabel
            // 
            this.compConfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compConfLabel.Location = new System.Drawing.Point(419, 89);
            this.compConfLabel.Name = "compConfLabel";
            this.compConfLabel.Size = new System.Drawing.Size(91, 23);
            this.compConfLabel.TabIndex = 19;
            this.compConfLabel.Text = "Config";
            this.toolTip.SetToolTip(this.compConfLabel, "Configuration for compression");
            // 
            // threadCount
            // 
            this.threadCount.Location = new System.Drawing.Point(473, 112);
            this.threadCount.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.threadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCount.Name = "threadCount";
            this.threadCount.Size = new System.Drawing.Size(37, 20);
            this.threadCount.TabIndex = 18;
            this.toolTip.SetToolTip(this.threadCount, "Number of threads to use for compression");
            this.threadCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // threadLabel
            // 
            this.threadLabel.AutoSize = true;
            this.threadLabel.Location = new System.Drawing.Point(422, 114);
            this.threadLabel.Name = "threadLabel";
            this.threadLabel.Size = new System.Drawing.Size(49, 13);
            this.threadLabel.TabIndex = 17;
            this.threadLabel.Text = "Threads:";
            this.toolTip.SetToolTip(this.threadLabel, "Number of threads to use for compression");
            // 
            // compLevel
            // 
            this.compLevel.Location = new System.Drawing.Point(473, 138);
            this.compLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.compLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.compLevel.Name = "compLevel";
            this.compLevel.Size = new System.Drawing.Size(37, 20);
            this.compLevel.TabIndex = 20;
            this.toolTip.SetToolTip(this.compLevel, "Compression level (0-7), higher values will take longer, but will reduce the file" +
        "size more.");
            this.compLevel.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // compLevelLabel
            // 
            this.compLevelLabel.AutoSize = true;
            this.compLevelLabel.Location = new System.Drawing.Point(424, 140);
            this.compLevelLabel.Name = "compLevelLabel";
            this.compLevelLabel.Size = new System.Drawing.Size(36, 13);
            this.compLevelLabel.TabIndex = 21;
            this.compLevelLabel.Text = "Level:";
            this.toolTip.SetToolTip(this.compLevelLabel, "Compression level (0-7), higher values will take longer, but will reduce the file" +
        "size more.");
            // 
            // fileSizeSaveLabel
            // 
            this.fileSizeSaveLabel.Location = new System.Drawing.Point(422, 45);
            this.fileSizeSaveLabel.Name = "fileSizeSaveLabel";
            this.fileSizeSaveLabel.Size = new System.Drawing.Size(91, 19);
            this.fileSizeSaveLabel.TabIndex = 22;
            this.fileSizeSaveLabel.Text = "Saved: 0.0 B";
            this.toolTip.SetToolTip(this.fileSizeSaveLabel, "Total filesize saved");
            // 
            // threadStatsLabel
            // 
            this.threadStatsLabel.Location = new System.Drawing.Point(422, 64);
            this.threadStatsLabel.Name = "threadStatsLabel";
            this.threadStatsLabel.Size = new System.Drawing.Size(91, 19);
            this.threadStatsLabel.TabIndex = 23;
            this.threadStatsLabel.Text = "Threads: 0/0";
            this.toolTip.SetToolTip(this.threadStatsLabel, "No threads running");
            // 
            // missingTexturesTab
            // 
            this.missingTexturesTab.Controls.Add(this.totalLabel);
            this.missingTexturesTab.Controls.Add(this.totalStats);
            this.missingTexturesTab.Controls.Add(this.missingLabel);
            this.missingTexturesTab.Controls.Add(this.includeRealmsMT);
            this.missingTexturesTab.Controls.Add(this.missingTextures);
            this.missingTexturesTab.Controls.Add(this.mtExportButton);
            this.missingTexturesTab.Controls.Add(this.mtSearchButton);
            this.missingTexturesTab.Controls.Add(this.missingTexturesTextBox);
            this.missingTexturesTab.Location = new System.Drawing.Point(4, 22);
            this.missingTexturesTab.Name = "missingTexturesTab";
            this.missingTexturesTab.Padding = new System.Windows.Forms.Padding(3);
            this.missingTexturesTab.Size = new System.Drawing.Size(516, 256);
            this.missingTexturesTab.TabIndex = 0;
            this.missingTexturesTab.Text = "Missing Textures";
            this.missingTexturesTab.UseVisualStyleBackColor = true;
            // 
            // missingTexturesTextBox
            // 
            this.missingTexturesTextBox.Location = new System.Drawing.Point(0, 0);
            this.missingTexturesTextBox.Name = "missingTexturesTextBox";
            this.missingTexturesTextBox.ReadOnly = true;
            this.missingTexturesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.missingTexturesTextBox.Size = new System.Drawing.Size(413, 256);
            this.missingTexturesTextBox.TabIndex = 1;
            this.missingTexturesTextBox.Text = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.missingTexturesTab);
            this.tabControl.Controls.Add(this.unusedTexturesTab);
            this.tabControl.Controls.Add(this.compressionTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(0, 99);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(524, 282);
            this.tabControl.TabIndex = 3;
            // 
            // unusedTexturesTab
            // 
            this.unusedTexturesTab.Controls.Add(this.unusedLabel);
            this.unusedTexturesTab.Controls.Add(this.includeRealmsUT);
            this.unusedTexturesTab.Controls.Add(this.unusedStats);
            this.unusedTexturesTab.Controls.Add(this.exportButtonUT);
            this.unusedTexturesTab.Controls.Add(this.searchButtonUT);
            this.unusedTexturesTab.Controls.Add(this.unusedTexturesTextBox);
            this.unusedTexturesTab.Location = new System.Drawing.Point(4, 22);
            this.unusedTexturesTab.Name = "unusedTexturesTab";
            this.unusedTexturesTab.Padding = new System.Windows.Forms.Padding(3);
            this.unusedTexturesTab.Size = new System.Drawing.Size(516, 256);
            this.unusedTexturesTab.TabIndex = 1;
            this.unusedTexturesTab.Text = "Unused Textures";
            this.unusedTexturesTab.UseVisualStyleBackColor = true;
            // 
            // unusedTexturesTextBox
            // 
            this.unusedTexturesTextBox.Location = new System.Drawing.Point(0, 0);
            this.unusedTexturesTextBox.Name = "unusedTexturesTextBox";
            this.unusedTexturesTextBox.ReadOnly = true;
            this.unusedTexturesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.unusedTexturesTextBox.Size = new System.Drawing.Size(412, 256);
            this.unusedTexturesTextBox.TabIndex = 7;
            this.unusedTexturesTextBox.Text = "";
            // 
            // compressionTab
            // 
            this.compressionTab.Controls.Add(this.threadStatsLabel);
            this.compressionTab.Controls.Add(this.fileSizeSaveLabel);
            this.compressionTab.Controls.Add(this.compLevelLabel);
            this.compressionTab.Controls.Add(this.compLevel);
            this.compressionTab.Controls.Add(this.compConfLabel);
            this.compressionTab.Controls.Add(this.threadCount);
            this.compressionTab.Controls.Add(this.threadLabel);
            this.compressionTab.Controls.Add(this.compStatsLabel);
            this.compressionTab.Controls.Add(this.compressBasicStats);
            this.compressionTab.Controls.Add(this.compressButton);
            this.compressionTab.Controls.Add(this.compressTextBox);
            this.compressionTab.Location = new System.Drawing.Point(4, 22);
            this.compressionTab.Name = "compressionTab";
            this.compressionTab.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTab.Size = new System.Drawing.Size(516, 256);
            this.compressionTab.TabIndex = 2;
            this.compressionTab.Text = "Compress Textures";
            this.compressionTab.UseVisualStyleBackColor = true;
            // 
            // compressTextBox
            // 
            this.compressTextBox.Location = new System.Drawing.Point(0, 0);
            this.compressTextBox.Name = "compressTextBox";
            this.compressTextBox.ReadOnly = true;
            this.compressTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.compressTextBox.Size = new System.Drawing.Size(412, 256);
            this.compressTextBox.TabIndex = 13;
            this.compressTextBox.Text = "";
            // 
            // exportFileListToolStripMenuItem
            // 
            this.exportFileListToolStripMenuItem.Name = "exportFileListToolStripMenuItem";
            this.exportFileListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportFileListToolStripMenuItem.Text = "Export File List";
            this.exportFileListToolStripMenuItem.Click += new System.EventHandler(this.exportFileListToolStripMenuItem_Click);
            // 
            // ResourcePackUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 381);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 420);
            this.MinimumSize = new System.Drawing.Size(540, 420);
            this.Name = "ResourcePackUtils";
            this.Text = "Resource Pack Utils";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compLevel)).EndInit();
            this.missingTexturesTab.ResumeLayout(false);
            this.missingTexturesTab.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.unusedTexturesTab.ResumeLayout(false);
            this.unusedTexturesTab.PerformLayout();
            this.compressionTab.ResumeLayout(false);
            this.compressionTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label typeMcInstallLabel;
        private System.Windows.Forms.RadioButton vanillaRadioButtom;
        private System.Windows.Forms.RadioButton multimcRadioButton;
        private System.Windows.Forms.Label mcVersionLabel;
        private System.Windows.Forms.TextBox mcVerTextBox;
        private System.Windows.Forms.Button locateButton;
        private System.Windows.Forms.Label jarLocPath;
        private System.Windows.Forms.Label rpLocPath;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem changeMultiMCPathToolStripMenuItem;
        private System.Windows.Forms.TabPage missingTexturesTab;
        private System.Windows.Forms.CheckBox includeRealmsMT;
        private System.Windows.Forms.Label missingTextures;
        private System.Windows.Forms.Button mtExportButton;
        private System.Windows.Forms.Button mtSearchButton;
        private System.Windows.Forms.RichTextBox missingTexturesTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label missingLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalStats;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label locatedLabel;
        private System.Windows.Forms.TabPage unusedTexturesTab;
        private System.Windows.Forms.Label unusedLabel;
        private System.Windows.Forms.CheckBox includeRealmsUT;
        private System.Windows.Forms.Label unusedStats;
        private System.Windows.Forms.Button exportButtonUT;
        private System.Windows.Forms.Button searchButtonUT;
        private System.Windows.Forms.RichTextBox unusedTexturesTextBox;
        private System.Windows.Forms.TabPage compressionTab;
        private System.Windows.Forms.Label compStatsLabel;
        private System.Windows.Forms.Label compressBasicStats;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.RichTextBox compressTextBox;
        private System.Windows.Forms.Label compConfLabel;
        private System.Windows.Forms.NumericUpDown threadCount;
        private System.Windows.Forms.Label threadLabel;
        private System.Windows.Forms.Label compLevelLabel;
        private System.Windows.Forms.NumericUpDown compLevel;
        private System.Windows.Forms.Label fileSizeSaveLabel;
        private System.Windows.Forms.Label threadStatsLabel;
        private System.Windows.Forms.ToolStripMenuItem exportFileListToolStripMenuItem;
    }
}


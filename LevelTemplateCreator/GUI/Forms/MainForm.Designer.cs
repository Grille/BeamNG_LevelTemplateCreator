namespace LevelTemplateCreator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            savePresetToolStripMenuItem = new ToolStripMenuItem();
            loadPresetToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            systemToolStripMenuItem = new ToolStripMenuItem();
            reloadToolStripMenuItem = new ToolStripMenuItem();
            displayToolStripMenuItem = new ToolStripMenuItem();
            itemSizeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            utilsToolStripMenuItem = new ToolStripMenuItem();
            createTexturePackFromLevelToolStripMenuItem = new ToolStripMenuItem();
            terrainMergerToolStripMenuItem = new ToolStripMenuItem();
            misDecalV5ToolStripMenuItem = new ToolStripMenuItem();
            batchEditForest4jsonToolStripMenuItem = new ToolStripMenuItem();
            treeMapBuilderToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            LevelSettings = new LevelTemplateCreator.GUI.LevelSettings();
            ContentManager = new LevelTemplateCreator.GUI.ContentManager();
            ToolTip = new ToolTip(components);
            enableToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, displayToolStripMenuItem, utilsToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(1335, 24);
            MenuStrip.TabIndex = 3;
            MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator3, savePresetToolStripMenuItem, loadPresetToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(186, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(186, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(183, 6);
            // 
            // savePresetToolStripMenuItem
            // 
            savePresetToolStripMenuItem.Name = "savePresetToolStripMenuItem";
            savePresetToolStripMenuItem.Size = new Size(186, 22);
            savePresetToolStripMenuItem.Text = "Save Preset";
            savePresetToolStripMenuItem.Click += savePresetToolStripMenuItem_Click;
            // 
            // loadPresetToolStripMenuItem
            // 
            loadPresetToolStripMenuItem.Name = "loadPresetToolStripMenuItem";
            loadPresetToolStripMenuItem.Size = new Size(186, 22);
            loadPresetToolStripMenuItem.Text = "Load Preset";
            loadPresetToolStripMenuItem.Click += loadPresetToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            exitToolStripMenuItem.Size = new Size(186, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { systemToolStripMenuItem, reloadToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(62, 20);
            settingsToolStripMenuItem.Text = "Content";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(144, 22);
            systemToolStripMenuItem.Text = "System Paths";
            systemToolStripMenuItem.Click += systemToolStripMenuItem_Click;
            // 
            // reloadToolStripMenuItem
            // 
            reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            reloadToolStripMenuItem.Size = new Size(144, 22);
            reloadToolStripMenuItem.Text = "Reload";
            reloadToolStripMenuItem.Click += reloadToolStripMenuItem_Click;
            // 
            // displayToolStripMenuItem
            // 
            displayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemSizeToolStripMenuItem });
            displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            displayToolStripMenuItem.Size = new Size(57, 20);
            displayToolStripMenuItem.Text = "Display";
            // 
            // itemSizeToolStripMenuItem
            // 
            itemSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            itemSizeToolStripMenuItem.Name = "itemSizeToolStripMenuItem";
            itemSizeToolStripMenuItem.Size = new Size(121, 22);
            itemSizeToolStripMenuItem.Text = "Item Size";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(150, 22);
            toolStripMenuItem2.Text = "Small Icons";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(150, 22);
            toolStripMenuItem3.Text = "Medium Icons";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(150, 22);
            toolStripMenuItem4.Text = "Large Icons";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // utilsToolStripMenuItem
            // 
            utilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createTexturePackFromLevelToolStripMenuItem, terrainMergerToolStripMenuItem, misDecalV5ToolStripMenuItem, batchEditForest4jsonToolStripMenuItem, treeMapBuilderToolStripMenuItem, enableToolStripMenuItem });
            utilsToolStripMenuItem.Name = "utilsToolStripMenuItem";
            utilsToolStripMenuItem.Size = new Size(42, 20);
            utilsToolStripMenuItem.Text = "Utils";
            // 
            // createTexturePackFromLevelToolStripMenuItem
            // 
            createTexturePackFromLevelToolStripMenuItem.Enabled = false;
            createTexturePackFromLevelToolStripMenuItem.Name = "createTexturePackFromLevelToolStripMenuItem";
            createTexturePackFromLevelToolStripMenuItem.Size = new Size(201, 22);
            createTexturePackFromLevelToolStripMenuItem.Text = "Texture Pack Primer";
            createTexturePackFromLevelToolStripMenuItem.Click += createTexturePackFromLevelToolStripMenuItem_Click;
            // 
            // terrainMergerToolStripMenuItem
            // 
            terrainMergerToolStripMenuItem.Name = "terrainMergerToolStripMenuItem";
            terrainMergerToolStripMenuItem.Size = new Size(201, 22);
            terrainMergerToolStripMenuItem.Text = "Terrain Merger";
            terrainMergerToolStripMenuItem.Click += terrainMergerToolStripMenuItem_Click;
            // 
            // misDecalV5ToolStripMenuItem
            // 
            misDecalV5ToolStripMenuItem.Name = "misDecalV5ToolStripMenuItem";
            misDecalV5ToolStripMenuItem.Size = new Size(201, 22);
            misDecalV5ToolStripMenuItem.Text = "Mis.Decal(V5) Converter";
            misDecalV5ToolStripMenuItem.Click += misDecalV5ToolStripMenuItem_Click;
            // 
            // batchEditForest4jsonToolStripMenuItem
            // 
            batchEditForest4jsonToolStripMenuItem.Name = "batchEditForest4jsonToolStripMenuItem";
            batchEditForest4jsonToolStripMenuItem.Size = new Size(201, 22);
            batchEditForest4jsonToolStripMenuItem.Text = "Batch Edit Forest4.json";
            batchEditForest4jsonToolStripMenuItem.Click += batchEditForest4jsonToolStripMenuItem_Click;
            // 
            // treeMapBuilderToolStripMenuItem
            // 
            treeMapBuilderToolStripMenuItem.Name = "treeMapBuilderToolStripMenuItem";
            treeMapBuilderToolStripMenuItem.Size = new Size(201, 22);
            treeMapBuilderToolStripMenuItem.Text = "TreeMapBuilder";
            treeMapBuilderToolStripMenuItem.Click += treeMapBuilderToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(LevelSettings);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ContentManager);
            splitContainer1.Size = new Size(1335, 558);
            splitContainer1.SplitterDistance = 346;
            splitContainer1.TabIndex = 10;
            // 
            // LevelSettings
            // 
            LevelSettings.Dock = DockStyle.Fill;
            LevelSettings.Location = new Point(0, 0);
            LevelSettings.Name = "LevelSettings";
            LevelSettings.Size = new Size(346, 558);
            LevelSettings.TabIndex = 11;
            // 
            // ContentManager
            // 
            ContentManager.Dock = DockStyle.Fill;
            ContentManager.Location = new Point(0, 0);
            ContentManager.Name = "ContentManager";
            ContentManager.Size = new Size(985, 558);
            ContentManager.TabIndex = 0;
            // 
            // enableToolStripMenuItem
            // 
            enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            enableToolStripMenuItem.Size = new Size(201, 22);
            enableToolStripMenuItem.Text = "Enable Anisotropic";
            enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1335, 582);
            Controls.Add(splitContainer1);
            Controls.Add(MenuStrip);
            DoubleBuffered = true;
            MainMenuStrip = MenuStrip;
            Name = "MainForm";
            Text = "Template Creator";
            Load += MainForm_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem utilsToolStripMenuItem;
        private ToolStripMenuItem createTexturePackFromLevelToolStripMenuItem;
        private SplitContainer splitContainer1;
        private GUI.LevelSettings LevelSettings;
        private GUI.ContentManager ContentManager;
        private ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripMenuItem itemSizeToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolTip ToolTip;
        private ToolStripMenuItem terrainMergerToolStripMenuItem;
        private ToolStripMenuItem savePresetToolStripMenuItem;
        private ToolStripMenuItem loadPresetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem misDecalV5ToolStripMenuItem;
        private ToolStripMenuItem batchEditForest4jsonToolStripMenuItem;
        private ToolStripMenuItem treeMapBuilderToolStripMenuItem;
        private ToolStripMenuItem enableToolStripMenuItem;
    }
}

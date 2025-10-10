using LevelTemplateCreator.GUI.Controls;

namespace LevelTemplateCreator.GUI;

partial class TerrainMerger
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
        Grille.BeamNG.TerrainTemplate terrainTemplate1 = new Grille.BeamNG.TerrainTemplate();
        terrainView = new TerrainView();
        splitContainer1 = new SplitContainer();
        settingsPanel = new Panel();
        label1 = new Label();
        terrainSettings = new TerrainSettings();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        loadTerrainToolStripMenuItem = new ToolStripMenuItem();
        displayToolStripMenuItem = new ToolStripMenuItem();
        showBoundingsToolStripMenuItem = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        settingsPanel.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // terrainView
        // 
        terrainView.BackColor = Color.FromArgb(64, 0, 64);
        terrainView.DebugInfoEnabled = false;
        terrainView.DefaultMouseEventsEnabled = true;
        terrainView.Dock = DockStyle.Fill;
        terrainView.DrawBoundings = true;
        terrainView.FancyBackgroundEnabled = false;
        terrainView.LightAngle = 0F;
        terrainView.Location = new Point(0, 0);
        terrainView.Name = "terrainView";
        terrainView.OnLeftMouseDown = Grille.Graphics.Isometric.WinForms.RenderSurface.LDownAction.DragView;
        terrainView.RenderAllways = false;
        terrainView.Size = new Size(741, 543);
        terrainView.TabIndex = 0;
        terrainView.Text = "terrainView1";
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
        splitContainer1.Panel1.Controls.Add(settingsPanel);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(terrainView);
        splitContainer1.Size = new Size(1035, 543);
        splitContainer1.SplitterDistance = 290;
        splitContainer1.TabIndex = 1;
        // 
        // settingsPanel
        // 
        settingsPanel.AutoScroll = true;
        settingsPanel.Controls.Add(label1);
        settingsPanel.Controls.Add(terrainSettings);
        settingsPanel.Dock = DockStyle.Fill;
        settingsPanel.Location = new Point(0, 0);
        settingsPanel.Margin = new Padding(0);
        settingsPanel.Name = "settingsPanel";
        settingsPanel.Size = new Size(290, 543);
        settingsPanel.TabIndex = 0;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label1.BackColor = SystemColors.InactiveCaption;
        label1.ForeColor = SystemColors.InactiveCaptionText;
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Padding = new Padding(3, 0, 3, 0);
        label1.Size = new Size(284, 23);
        label1.TabIndex = 1;
        label1.Text = "Canvas";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // terrainSettings
        // 
        terrainSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        terrainSettings.Location = new Point(0, 23);
        terrainSettings.Margin = new Padding(0);
        terrainSettings.MaximumSize = new Size(10000, 145);
        terrainSettings.MinimumSize = new Size(0, 145);
        terrainSettings.Name = "terrainSettings";
        terrainSettings.Size = new Size(290, 145);
        terrainSettings.TabIndex = 0;
        terrainTemplate1.Height = 9.99234F;
        terrainTemplate1.MaxHeight = 512F;
        terrainTemplate1.Resolution = 1024;
        terrainTemplate1.SquareSize = 1F;
        terrainTemplate1.U16Height = (ushort)1279;
        terrainTemplate1.WorldSize = 1024F;
        terrainSettings.Terrain = terrainTemplate1;
        terrainSettings.Load += terrainSettings1_Load;
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, displayToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1035, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadTerrainToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // loadTerrainToolStripMenuItem
        // 
        loadTerrainToolStripMenuItem.Name = "loadTerrainToolStripMenuItem";
        loadTerrainToolStripMenuItem.Size = new Size(146, 22);
        loadTerrainToolStripMenuItem.Text = "Export Terrain";
        loadTerrainToolStripMenuItem.Click += exportTerrainToolStripMenuItem_Click;
        // 
        // displayToolStripMenuItem
        // 
        displayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showBoundingsToolStripMenuItem });
        displayToolStripMenuItem.Name = "displayToolStripMenuItem";
        displayToolStripMenuItem.Size = new Size(57, 20);
        displayToolStripMenuItem.Text = "Display";
        // 
        // showBoundingsToolStripMenuItem
        // 
        showBoundingsToolStripMenuItem.Checked = true;
        showBoundingsToolStripMenuItem.CheckOnClick = true;
        showBoundingsToolStripMenuItem.CheckState = CheckState.Checked;
        showBoundingsToolStripMenuItem.Name = "showBoundingsToolStripMenuItem";
        showBoundingsToolStripMenuItem.Size = new Size(180, 22);
        showBoundingsToolStripMenuItem.Text = "Show Boundings";
        showBoundingsToolStripMenuItem.Click += showBoundingsToolStripMenuItem_Click;
        // 
        // TerrainMerger
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1035, 567);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "TerrainMerger";
        Text = "TerrainMerger";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        settingsPanel.ResumeLayout(false);
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TerrainView terrainView;
    private SplitContainer splitContainer1;
    private MenuStrip menuStrip1;
    private TerrainSettings terrainSettings;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem loadTerrainToolStripMenuItem;
    private Panel settingsPanel;
    private Label label1;
    private ToolStripMenuItem displayToolStripMenuItem;
    private ToolStripMenuItem showBoundingsToolStripMenuItem;
}
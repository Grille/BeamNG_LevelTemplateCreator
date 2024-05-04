namespace LevelTemplateCreator.GUI
{
    internal partial class LevelSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox3 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBoxPreset = new ComboBox();
            label6 = new Label();
            textBoxNamespace = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            TerainSettings = new TerrainSettings();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            textBoxAuthors = new TextBox();
            label2 = new Label();
            textBoxTitle = new TextBox();
            groupBox3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox3.Controls.Add(tableLayoutPanel2);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(297, 100);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "System";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(comboBoxPreset, 1, 1);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(textBoxNamespace, 1, 0);
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RightToLeft = RightToLeft.No;
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(291, 78);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // comboBoxPreset
            // 
            comboBoxPreset.Dock = DockStyle.Fill;
            comboBoxPreset.DropDownWidth = 100;
            comboBoxPreset.FormattingEnabled = true;
            comboBoxPreset.Location = new Point(78, 32);
            comboBoxPreset.Name = "comboBoxPreset";
            comboBoxPreset.Size = new Size(210, 23);
            comboBoxPreset.TabIndex = 8;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 36);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 2;
            label6.Text = "Level Preset";
            // 
            // textBoxNamespace
            // 
            textBoxNamespace.Dock = DockStyle.Fill;
            textBoxNamespace.Location = new Point(78, 3);
            textBoxNamespace.Name = "textBoxNamespace";
            textBoxNamespace.Size = new Size(210, 23);
            textBoxNamespace.TabIndex = 0;
            textBoxNamespace.TextChanged += textBoxNamespace_TextChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(3, 7);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 0;
            label7.Text = "Namepsace";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(TerainSettings);
            groupBox2.Location = new Point(6, 212);
            groupBox2.MinimumSize = new Size(100, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(294, 145);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Terrain";
            // 
            // TerainSettings
            // 
            TerainSettings.Dock = DockStyle.Fill;
            TerainSettings.Location = new Point(3, 19);
            TerainSettings.MaximumSize = new Size(10000, 116);
            TerainSettings.MinimumSize = new Size(0, 116);
            TerainSettings.Name = "TerainSettings";
            TerainSettings.Size = new Size(288, 116);
            TerainSettings.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(6, 109);
            groupBox1.MinimumSize = new Size(100, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 100);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxAuthors, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxTitle, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.No;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(288, 78);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 36);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 8;
            label4.Text = "Authors";
            // 
            // textBoxAuthors
            // 
            textBoxAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthors.Location = new Point(58, 32);
            textBoxAuthors.Name = "textBoxAuthors";
            textBoxAuthors.Size = new Size(227, 23);
            textBoxAuthors.TabIndex = 4;
            textBoxAuthors.TextChanged += textBoxAuthors_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 7);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Title";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Dock = DockStyle.Fill;
            textBoxTitle.Location = new Point(58, 3);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(227, 23);
            textBoxTitle.TabIndex = 3;
            textBoxTitle.TextChanged += textBoxTitle_TextChanged;
            // 
            // LevelSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "LevelSettings";
            Size = new Size(303, 378);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBoxPreset;
        private Label label6;
        private TextBox textBoxNamespace;
        private Label label7;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private TextBox textBoxAuthors;
        private Label label2;
        private TextBox textBoxTitle;
        public TerrainSettings TerainSettings;
    }
}

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
            Grille.BeamNG.TerrainTemplate terrainTemplate2 = new Grille.BeamNG.TerrainTemplate();
            TerainSettings = new TerrainSettings();
            TextBoxNamespace = new LabledTextbox();
            TextBoxTitle = new LabledTextbox();
            TextBoxAuthor = new LabledTextbox();
            ButtonSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            ComboBoxCopyMode = new ComboBox();
            label2 = new Label();
            ComboBoxNamingMode = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // TerainSettings
            // 
            TerainSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TerainSettings.Location = new Point(0, 87);
            TerainSettings.Margin = new Padding(0);
            TerainSettings.MaximumSize = new Size(10000, 145);
            TerainSettings.MinimumSize = new Size(0, 116);
            TerainSettings.Name = "TerainSettings";
            TerainSettings.Size = new Size(517, 145);
            TerainSettings.TabIndex = 0;
            terrainTemplate2.Height = 9.99234F;
            terrainTemplate2.MaterialIndex = 0;
            terrainTemplate2.MaxHeight = 512F;
            terrainTemplate2.Resolution = 1024;
            terrainTemplate2.SquareSize = 1F;
            terrainTemplate2.U16Height = (ushort)1279;
            terrainTemplate2.WorldSize = 1024F;
            TerainSettings.Terrain = terrainTemplate2;
            // 
            // TextBoxNamespace
            // 
            TextBoxNamespace.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxNamespace.LabelText = "Namespace";
            TextBoxNamespace.Location = new Point(0, 0);
            TextBoxNamespace.Margin = new Padding(0);
            TextBoxNamespace.Name = "TextBoxNamespace";
            TextBoxNamespace.Size = new Size(517, 29);
            TextBoxNamespace.TabIndex = 1;
            // 
            // TextBoxTitle
            // 
            TextBoxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxTitle.LabelText = "Title";
            TextBoxTitle.Location = new Point(0, 29);
            TextBoxTitle.Margin = new Padding(0);
            TextBoxTitle.Name = "TextBoxTitle";
            TextBoxTitle.Size = new Size(517, 29);
            TextBoxTitle.TabIndex = 2;
            // 
            // TextBoxAuthor
            // 
            TextBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxAuthor.LabelText = "Authors";
            TextBoxAuthor.Location = new Point(0, 58);
            TextBoxAuthor.Margin = new Padding(0);
            TextBoxAuthor.Name = "TextBoxAuthor";
            TextBoxAuthor.Size = new Size(517, 29);
            TextBoxAuthor.TabIndex = 3;
            // 
            // ButtonSave
            // 
            ButtonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonSave.Location = new Point(3, 509);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(511, 23);
            ButtonSave.TabIndex = 4;
            ButtonSave.Text = "Save Level";
            ButtonSave.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(ComboBoxCopyMode, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 232);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.MinimumSize = new Size(0, 29);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(517, 29);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "File Copy Mode";
            // 
            // ComboBoxCopyMode
            // 
            ComboBoxCopyMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxCopyMode.FormattingEnabled = true;
            ComboBoxCopyMode.Items.AddRange(new object[] { "Copy All Resources", "Copy Only Local Resouces", "Copy No Resources" });
            ComboBoxCopyMode.Location = new Point(103, 3);
            ComboBoxCopyMode.Name = "ComboBoxCopyMode";
            ComboBoxCopyMode.Size = new Size(411, 23);
            ComboBoxCopyMode.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 7);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 0;
            label2.Text = "Naming Mode";
            // 
            // ComboBoxNamingMode
            // 
            ComboBoxNamingMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxNamingMode.FormattingEnabled = true;
            ComboBoxNamingMode.Items.AddRange(new object[] { "Namespace_Name", "Name" });
            ComboBoxNamingMode.Location = new Point(103, 3);
            ComboBoxNamingMode.Name = "ComboBoxNamingMode";
            ComboBoxNamingMode.Size = new Size(411, 23);
            ComboBoxNamingMode.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(ComboBoxNamingMode, 1, 0);
            tableLayoutPanel2.Location = new Point(0, 261);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.MinimumSize = new Size(0, 29);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(517, 29);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // LevelSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(ButtonSave);
            Controls.Add(TextBoxAuthor);
            Controls.Add(TextBoxTitle);
            Controls.Add(TextBoxNamespace);
            Controls.Add(TerainSettings);
            Name = "LevelSettings";
            Size = new Size(517, 535);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public TerrainSettings TerainSettings;
        private LabledTextbox TextBoxNamespace;
        private LabledTextbox TextBoxTitle;
        private LabledTextbox TextBoxAuthor;
        public Button ButtonSave;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        public ComboBox ComboBoxCopyMode;
        private Label label2;
        public ComboBox ComboBoxNamingMode;
        private TableLayoutPanel tableLayoutPanel2;
    }
}

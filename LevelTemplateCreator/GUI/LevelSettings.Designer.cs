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
            TerainSettings = new TerrainSettings();
            TextBoxNamespace = new LabledTextbox();
            TextBoxTitle = new LabledTextbox();
            TextBoxAuthor = new LabledTextbox();
            ButtonSave = new Button();
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
            // LevelSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonSave);
            Controls.Add(TextBoxAuthor);
            Controls.Add(TextBoxTitle);
            Controls.Add(TextBoxNamespace);
            Controls.Add(TerainSettings);
            Name = "LevelSettings";
            Size = new Size(517, 535);
            ResumeLayout(false);
        }

        #endregion
        public TerrainSettings TerainSettings;
        private LabledTextbox TextBoxNamespace;
        private LabledTextbox TextBoxTitle;
        private LabledTextbox TextBoxAuthor;
        public Button ButtonSave;
    }
}

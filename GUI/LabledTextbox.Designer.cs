namespace LevelTemplateCreator.GUI
{
    partial class LabledTextbox
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
            TextBox = new TextBox();
            Label = new Label();
            SuspendLayout();
            // 
            // TextBox
            // 
            TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBox.Location = new Point(100, 0);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(260, 23);
            TextBox.TabIndex = 0;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(3, 3);
            Label.Name = "Label";
            Label.Size = new Size(32, 15);
            Label.TabIndex = 1;
            Label.Text = "label";
            // 
            // LabledTextbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Label);
            Controls.Add(TextBox);
            Name = "LabledTextbox";
            Size = new Size(360, 23);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox TextBox;
        public Label Label;
        private Label label1;
    }
}

namespace LevelTemplateCreator
{
    partial class PathBox
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
            Button = new Button();
            TextBox = new TextBox();
            FolderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // Button
            // 
            Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button.FlatStyle = FlatStyle.System;
            Button.Location = new Point(173, 0);
            Button.Name = "Button";
            Button.Size = new Size(27, 23);
            Button.TabIndex = 0;
            Button.Text = "...";
            Button.TextAlign = ContentAlignment.TopCenter;
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // TextBox
            // 
            TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox.Location = new Point(0, 0);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(167, 23);
            TextBox.TabIndex = 1;
            // 
            // PathBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TextBox);
            Controls.Add(Button);
            Name = "PathBox";
            Size = new Size(200, 23);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button Button;
        public TextBox TextBox;
        public FolderBrowserDialog FolderBrowserDialog;
    }
}

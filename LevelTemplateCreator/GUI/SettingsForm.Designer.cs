namespace LevelTemplateCreator
{
    partial class SettingsForm
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
            label2 = new Label();
            label1 = new Label();
            buttonCancel = new Button();
            buttonOk = new Button();
            label3 = new Label();
            pathBoxPack = new PathBox();
            pathBoxUser = new PathBox();
            pathBoxGame = new PathBox();
            buttonFind = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new Point(9, 38);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(100, 29);
            label2.TabIndex = 9;
            label2.Text = "Userdata Path";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(9, 9);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 29);
            label1.TabIndex = 7;
            label1.Text = "Gamedata Path";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(397, 105);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(316, 105);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 14;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // label3
            // 
            label3.Location = new Point(9, 67);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(100, 29);
            label3.TabIndex = 17;
            label3.Text = "Packages Path";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pathBoxPack
            // 
            pathBoxPack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathBoxPack.FileFilter = "All files (*.*)|*.*";
            pathBoxPack.Location = new Point(109, 67);
            pathBoxPack.Margin = new Padding(0);
            pathBoxPack.Name = "pathBoxPack";
            pathBoxPack.Size = new Size(366, 29);
            pathBoxPack.TabIndex = 19;
            pathBoxPack.Target = PathBox.TargetType.Folder;
            // 
            // pathBoxUser
            // 
            pathBoxUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathBoxUser.FileFilter = "All files (*.*)|*.*";
            pathBoxUser.Location = new Point(109, 38);
            pathBoxUser.Margin = new Padding(0);
            pathBoxUser.Name = "pathBoxUser";
            pathBoxUser.Size = new Size(366, 29);
            pathBoxUser.TabIndex = 20;
            pathBoxUser.Target = PathBox.TargetType.Folder;
            // 
            // pathBoxGame
            // 
            pathBoxGame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathBoxGame.FileFilter = "All files (*.*)|*.*";
            pathBoxGame.Location = new Point(109, 9);
            pathBoxGame.Margin = new Padding(0);
            pathBoxGame.Name = "pathBoxGame";
            pathBoxGame.Size = new Size(366, 29);
            pathBoxGame.TabIndex = 21;
            pathBoxGame.Target = PathBox.TargetType.Folder;
            // 
            // buttonFind
            // 
            buttonFind.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFind.Location = new Point(12, 105);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(75, 23);
            buttonFind.TabIndex = 22;
            buttonFind.Text = "Autodetect";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 136);
            Controls.Add(buttonFind);
            Controls.Add(pathBoxGame);
            Controls.Add(pathBoxUser);
            Controls.Add(pathBoxPack);
            Controls.Add(label3);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(500, 175);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label1;
        private Button buttonCancel;
        private Button buttonOk;
        private Label label3;
        private PathBox pathBoxPack;
        private PathBox pathBoxUser;
        private PathBox pathBoxGame;
        private Button buttonFind;
    }
}
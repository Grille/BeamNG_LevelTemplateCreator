﻿namespace LevelTemplateCreator
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Button
            // 
            Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button.FlatStyle = FlatStyle.System;
            Button.Location = new Point(275, 3);
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
            TextBox.Location = new Point(3, 3);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(266, 23);
            TextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(TextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(Button, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new Size(305, 29);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // PathBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "PathBox";
            Size = new Size(305, 29);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Button Button;
        public TextBox TextBox;
        private TableLayoutPanel tableLayoutPanel1;
    }
}

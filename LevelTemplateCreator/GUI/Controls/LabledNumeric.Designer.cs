namespace LevelTemplateCreator.GUI
{
    partial class LabledNumeric
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
            Label = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            Numeric = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Numeric).BeginInit();
            SuspendLayout();
            // 
            // Label
            // 
            Label.Anchor = AnchorStyles.Left;
            Label.AutoSize = true;
            Label.Location = new Point(3, 7);
            Label.Name = "Label";
            Label.Size = new Size(32, 15);
            Label.TabIndex = 1;
            Label.Text = "label";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Label, 0, 0);
            tableLayoutPanel1.Controls.Add(Numeric, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(460, 29);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // Numeric
            // 
            Numeric.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Numeric.Location = new Point(103, 3);
            Numeric.Name = "Numeric";
            Numeric.Size = new Size(354, 23);
            Numeric.TabIndex = 2;
            // 
            // LabledNumeric
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "LabledNumeric";
            Size = new Size(460, 29);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label Label;
        private TableLayoutPanel tableLayoutPanel1;
        public NumericUpDown Numeric;
    }
}

namespace LevelTemplateCreator.GUI
{
    partial class TerrainSettings
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
            NumericWorldSize = new NumericUpDown();
            ComboBoxRes = new ComboBox();
            NumericSquareSize = new NumericUpDown();
            NumericMaxHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            NumericBaseHeight = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)NumericWorldSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericSquareSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericMaxHeight).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericBaseHeight).BeginInit();
            SuspendLayout();
            // 
            // NumericWorldSize
            // 
            NumericWorldSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericWorldSize.DecimalPlaces = 2;
            NumericWorldSize.Location = new Point(103, 32);
            NumericWorldSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericWorldSize.Name = "NumericWorldSize";
            NumericWorldSize.Size = new Size(475, 23);
            NumericWorldSize.TabIndex = 3;
            NumericWorldSize.ValueChanged += numericUpDownWorldSize_ValueChanged;
            // 
            // ComboBoxRes
            // 
            ComboBoxRes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxRes.FormattingEnabled = true;
            ComboBoxRes.Items.AddRange(new object[] { "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768", "65536" });
            ComboBoxRes.Location = new Point(103, 3);
            ComboBoxRes.Name = "ComboBoxRes";
            ComboBoxRes.Size = new Size(475, 23);
            ComboBoxRes.TabIndex = 4;
            ComboBoxRes.TextChanged += ComboBoxRes_TextChanged;
            // 
            // NumericSquareSize
            // 
            NumericSquareSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericSquareSize.DecimalPlaces = 2;
            NumericSquareSize.Location = new Point(103, 61);
            NumericSquareSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericSquareSize.Name = "NumericSquareSize";
            NumericSquareSize.Size = new Size(475, 23);
            NumericSquareSize.TabIndex = 5;
            NumericSquareSize.ValueChanged += numericUpDownSquareSize_ValueChanged;
            // 
            // NumericMaxHeight
            // 
            NumericMaxHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericMaxHeight.DecimalPlaces = 2;
            NumericMaxHeight.Location = new Point(103, 90);
            NumericMaxHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericMaxHeight.Name = "NumericMaxHeight";
            NumericMaxHeight.Size = new Size(475, 23);
            NumericMaxHeight.TabIndex = 6;
            NumericMaxHeight.ValueChanged += numericUpDownMaxHeight_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 7;
            label1.Text = "Resolution (px)";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 36);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 8;
            label2.Text = "World Size (m)";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 65);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 9;
            label3.Text = "Square Size (m)";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 94);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 10;
            label4.Text = "Max Height (m)";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(NumericBaseHeight, 1, 4);
            tableLayoutPanel1.Controls.Add(NumericMaxHeight, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(NumericSquareSize, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(NumericWorldSize, 1, 1);
            tableLayoutPanel1.Controls.Add(ComboBoxRes, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(581, 145);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // NumericBaseHeight
            // 
            NumericBaseHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericBaseHeight.DecimalPlaces = 2;
            NumericBaseHeight.Location = new Point(103, 119);
            NumericBaseHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericBaseHeight.Name = "NumericBaseHeight";
            NumericBaseHeight.Size = new Size(475, 23);
            NumericBaseHeight.TabIndex = 12;
            NumericBaseHeight.ValueChanged += numericBaseHeight_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 123);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 13;
            label5.Text = "Base Height (m)";
            // 
            // TerrainSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(10000, 145);
            MinimumSize = new Size(0, 145);
            Name = "TerrainSettings";
            Size = new Size(581, 145);
            ((System.ComponentModel.ISupportInitialize)NumericWorldSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericSquareSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericMaxHeight).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericBaseHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        public NumericUpDown NumericWorldSize;
        public ComboBox ComboBoxRes;
        public NumericUpDown NumericSquareSize;
        public NumericUpDown NumericMaxHeight;
        public NumericUpDown NumericBaseHeight;
    }
}

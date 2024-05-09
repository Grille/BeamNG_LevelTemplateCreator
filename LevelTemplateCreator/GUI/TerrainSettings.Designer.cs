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
            numericWorldSize = new NumericUpDown();
            comboBoxRes = new ComboBox();
            numericSquareSize = new NumericUpDown();
            numericMaxHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            numericBaseHeight = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericWorldSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSquareSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxHeight).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericBaseHeight).BeginInit();
            SuspendLayout();
            // 
            // numericWorldSize
            // 
            numericWorldSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericWorldSize.DecimalPlaces = 2;
            numericWorldSize.Location = new Point(103, 32);
            numericWorldSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericWorldSize.Name = "numericWorldSize";
            numericWorldSize.Size = new Size(475, 23);
            numericWorldSize.TabIndex = 3;
            numericWorldSize.ValueChanged += numericUpDownWorldSize_ValueChanged;
            // 
            // comboBoxRes
            // 
            comboBoxRes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRes.FormattingEnabled = true;
            comboBoxRes.Items.AddRange(new object[] { "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768", "65536" });
            comboBoxRes.Location = new Point(103, 3);
            comboBoxRes.Name = "comboBoxRes";
            comboBoxRes.Size = new Size(475, 23);
            comboBoxRes.TabIndex = 4;
            comboBoxRes.SelectedIndexChanged += comboBoxRes_SelectedIndexChanged;
            // 
            // numericSquareSize
            // 
            numericSquareSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericSquareSize.DecimalPlaces = 2;
            numericSquareSize.Location = new Point(103, 61);
            numericSquareSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericSquareSize.Name = "numericSquareSize";
            numericSquareSize.Size = new Size(475, 23);
            numericSquareSize.TabIndex = 5;
            numericSquareSize.ValueChanged += numericUpDownSquareSize_ValueChanged;
            // 
            // numericMaxHeight
            // 
            numericMaxHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericMaxHeight.DecimalPlaces = 2;
            numericMaxHeight.Location = new Point(103, 90);
            numericMaxHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericMaxHeight.Name = "numericMaxHeight";
            numericMaxHeight.Size = new Size(475, 23);
            numericMaxHeight.TabIndex = 6;
            numericMaxHeight.ValueChanged += numericUpDownMaxHeight_ValueChanged;
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
            tableLayoutPanel1.Controls.Add(numericBaseHeight, 1, 4);
            tableLayoutPanel1.Controls.Add(numericMaxHeight, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(numericSquareSize, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(numericWorldSize, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBoxRes, 1, 0);
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
            // numericBaseHeight
            // 
            numericBaseHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBaseHeight.DecimalPlaces = 2;
            numericBaseHeight.Location = new Point(103, 119);
            numericBaseHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericBaseHeight.Name = "numericBaseHeight";
            numericBaseHeight.Size = new Size(475, 23);
            numericBaseHeight.TabIndex = 12;
            numericBaseHeight.ValueChanged += numericBaseHeight_ValueChanged;
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
            ((System.ComponentModel.ISupportInitialize)numericWorldSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSquareSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxHeight).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericBaseHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numericWorldSize;
        private ComboBox comboBoxRes;
        private NumericUpDown numericSquareSize;
        private NumericUpDown numericMaxHeight;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numericBaseHeight;
        private Label label5;
    }
}

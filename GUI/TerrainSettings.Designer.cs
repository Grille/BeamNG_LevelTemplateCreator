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
            numericUpDownWorldSize = new NumericUpDown();
            comboBoxRes = new ComboBox();
            numericUpDownSquareSize = new NumericUpDown();
            numericUpDownMaxHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorldSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSquareSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxHeight).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // numericUpDownWorldSize
            // 
            numericUpDownWorldSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownWorldSize.DecimalPlaces = 2;
            numericUpDownWorldSize.Location = new Point(100, 32);
            numericUpDownWorldSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownWorldSize.Name = "numericUpDownWorldSize";
            numericUpDownWorldSize.Size = new Size(308, 23);
            numericUpDownWorldSize.TabIndex = 3;
            numericUpDownWorldSize.ValueChanged += numericUpDownWorldSize_ValueChanged;
            // 
            // comboBoxRes
            // 
            comboBoxRes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRes.FormattingEnabled = true;
            comboBoxRes.Items.AddRange(new object[] { "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768", "65536" });
            comboBoxRes.Location = new Point(100, 3);
            comboBoxRes.Name = "comboBoxRes";
            comboBoxRes.Size = new Size(308, 23);
            comboBoxRes.TabIndex = 4;
            comboBoxRes.SelectedIndexChanged += comboBoxRes_SelectedIndexChanged;
            // 
            // numericUpDownSquareSize
            // 
            numericUpDownSquareSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownSquareSize.DecimalPlaces = 2;
            numericUpDownSquareSize.Location = new Point(100, 61);
            numericUpDownSquareSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownSquareSize.Name = "numericUpDownSquareSize";
            numericUpDownSquareSize.Size = new Size(308, 23);
            numericUpDownSquareSize.TabIndex = 5;
            numericUpDownSquareSize.ValueChanged += numericUpDownSquareSize_ValueChanged;
            // 
            // numericUpDownMaxHeight
            // 
            numericUpDownMaxHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownMaxHeight.DecimalPlaces = 2;
            numericUpDownMaxHeight.Location = new Point(100, 90);
            numericUpDownMaxHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownMaxHeight.Name = "numericUpDownMaxHeight";
            numericUpDownMaxHeight.Size = new Size(308, 23);
            numericUpDownMaxHeight.TabIndex = 6;
            numericUpDownMaxHeight.ValueChanged += numericUpDownMaxHeight_ValueChanged;
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(numericUpDownMaxHeight, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(numericUpDownSquareSize, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(numericUpDownWorldSize, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBoxRes, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(411, 116);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // TerrainSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(10000, 116);
            MinimumSize = new Size(0, 116);
            Name = "TerrainSettings";
            Size = new Size(411, 116);
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorldSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSquareSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxHeight).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numericUpDownWorldSize;
        private ComboBox comboBoxRes;
        private NumericUpDown numericUpDownSquareSize;
        private NumericUpDown numericUpDownMaxHeight;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
    }
}

namespace LevelTemplateCreator.GUI
{
    partial class ContentManager
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
            tableLayoutPanel1 = new TableLayoutPanel();
            AssetListBoxSelected = new AssetViewBox();
            textBoxSelectedFilter = new TextBox();
            textBoxAvailableFilter = new TextBox();
            AssetListBoxAvailable = new AssetViewBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(AssetListBoxSelected, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxSelectedFilter, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxAvailableFilter, 1, 0);
            tableLayoutPanel1.Controls.Add(AssetListBoxAvailable, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1204, 701);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AssetListBoxSelected
            // 
            AssetListBoxSelected.BackColor = SystemColors.Window;
            AssetListBoxSelected.Dock = DockStyle.Fill;
            AssetListBoxSelected.Filter = null;
            AssetListBoxSelected.ItemHeight = 128;
            AssetListBoxSelected.Location = new Point(0, 29);
            AssetListBoxSelected.Margin = new Padding(0);
            AssetListBoxSelected.Name = "AssetListBoxSelected";
            AssetListBoxSelected.OnItemClick = null;
            AssetListBoxSelected.Position = 0;
            AssetListBoxSelected.Size = new Size(602, 672);
            AssetListBoxSelected.TabIndex = 1;
            // 
            // textBoxSelectedFilter
            // 
            textBoxSelectedFilter.Dock = DockStyle.Fill;
            textBoxSelectedFilter.Location = new Point(3, 3);
            textBoxSelectedFilter.Name = "textBoxSelectedFilter";
            textBoxSelectedFilter.Size = new Size(596, 23);
            textBoxSelectedFilter.TabIndex = 2;
            textBoxSelectedFilter.TextChanged += textBoxSelectedFilter_TextChanged;
            // 
            // textBoxAvailableFilter
            // 
            textBoxAvailableFilter.Dock = DockStyle.Fill;
            textBoxAvailableFilter.Location = new Point(605, 3);
            textBoxAvailableFilter.Name = "textBoxAvailableFilter";
            textBoxAvailableFilter.Size = new Size(596, 23);
            textBoxAvailableFilter.TabIndex = 3;
            textBoxAvailableFilter.TextChanged += textBoxAvailableFilter_TextChanged;
            // 
            // AssetListBoxAvailable
            // 
            AssetListBoxAvailable.BackColor = SystemColors.Window;
            AssetListBoxAvailable.Dock = DockStyle.Fill;
            AssetListBoxAvailable.Filter = null;
            AssetListBoxAvailable.ItemHeight = 128;
            AssetListBoxAvailable.Location = new Point(602, 29);
            AssetListBoxAvailable.Margin = new Padding(0);
            AssetListBoxAvailable.Name = "AssetListBoxAvailable";
            AssetListBoxAvailable.OnItemClick = null;
            AssetListBoxAvailable.Position = 0;
            AssetListBoxAvailable.Size = new Size(602, 672);
            AssetListBoxAvailable.TabIndex = 0;
            // 
            // ContentManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ContentManager";
            Size = new Size(1204, 701);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        public AssetViewBox AssetListBoxAvailable;
        public AssetViewBox AssetListBoxSelected;
        private TextBox textBoxSelectedFilter;
        private TextBox textBoxAvailableFilter;
    }
}

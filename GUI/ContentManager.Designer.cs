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
            AssetListBoxAvailable = new AssetListBox();
            AssetListBoxSelected = new AssetListBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(AssetListBoxAvailable, 2, 0);
            tableLayoutPanel1.Controls.Add(AssetListBoxSelected, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1204, 701);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AssetListBoxAvailable
            // 
            AssetListBoxAvailable.Dock = DockStyle.Fill;
            AssetListBoxAvailable.DrawMode = DrawMode.OwnerDrawFixed;
            AssetListBoxAvailable.FormattingEnabled = true;
            AssetListBoxAvailable.IntegralHeight = false;
            AssetListBoxAvailable.ItemHeight = 64;
            AssetListBoxAvailable.Location = new Point(612, 0);
            AssetListBoxAvailable.Margin = new Padding(0);
            AssetListBoxAvailable.Name = "AssetListBoxAvailable";
            AssetListBoxAvailable.ScrollAlwaysVisible = true;
            AssetListBoxAvailable.Size = new Size(592, 701);
            AssetListBoxAvailable.TabIndex = 0;
            // 
            // AssetListBoxSelected
            // 
            AssetListBoxSelected.Dock = DockStyle.Fill;
            AssetListBoxSelected.DrawMode = DrawMode.OwnerDrawFixed;
            AssetListBoxSelected.FormattingEnabled = true;
            AssetListBoxSelected.IntegralHeight = false;
            AssetListBoxSelected.ItemHeight = 64;
            AssetListBoxSelected.Location = new Point(0, 0);
            AssetListBoxSelected.Margin = new Padding(0);
            AssetListBoxSelected.Name = "AssetListBoxSelected";
            AssetListBoxSelected.ScrollAlwaysVisible = true;
            AssetListBoxSelected.Size = new Size(592, 701);
            AssetListBoxSelected.TabIndex = 1;
            // 
            // ContentManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ContentManager";
            Size = new Size(1204, 701);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        public AssetListBox AssetListBoxAvailable;
        public AssetListBox AssetListBoxSelected;
    }
}

namespace LevelTemplateCreator.GUI;

partial class TreeMapBuilder
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
        splitContainer1 = new SplitContainer();
        labledNumericRegion = new LabledNumeric();
        buttonUpdate = new Button();
        buttonSave = new Button();
        labledNumericPen = new LabledNumeric();
        buttonClear = new Button();
        buttonAddDir = new Button();
        buttonAddFile = new Button();
        labledNumericCanvas = new LabledNumeric();
        pictureBox = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(labledNumericRegion);
        splitContainer1.Panel1.Controls.Add(buttonUpdate);
        splitContainer1.Panel1.Controls.Add(buttonSave);
        splitContainer1.Panel1.Controls.Add(labledNumericPen);
        splitContainer1.Panel1.Controls.Add(buttonClear);
        splitContainer1.Panel1.Controls.Add(buttonAddDir);
        splitContainer1.Panel1.Controls.Add(buttonAddFile);
        splitContainer1.Panel1.Controls.Add(labledNumericCanvas);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(pictureBox);
        splitContainer1.Size = new Size(888, 524);
        splitContainer1.SplitterDistance = 296;
        splitContainer1.TabIndex = 0;
        // 
        // labledNumericRegion
        // 
        labledNumericRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labledNumericRegion.LabelText = "Region Size";
        labledNumericRegion.Location = new Point(1, 116);
        labledNumericRegion.Margin = new Padding(0);
        labledNumericRegion.Name = "labledNumericRegion";
        labledNumericRegion.Size = new Size(296, 29);
        labledNumericRegion.TabIndex = 8;
        labledNumericRegion.Value = new decimal(new int[] { 2000, 0, 0, 0 });
        // 
        // buttonUpdate
        // 
        buttonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonUpdate.Location = new Point(4, 177);
        buttonUpdate.Name = "buttonUpdate";
        buttonUpdate.Size = new Size(290, 23);
        buttonUpdate.TabIndex = 7;
        buttonUpdate.Text = "Update";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += buttonUpdate_Click;
        // 
        // buttonSave
        // 
        buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonSave.Location = new Point(4, 206);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new Size(290, 23);
        buttonSave.TabIndex = 6;
        buttonSave.Text = "Save";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // labledNumericPen
        // 
        labledNumericPen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labledNumericPen.LabelText = "Pen Size";
        labledNumericPen.Location = new Point(1, 145);
        labledNumericPen.Margin = new Padding(0);
        labledNumericPen.Name = "labledNumericPen";
        labledNumericPen.Size = new Size(296, 29);
        labledNumericPen.TabIndex = 5;
        labledNumericPen.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // buttonClear
        // 
        buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonClear.Location = new Point(4, 61);
        buttonClear.Name = "buttonClear";
        buttonClear.Size = new Size(290, 23);
        buttonClear.TabIndex = 4;
        buttonClear.Text = "Clear";
        buttonClear.UseVisualStyleBackColor = true;
        buttonClear.Click += buttonClear_Click;
        // 
        // buttonAddDir
        // 
        buttonAddDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddDir.Location = new Point(4, 32);
        buttonAddDir.Name = "buttonAddDir";
        buttonAddDir.Size = new Size(290, 23);
        buttonAddDir.TabIndex = 3;
        buttonAddDir.Text = "Add Folder";
        buttonAddDir.UseVisualStyleBackColor = true;
        buttonAddDir.Click += buttonAddDir_Click;
        // 
        // buttonAddFile
        // 
        buttonAddFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddFile.Location = new Point(3, 3);
        buttonAddFile.Name = "buttonAddFile";
        buttonAddFile.Size = new Size(290, 23);
        buttonAddFile.TabIndex = 2;
        buttonAddFile.Text = "Add File";
        buttonAddFile.UseVisualStyleBackColor = true;
        buttonAddFile.Click += buttonAddFile_Click;
        // 
        // labledNumericCanvas
        // 
        labledNumericCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labledNumericCanvas.LabelText = "Canvas Size";
        labledNumericCanvas.Location = new Point(1, 87);
        labledNumericCanvas.Margin = new Padding(0);
        labledNumericCanvas.Name = "labledNumericCanvas";
        labledNumericCanvas.Size = new Size(296, 29);
        labledNumericCanvas.TabIndex = 1;
        labledNumericCanvas.Value = new decimal(new int[] { 2048, 0, 0, 0 });
        // 
        // pictureBox
        // 
        pictureBox.BackColor = Color.Gray;
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Location = new Point(0, 0);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(588, 524);
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.TabIndex = 0;
        pictureBox.TabStop = false;
        // 
        // TreeMapBuilder
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(888, 524);
        Controls.Add(splitContainer1);
        Name = "TreeMapBuilder";
        Text = "TreeMapBuilder";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private LabledNumeric labledNumericCanvas;
    private PictureBox pictureBox;
    private Button buttonAddFile;
    private Button buttonSave;
    private LabledNumeric labledNumericPen;
    private Button buttonClear;
    private Button buttonAddDir;
    private Button buttonUpdate;
    private LabledNumeric labledNumericRegion;
}
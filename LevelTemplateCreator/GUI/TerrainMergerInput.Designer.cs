namespace LevelTemplateCreator.GUI;

partial class TerrainMergerInputControl
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
        InputPath = new PathBox();
        InputTitle = new Label();
        ResolutionTextBox = new LabledTextbox();
        OffsetXNumeric = new LabledNumeric();
        OffsetYNumeric = new LabledNumeric();
        SizeNumeric = new LabledNumeric();
        MaxHeightNumeric = new LabledNumeric();
        SuspendLayout();
        // 
        // InputPath
        // 
        InputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        InputPath.FileFilter = "All files (*.*)|*.*";
        InputPath.LabelText = "Terrain";
        InputPath.Location = new Point(0, 23);
        InputPath.Margin = new Padding(3, 0, 3, 0);
        InputPath.Name = "InputPath";
        InputPath.Size = new Size(546, 29);
        InputPath.TabIndex = 0;
        InputPath.Target = PathBox.TargetType.Folder;
        // 
        // InputTitle
        // 
        InputTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        InputTitle.Location = new Point(3, 0);
        InputTitle.Name = "InputTitle";
        InputTitle.Size = new Size(540, 23);
        InputTitle.TabIndex = 1;
        InputTitle.Text = "Input 1";
        InputTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // ResolutionTextBox
        // 
        ResolutionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        ResolutionTextBox.LabelText = "Resolution";
        ResolutionTextBox.Location = new Point(0, 52);
        ResolutionTextBox.Margin = new Padding(0);
        ResolutionTextBox.Name = "ResolutionTextBox";
        ResolutionTextBox.Size = new Size(546, 29);
        ResolutionTextBox.TabIndex = 2;
        // 
        // OffsetXNumeric
        // 
        OffsetXNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        OffsetXNumeric.LabelText = "Offset X";
        OffsetXNumeric.Location = new Point(0, 110);
        OffsetXNumeric.Margin = new Padding(0);
        OffsetXNumeric.Name = "OffsetXNumeric";
        OffsetXNumeric.Size = new Size(546, 29);
        OffsetXNumeric.TabIndex = 3;
        OffsetXNumeric.Value = new decimal(new int[] { 0, 0, 0, 0 });
        // 
        // OffsetYNumeric
        // 
        OffsetYNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        OffsetYNumeric.LabelText = "Offset Y";
        OffsetYNumeric.Location = new Point(0, 139);
        OffsetYNumeric.Margin = new Padding(0);
        OffsetYNumeric.Name = "OffsetYNumeric";
        OffsetYNumeric.Size = new Size(546, 29);
        OffsetYNumeric.TabIndex = 4;
        OffsetYNumeric.Value = new decimal(new int[] { 0, 0, 0, 0 });
        // 
        // SizeNumeric
        // 
        SizeNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        SizeNumeric.LabelText = "Size";
        SizeNumeric.Location = new Point(0, 81);
        SizeNumeric.Margin = new Padding(0);
        SizeNumeric.Name = "SizeNumeric";
        SizeNumeric.Size = new Size(546, 29);
        SizeNumeric.TabIndex = 5;
        SizeNumeric.Value = new decimal(new int[] { 0, 0, 0, 0 });
        // 
        // MaxHeightNumeric
        // 
        MaxHeightNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        MaxHeightNumeric.LabelText = "MaxHeight";
        MaxHeightNumeric.Location = new Point(0, 168);
        MaxHeightNumeric.Margin = new Padding(0);
        MaxHeightNumeric.Name = "MaxHeightNumeric";
        MaxHeightNumeric.Size = new Size(546, 29);
        MaxHeightNumeric.TabIndex = 6;
        MaxHeightNumeric.Value = new decimal(new int[] { 0, 0, 0, 0 });
        // 
        // TerrainMergerInputControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(MaxHeightNumeric);
        Controls.Add(SizeNumeric);
        Controls.Add(OffsetYNumeric);
        Controls.Add(OffsetXNumeric);
        Controls.Add(ResolutionTextBox);
        Controls.Add(InputTitle);
        Controls.Add(InputPath);
        Name = "TerrainMergerInputControl";
        Size = new Size(546, 200);
        ResumeLayout(false);
    }

    #endregion

    public PathBox InputPath;
    public Label InputTitle;
    private LabledTextbox ResolutionTextBox;
    public LabledNumeric OffsetXNumeric;
    public LabledNumeric OffsetYNumeric;
    public LabledNumeric SizeNumeric;
    public LabledNumeric MaxHeightNumeric;
}

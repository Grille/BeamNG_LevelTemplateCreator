using Grille.BeamNG;
using Grille.Graphics.Isometric.Buffers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.GUI;
public partial class TerrainMergerInputControl : UserControl
{
    public float MaxHeight { get; private set; }

    public bool InputEnabled { get; private set; }

    bool _cancelOnInputChanged;

    public Terrain Terrain { get; }

    public event EventHandler? InputChanged;

    public TerrainMergerInputControl()
    {
        InitializeComponent();

        InputPath.Target = PathBox.TargetType.OpenFile;
        InputPath.FileFilter = TerrainFileDialog.Filter;

        MaxHeight = 255;

        Terrain = new Terrain();

        ResolutionTextBox.TextBox.ReadOnly = true;

        InputPath.TextBox.TextChanged += TextBoxPath_TextChanged;

        MaxHeightNumeric.Numeric.ValueChanged += OnInputChanged;
        OffsetXNumeric.Numeric.ValueChanged += OnInputChanged;
        OffsetYNumeric.Numeric.ValueChanged += OnInputChanged;
        SizeNumeric.Numeric.ValueChanged += OnInputChanged;
    }



    public void OnInputChanged()
    {
        if (_cancelOnInputChanged)
            return;

        InputChanged?.Invoke(this, EventArgs.Empty);
    }

    bool PathChanged(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            Terrain.Load(path);
            return true;
        }
        catch (Exception ex)
        {
            ExceptionBox.Show(this, ex);
            return false;
        }
    }

    private void TextBoxPath_TextChanged(object? sender, EventArgs e)
    {
        _cancelOnInputChanged = true;

        if (PathChanged(InputPath.Text))
        {
            InputEnabled = true;
            ResolutionTextBox.Text = Terrain.Size.ToString();
            SizeNumeric.Value = Terrain.Size;
            InputPath.TextBox.ForeColor = Color.Black;
        }
        else
        {
            InputEnabled = false;
            ResolutionTextBox.Text = "-";
            InputPath.TextBox.ForeColor = Color.Red;
        }

        _cancelOnInputChanged = false;

        OnInputChanged();
    }

    private void OnInputChanged(object? sender, EventArgs e)
    {
        OnInputChanged();
    }
}

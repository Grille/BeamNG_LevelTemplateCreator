using Grille.BeamNG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LevelTemplateCreator.GUI;

public partial class TerrainSettings : UserControl
{
    TerrainTemplate _terrain;

    bool isUpdating = false;

    [Browsable(true)]
    public event EventHandler? TerrainChanged;

    public TerrainTemplate Terrain
    {
        get => _terrain;
        set
        {
            _terrain = value;
            UpdateDisplayFromNewTerrain();
        }
    }

    public TerrainSettings()
    {
        InitializeComponent();

        NumericWorldSize.Maximum = decimal.MaxValue;
        NumericSquareSize.Maximum = decimal.MaxValue;
        NumericMaxHeight.Maximum = decimal.MaxValue;


        ComboBoxRes.Items.Clear();
        int size = 256;
        for (int i = 0; i < 6; i++)
        {
            ComboBoxRes.Items.Add(size);
            size *= 2;
        }

        _terrain = new TerrainTemplate();
        UpdateDisplayFromNewTerrain();
    }

    void UpdateDisplayFromNewTerrain()
    {
        isUpdating = true;

        ComboBoxRes.Text = _terrain.Resolution.ToString();
        NumericMaxHeight.Value = (decimal)_terrain.MaxHeight;
        NumericBaseHeight.Value = (decimal)_terrain.Height;

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        isUpdating = true;


        UpdateNumericBaseHeightColor();

        NumericWorldSize.Value = (decimal)Terrain.WorldSize;
        NumericSquareSize.Value = (decimal)Terrain.SquareSize;

        isUpdating = false;
    }

    protected void OnTerrainChanged()
    {
        UpdateDisplay();
        TerrainChanged?.Invoke(this, EventArgs.Empty);
    }

    private void numericUpDownWorldSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.WorldSize = (float)NumericWorldSize.Value;

        OnTerrainChanged();
    }

    private void numericUpDownSquareSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.SquareSize = (float)NumericSquareSize.Value;

        OnTerrainChanged();
    }

    private void numericUpDownMaxHeight_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.MaxHeight = (float)NumericMaxHeight.Value;

        OnTerrainChanged();
    }

    private void numericBaseHeight_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.Height = (float)NumericBaseHeight.Value;

        OnTerrainChanged();
    }

    void UpdateNumericBaseHeightColor()
    {
        NumericBaseHeight.ForeColor = Terrain.Height > Terrain.MaxHeight ? Color.Red : Color.Black;
    }

    private void ComboBoxRes_TextChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        var text = ComboBoxRes.Text;

        if (int.TryParse(text, out int res))
        {
            Terrain.Resolution = res;
            ComboBoxRes.ForeColor = Color.Black;
        }
        else
        {
            ComboBoxRes.ForeColor = Color.Red;
        }

        OnTerrainChanged();
    }
}

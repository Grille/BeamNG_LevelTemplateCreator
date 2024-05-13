using Grille.BeamNG;
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

public partial class TerrainSettings : UserControl
{
    TerrainTemplate _terrain;

    bool isUpdating = false;

    internal TerrainTemplate Terrain
    {
        get => _terrain;
        set
        {
            _terrain = value;
            ComboBoxRes.SelectedText = _terrain.Resolution.ToString();
            NumericMaxHeight.Value = (decimal)_terrain.MaxHeight;
            NumericBaseHeight.Value = (decimal)_terrain.Height;
            UpdatenumericBaseHeightColor();

            UpdateDisplay();
        }
    }

    public TerrainSettings()
    {
        InitializeComponent();

        _terrain = null!;

        NumericWorldSize.Maximum = decimal.MaxValue;
        NumericSquareSize.Maximum = decimal.MaxValue;
        NumericMaxHeight.Maximum = decimal.MaxValue;
    }



    public void UpdateDisplay()
    {
        isUpdating = true;

        NumericWorldSize.Value = (decimal)Terrain.WorldSize;
        NumericSquareSize.Value = (decimal)Terrain.SquareSize;

        isUpdating = false;
    }

    private void comboBoxRes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        var text = ComboBoxRes.Text;
        Terrain.Resolution = int.Parse(text);

        if (ComboBoxRes.SelectedIndex == -1)
        {
            ComboBoxRes.ForeColor = Color.Red;
        }
        else
        {
            ComboBoxRes.ForeColor = Color.Black;
        }

        UpdateDisplay();
    }

    private void numericUpDownWorldSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.WorldSize = (float)NumericWorldSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownSquareSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.SquareSize = (float)NumericSquareSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownMaxHeight_ValueChanged(object sender, EventArgs e)
    {
        Terrain.MaxHeight = (float)NumericMaxHeight.Value;
        UpdatenumericBaseHeightColor();
    }

    private void numericBaseHeight_ValueChanged(object sender, EventArgs e)
    {
        Terrain.Height = (float)NumericBaseHeight.Value;
        UpdatenumericBaseHeightColor();
    }

    void UpdatenumericBaseHeightColor()
    {
        NumericBaseHeight.ForeColor = Terrain.Height > Terrain.MaxHeight ? Color.Red : Color.Black;
    }
}

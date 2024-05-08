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
    TerrainInfo _terrain;

    bool isUpdating = false;

    internal TerrainInfo Terrain
    {
        get => _terrain;
        set
        {
            _terrain = value;
            comboBoxRes.SelectedText = _terrain.Resolution.ToString();
            numericMaxHeight.Value = (decimal)_terrain.MaxHeight;
            numericBaseHeight.Value = (decimal)_terrain.Height;
            UpdatenumericBaseHeightColor();

            UpdateDisplay();
        }
    }

    public TerrainSettings()
    {
        InitializeComponent();

        _terrain = null!;

        numericWorldSize.Maximum = decimal.MaxValue;
        numericSquareSize.Maximum = decimal.MaxValue;
        numericMaxHeight.Maximum = decimal.MaxValue;
    }



    public void UpdateDisplay()
    {
        isUpdating = true;

        numericWorldSize.Value = (decimal)Terrain.WorldSize;
        numericSquareSize.Value = (decimal)Terrain.SquareSize;

        isUpdating = false;
    }

    private void comboBoxRes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        var text = comboBoxRes.Text;
        Terrain.Resolution = int.Parse(text);

        if (comboBoxRes.SelectedIndex == -1)
        {
            comboBoxRes.ForeColor = Color.Red;
        }
        else
        {
            comboBoxRes.ForeColor = Color.Black;
        }

        UpdateDisplay();
    }

    private void numericUpDownWorldSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.WorldSize = (float)numericWorldSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownSquareSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.SquareSize = (float)numericSquareSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownMaxHeight_ValueChanged(object sender, EventArgs e)
    {
        Terrain.MaxHeight = (float)numericMaxHeight.Value;
        UpdatenumericBaseHeightColor();
    }

    private void numericBaseHeight_ValueChanged(object sender, EventArgs e)
    {
        Terrain.Height = (float)numericBaseHeight.Value;
        UpdatenumericBaseHeightColor();
    }

    void UpdatenumericBaseHeightColor()
    {
        numericBaseHeight.ForeColor = Terrain.Height > Terrain.MaxHeight ? Color.Red : Color.Black;
    }
}

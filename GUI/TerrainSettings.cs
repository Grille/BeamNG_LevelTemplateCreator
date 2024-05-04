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
            numericUpDownMaxHeight.Value = _terrain.MaxHeight;

            UpdateDisplay();
        }
    }

    public TerrainSettings()
    {
        InitializeComponent();

        numericUpDownWorldSize.Maximum = decimal.MaxValue;
        numericUpDownSquareSize.Maximum = decimal.MaxValue;
        numericUpDownMaxHeight.Maximum = decimal.MaxValue;
    }



    public void UpdateDisplay()
    {
        isUpdating = true;

        numericUpDownWorldSize.Value = (decimal)Terrain.WorldSize;
        numericUpDownSquareSize.Value = (decimal)Terrain.SquareSize;

        isUpdating = false;
    }

    private void comboBoxRes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        var text = comboBoxRes.Text;
        Terrain.Resolution = int.Parse(text);

        if (comboBoxRes.SelectedIndex == -1) { 
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

        Terrain.WorldSize = (float)numericUpDownWorldSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownSquareSize_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.SquareSize = (float)numericUpDownSquareSize.Value;

        UpdateDisplay();
    }

    private void numericUpDownMaxHeight_ValueChanged(object sender, EventArgs e)
    {
        if (isUpdating)
            return;

        Terrain.MaxHeight = (int)numericUpDownMaxHeight.Value;
    }
}

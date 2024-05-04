using LevelTemplateCreator.Assets;
using LevelTemplateCreator.IO.Resources;
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

internal partial class LevelSettings : UserControl
{
    Level _level;

    public Level Level { get => _level; set => SetLevel(value); }

    public AssetLibary AssetLibary => Level.Libary;

    public LevelPreset SelectedLevelPreset => (LevelPreset)comboBoxPreset.SelectedItem;

    void SetLevel(Level level)
    {
        _level = level;

        if (_level == null)
            return;

        if (AssetLibary.LevelPresets.Count > 0)
        {
            foreach (var item in AssetLibary.LevelPresets)
            {
                comboBoxPreset.Items.Add(item);
            }
            comboBoxPreset.SelectedIndex = 0;
        }

        TerainSettings.Terrain = Level.Terrain;

        textBoxNamespace.Text = Level.Namespace;
        textBoxTitle.Text = Level.Info.Title;
        textBoxAuthors.Text = Level.Info.Authors;
    }

    public LevelSettings()
    {
        InitializeComponent();
    }

    private void textBoxNamespace_TextChanged(object sender, EventArgs e)
    {
        Level.Namespace = textBoxNamespace.Text;
    }

    private void textBoxTitle_TextChanged(object sender, EventArgs e)
    {
        Level.Info.Title = textBoxTitle.Text;
    }

    private void textBoxAuthors_TextChanged(object sender, EventArgs e)
    {
        Level.Info.Authors = textBoxAuthors.Text;
    }
}

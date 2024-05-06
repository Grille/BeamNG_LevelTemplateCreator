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
    Level? _level;

    public void SetLevel(Level level)
    {
        _level = level;

        if (_level == null)
            return;

        TerainSettings.Terrain = _level.Terrain;

        TextBoxNamespace.Text = _level.Namespace;
        TextBoxTitle.Text = _level.Info.Title;
        TextBoxAuthor.Text = _level.Info.Authors;
    }

    public LevelSettings()
    {
        InitializeComponent();


    }

    private void textBoxNamespace_TextChanged(object sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Namespace = TextBoxNamespace.Text;
    }

    private void textBoxTitle_TextChanged(object sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Info.Title = TextBoxTitle.Text;
    }

    private void textBoxAuthors_TextChanged(object sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Info.Authors = TextBoxAuthor.Text;
    }
}

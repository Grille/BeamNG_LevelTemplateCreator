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
    AssetLevelBuilder? _level;

    public void SetLevel(AssetLevelBuilder level)
    {
        _level = level;

        if (_level == null)
            return;

        TerainSettings.Terrain = _level.Terrain;

        TextBoxNamespace.Text = _level.Namespace;
        TextBoxTitle.Text = _level.Info.Title.Value;
        TextBoxAuthor.Text = _level.Info.Authors.Value;

        TextBoxNamespace.TextBox.TextChanged += Namespace_TextChanged;
        TextBoxTitle.TextBox.TextChanged += Title_TextChanged;
        TextBoxAuthor.TextBox.TextChanged += Authors_TextChanged;
        ComboBoxCopyMode.SelectedIndexChanged += ComboBoxCopyMode_SelectedIndexChanged;

        ComboBoxCopyMode.SelectedIndex = 0;
        ComboBoxNamingMode.SelectedIndex = 0;
    }

    public LevelSettings()
    {
        InitializeComponent();
    }

    private void ComboBoxCopyMode_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.CopyMode = (FileCopyMode)ComboBoxCopyMode.SelectedIndex;
    }

    private void Namespace_TextChanged(object? sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Namespace = TextBoxNamespace.Text;
    }

    private void Title_TextChanged(object? sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Info.Title.Value = TextBoxTitle.Text;
    }

    private void Authors_TextChanged(object? sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Info.Authors.Value = TextBoxAuthor.Text;
    }
}

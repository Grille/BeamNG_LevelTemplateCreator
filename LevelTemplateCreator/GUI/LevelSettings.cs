﻿using LevelTemplateCreator.Assets;
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

        TextBoxNamespace.TextBox.TextChanged += Namespace_TextChanged;
        TextBoxTitle.TextBox.TextChanged += Title_TextChanged;
        TextBoxAuthor.TextBox.TextChanged += Authors_TextChanged;
    }

    public LevelSettings()
    {
        InitializeComponent();
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

        _level.Info.Title = TextBoxTitle.Text;
    }

    private void Authors_TextChanged(object? sender, EventArgs e)
    {
        if (_level == null)
            return;

        _level.Info.Authors = TextBoxAuthor.Text;
    }
}
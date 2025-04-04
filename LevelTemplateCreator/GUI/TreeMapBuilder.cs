using Grille.BeamNG.SceneTree.Forest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.GUI;
public partial class TreeMapBuilder : Form
{
    ForestGroup forest;

    public TreeMapBuilder()
    {
        forest = new();
        InitializeComponent();
    }

    Bitmap BuildImage()
    {
        int size = (int)labledNumericCanvas.Value;
        var canvas = new Bitmap(size, size);

        using var g = Graphics.FromImage(canvas);

        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.Half;

        float penSize = (float)labledNumericPen.Value;
        float penOffset = -penSize / 2f;

        float area = (float)labledNumericRegion.Value;
        var factor = size / area;

        float offset = penOffset;
        float penSizeScaled = penSize * factor;

        g.FillRectangle(Brushes.Black, 0, 0, size, size);

        float hsize = size / 2f;
        
        foreach (var items in forest.Dict.Values)
        {
            foreach (var item in items)
            {
                var position = item.Position.Value;
                float x = (+position.X + offset) * factor;
                float y = (-position.Y + offset) * factor;

                g.FillEllipse(Brushes.White, x + hsize, y + hsize, penSizeScaled, penSizeScaled);
            }
        }

        return canvas;
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            pictureBox.Image.Dispose();
        }
        pictureBox.Image = BuildImage();
    }

    private void buttonAddFile_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            forest.LoadFile(dialog.FileName);
        }
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
        forest.Dict.Clear();
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            using var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(dialog.FileName);
            }
        }
    }

    private void buttonAddDir_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            forest.LoadTree(dialog.SelectedPath);
        }
    }
}

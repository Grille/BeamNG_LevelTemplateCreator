using Grille.BeamNG;
using Grille.Graphics.Isometric.Diagnostics;
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
public partial class TerrainMerger : Form
{
    readonly TerrainMergerInputControl[] _inputs;

    public Terrain Canvas => terrainView.Canvas;

    public TerrainMerger()
    {
        InitializeComponent();

        Icon = Properties.Resources.GrilleBeamNgIcon;

        _inputs = new TerrainMergerInputControl[10];
        int offset = terrainSettings.Height + 23;
        for (int i = 0; i < _inputs.Length; i++)
        {
            var owner = settingsPanel;
            var input = new TerrainMergerInputControl();
            input.Location = new Point(0, offset);
            input.Width = owner.Width;
            input.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            input.InputTitle.BackColor = SystemColors.InactiveCaption;
            input.InputTitle.ForeColor = SystemColors.InactiveCaptionText;
            input.InputTitle.Text = $"Input {i}";
            input.MaxHeightNumeric.Value = 512m;
            input.InputChanged += Input_InputChanged;
            owner.Controls.Add(input);
            _inputs[i] = input;

            offset += input.Height;
        }

        terrainView.TerrainInputs = _inputs;
        terrainView.DefaultMouseEventsEnabled = true;
        terrainView.DebugInfoEnabled = true;
        terrainView.DrawBoundings = true;

        terrainView.OnLeftMouseDown = Grille.Graphics.Isometric.WinForms.RenderSurface.LDownAction.RotateRender;

        terrainSettings.NumericBaseHeight.Value = 0m;
        terrainSettings.NumericBaseHeight.Enabled = false;
        terrainSettings.NumericWorldSize.Enabled = false;
        terrainSettings.NumericSquareSize.Enabled = false;
        terrainSettings.Terrain.Resolution = 1024;
        terrainSettings.TerrainChanged += TerrainSettings_TerrainChanged;
        TerrainSettings_TerrainChanged(null, null!);
    }

    private void Input_InputChanged(object? sender, EventArgs e)
    {
        PaintTerrains();
    }

    private void TerrainSettings_TerrainChanged(object? sender, EventArgs e)
    {
        bool refrsh = false;

        if (Canvas.Size != terrainSettings.Terrain.Resolution)
        {
            Canvas.ResizeDataBuffer(terrainSettings.Terrain.Resolution);
            refrsh = true;
        }

        int maxHeight = (int)terrainSettings.Terrain.MaxHeight;
        if (terrainView.Renderer.MaxHeight != maxHeight)
        {
            terrainView.SetMaxHeight(maxHeight);
            refrsh = true;
        }

        if (refrsh)
        {
            PaintTerrains();
        }
    }

    void PaintTerrains()
    {
        var p = new Profiler();
        p.Begin();

        Canvas.Clear();

        foreach (var terrainInput in _inputs)
        {
            if (!terrainInput.InputEnabled)
                continue;

            var terrain = terrainInput.Terrain;

            int x = (int)terrainInput.OffsetXNumeric.Value;
            int y = (int)terrainInput.OffsetYNumeric.Value;
            int size = (int)terrainInput.SizeNumeric.Value;

            float maxHeight = (float)terrainInput.MaxHeightNumeric.Value;
            float scale = maxHeight / terrainSettings.Terrain.MaxHeight;


            var srcRect = new Rectangle(0, 0, terrain.Width, terrain.Height);
            var dstRect = new Rectangle(x, y, size, size);

            Canvas.Draw(terrain, dstRect, srcRect, scale);
        }

        p.End();

        Console.WriteLine(p);

        Console.WriteLine($"{Canvas.MaterialNames.Length} materials found:");
        foreach (var name in Canvas.MaterialNames)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        terrainView.UpdateBuffer();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        terrainView.Timer.Start();
        terrainView.UpdateBuffer();
    }

    private void exportTerrainToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TerrainFileDialog.TrySave(this, Canvas);
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        terrainView.Invalidate();

        base.OnResizeEnd(e);
    }

    private void terrainSettings1_Load(object sender, EventArgs e)
    {

    }

    private void showBoundingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        terrainView.DrawBoundings = showBoundingsToolStripMenuItem.Checked;
        terrainView.Invalidate();
    }
}

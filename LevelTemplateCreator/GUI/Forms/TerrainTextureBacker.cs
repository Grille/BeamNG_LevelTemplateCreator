using LevelTemplateCreator.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.GUI.Forms;

public partial class TerrainTextureBacker : Form
{
    public TerrainTextureBacker()
    {
        InitializeComponent();

        terrainView.DefaultMouseEventsEnabled = true;
        terrainView.DebugInfoEnabled = true;
        terrainView.DrawBoundings = true;
        terrainView.OnLeftMouseDown = Grille.Graphics.Isometric.WinForms.RenderSurface.LDownAction.RotateRender;
    }

    private void TerrainTextureBacker_Load(object sender, EventArgs e)
    {
        terrainView.Timer.Start();
    }
}

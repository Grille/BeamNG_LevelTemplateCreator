using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LevelTemplateCreator.Assets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LevelTemplateCreator;

internal class AssetViewBox : Control
{
    public List<Asset> Items { get; }

    public int ItemHeight { get; set; }

    public int Position {  get; set; }

    public int MaxPosition => Items.Count * ItemHeight;

    public int HoveredIndex { get; private set; }

    public VScrollBar ScrollBar { get; }

    public Action<Asset> OnItemClick { get; set; }

    public AssetViewBox()
    {
        Items = new List<Asset>();
        ItemHeight = 128;

        DoubleBuffered = true;

        ScrollBar = new VScrollBar();
        ScrollBar.Dock = DockStyle.Right;
        ScrollBar.LargeChange = 200;
        ScrollBar.ValueChanged += (object? sender, EventArgs e) => { 
            Position = ScrollBar.Value;
            Invalidate();
        };

        Controls.Add(ScrollBar);
    }

    public void ItemsChanged()
    {
        ScrollBar.Maximum = MaxPosition + ScrollBar.LargeChange - 1;
        Items.Sort((x, y) => x.Name.CompareTo(y.Name));

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;

        for (var i = 0; i < Items.Count; i++)
        {
            var asset = Items[i];
            DrawItem(g, asset, i);
        }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        Position -= e.Delta;

        if (Position > MaxPosition) { 
            Position = MaxPosition;
        }

        if (Position < 0)
        {
            Position = 0;
        }

        ScrollBar.Value = Position;

        Invalidate();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);

        if (HoveredIndex < 0)
            return;

        if (HoveredIndex > Items.Count - 1)
            return;

        if (OnItemClick == null)
            return;

        OnItemClick(Items[HoveredIndex]);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        HoveredIndex = (e.Location.Y + Position) / ItemHeight;

        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        HoveredIndex = -1;

        Invalidate();
    }

    Rectangle GetBounds(int index)
    {
        return new Rectangle(0, ItemHeight * index - Position, ClientSize.Width, ItemHeight);
    }


    void DrawItem(Graphics g, Asset item, int index)
    {
        
        var brush = new SolidBrush(Color.Black);

        var bounds = GetBounds(index);

        var boundsPreview = new Rectangle(bounds.X, bounds.Y, bounds.Height, bounds.Height);

        var boundsText = new Rectangle(bounds.Height, bounds.Y, bounds.Width - bounds.Height, bounds.Height);

        Brush backcolor = index % 2 == 0 ? Brushes.White : Brushes.Lavender;

        g.FillRectangle(backcolor, bounds);

        if (item.Preview != null)
        {
            g.DrawImage(item.Preview, boundsPreview);
        }
        else
        {
            g.FillRectangle(Brushes.DarkGray, boundsPreview);
        }

        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(item.Name))
        {
            sb.AppendLine(item.Name);
        }
        if (!string.IsNullOrEmpty(item.Description))
        {
            sb.AppendLine(item.Description);
        }
        sb.AppendLine(item.Object.Class.Value);
        sb.AppendLine(item.SourceFile);

        g.DrawString(sb.ToString(), Font, brush, boundsText);
        

        
        if (HoveredIndex == index)
        {
            int offset = 2;
            var rect = new Rectangle(boundsPreview.X + offset, boundsPreview.Y + offset, boundsPreview.Width - offset * 2, boundsPreview.Height - offset * 2);
            var pen = new Pen(Color.Green, offset*2);
            g.DrawRectangle(pen, rect);

            var bru = new SolidBrush(Color.FromArgb(50, Color.Lime));
            g.FillRectangle(bru, boundsPreview);
        }
        
        
    }
}

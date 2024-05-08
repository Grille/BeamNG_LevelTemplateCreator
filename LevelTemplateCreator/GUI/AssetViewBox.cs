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
    readonly List<Asset> _visibleItems;

    List<Asset> _itemsPtr;

    int _hiddenCount = 0;

    string? _filter = null;

    public string? Filter
    {
        get => _filter; set
        {
            _filter = value;
            ItemsChanged();
        }
    }

    public List<Asset> Items { get; }


    public int ItemHeight { get; set; }

    public int Position {  get; set; }

    public int MaxPosition => _itemsPtr.Count * ItemHeight;

    public int HoveredIndex { get; private set; }

    public VScrollBar ScrollBar { get; }

    public Action<Asset>? OnItemClick { get; set; }

    public AssetViewBox()
    {
        Items = new List<Asset>();
        _visibleItems = new List<Asset>();

        _itemsPtr = Items;

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
        if (string.IsNullOrEmpty(_filter))
        {
            _itemsPtr = Items;
            _hiddenCount = 0;
        }
        else
        {
            var filter = _filter.ToLower();

            _visibleItems.Clear();

            foreach (var item in Items)
            {
                if (item.DisplayName.ToLower().Contains(_filter.ToLower()))
                {
                    _visibleItems.Add(item);
                }
            }

            _hiddenCount = Items.Count - _visibleItems.Count;
            _itemsPtr = _visibleItems;
        }

        ScrollBar.Maximum = MaxPosition + ScrollBar.LargeChange - 1;
        Items.Sort((x, y) => x.DisplayName.CompareTo(y.DisplayName));


        Invalidate();
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

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (HoveredIndex < 0)
            return;

        if (HoveredIndex > _itemsPtr.Count - 1)
            return;

        if (OnItemClick == null)
            return;

        OnItemClick(_itemsPtr[HoveredIndex]);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        int index = (e.Location.Y + Position) / ItemHeight;

        if (HoveredIndex != index)
        {
            HoveredIndex = index;
            Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        HoveredIndex = -1;

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;

        int pos = 0;
        for (var i = 0; i < _itemsPtr.Count; i++)
        {
            var asset = _itemsPtr[i];
            DrawItem(g, asset, i, pos++);
        }

        DrawHidden(g);
    }

    Rectangle GetBounds(int index)
    {
        return new Rectangle(0, ItemHeight * index - Position, ClientSize.Width, ItemHeight);
    }

    void DrawItem(Graphics g, Asset item, int index, int position)
    {
        var bounds = GetBounds(position);

        if (bounds.Y + bounds.Height < 0)
            return;

        if (bounds.Y > ClientSize.Height)
            return;

        var brush = new SolidBrush(Color.Black);

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
        if (!string.IsNullOrEmpty(item.DisplayName))
        {
            sb.AppendLine(item.DisplayName);
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

    void DrawHidden(Graphics g)
    {
        if (_hiddenCount == 0)
            return;

        var bounds = GetBounds(_itemsPtr.Count);

        var brush = new SolidBrush(Color.Black);

        g.DrawString($"{_hiddenCount} items hidden...", Font, brush, bounds);
    }
}

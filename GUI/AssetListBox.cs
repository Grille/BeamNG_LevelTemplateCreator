using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LevelTemplateCreator.Assets;

namespace LevelTemplateCreator;

public partial class AssetListBox : ListBox
{
    public AssetListBox()
    {

    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        var brush = new SolidBrush(e.ForeColor);
        base.OnDrawItem(e);
        var g = e.Graphics;

        if (e.Index >= Items.Count || e.Index < 0)
        {
            return;
        }

        var item = (Asset)Items[e.Index];

        var bounds = e.Bounds;

        var boundsPreview = new Rectangle(bounds.X, bounds.Y, bounds.Height, bounds.Height);

        var boundsText = new Rectangle(bounds.Height, bounds.Y, bounds.Width - bounds.Height, bounds.Height);

        Brush backcolor = e.Index % 2 == 0 ? Brushes.White : Brushes.Lavender;

        if (e.State.HasFlag(DrawItemState.Selected))
        {
            backcolor = Brushes.LightBlue;
        }

        g.FillRectangle(backcolor, bounds);

        if (item.Preview != null)
        {
            g.DrawImage(item.Preview, boundsPreview);
        }
        else
        {
            g.FillRectangle(Brushes.DarkGray, boundsPreview);
        }



        

        g.DrawString(item.Name, e.Font, brush, boundsText);





    }
}

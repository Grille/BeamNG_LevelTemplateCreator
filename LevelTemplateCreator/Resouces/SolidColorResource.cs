﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Grille.BeamNG.IO.Resources;

namespace LevelTemplateCreator.IO.Resources;

public class SolidColorResource : Resource
{
    public byte[] Bytes { get; }

    public SolidColorResource(string name, int color, int size = 1024) : base(name, false)
    {
        const int mask = -16777216;

        using var stream = new MemoryStream();
        {
            using var bitmap = new Bitmap(size, size, PixelFormat.Format24bppRgb);
            using var g = Graphics.FromImage(bitmap);
            var brush = new SolidBrush(Color.FromArgb(color | mask));
            g.FillRectangle(brush, 0, 0, size, size);
            bitmap.Save(stream, ImageFormat.Png);
        }
        Bytes = stream.ToArray();
    }

    protected override bool TryOpen(out Stream stream, bool canThrow)
    {
        stream = new MemoryStream(Bytes, false);
        return true;
    }
}

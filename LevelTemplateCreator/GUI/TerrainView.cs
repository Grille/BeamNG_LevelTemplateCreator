using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grille.BeamNG;
using Grille.Graphics.Isometric.Numerics;
using Grille.Graphics.Isometric.Buffers;
using Grille.Graphics.Isometric.WinForms;
using Grille.Graphics.Isometric.Shading;
using System.Numerics;
using Grille.Graphics.Isometric.Diagnostics;

namespace LevelTemplateCreator.GUI;

internal class TerrainView : RenderSurface
{
    NativeBuffer<InputData> _input;
    readonly ARGBColor[] _colors;
    Task _normalsTask;

    public Terrain Canvas { get; }

    public TerrainMergerInputControl[] TerrainInputs { get; set; }

    public bool BoundingsEnabled { get; set; }

    Profiler BufferProfiler { get; }

    public unsafe void UpdateBuffer()
    {
        BufferProfiler.Begin();

        var terrain = Canvas;

        NativeBuffer<InputData> buffer = _input;
        bool dispose = false;

        if (_input.Width != terrain.Width || _input.Height != terrain.Height)
        {
            dispose = true;
            buffer = new NativeBuffer<InputData>(terrain.Width, terrain.Height);
        }

        var hole = new ARGBColor(0, 0, 0);

        int length = buffer.Length;
        for (int i = 0; i < length; i++)
        {
            var src = terrain.Data[i];
            buffer[i].Height = (ushort)Math.Min(src.Height * ushort.MaxValue, ushort.MaxValue);
            if (src.IsHole)
                buffer[i].Color = hole;
            else
                buffer[i].Color = _colors[src.Material];
        }

        Renderer.SetInput(buffer, false);

        buffer.CalculateNormals();
        InvalidateRender();

        if (dispose)
        {
            _input.Dispose();
            _input = buffer;
        }

        BufferProfiler.End();
    }

    public void SetMaxHeight(float maxHeight)
    {
        if (Renderer.MaxHeight == (int)maxHeight)
            return;

        Renderer.Uniforms.ZScale = maxHeight / (float)ushort.MaxValue;
        Renderer.MaxHeight = (int)maxHeight;
        InvalidateRender();
    }

    static ARGBColor[] GetColors()
    {
        var rnd = new Random(1);
        var colors = new ARGBColor[256];

        float NextSingle() => (float)rnd.NextDouble() + 0.2f;

        ARGBColor Next()
        {
            var vec4 = new Vector4(NextSingle(), NextSingle(), NextSingle(), 0.5f);
            var vec4n = Vector4.Normalize(vec4);
            return new ARGBColor((byte)(vec4n.X * 255), (byte)(vec4n.Y * 255), (byte)(vec4n.Z * 255));
        }

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Next();
        }

        return colors;
    }

    public TerrainView() : base()
    {

        _colors = GetColors();
        _input = new NativeBuffer<InputData>(10, 10);
        Renderer.SetInput(_input);
        Renderer.Shader = new ShaderProgram(Shaders.DynamicShading);
        TerrainInputs = Array.Empty<TerrainMergerInputControl>();
        Canvas = new Terrain();
        BufferProfiler = new();

        _normalsTask = Task.CompletedTask;
    }

    IEnumerable<TerrainMergerInputControl> EnumerateInputs()
    {
        if (!DrawBoundings)
            yield break;

        foreach (var input in TerrainInputs)
        {
            if (!input.InputEnabled)
                continue;

            yield return input;
        }

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        GdiRenderer.UseGraphics(e.Graphics);


        foreach (var input in EnumerateInputs())
        {
            float offset = Canvas.Size / 2f;

            float maxHeight = (float)input.MaxHeightNumeric.Value;
            float x = (float)input.OffsetXNumeric.Value - offset;
            float y = (float)input.OffsetYNumeric.Value - offset;
            float size = (float)input.SizeNumeric.Value;

            var begin = new Vector3(x, y, 0);
            var end = new Vector3(x + size, y + size, maxHeight);

            GdiRenderer.DrawBoundings(begin, end);
        }

        var info = GdiRenderer.Info;
        info.AppendLine($"Buffer Update");
        info.AppendLine($"  {BufferProfiler.FrameTime:F2}ms");
        info.AppendLine();

        base.OnPaint(e);

        foreach (var input in EnumerateInputs())
        {
            float offset = Canvas.Size / 2f;
            float x = (float)input.OffsetXNumeric.Value - offset;
            float y = (float)input.OffsetYNumeric.Value - offset;

            var begin = new Vector3(x, y, 0);

            GdiRenderer.DrawCoords(begin);
            GdiRenderer.DrawText(input.InputTitle.Text, Brushes.White, begin);
        }
    }
}

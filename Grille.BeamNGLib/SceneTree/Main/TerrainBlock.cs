namespace Grille.BeamNgLib.SceneTree.Main;

public class TerrainBlock : SimItem
{
    public JsonDictProperty<string> MaterialTextureSet { get; }
    public JsonDictProperty<string> TerrainFile { get; }
    public JsonDictProperty<int> BaseTexSize { get; }
    public JsonDictProperty<float> MaxHeight { get; }
    public JsonDictProperty<float> SquareSize { get; }

    public TerrainBlock(JsonDict dict) : base(dict)
    {
        MaterialTextureSet = new(this, "materialTextureSet");
        TerrainFile = new(this, "terrainFile");
        BaseTexSize = new(this, "baseTexSize");
        MaxHeight = new(this, "maxHeight");
        SquareSize = new(this, "squareSize");

        Name.Value = "theTerrain";
        Class.Value = "TerrainBlock";
    }

    public TerrainBlock(TerrainInfo info) : this(new JsonDict())
    {
        int offset = (int)info.WorldSize / 2;
        Position.Value = new System.Numerics.Vector3(-offset, -offset, 0);
        MaxHeight.Value = info.MaxHeight;
        SquareSize.Value = info.SquareSize;
    }
}

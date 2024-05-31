using Grille.BeamNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.GUI;
public static class JsonFileDialog
{
    public const string Filter = "Json Files(*.Json)|*.json;|All files (*.*)|*.*";
    public const string Extension = "json";

    public static bool TryOpen(IWin32Window owner, out Terrain terrain)
    {
        terrain = new Terrain(0);

        using var dialog = new OpenFileDialog();
        dialog.Filter = Filter;
        dialog.AddExtension = true;
        dialog.DefaultExt = "json";
        if (dialog.ShowDialog(owner) == DialogResult.OK)
        {
            terrain.Load(dialog.FileName);
            return true;
        }

        return false;
    }

    public static bool TrySave(IWin32Window owner, Terrain terrain)
    {
        using var dialog = new SaveFileDialog();
        dialog.Filter = Filter;
        if (dialog.ShowDialog(owner) == DialogResult.OK)
        {
            terrain.Save(dialog.FileName);
            return true;
        }
        return false;
    }
}

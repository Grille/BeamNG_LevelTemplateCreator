using LevelTemplateCreator.GUI;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

public partial class AssetLibaryLoader
{
    internal class CfgScriptEvaluator
    {
        Asset? usedAsset;

        public AssetLibaryLoader Loader { get; }

        public AssetLibary Libary { get; }

        Asset UsedAsset
        {
            get
            {
                if (usedAsset == null)
                    throw new InvalidOperationException($"No asset used.");

                return usedAsset;
            }
        }

        public CfgScriptEvaluator(AssetLibaryLoader loader)
        {
            Loader = loader;
            Libary = loader.Libary;
        }

        public void Evaluate(CfgScript cfg)
        {
            foreach (var entry in cfg.Entries)
            {
                var key = entry.Key;
                var args = entry.Args;

                try
                {
                    EvalLine(key, args);
                }
                catch (Exception e)
                {
                    Loader.LogException(e);
                }
            }
        }

        void EvalLine(string key, string[] args)
        {
            if (key == "var")
            {
                var name = args[0];
                var value = args[1];
                SetVariable(name, value);
            }
            else if (key == "return")
            {
                return;
            }
            else if (key == "include")
            {
                var include = args[0];
                Loader.Include(include);
            }
            else if (key == "Using")
            {
                var assetkey = Loader.CurrentNamespace + args[0];
                var obj = Libary.Get(assetkey);
                usedAsset = obj;
                if (obj == null)
                {
                    throw new KeyNotFoundException($"Could not find asset {assetkey}.");
                }
            }
            else if (key == "Preview")
            {
                var ppath = args[0];
                UsedAsset.LoadPreview(ppath);
            }
            else if (key == "SquareSize")
            {
                var squareSize = float.Parse(Eval(args[0]));
                ((TerrainMaterialAsset)UsedAsset).SquareSize = squareSize;
            }
            else if (key == "Export.Terrain_Materials")
            {
                TexturePackPrimer.Open(Libary, Loader.CurrentNamespace);
            }
            else if (key == "Set")
            {
                if (args.Length != 2)
                    throw new InvalidOperationException("Set() takes 2 arguments.");

                var jkey = args[0];
                var jvalue = args[1];
                UsedAsset.Object.Dict[jkey] = jvalue;
            }
            else
            {
                throw new InvalidOperationException($"Unknown command {key}().");
            }
        }

        string Eval(string var)
        {
            if (var.StartsWith('$'))
            {
                var key = '$' + Loader.CurrentNamespace + var.Substring(1);
                return Eval(Variables.Get(key));
            }
            return var;
        }

        public void SetVariable(string key, string value)
        {
            Variables.Set('$' + Loader.CurrentNamespace + key, value);
        }
    }
}

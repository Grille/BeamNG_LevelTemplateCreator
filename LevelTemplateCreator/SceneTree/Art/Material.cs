﻿using LevelTemplateCreator.Assets;
using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal abstract class Material : JsonDictWrapper
{
    protected Material(JsonDict dict) : base(dict)
    {

    }

    public abstract void ResolveTexturePaths(MaterialLibary libary, AssetInfo info);

    public override abstract Material Copy();
}

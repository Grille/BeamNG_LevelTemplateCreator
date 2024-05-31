using Grille.BeamNG.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

public class AssetCollection<T> : KeyedCollection<T> where T : Asset { }

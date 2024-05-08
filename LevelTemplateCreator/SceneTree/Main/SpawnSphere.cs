using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class SpawnSphere : SimItem
{
    public JsonDictProperty<string> DataBlock { get; }

    public SpawnSphere(JsonDict dict) : base(dict)
    {
        DataBlock = new(this, "dataBlock");
    }

    public SpawnSphere(float height) : this(new JsonDict())
    {
        Name.Value = "spawn_default";
        Class.Value = "SpawnSphere";
        DataBlock.Value = "SpawnSphereMarker";
        Position.Value = new System.Numerics.Vector3(0, 0, height);
    }

    /*
    "name": "spawn_default",
    "class": "SpawnSphere",
    "position": [
        0,
        0,
        0
    ],
    "autoplaceOnSpawn": "0",
    "dataBlock": "SpawnSphereMarker",
    "enabled": "1",
    "homingCount": "0",
    "indoorWeight": "1",
    "isAIControlled": "0",
    "lockCount": "0",
    "outdoorWeight": "1",
    "radius": 1,
    "rotationMatrix": [
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        1
    ],
    "sphereWeight": "1"
    */
}

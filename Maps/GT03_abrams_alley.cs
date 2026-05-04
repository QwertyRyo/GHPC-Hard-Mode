using GHPC;
using GHPC.Mission.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Hard_Mode
{
    public static class GT03_abrams_alley
    {
        public static List<SpawnEntry> Spawns() => new List<SpawnEntry>
        {
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(2039.431f, 82.4362f, -1950.396f),
                Rotation = Quaternion.Euler(0f, 270f, 0f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 1 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1226.373f, 69.8381f, -1607.632f),
                Rotation = Quaternion.Euler(0.9459f, 220.2668f, 3.4797f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 2 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1264.383f, 67.8381f, -1592.641f),
                Rotation = Quaternion.Euler(0f, 219.4734f, 2f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 3 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1586.989f, 37.2426f, -820.2175f),
                Rotation = Quaternion.Euler(359.6815f, 203.3798f, 359.7273f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 4 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1559.244f, 36.9282f, -811.1731f),
                Rotation = Quaternion.Euler(358.7519f, 191.9604f, 0.0392f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 5 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1442.101f, 54.0921f, -2247.204f),
                Rotation = Quaternion.Euler(0.0002f, 278.9434f, -0.0001f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 6 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(1442.854f, 57.3884f, -2219.696f),
                Rotation = Quaternion.Euler(0.0002f, 278.9434f, 9.8545f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 7 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T80B",
                Position = new Vector3(979.5067f, 81.6688f, -1582.236f),
                Rotation = Quaternion.Euler(5.7237f, 157.6201f, 0.7074f),
                Allegiance = Faction.Red,
                DisplayName = "T-80B 8 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "BMP2",
                Position = new Vector3(1928.377f, 51.0288f, -1121.505f),
                Rotation = Quaternion.Euler(354.9498f, 228.0831f, 355.9422f),
                Allegiance = Faction.Red,
                DisplayName = "BMP-2 1"
            },
            new SpawnEntry
            {
                PrefabName = "BMP2",
                Position = new Vector3(1941.994f, 51.4077f, -1135.152f),
                Rotation = Quaternion.Euler(356.4658f, 226.0959f, 359.8655f),
                Allegiance = Faction.Red,
                DisplayName = "BMP-2 2"
            },
            new SpawnEntry
            {
                PrefabName = "BMP2",
                Position = new Vector3(1887.6f, 47.7749f, -1104.829f),
                Rotation = Quaternion.Euler(0.4542f, 231.8899f, 353.8273f),
                Allegiance = Faction.Red,
                DisplayName = "BMP-2 3"
            }
        };
    }
}

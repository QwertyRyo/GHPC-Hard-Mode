using GHPC;
using GHPC.Mission.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Hard_Mode
{
    public static class GT03_patton_pass
    {
        public static List<SpawnEntry> Spawns() => new List<SpawnEntry>
        {
            new SpawnEntry
            {
                PrefabName = "T55A",
                Position = new Vector3(614.8817f, 55.1615f, 177.4814f),
                Rotation = Quaternion.Euler(1.6604f, 183.9117f, 0.9028f),
                Allegiance = Faction.Red,
                DisplayName = "T-55A 1 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T55A",
                Position = new Vector3(1058.597f, 51.0649f, 103.6629f),
                Rotation = Quaternion.Euler(359.8678f, 214.3342f, 0.3024f),
                Allegiance = Faction.Red,
                DisplayName = "T-55A 2 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T55A",
                Position = new Vector3(304.7652f, 69.3903f, -800.3547f),
                Rotation = Quaternion.Euler(356.1756f, 152.4979f, 358.6177f),
                Allegiance = Faction.Red,
                DisplayName = "T-55A 3 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-820.0128f, 71.0977f, -500.6957f),
                Rotation = Quaternion.Euler(0.3356f, 119.966f, 8.1891f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 1 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-1128.478f, 67.1751f, -503.628f),
                Rotation = Quaternion.Euler(358.796f, 115.5301f, 7.1416f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 2 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-1242.462f, 77.8024f, -652.0635f),
                Rotation = Quaternion.Euler(0.6436f, 112.6737f, 3.1814f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 3 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-2297.394f, 111.3439f, 137.0465f),
                Rotation = Quaternion.Euler(0.1808f, 139.8533f, 2.1187f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 4 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-2238.098f, 108.6313f, 160.2622f),
                Rotation = Quaternion.Euler(2.6449f, 133.9807f, 4.1793f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 5 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "T72M1",
                Position = new Vector3(-2254.222f, 123.2036f, 394.2121f),
                Rotation = Quaternion.Euler(359.0435f, 115.5051f, 0.0771f),
                Allegiance = Faction.Red,
                DisplayName = "T-72M1 6 Modded"
            },
            new SpawnEntry
            {
                PrefabName = "STATIC_9K111",
                Position = new Vector3(-150.9853f, 58.6319f, -153.2439f),
                Rotation = Quaternion.Euler(1.4287f, 169.7619f, 359.3453f),
                Allegiance = Faction.Red,
                DisplayName = "STATIC_9K111"
            },  
            new SpawnEntry
            {
                PrefabName = "STATIC_9K111",
                Position = new Vector3(-812.4919f, 72.0769f, -514.4508f),
                Rotation = Quaternion.Euler(358.3652f, 131.8527f, 357.6022f),
                Allegiance = Faction.Red,
                DisplayName = "STATIC_9K111"
            },
        };
    }
}

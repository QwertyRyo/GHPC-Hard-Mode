using GHPC;
using GHPC.Mission.Data;
using UnityEngine;

namespace Hard_Mode
{
    public struct SpawnEntry
    {
        public string PrefabName;
        public Vector3 Position;
        public Quaternion Rotation;
        public Faction Allegiance;
        public string DisplayName;
    }
}

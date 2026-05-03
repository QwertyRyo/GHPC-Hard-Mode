using GHPC;
using GHPC.Camera;
using GHPC.Mission;
using GHPC.Mission.Data;
using GHPC.Player;
using GHPC.State;
using GHPC.Vehicle;
using HarderMaps;
using HarmonyLib;
using MelonLoader;
using System.Collections;
using System.Linq;
using UnityEngine;
using GHPC.Effects.Voices;

[assembly: MelonInfo(typeof(GMPC), "Harder Maps", "1.0.0", "Qwertyryo")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace HarderMaps
{
    public class GMPC : MelonMod
    {
        public override void OnInitializeMelon()
        {
            HarmonyInstance.PatchAll();
        }
      
        private bool _done = false;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded scene {sceneName}, trying to patch game...");

            if (sceneName != "GT03_abrams_alley") return;

            _done = false;
            StateController.RunOrDefer(
                GameState.GameReady,
                new GameStateEventHandler(OnGameReady),
                GameStatePriority.Medium
            );
        }

        private IEnumerator OnGameReady(GameState _)
{
    if (_done) yield break;
    _done = true;

    /*
    var allPrefabNames = UnitSpawner.Instance.PrefabLookup.AllUnits.Select(u => u.Name);
    LoggerInstance.Msg("Available prefabs: " + string.Join(", ", allPrefabNames));
    Available prefabs: M60A3TTS, T55A, T72M1, M2BRADLEY, M2BRADLEY(ALT), M901, M113, M113G, M151M232, M151, BRDM2, UAZ469, STATIC_TOW, STATIC_9K111, STATIC_SPG9, STATIC_SPG9_SA, T3485, TC, BMP1, URAL375D, M923, BMP2, LEO1A1, LEO1A1A2, LEO1A1A3, LEO1A1A4, LEO1A3, LEO1A3A1, LEO1A3A2, LEO1A3A3, T62, T64R, T64A74, T64A79, T64A81, T64A, T64A84, T64B, T64B81, T64B1, T64B181, T72M, M60A1RISEP, M60A1RISEP77, M60A1, M60A1AOS, M60A3, M1, M1IP, T72GILLS, T72UV1, T72UV2, T72ULEM, T72, SquadUnit_US_PASGT, SquadUnit_GDR, BMP1P, BMP1P_SA, STATIC_9K111_SA, BMP1_SA, BMP2_SA, BRDM2_SA, BTR60PB, BTR60PB_SA, URAL375D_SA, PT76B, T80B, T54A, BTR70, AH1, MI2, Mi8T, Mi24, Mi24V_SA, OH58A, Mi24V_NVA, STATIC_SPG9_TRENCH, STATIC_SPG9_SA_TRENCH, STATIC_9K111_TRENCH, STATIC_9K111_SA_TRENCH, STATIC_TOW_TRENCH, AH1_rockets, Mi24_rockets, Mi24V_SA_rockets, Mi24V_NVA_rockets, RTS_CAMERA, MARDERA1, MARDERA1_NO_ATGM, MARDERA1PLUS, MARDER1A2
    */

    var t80b = Resources.FindObjectsOfTypeAll<GameObject>()
        .FirstOrDefault(o => o.name == "T80B");

    if (t80b == null)
    {
        LoggerInstance.Error("T80B prefab not found");
        yield break;
    }

    var unit = UnitSpawner.Instance.SpawnUnit(
        t80b,
        new GHPC.Mission.Data.UnitMetaData()
        {
            Allegiance = Faction.Red,
            Position = new Vector3(2047.665f, 82.4362f, -1950.396f),
            Rotation = Quaternion.Euler(0f, 270f, 0f),
            Name = "T-80B (MODDED)"
        }
    );
if (unit != null)
{
    LoggerInstance.Msg("T-80B spawned via UnitSpawner");

    unit.Targetable = true;

    var spawnedUnit = unit as Unit;
    if (spawnedUnit != null)
    {
        spawnedUnit.Targetable = true;

        var infoBroker = spawnedUnit.GetComponentInChildren<UnitInfoBroker>(true);
        LoggerInstance.Msg($"InfoBroker: {infoBroker != null}");

    }

    var infoBrokerCheck = unit.transform.GetComponentInChildren<UnitInfoBroker>(true);
}


    yield break;
}

}
}

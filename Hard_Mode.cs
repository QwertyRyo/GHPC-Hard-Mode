using GHPC;
using GHPC.Effects.Voices;
using GHPC.Mission;
using GHPC.Mission.Data;
using GHPC.State;
using GHPC.Vehicle;
using Hard_Mode;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[assembly: MelonInfo(typeof(GMPC), "Hard Mode", "1.0.0", "Qwertyryo")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]
/*available prefabs: M60A3TTS, T55A, T72M1, M2BRADLEY, M2BRADLEY(ALT), M901, M113, M113G, M151M232, M151, BRDM2, UAZ469, STATIC_TOW, STATIC_9K111, STATIC_SPG9, STATIC_SPG9_SA, T3485, TC, BMP1, URAL375D, M923, BMP2, LEO1A1, LEO1A1A2, LEO1A1A3, LEO1A1A4, LEO1A3, LEO1A3A1, LEO1A3A2, LEO1A3A3, T62, T64R, T64A74, T64A79, T64A81, T64A, T64A84, T64B, T64B81, T64B1, T64B181, T72M, M60A1RISEP, M60A1RISEP77, M60A1, M60A1AOS, M60A3, M1, M1IP, T72GILLS, T72UV1, T72UV2, T72ULEM, T72, SquadUnit_US_PASGT, SquadUnit_GDR, BMP1P, BMP1P_SA, STATIC_9K111_SA, BMP1_SA, BMP2_SA, BRDM2_SA, BTR60PB, BTR60PB_SA, URAL375D_SA, PT76B, T80B, T54A, BTR70, AH1, MI2, Mi8T, Mi24, Mi24V_SA, OH58A, Mi24V_NVA, STATIC_SPG9_TRENCH, STATIC_SPG9_SA_TRENCH, STATIC_9K111_TRENCH, STATIC_9K111_SA_TRENCH, STATIC_TOW_TRENCH, AH1_rockets, Mi24_rockets, Mi24V_SA_rockets, Mi24V_NVA_rockets, RTS_CAMERA, MARDERA1, MARDERA1_NO_ATGM, MARDERA1PLUS, MARDER1A2*/
namespace Hard_Mode
{
    public class GMPC : MelonMod
    {
        private static readonly Dictionary<string, Func<List<SpawnEntry>>> _sceneSpawns =
            new Dictionary<string, Func<List<SpawnEntry>>>()
            {
                { "GT03_abrams_alley", GT03_abrams_alley.Spawns },
                { "GT03_patton_pass", GT03_patton_pass.Spawns }
            };

        public override void OnInitializeMelon()
        {
            HarmonyInstance.PatchAll();
        }

        private bool _done = false;
        private List<SpawnEntry> _pendingSpawns;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded scene {sceneName}, trying to patch game...");

            if (!_sceneSpawns.TryGetValue(sceneName, out var getSpawns)) return;

            _done = false;
            _pendingSpawns = getSpawns();
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

    var lookup = UnitSpawner.Instance.PrefabLookup;

    foreach (var entry in _pendingSpawns)
    {
        var meta = lookup.AllUnits.FirstOrDefault(u => u.Name == entry.PrefabName);

        if (meta == null)
        {
            LoggerInstance.Msg($"{entry.PrefabName} not found in unit lookup");
            continue;
        }

        // resolve the prefab
        GameObject prefab = null;
        if (meta.PrefabReference.Asset != null)
        {
            LoggerInstance.Msg("null asset else NOT ran");
            prefab = meta.PrefabReference.Asset as GameObject;
        }
        else
        {
            LoggerInstance.Msg("null asset else ran");
            var handle = meta.PrefabReference.LoadAssetAsync<GameObject>();
            yield return handle;
            prefab = handle.Result;
        }

        if (prefab == null)
        {
            LoggerInstance.Msg($"{entry.PrefabName} prefab failed to load");
            continue;
        }

        var unit = UnitSpawner.Instance.SpawnUnit(
            prefab,
            new UnitMetaData()
            {
                Allegiance = entry.Allegiance,
                Position = entry.Position,
                Rotation = entry.Rotation,
                Name = entry.DisplayName
            }
        );

        if (unit == null)
        {
            LoggerInstance.Error($"Failed to spawn {entry.DisplayName}");
            continue;
        }

        unit.Targetable = true;
        LoggerInstance.Msg($"{entry.DisplayName} spawned successfully");
    }

    yield break;
}
/*
        private IEnumerator OnGameReady(GameState _)
        {
            if (_done) yield break;
            _done = true;

            var allPrefabNames = UnitSpawner.Instance.PrefabLookup.AllUnits.Select(u => u.Name);
            LoggerInstance.Msg("Available prefabs: " + string.Join(", ", allPrefabNames));
            var lookup = UnitSpawner.Instance.PrefabLookup;
            var meta = lookup.AllUnits.FirstOrDefault(u => u.Name == "BMP2_SA");

            if (meta == null)
            {
                LoggerInstance.Error("BMP2_SA not found in unit lookup");
                yield break;
            }
            GameObject prefab_bmp2 = null;
    if (meta.PrefabReference.Asset != null)
    {
        prefab_bmp2 = meta.PrefabReference.Asset as GameObject;
    }
    else
    {
        var handle = meta.PrefabReference.LoadAssetAsync<GameObject>();
        yield return handle;
        prefab_bmp2 = handle.Result;
    }

    if (prefab_bmp2 == null)
    {
        LoggerInstance.Error("BMP2_SA prefab failed to load");
        yield break;
    }

    LoggerInstance.Msg($"BMP2_SA prefab loaded: {prefab_bmp2.name}");

            foreach (var entry in _pendingSpawns)
            {
                var prefab = Resources.FindObjectsOfTypeAll<GameObject>()
                    .FirstOrDefault(o => o.name == entry.PrefabName);

                if (prefab == null)
                {
                    LoggerInstance.Error($"{entry.PrefabName} prefab not found");
                    continue;
                }

                var unit = UnitSpawner.Instance.SpawnUnit(
                    prefab,
                    new UnitMetaData()
                    {
                        Allegiance = entry.Allegiance,
                        Position = entry.Position,
                        Rotation = entry.Rotation,
                        Name = entry.DisplayName
                    }
                );

                if (unit == null)
                {
                    LoggerInstance.Error($"Failed to spawn {entry.DisplayName}");
                    continue;
                }

                //LoggerInstance.Msg($"{entry.DisplayName} spawned via UnitSpawner");
                unit.Targetable = true;

                if (unit is Unit spawnedUnit)
                {
                    spawnedUnit.Targetable = true;
                    var infoBroker = spawnedUnit.GetComponentInChildren<UnitInfoBroker>(true);
                    //LoggerInstance.Msg($"InfoBroker: {infoBroker != null}");
                }
            }

            yield break;
        }
    */
    }
}

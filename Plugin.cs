using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using Receiver2;
using UnityEngine;
using System.Collections;
using System.Linq;
using System;

namespace MagLoaderThing
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private static ConfigEntry<bool> magloader_enabled;
        private static GameObject shooting_range_magloader;
        private static GameObject challenge_dome_magloader;

        private void Awake() {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            magloader_enabled = Config.Bind("Magloader settings", "Enable the magloader", true, "Should the magloader appear in the Compound");

			magloader_enabled.SettingChanged += (object sender, EventArgs args) => {
				if (shooting_range_magloader != null) shooting_range_magloader.SetActive(magloader_enabled.Value);
				if (challenge_dome_magloader != null) challenge_dome_magloader.SetActive(magloader_enabled.Value);

				Debug.Log("Enabled");
			};

            Harmony.CreateAndPatchAll(this.GetType());
        }

        [HarmonyPatch(typeof(ReceiverCoreScript), "SpawnPlayer")]
        [HarmonyPostfix]
        private static void OnStartCompound() {
            if (ReceiverCoreScript.Instance().game_mode.GetGameMode() != GameMode.ReceiverMall) return;

            shooting_range_magloader = GameObject.Find("/Shooting Range/Gameplay/Ammo Tables/MagazineLoader");
			if (shooting_range_magloader != null) {
				shooting_range_magloader.SetActive(magloader_enabled.Value);

				DestroyImmediate(shooting_range_magloader.transform.Find("collider").GetComponent<MagazineLoader>());
				shooting_range_magloader.transform.Find("collider").gameObject.AddComponent<AutomaticMagLoader>();
			}

            challenge_dome_magloader = GameObject.Find("/Challenge Room/Challenge Room Geometry/AmmoTable/MagazineLoader");
			if (challenge_dome_magloader != null) {
				challenge_dome_magloader.SetActive(magloader_enabled.Value);

				DestroyImmediate(challenge_dome_magloader.transform.Find("collider").GetComponent<MagazineLoader>());
				challenge_dome_magloader.transform.Find("collider").gameObject.AddComponent<AutomaticMagLoader>();
			}
		}
    }
}

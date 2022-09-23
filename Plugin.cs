using BepInEx;
using BepInEx.Configuration;
using Receiver2;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using System;

namespace MagLoaderThing
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, "1.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> enable_key;
        public bool plugin_done = false;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            enable_key = Config.Bind("Manual Activation", "Activate manually, (if true, uses Ending Mistake key)", false, "this is the key to enable the mag loaders");
        }
        public GameObject ammoBox1;
        public GameObject ammoBox2;
        internal void Update()
        {
            /*string ebable_bey = enable_key.ToString();
            //LOSING MYT FUCKING MINd!!!!!!!!!!!!!
            if (Input.GetKeyDown("b"))
            {
                Debug.Log(ebable_bey);
            }
            // i will fucking kill you if you don't work */
            LocalAimHandler lah = LocalAimHandler.player_instance;
            Scene scene = SceneManager.GetActiveScene();
            if (Input.GetKeyDown("b"))
            {
                Debug.Log(scene.name);
            }
            if (scene.name == "ReceiverMall")
            {
                if (plugin_done == false)
                {
                    if (enable_key.Value == true)
                    {
                        if (lah.character_input.GetButtonUp(73))
                        {
                            ammoBox1 = GameObject.Find("/Challenge Room/Challenge Room Geometry/AmmoTable/MagazineLoader");
                            ammoBox2 = GameObject.Find("/Shooting Range/Gameplay/Ammo Tables/MagazineLoader");
                            ammoBox1.SetActive(true);
                            ammoBox2.SetActive(true);
                            Debug.Log("yep it should've worked");
                            plugin_done = true;
                        }
                    }
                    else if (enable_key.Value == false)
                    {
                        ammoBox1 = GameObject.Find("/Challenge Room/Challenge Room Geometry/AmmoTable/MagazineLoader");
                        ammoBox2 = GameObject.Find("/Shooting Range/Gameplay/Ammo Tables/MagazineLoader");
                        ammoBox1.SetActive(true);
                        ammoBox2.SetActive(true);
                        Debug.Log("yep it should've worked");
                        plugin_done = true;
                    }
                }
            }
            else
            {
                plugin_done=false;
            }
        }
    }
}

using BepInEx;
using BepInEx.Configuration;
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
        //public static ConfigEntry<string> enable_key;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            instance = this;

            //enable_key = Config.Bind("Key config", "chosen key", "m", "this is the key to enable the mag loaders");
        }
        static Plugin instance;
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
            if (Input.GetKeyDown("b"))
            {
                ammoBox1 = GameObject.Find("/Challenge Room/Challenge Room Geometry/AmmoTable/MagazineLoader");
                ammoBox2 = GameObject.Find("/Shooting Range/Gameplay/Ammo Tables/MagazineLoader");
                ammoBox1.SetActive(true);
                ammoBox2.SetActive(true);
                Debug.Log("yep it should've worked");
            }
        }
    }
}

using BepInEx;
using MonkeBadges.Utils;
using System;
using UnityEngine;

namespace MonkeBadges
{
    [BepInDependency("org.legoandmars.gorillatag.utilla")]
    [BepInPlugin(PROJECT, NAME, VERSION)]
    internal class Plugin : BaseUnityPlugin
    {
        GameObject BadgesBundle;

        const string
            PROJECT = "chin.monkebadges",
            NAME = "Monke Badges",
            VERSION = "1.0.0";

        void Awake()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            AssetbundleLoading.LoadBundle(BadgesBundle);
        }
    }
}
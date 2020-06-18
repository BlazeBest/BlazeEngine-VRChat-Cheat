using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Addons.Mods
{
    internal static class NoLocalPickup
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Hide Pickup", !BlazeManager.GetForPlayer<bool>("Hide Pickup"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Hide Pickup");
            BlazeManagerMenu.Main.togglerList["Hide Pickup"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Hide Pickup"].btnOff.SetActive(!toggle);
            Update();
        }

        internal static void Update()
        {
            ScanObjects();
            if (BlazeManager.GetForPlayer<bool>("Hide Pickup"))
            {
                HideAllObjects();
            }
            else
            {
                ShowAllObjects();
            }
        }

        private static void ScanObjects()
        {

            foreach (var obj in UnityEngine.Object.FindObjectsOfType<VRCSDK2.VRC_Pickup>())
            {
                GameObject gameObject = obj.gameObject;
                if (!gameObjects.Contains(gameObject) && gameObject.active)
                    gameObjects.Add(gameObject);
            }
            foreach (var obj in UnityEngine.Object.FindObjectsOfType<VRC.SDK3.Components.VRCPickup>())
            {
                GameObject gameObject = obj.gameObject;
                if (!gameObjects.Contains(gameObject) && gameObject.active)
                    gameObjects.Add(gameObject);
            }
        }

        internal static void ClearObjects() => gameObjects.Clear();

        internal static void HideAllObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
        }

        internal static void ShowAllObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(true);
            }
        }

        private static List<GameObject> gameObjects = new List<GameObject>();
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using VRCSDK2;
using BlazeIL;

namespace Addons
{
    public static class UserUtils
    {
        #region TeleportTo
        public static void TeleportTo(VRC.Player player) => TeleportTo(player.transform);
        public static void TeleportTo(GameObject gameObject) => TeleportTo(gameObject.transform);
        public static void TeleportTo(Transform transform) => TeleportTo(transform.position);
        public static void TeleportTo(Vector3 position) => VRC.Player.Instance.transform.position = position;
        #endregion

        #region SpawnPortal
        public static GameObject SpawnPortal(Vector3 Position)
        {
            GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", Position, new Quaternion(0, 0, 0, 0));
            if (gameObject == null)
                return null;

            VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
            {
                IL2Import.StringToIntPtr("wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde"),
                IL2Import.il2cpp_string_new_len("Banned Instance\nTupper\0", "Banned Instance\nTupper\0".Length),
                IL2Import.CreateNewObject(0, BlazeTools.IL2SystemClass.Int32)
            });

            return gameObject;
        }
        #endregion CreatePortal

        public static void RemoveInstiatorObjects()
        {
            foreach(var obj in UnityEngine.Object.FindObjectsOfType<ObjectInstantiatorHandle>())
                obj.gameObject.Destroy();
        }

        public static List<string> Menu_AvatarsList = new List<string>();
    }
}

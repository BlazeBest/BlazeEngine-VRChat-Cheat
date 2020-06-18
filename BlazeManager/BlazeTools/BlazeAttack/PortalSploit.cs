using System;
using System.Runtime.ExceptionServices;
using UnityEngine;
using Addons;
using VRCSDK2;
using BlazeIL;

namespace BlazeAttack
{
    public class PortalSploit
    {
        [HandleProcessCorruptedStateExceptions]
        public static void Start()
        {
            try
            {
                VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
                /*
                Vector3 position = VRC.Player.Instance.transform.position;
                GameObject gameObject = UserUtils.SpawnPortal(position);
                if (gameObject == null)
                    return;

                PortalInternal portalInternal = gameObject.GetComponent<PortalInternal>();
                if (portalInternal == null)
                    return;

                portalInternal.Destroy();
                */
            }
            catch { }
        }
        public static void Test(GameObject gameObject)
        {
            try
            {
                VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "initUSpeakSenderRPC", new IntPtr[]
                {
                    IL2Import.CreateNewObject(rand.Next(0, 25), BlazeTools.IL2SystemClass.Int32)
                });
            }
            catch { }
        }

        private static Random rand = new Random();
    }
}

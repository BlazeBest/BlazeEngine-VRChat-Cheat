using System;
using System.Reflection;
using ExitGames.Client.Photon;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_PhotonSerilize
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Photon Serilize", !BlazeManager.GetForPlayer<bool>("Photon Serilize"));
            RefreshStatus();
        }
        
        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Photon Serilize");
            BlazeManagerMenu.Main.togglerList["Photon Serilize"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Photon Serilize"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["Photon3Unity3D"].GetClass("EnetPeer", "ExitGames.Client.Photon").GetMethod("EnqueueOperation");
                if (method == null)
                    throw new Exception();

                pPhotonPeer = IL2Ch.Patch(method, typeof(patch_PhotonSerilize).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: Photon Serilize");

            }
            catch
            {
                ConSole.Error("Patch: Photon Serilize");
            }
        }

        private static IntPtr patch_method(IntPtr __self, IntPtr parameters, byte opCode, SendOptions sendParams, EgMessageType messageType = EgMessageType.Operation)
        {
            /*
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.P))
            {
                VRC.UI.PageWorldInfo pageWorldInfo = UnityEngine.Object.FindObjectsOfType<VRC.UI.PageWorldInfo>()[0];
                Console.WriteLine(pageWorldInfo.apiWorld.id);
            }
            */
            /*
            Console.WriteLine("------------------------------");
            Console.WriteLine("opCode: " + opCode.ToString());
            Console.WriteLine("sendParams [channel]: " + sendParams.Channel.ToString());
            Console.WriteLine("sendParams [DeliveryMode]: " + sendParams.DeliveryMode.ToString());
            Console.WriteLine("sendParams [Encrypt]: " + sendParams.Encrypt.ToString());
            Console.WriteLine("messageType: " + messageType.ToString());
            */

            if (BlazeManager.GetForPlayer<bool>("Photon Serilize"))
            {
                if (sendParams.DeliveryMode == DeliveryMode.UnreliableUnsequenced && sendParams.Channel != 1)
                    return true.Cast();
            }

            return (pPhotonPeer.InvokeOriginal(__self, new IntPtr[] { parameters, new IntPtr(opCode), sendParams.Cast(), new IntPtr((int)messageType) }) != null).Cast();
        }

        public static IL2Patch pPhotonPeer;
    }
}

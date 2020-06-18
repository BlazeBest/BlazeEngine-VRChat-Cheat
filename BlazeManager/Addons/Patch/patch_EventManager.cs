using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRC.SDKBase;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_EventManager
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("RPC Block", !BlazeManager.GetForPlayer<bool>("RPC Block"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("RPC Block");
            BlazeManagerMenu.Main.togglerList["RPC Block"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["RPC Block"].btnOff.SetActive(!toggle);
        }


        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventDispatcherRFC").GetMethod("TriggerEvent");

                if (method == null)
                    new Exception();

                pTriggerEvent = IL2Ch.Patch(method, typeof(patch_EventManager).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: EventManager");

            }
            catch
            {
                ConSole.Error("Patch: EventManager");
            }
            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("RoomManagerBase").GetMethod("OnConnectedToMaster");

                if (method == null)
                    new Exception();

                pOnConnectToMaster = IL2Ch.Patch(method, typeof(patch_EventManager).GetMethod("patch_method2", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: EventManager [JoinRoom]");

            }
            catch
            {
                ConSole.Error("Patch: EventManager [JoinRoom]");
            }
        }

        // TriggerEvent
        //  (VRC_EventHandler handler,
        //   VRC_EventHandler.VrcEvent e,
        //   VRC_EventHandler.VrcBroadcastType broadcast,
        //   int instagatorId,
        //   float fastForward);
        private static void patch_method(IntPtr instance, IntPtr handler, IntPtr e, IntPtr broadcast, IntPtr instagatorId, IntPtr fastForward)
        {
            if (instance == IntPtr.Zero)
                return;
            
            var eVent = new VRC_EventHandler.VrcEvent(e);
            string paramet = eVent.ParameterString;

            if (BlazeManager.GetForPlayer<bool>("RPC Block"))
            {
                if (!whiteList.Contains(paramet))
                    return;
            }

            pTriggerEvent.InvokeOriginal(instance, new IntPtr[] { handler, e, broadcast, instagatorId, fastForward });

            if (BlazeManager.GetForPlayer<bool>("No Portal Spawn"))
            {
                if (paramet == "ConfigurePortal")
                {
                    UserUtils.RemoveInstiatorObjects();
                }
            }
        }

        private static void patch_method2(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            pOnConnectToMaster.InvokeOriginal(instance);
            Threads.bFirstThreadInRoom = false;
        }

        public static IL2Patch pTriggerEvent;
        public static IL2Patch pOnConnectToMaster;

        public static string[] whiteList = { "initUSpeakSenderRPC", "ReceiveVoiceStatsSyncRPC" };
    }
}

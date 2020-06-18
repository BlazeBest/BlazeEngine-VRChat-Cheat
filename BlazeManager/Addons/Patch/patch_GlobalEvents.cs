using System;
using System.Linq;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using VRCSDK2;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_GlobalEvents
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Global Events", !BlazeManager.GetForPlayer<bool>("Global Events"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Global Events");
            BlazeManagerMenu.Main.togglerList["Global Events"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Global Events"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = IL2Cmds.GetAssembly("VRCSDKBase").GetClass("VRC_EventHandler", "VRC.SDKBase").GetMethod("InternalTriggerEvent");
                if (method == null)
                    throw new Exception();

                pGlobalEvents = IL2Ch.Patch(method, typeof(patch_GlobalEvents).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: Global Events");
            }
            catch
            {
                ConSole.Error("Patch: Global Events");
            }
        }

        private static void patch_method(IntPtr instance, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, IntPtr instagatorId, IntPtr fastForward)
        {
            if (BlazeManager.GetForPlayer<bool>("Global Events"))
                broadcast = VRC_EventHandler.VrcBroadcastType.Always;

            pGlobalEvents.InvokeOriginal(instance, new IntPtr[] { e, new IntPtr((int)broadcast), instagatorId, fastForward });
        }

        public static IL2Patch pGlobalEvents;
    }
}

using System;
using System.Reflection;
using System.Linq;
using System.Text;
using BlazeTools;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;

namespace Addons.Patch
{
    public static class patch_NoPortal
    {
        public static void Toggle_Enable_Join()
        {
            BlazeManager.SetForPlayer("No Portal Join", !BlazeManager.GetForPlayer<bool>("No Portal Join"));
            RefreshStatusJoin();
        }
        public static void Toggle_Enable_Spawn()
        {
            BlazeManager.SetForPlayer("No Portal Spawn", !BlazeManager.GetForPlayer<bool>("No Portal Spawn"));
            RefreshStatusSpawn();
        }

        public static void RefreshStatusJoin()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("No Portal Join");
            BlazeManagerMenu.Main.togglerList["No Portal Join"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["No Portal Join"].btnOff.SetActive(!toggle);
        }

        public static void RefreshStatusSpawn()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("No Portal Spawn");
            BlazeManagerMenu.Main.togglerList["No Portal Spawn"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["No Portal Spawn"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = PortalTrigger.Instance_Class.GetMethod("OnTriggerEnter");
                if (method == null)
                    throw new Exception();

                pPortalJoin = IL2Ch.Patch(method, typeof(patch_NoPortal).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: No Portal Join");
            }
            catch
            {
                ConSole.Error("Patch: No Portal Join");
            }
        }

        private static void patch_method(IntPtr instance, IntPtr collider)
        {
            if (instance == IntPtr.Zero)
                return;

            if (BlazeManager.GetForPlayer<bool>("No Portal Join"))
                return;

            pPortalJoin.InvokeOriginal(instance, new IntPtr[] { collider });
        }

        public static IL2Patch pPortalJoin;

    }
}

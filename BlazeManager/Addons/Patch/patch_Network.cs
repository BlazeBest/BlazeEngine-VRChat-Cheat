using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using SharpDisasm;
using SharpDisasm.Udis86;
using System.Runtime.InteropServices;

namespace Addons.Patch
{
    public static class patch_Network
    {
        public static void Toggle_FastJoin()
        {
            BlazeManager.SetForPlayer("Fast Join", !BlazeManager.GetForPlayer<bool>("Fast Join"));
            RefreshStatus_FastJoin();
        }

        public static void Toggle_SteamSpoof()
        {
            BlazeManager.SetForPlayer("Steam Spoof", !BlazeManager.GetForPlayer<bool>("Steam Spoof"));
            RefreshStatus_SteamSpoof();
            VRCPlayer.Refresh_Properties();
        }

        public static void RefreshStatus_FastJoin()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Fast Join");
            BlazeManagerMenu.Main.togglerList["Fast Join"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Fast Join"].btnOff.SetActive(!toggle);
        }
        public static void RefreshStatus_SteamSpoof()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Steam Spoof");
            BlazeManagerMenu.Main.togglerList["Steam Spoof"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Steam Spoof"].btnOff.SetActive(!toggle);
        }


        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventLog").GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "System.Boolean" && x.GetGetMethod().HasFlag(IL2BindingFlags.METHOD_STATIC)).GetGetMethod();
                pPatch[2] = IL2Ch.Patch(method, typeof(patch_Network).GetMethod("patch_method3", BindingFlags.Static | BindingFlags.NonPublic));

                method = Assemblies.a["Assembly-CSharp"].GetClass("SteamNetworkingManager", "VRC.Steam").GetProperties().First(x => x.GetGetMethod().HasFlag(IL2BindingFlags.METHOD_STATIC) && x.GetGetMethod().GetReturnType().Name == "System.Boolean").GetGetMethod();
                pPatch[3] = IL2Ch.Patch(method, typeof(patch_Network).GetMethod("patch_method4", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: Network");
            }
        }

        private static IntPtr patch_method3()
        {
            if (BlazeManager.GetForPlayer<bool>("Fast Join"))
                return true.Cast();

            return (pPatch[2].InvokeOriginal() != null).Cast();
        }

        private static IntPtr patch_method4()
        {
            if (BlazeManager.GetForPlayer<bool>("Steam Spoof"))
                return false.Cast();

            return (pPatch[3].InvokeOriginal() != null).Cast();
        }


        public static IL2Patch[] pPatch = new IL2Patch[5];
    }
}

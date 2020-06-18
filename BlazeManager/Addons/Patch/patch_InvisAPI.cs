using System;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_InvisAPI
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Invis API", !BlazeManager.GetForPlayer<bool>("Invis API"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Invis API");
            BlazeManagerMenu.Main.togglerList["Invis API"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Invis API"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["VRCCore-Standalone"].GetClass("API", "VRC.Core").GetMethod("SendRequestInternal");
                if (method == null)
                    throw new Exception();

                pInvisMode = IL2Ch.Patch(method, typeof(patch_InvisAPI).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: InvisAPI");
            }
            catch
            {
                ConSole.Error("Patch: InvisAPI");
            }
        }

        private static void patch_method(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, IntPtr authenticationRequired, IntPtr disableCache, IntPtr cacheLifetime, IntPtr retryCount, IntPtr credentials)
        {
            string sEndpoint = IL2Import.IntPtrToString(endpoint);

            if ((sEndpoint == "visits" || sEndpoint == "joins" || (sEndpoint.StartsWith("avatars/avtr_") && sEndpoint.EndsWith("/select"))) && BlazeManager.GetForPlayer<bool>("Invis API"))
                return;

            pInvisMode.InvokeOriginal(IntPtr.Zero, new IntPtr[] {
                endpoint,
                method,
                responseContainer,
                requestParams,
                authenticationRequired,
                disableCache,
                cacheLifetime,
                retryCount,
                credentials
            });
        }

        public static IL2Patch pInvisMode;
    }
}

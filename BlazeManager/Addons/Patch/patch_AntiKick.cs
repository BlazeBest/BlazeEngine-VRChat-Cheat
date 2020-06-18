using System;
using System.Reflection;
using System.Linq;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine.Analytics;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_AntiKick
    {
        public static void Start()
        {
            IL2Method method;
            int iError = 0;

            // ~ Analytics [Count: 3]
            try
            {
                method = Assemblies.a["UnityEngine.UnityAnalyticsModule"].GetClass("Analytics", "UnityEngine.Analytics").GetMethods()
                    .Where(x => x.Name == "CustomEvent" && x.GetParameters().Length == 2)
                    .First(x => x.GetParameters()[1].Name == "eventData");
                pAnalytics[0] = IL2Ch.Patch(method, typeof(patch_AntiKick).GetMethod("patch_method_3", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [2]");
                iError++;
            }
            try
            {
                method = Assemblies.a["Assembly-CSharp"].GetClass("Analytics").GetMethods()
                .Where(x => x.GetReturnType().Name == "System.Void" && x.GetParameters().Length == 3)
                .Where(x => x.GetParameters()[0].typeName[0] == 'A')
                .First(x => x.HasFlag(IL2BindingFlags.METHOD_STATIC));
                pAnalytics[1] = IL2Ch.Patch(method, typeof(patch_AntiKick).GetMethod("patch_method_4", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [3]");
                iError++;
            }
            try
            {
                method = Assemblies.a["VRCCore-Standalone"].GetClass("AmplitudeWrapper", "AmplitudeSDKWrapper").GetMethod("CheckedLogEvent");
                pAnalytics[2] = IL2Ch.Patch(method, typeof(patch_AntiKick).GetMethod("patch_method_5", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [4]");
                iError++;
            }
            try
            {
                foreach (var m in Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager").GetMethods()
                    .Where(x => x.GetReturnType().Name == "System.Boolean" && x.GetParameters().Length == 0))
                    //.Where(x => x.HasFlag(IL2BindingFlags.METHOD_STATIC)))
                    IL2Ch.Patch(m, typeof(patch_AntiKick).GetMethod("patch_method_6", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [5]");
                iError++;
            }
            try
            {
                foreach (var m in Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager").GetMethods()
                    .Where(x => x.GetParameters().Length == 3)
                    .Where(x => IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "System.String")
                    .Where(x => IL2Import.il2cpp_type_get_name(x.GetParameters()[1].ptr) == "System.String")
                    .Where(x => IL2Import.il2cpp_type_get_name(x.GetParameters()[2].ptr) == "System.String"))
                    IL2Ch.Patch(m, typeof(patch_AntiKick).GetMethod("patch_method_7", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [6]");
                iError++;
            }
            try
            {
                method = Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager").GetMethod("KickUserRPC");
                IL2Ch.Patch(method, typeof(patch_AntiKick).GetMethod("patch_method_5", BindingFlags.Static | BindingFlags.NonPublic));
                method = Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager").GetMethod("WarnUserRPC");
                IL2Ch.Patch(method, typeof(patch_AntiKick).GetMethod("patch_method_5", BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [6]");
                iError++;
            }

            // Debug
            if (iError == 0)
                ConSole.Success("Patch: AntiKick");
            else
                ConSole.Error("Patch: AntiKick");
        }

        private static AnalyticsResult patch_method_3()
        {
            return AnalyticsResult.Ok;
        }
        private static void patch_method_4(IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {

        }
        private static void patch_method_5()
        {

        }

        private static bool patch_method_6() => patch_method_7(IntPtr.Zero);
        private static bool patch_method_7(IntPtr ptrInstance)
        {
            return false;
        }

        public static IL2Patch[] pRPCKick = new IL2Patch[2];
        public static IL2Patch[] pAnalytics = new IL2Patch[3];
    }
}

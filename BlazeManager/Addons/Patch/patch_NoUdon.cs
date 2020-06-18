using System;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using VRC.Udon;

namespace Addons.Patch
{
    public static class patch_NoUdon
    {
        public static void Start()
        {
            try
            {
                // ----------------- [ Update ] --------------------------- //
                IL2Method method = UdonBehaviour.Instance_Class.GetMethod("Update");

                if (method == null)
                    new Exception();

                pList[0] = IL2Ch.Patch(method, typeof(patch_NoUdon).GetMethod("patch_method_0", BindingFlags.Static | BindingFlags.NonPublic));

                // ----------------- [ LateUpdate ] --------------------------- //
                method = UdonBehaviour.Instance_Class.GetMethod("LateUpdate");

                if (method == null)
                    new Exception();

                pList[1] = IL2Ch.Patch(method, typeof(patch_NoUdon).GetMethod("patch_method_1", BindingFlags.Static | BindingFlags.NonPublic));

                // ----------------- [ FixedUpdate ] --------------------------- //
                method = UdonBehaviour.Instance_Class.GetMethod("FixedUpdate");

                if (method == null)
                    new Exception();

                pList[2] = IL2Ch.Patch(method, typeof(patch_NoUdon).GetMethod("patch_method_2", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: NO-Udon");

            }
            catch
            {
                ConSole.Error("Patch: NO-Udon");
            }
        }

        private static void patch_method_0(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero || Enabled)
                return;

            pList[0].InvokeOriginal(ptrInstance, new IntPtr[0]);
        }

        private static void patch_method_1(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero || Enabled)
                return;

            pList[1].InvokeOriginal(ptrInstance, new IntPtr[0]);
        }

        private static void patch_method_2(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero || Enabled)
                return;

            pList[2].InvokeOriginal(ptrInstance, new IntPtr[0]);
        }

        // pList[0] - Update
        // pList[1] - LateUpdate
        // pList[2] - FixedUpdate
        public static IL2Patch[] pList = new IL2Patch[3];
        public static bool Enabled = true;
    }
}

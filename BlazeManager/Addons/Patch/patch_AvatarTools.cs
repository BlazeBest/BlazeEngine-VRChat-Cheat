using System;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_AvatarTools
    {
        public static void Start()
        {
            try
            {
                IL2Method method = UiAvatarList.Instance_Class.GetMethod("Update");

                if (method == null)
                    new Exception();

                pUpdate = IL2Ch.Patch(method, typeof(patch_AvatarTools).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: Avatar Tools");

            }
            catch
            {
                ConSole.Error("Patch: Avatar Tools");
            }
        }

        private static void patch_method(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero)
                return;

            pUpdate.InvokeOriginal(ptrInstance, new IntPtr[0]);
            Avatars.UIAvatar.Update();
        }

        public static IL2Patch pUpdate;
    }
}

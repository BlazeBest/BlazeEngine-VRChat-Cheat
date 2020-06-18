using System;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_AvatarSteal
    {
        public static void Start()
        {
            IL2Method method = null;
            try
            {
                method = Assemblies.a["Assembly-CSharp"].GetClass("UserInteractMenu").GetMethod("Update");
                if (method == null)
                    new Exception();

                pAvatarStealer = IL2Ch.Patch(method, typeof(patch_AvatarSteal).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: Avatar Stealer");

            }
            catch
            {
                ConSole.Error("Patch: Avatar Stealer");
            }
        }

        private static void patch_method(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero)
                return;

            // pAvatarStealer.InvokeOriginal(ptrInstance, new IntPtr[0]);

            var __instance = ptrInstance.MonoCast<UserInteractMenu>();
            var menuController = __instance.menuController;
            if (menuController == null)
                return;

            var activeAvatar = menuController.activeAvatar;
            var activeUser = menuController.activeUser;
            if (activeAvatar == null
            || activeUser == null)
                return;

            if (activeAvatar.releaseStatus != "public"
            || activeUser.allowAvatarCopying)
            {
                if (sUserId != activeUser.id)
                {
                    __instance.cloneAvatarButtonText.text = "Clone\nPublic\nAvatar";
                }
            }
            else
            {
                sUserId = activeUser.id;
                activeUser.allowAvatarCopying = true;
                __instance.cloneAvatarButton.interactable = true;
                __instance.cloneAvatarButtonText.color = new Color(1f, 1f, 1f);
                __instance.cloneAvatarButtonText.text = "<color=red>Clone\nPublic\nAvatar</color>";
            }

            // __instance.menuController.
        }

        private static string sUserId = string.Empty;
        public static IL2Patch pAvatarStealer;
    }
}

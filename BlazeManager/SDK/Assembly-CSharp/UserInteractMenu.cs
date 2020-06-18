using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine.UI;

public class UserInteractMenu : UnityEngine.Object
{
    public UserInteractMenu(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    private static IL2Field fieldCloneAvatarButton = null;
    public Button cloneAvatarButton
    {
        get
        {
            if (!IL2Get.Field("cloneAvatarButton", Instance_Class, ref fieldCloneAvatarButton))
                return null;

            return fieldCloneAvatarButton.GetValue(ptr)?.Unbox<Button>();
        }
        set
        {
            if (!IL2Get.Field("cloneAvatarButton", Instance_Class, ref fieldCloneAvatarButton))
                return;

            fieldCloneAvatarButton.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldCloneAvatarButtonText = null;
    public Text cloneAvatarButtonText
    {
        get
        {
            if (!IL2Get.Field("cloneAvatarButtonText", Instance_Class, ref fieldCloneAvatarButtonText))
                return null;

            return fieldCloneAvatarButtonText.GetValue(ptr)?.Unbox<Text>();
        }
        set
        {
            if (!IL2Get.Field("cloneAvatarButtonText", Instance_Class, ref fieldCloneAvatarButtonText))
                return;

            fieldCloneAvatarButtonText.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldMenuController = null;
    public MenuController menuController
    {
        get
        {
            if (!IL2Get.Field("menuController", Instance_Class, ref fieldMenuController))
                return null;

            return fieldMenuController.GetValue(ptr)?.Unbox<MenuController>();
        }
        set
        {
            if (!IL2Get.Field("menuController", Instance_Class, ref fieldMenuController))
                return;

            fieldMenuController.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UserInteractMenu");
}

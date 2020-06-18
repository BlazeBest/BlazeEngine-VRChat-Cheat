using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using VRC.Core;

public class MenuController : UnityEngine.Object
{
    public MenuController(IntPtr newPtr) : base(newPtr) =>
        ptr = newPtr;


    private static IL2Field fieldActiveUser = null;
    public APIUser activeUser
    {
        get
        {
            if (!IL2Get.Field("activeUser", Instance_Class, ref fieldActiveUser))
                return null;

            return fieldActiveUser.GetValue(ptr)?.Unbox<APIUser>();
        }
        set
        {
            if (!IL2Get.Field("activeUser", Instance_Class, ref fieldActiveUser))
                return;

            fieldActiveUser.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldActiveAvatar = null;
    public ApiAvatar activeAvatar
    {
        get
        {
            if (!IL2Get.Field("activeAvatar", Instance_Class, ref fieldActiveAvatar))
                return null;

            return fieldActiveAvatar.GetValue(ptr)?.Unbox<ApiAvatar>();
        }
        set
        {
            if (!IL2Get.Field("activeAvatar", Instance_Class, ref fieldActiveAvatar))
                return;

            fieldActiveAvatar.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("MenuController");
}

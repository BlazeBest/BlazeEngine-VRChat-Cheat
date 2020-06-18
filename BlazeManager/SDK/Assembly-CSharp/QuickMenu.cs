using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

unsafe public class QuickMenu : Component
{
    public QuickMenu(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Property propertyInstance = null;
    public static QuickMenu Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "QuickMenu");
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<QuickMenu>();
        }
    }

    private static IL2Property propertySelectedUser = null;
    public APIUser SelectedUser
    {
        get
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Core.APIUser");
                if (propertySelectedUser == null)
                    return null;
            }

            return propertySelectedUser.GetGetMethod().Invoke(ptr)?.Unbox<APIUser>();
        }
        set
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Core.APIUser");
                if (propertySelectedUser == null)
                    return;
            }

            propertySelectedUser.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }
    }

    private IL2Field fieldCurrentMenu = null;
    public GameObject _currentMenu
    {
        get
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.token == 0xF0);
                if (fieldCurrentMenu == null)
                    return null;
            }
            return fieldCurrentMenu.GetValue(ptr)?.Unbox<GameObject>();
        }
        set
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.token == 0xF0);
                if (fieldCurrentMenu == null)
                    return;
            }
            fieldCurrentMenu.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("QuickMenu");
}

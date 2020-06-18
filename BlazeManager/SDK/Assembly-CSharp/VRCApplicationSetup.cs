using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class VRCApplicationSetup : Component
{
    public VRCApplicationSetup(IntPtr newPtr) : base(newPtr) =>
        ptr = newPtr;


    private static IL2Property propertyInstance = null;
    public static VRCApplicationSetup Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCApplicationSetup");
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<VRCApplicationSetup>();
        }
    }



    private static IL2Field fieldAppVersion = null;
    public string appVersion
    {
        get
        {
            if (!IL2Get.Field("appVersion", Instance_Class, ref fieldAppVersion))
                return default;

            return fieldAppVersion.GetValue(ptr).Unbox<string>();
        }
    }
    

    private static IL2Field fieldBuildNumber = null;
    public int buildNumber
    {
        get
        {
            if (!IL2Get.Field("buildNumber", Instance_Class, ref fieldBuildNumber))
                return default;

            return fieldBuildNumber.GetValue(ptr).Unbox<int>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCApplicationSetup");
}

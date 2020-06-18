using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;

public class ModerationManager : Component
{
    public ModerationManager(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Property propertyInstance = null;
    public static ModerationManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "ModerationManager");
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<ModerationManager>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager");
}
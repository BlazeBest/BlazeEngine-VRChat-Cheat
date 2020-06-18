using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCFlowManager : Component
{
    public VRCFlowManager(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Property propertyInstance = null;
    public static VRCFlowManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCFlowManager");
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<VRCFlowManager>();
        }
    }

    private static IL2Method methodEnterWorld = null;
    public void EnterWorld(string WorldId) => EnterWorld(WorldId, null);
    public void EnterWorld(string WorldId, string InstanceID)
    {
        if(methodEnterWorld == null)
        {
            methodEnterWorld = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 5).First(x => x.GetParameters()[3].typeName == "System.Action<System.String>");
            if (methodEnterWorld == null)
                return;
        }

        if(string.IsNullOrEmpty(InstanceID))
        {
            string[] array = WorldId.Split(new char[]
            {
            ':'
            });
            if (array.Length != 2)
                return;

            WorldId = array[0];
            InstanceID = array[1];
        }

        methodEnterWorld.Invoke(ptr, new IntPtr[] {
            IL2Import.StringToIntPtr(WorldId),
            IL2Import.il2cpp_string_new_len(InstanceID, InstanceID.Length),
            IL2Import.ObjectToIntPtr(null),
            IL2Import.ObjectToIntPtr(null),
            false.MonoCast()
        });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCFlowManager");
}
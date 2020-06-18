using System;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class PortalInternal : Component
{
    public PortalInternal(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    private static IL2Method methodOnDestroy = null;
    public void OnDestroy()
    {
        if (!IL2Get.Method("OnDestroy", Instance_Class, ref methodOnDestroy))
            return;

        methodOnDestroy.Invoke(ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PortalInternal");
}

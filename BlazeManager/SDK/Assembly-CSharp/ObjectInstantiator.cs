using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class ObjectInstantiator : Component
{
    public ObjectInstantiator(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ObjectInstantiator");
}

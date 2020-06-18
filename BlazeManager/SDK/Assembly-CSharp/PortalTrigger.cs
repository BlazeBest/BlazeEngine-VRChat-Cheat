using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class PortalTrigger : Component
{
    public PortalTrigger(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PortalTrigger");
}

using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class LocomotionInputController : Component
{
    public LocomotionInputController(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("LocomotionInputController");
}
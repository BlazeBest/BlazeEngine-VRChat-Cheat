using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class USpeakPhotonSender3D : Component
{
    public USpeakPhotonSender3D(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeakPhotonSender3D");
}
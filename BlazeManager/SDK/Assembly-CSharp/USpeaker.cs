using System;
using BlazeIL.il2cpp;
using UnityEngine;

public class USpeaker : Component
{
    public USpeaker(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeaker");
}
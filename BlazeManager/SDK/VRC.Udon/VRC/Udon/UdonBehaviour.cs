using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.Udon
{
    public class UdonBehaviour : Behaviour
    {
        public UdonBehaviour(IntPtr newPtr) : base(newPtr) =>
            ptr = newPtr;


        public static new IL2Type Instance_Class = Assemblies.a["VRC.Udon"].GetClass("UdonBehaviour", "VRC.Udon");
    }
}

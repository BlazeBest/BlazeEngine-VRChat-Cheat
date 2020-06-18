using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.SDK3.Components
{
    public class VRCPickup : Component
    {
        public VRCPickup(IntPtr newPtr) : base(newPtr) =>
            ptr = newPtr;
        
        public static new IL2Type Instance_Class = Assemblies.a["VRCSDK3"].GetClass("VRCPickup", "VRC.SDK3.Components");
    }
}

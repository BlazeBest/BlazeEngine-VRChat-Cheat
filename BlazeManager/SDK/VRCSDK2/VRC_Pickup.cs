using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    public class VRC_Pickup : Component
    {

        public VRC_Pickup(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        public static new IL2Type Instance_Class = Assemblies.a["VRCSDK2"].GetClass("VRC_Pickup", "VRCSDK2");
    }
}

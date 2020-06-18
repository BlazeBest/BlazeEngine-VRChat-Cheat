using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using VRC.Core;

namespace VRC.UI
{
    public class PageWorldInfo : Component
    {
        public PageWorldInfo(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Field fieldApiWorld = null;
        public ApiWorld apiWorld
        {
            get
            {
                if (fieldApiWorld == null)
                {
                    fieldApiWorld = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRC.Core.ApiWorld");
                    if (fieldApiWorld == null)
                        return null;
                }
                return fieldApiWorld.GetValue(ptr)?.MonoCast<ApiWorld>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageWorldInfo", "VRC.UI");
    }
}

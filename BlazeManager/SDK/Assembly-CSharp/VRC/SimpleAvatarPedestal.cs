using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC
{
    public class SimpleAvatarPedestal : Component
    {
        public SimpleAvatarPedestal(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Field fieldApiAvatar = null;
        public ApiAvatar apiAvatar
        {
            get
            {
                if (fieldApiAvatar == null)
                {
                    fieldApiAvatar = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRC.Core.ApiAvatar");
                    if (fieldApiAvatar == null)
                        return null;
                }

                return fieldApiAvatar.GetValue(ptr)?.Unbox<ApiAvatar>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("SimpleAvatarPedestal", "VRC");
    }
}
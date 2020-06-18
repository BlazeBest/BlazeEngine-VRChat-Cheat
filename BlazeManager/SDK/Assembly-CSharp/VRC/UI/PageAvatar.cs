using System;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.UI
{
    public class PageAvatar : Component
    {
        public PageAvatar(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;


        private static IL2Field fieldAvatar = null;
        public SimpleAvatarPedestal avatar
        {
            get
            {
                if (!IL2Get.Field("avatar", Instance_Class, ref fieldAvatar))
                    return default;

                return fieldAvatar.GetValue(ptr)?.Unbox<SimpleAvatarPedestal>();
            }
            set
            {
                if (!IL2Get.Field("avatar", Instance_Class, ref fieldAvatar))
                    return;

                fieldAvatar.SetValue(ptr, value.ptr);
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageAvatar", "VRC.UI");
    }
}
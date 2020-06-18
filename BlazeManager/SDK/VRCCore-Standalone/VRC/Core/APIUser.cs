using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyCurrentUser = null;
        public static APIUser CurrentUser
        {
            get
            {
                if (!IL2Get.Property("CurrentUser", Instance_Class, ref propertyCurrentUser))
                    return null;

                return propertyCurrentUser.GetGetMethod().Invoke()?.MonoCast<APIUser>();
            }
        }

        private static IL2Property propertyDisplayName = null;
        public string displayName
        {
            get
            {
                if (!IL2Get.Property("displayName", Instance_Class, ref propertyDisplayName))
                    return null;

                return propertyDisplayName.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
        }
        

        private static IL2Property propertyHasVIPAccess = null;
        public bool hasVIPAccess
        {
            get
            {
                if (!IL2Get.Property("hasVIPAccess", Instance_Class, ref propertyHasVIPAccess))
                    return default;

                return propertyHasVIPAccess.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyAllowAvatarCopying = null;
        public bool allowAvatarCopying
        {
            get
            {
                if (!IL2Get.Property("allowAvatarCopying", Instance_Class, ref propertyAllowAvatarCopying))
                    return default;

                return propertyAllowAvatarCopying.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (!IL2Get.Property("allowAvatarCopying", Instance_Class, ref propertyAllowAvatarCopying))
                    return;

                propertyAllowAvatarCopying.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyHasModerationPowers = null;
        public bool hasModerationPowers
        {
            get
            {
                if (!IL2Get.Property("hasModerationPowers", Instance_Class, ref propertyHasModerationPowers))
                    return default;

                return propertyHasModerationPowers.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }
        

        private static IL2Property propertyHasScriptingAccess = null;
        public bool hasScriptingAccess
        {
            get
            {
                if (!IL2Get.Property("hasScriptingAccess", Instance_Class, ref propertyHasScriptingAccess))
                    return default;

                return propertyHasScriptingAccess.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}
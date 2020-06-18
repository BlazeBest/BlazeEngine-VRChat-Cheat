using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    public class ApiAvatar : ApiModel
    {
        public ApiAvatar(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyReleaseStatus = null;
        public string releaseStatus
		{
			get
            {
                if (!IL2Get.Property("releaseStatus", Instance_Class, ref propertyReleaseStatus))
                    return default;

                return propertyReleaseStatus.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
			set
            {
                if (!IL2Get.Property("releaseStatus", Instance_Class, ref propertyReleaseStatus))
                    return;

                propertyReleaseStatus.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
		}

        
        private static IL2Property propertyAuthorId = null;
        public string authorId
        {
            get
            {
                if (!IL2Get.Property("authorId", Instance_Class, ref propertyAuthorId))
                    return default;

                return propertyAuthorId.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (!IL2Get.Property("authorId", Instance_Class, ref propertyAuthorId))
                    return;

                propertyAuthorId.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }


        private static IL2Property propertyAssetUrl = null;
        public string assetUrl
        {
            get
            {
                if (!IL2Get.Property("assetUrl", Instance_Class, ref propertyAssetUrl))
                    return default;

                return propertyAssetUrl.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (!IL2Get.Property("assetUrl", Instance_Class, ref propertyAssetUrl))
                    return;

                propertyAssetUrl.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        private static IL2Method methodSaveReleaseStatus = null;
        public void SaveReleaseStatus(Action<ApiContainer> onSuccess = null, Action<ApiContainer> onFailure = null)
        {
            if (!IL2Get.Method("SaveReleaseStatus", Instance_Class, ref methodSaveReleaseStatus))
                return;

            IntPtr ptrSucc = IntPtr.Zero;
            IntPtr ptrFail = IntPtr.Zero;
            if (onSuccess != null)
                ptrSucc = UnityEngine.Events._UnityAction.CreateDelegate(onSuccess, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);
            if(onFailure != null)
                ptrFail = UnityEngine.Events._UnityAction.CreateDelegate(onFailure, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);
            methodSaveReleaseStatus.Invoke(ptr, new IntPtr[] { ptrSucc, ptrFail });
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiAvatar", "VRC.Core");
    }
}

using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class Application
    {
        private static IL2Property propertyTargetFrameRate = null;
        public static int targetFrameRate
        {
            get
            {
                if (!IL2Get.Property("targetFrameRate", Instance_Class, ref propertyTargetFrameRate))
                    return default;

                return propertyTargetFrameRate.GetGetMethod().Invoke().Unbox<int>();
            }
            set
            {
                if (!IL2Get.Property("targetFrameRate", Instance_Class, ref propertyTargetFrameRate))
                    return;

                propertyTargetFrameRate.GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyUnityVersion = null;
        public static string unityVersion
        {
            get
            {
                if (!IL2Get.Property("unityVersion", Instance_Class, ref propertyUnityVersion))
                    return null;

                return propertyUnityVersion.GetGetMethod().Invoke()?.Unbox<string>();
            }
        }

        private static IL2Property propertyStreamingAssetsPath = null;
        public static string streamingAssetsPath
        {
            get
            {
                if (!IL2Get.Property("streamingAssetsPath", Instance_Class, ref propertyStreamingAssetsPath))
                    return null;

                return propertyStreamingAssetsPath.GetGetMethod().Invoke()?.Unbox<string>();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Application", "UnityEngine");
    }
}

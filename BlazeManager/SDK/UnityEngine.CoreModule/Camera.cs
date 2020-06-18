using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class Camera : Behaviour
    {
        public Camera(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyMain = null;
        public static Camera main
        {
            get
            {
                if (!IL2Get.Property("main", Instance_Class, ref propertyMain))
                    return null;

                return propertyMain.GetGetMethod().Invoke()?.Unbox<Camera>();
            }
        }

        private static IL2Property propertyCurrent = null;
        public static Camera current
        {
            get
            {
                if (!IL2Get.Property("current", Instance_Class, ref propertyCurrent))
                    return null;

                return propertyCurrent.GetGetMethod().Invoke()?.Unbox<Camera>();
            }
        }


        private static IL2Method ScreenPointToRay1 = null;
        public Ray ScreenPointToRay(Vector3 pos)
        {
            if (ScreenPointToRay1 == null)
            {
                ScreenPointToRay1 = Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1);
                if (ScreenPointToRay1 == null)
                    return default;
            }

            IL2Object result = ScreenPointToRay1.Invoke(ptr, new IntPtr[] { pos.MonoCast() });
            if (result == null)
                return default;

            return result.Unbox<Ray>();
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Camera", "UnityEngine");
    }
}

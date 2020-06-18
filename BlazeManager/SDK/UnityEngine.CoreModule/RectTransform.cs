using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyAnchoredPosition = null;
        public Vector2 anchoredPosition
        {
            get
            {
                if (propertyAnchoredPosition == null)
                {
                    propertyAnchoredPosition = Instance_Class.GetProperty("anchoredPosition");
                    if (propertyAnchoredPosition == null)
                        return default;
                }

                return propertyAnchoredPosition.GetGetMethod().Invoke(ptr).Unbox<Vector2>();
            }
            set
            {
                if (propertyAnchoredPosition == null)
                {
                    propertyAnchoredPosition = Instance_Class.GetProperty("anchoredPosition");
                    if (propertyAnchoredPosition == null)
                        return;
                }

                propertyAnchoredPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertySizeDelta = null;
        public Vector2 sizeDelta
        {
            get
            {
                if (propertySizeDelta == null)
                {
                    propertySizeDelta = Instance_Class.GetProperty("sizeDelta");
                    if (propertySizeDelta == null)
                        return default;
                }

                return propertySizeDelta.GetGetMethod().Invoke(ptr).Unbox<Vector2>();
            }
            set
            {
                if (propertySizeDelta == null)
                {
                    propertySizeDelta = Instance_Class.GetProperty("sizeDelta");
                    if (propertySizeDelta == null)
                        return;
                }

                propertySizeDelta.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("RectTransform", "UnityEngine");
    }
}

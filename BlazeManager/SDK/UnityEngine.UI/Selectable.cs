using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    public class Selectable : Component
    {
        public Selectable(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyInteractable = null;
        public bool interactable
        {
            get
            {
                if (propertyInteractable == null)
                {
                    propertyInteractable = Instance_Class.GetProperty("interactable");
                    if (propertyInteractable == null)
                        return default;
                }

                return propertyInteractable.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyInteractable == null)
                {
                    propertyInteractable = Instance_Class.GetProperty("interactable");
                    if (propertyInteractable == null)
                        return;
                }

                propertyInteractable.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Selectable", "UnityEngine.UI");
    }
}

using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    public class Graphic : Behaviour
    {
        public Graphic(IntPtr ptrONew) : base(ptrONew) =>
            ptr = ptrONew;

        private static IL2Property propertyColor = null;
        public Color color
        {
            get
            {
                if (propertyColor == null)
                {
                    propertyColor = Instance_Class.GetProperty("color");
                    if (propertyColor == null)
                        return default;
                }

                return propertyColor.GetGetMethod().Invoke(ptr).Unbox<Color>();
            }
            set
            {
                if (propertyColor == null)
                {
                    propertyColor = Instance_Class.GetProperty("color");
                    if (propertyColor == null)
                        return;
                }

                propertyColor.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Graphic", "UnityEngine.UI");
    }
}

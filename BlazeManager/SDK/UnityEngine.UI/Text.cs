using System;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Text -> MaskableGraphic -> Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    public class Text : Graphic
    {
        public Text(IntPtr ptrONew) : base(ptrONew) =>
            ptr = ptrONew;

        private static IL2Property propertyText = null;
        public string text
        {
            get
            {
                if (propertyText == null)
                {
                    propertyText = Instance_Class.GetProperty("text");
                    if (propertyText == null)
                        return null;
                }

                return propertyText.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (propertyText == null)
                {
                    propertyText = Instance_Class.GetProperty("text");
                    if (propertyText == null)
                        return;
                }

                propertyText.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Text", "UnityEngine.UI");
    }
}

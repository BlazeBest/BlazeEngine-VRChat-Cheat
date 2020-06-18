using System;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Text -> MaskableGraphic -> Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    unsafe public class Image : Graphic
    {
        public Image(IntPtr ptrONew) : base(ptrONew) =>
            ptr = ptrONew;

        private static IL2Property propertySprite = null;
        public IntPtr sprite
        {
            get
            {
                if (propertySprite == null)
                {
                    propertySprite = Instance_Class.GetProperty("sprite");
                    if (propertySprite == null)
                        return IntPtr.Zero;
                }

                return propertySprite.GetGetMethod().Invoke(ptr).ptr;
            }
            set
            {
                if (propertySprite == null)
                {
                    propertySprite = Instance_Class.GetProperty("sprite");
                    if (propertySprite == null)
                        return;
                }

                propertySprite.GetSetMethod().Invoke(ptr, new IntPtr[] { value });
            }
        }
        private static IL2Property propertyMaterial = null;
        public IntPtr material
        {
            get
            {
                if (propertyMaterial == null)
                {
                    propertyMaterial = Instance_Class.GetProperty("material");
                    if (propertyMaterial == null)
                        return IntPtr.Zero;
                }

                return propertyMaterial.GetGetMethod().Invoke(ptr).ptr;
            }
            set
            {
                if (propertyMaterial == null)
                {
                    propertyMaterial = Instance_Class.GetProperty("material");
                    if (propertyMaterial == null)
                        return;
                }

                propertyMaterial.GetSetMethod().Invoke(ptr, new IntPtr[] { value });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Image", "UnityEngine.UI");
    }
}

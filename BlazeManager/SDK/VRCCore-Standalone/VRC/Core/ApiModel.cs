using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiModel : IL2Base
    {
        public ApiModel(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyId = null;
        public string id
        {
            get
            {
                if (propertyId == null)
                {
                    propertyId = Instance_Class.GetProperty("id");
                    if (propertyId == null)
                        return null;
                }

                return propertyId.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {

                if (propertyId == null)
                {
                    propertyId = Instance_Class.GetProperty("id");
                    if (propertyId == null)
                        return;
                }

                propertyId.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }
    
        private static IL2Property propertyPopulated = null;
        public bool Populated
        {
            get
            {
                if (propertyPopulated == null)
                {
                    propertyPopulated = Instance_Class.GetProperty("Populated");
                    if (propertyPopulated == null)
                        return default;
                }

                return propertyPopulated.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiModel", "VRC.Core");
    }
}
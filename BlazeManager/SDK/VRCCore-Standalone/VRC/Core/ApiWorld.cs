using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    public class ApiWorld : ApiModel
    {
        public ApiWorld(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        // Field 0
        public string currentInstanceIdWithTags
        {
            get
            {
                if (!IL2Get.Field("currentInstanceIdWithTags", Instance_Class, ref fields[0]))
                    return null;

                return fields[0].GetValue(ptr)?.Unbox<string>();
            }
        }

        // Property 0
        public string authorId
        {
            get
            {
                if (!IL2Get.Property("authorId", Instance_Class, ref properties[0]))
                    return null;

                return properties[0].GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (!IL2Get.Property("authorId", Instance_Class, ref properties[0]))
                    return;

                properties[0].GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        private static IL2Property[] properties = new IL2Property[1];
        private static IL2Field[] fields = new IL2Field[1];

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorld", "VRC.Core");
    }
}
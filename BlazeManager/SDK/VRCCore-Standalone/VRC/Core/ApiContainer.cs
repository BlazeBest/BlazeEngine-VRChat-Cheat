using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    public class ApiContainer : IL2Base
    {
        public ApiContainer(IntPtr newPtr) : base(newPtr) =>
            ptr = newPtr;


        public static IL2Constructor constructApiContaner = null;
        public ApiContainer() : base(IntPtr.Zero)
        {
            if (!IL2Get.Constructor(Instance_Class, ref constructApiContaner))
                throw new Exception("Create construct");

            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            constructApiContaner.Invoke(ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiContainer", "VRC.Core");
    }
}

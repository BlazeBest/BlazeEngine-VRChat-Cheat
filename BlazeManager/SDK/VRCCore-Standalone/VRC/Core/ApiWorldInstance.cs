using System;
using System.Linq;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    unsafe public class ApiWorldInstance : IL2Base
    {
        public ApiWorldInstance(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        // Constructor 0
        public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            if (!IL2Get.Constructor(x => x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "_count",
                Instance_Class, ref constructors[0]))
                return;

            ptr = constructors[0].Invoke().ptr;
        }

        // Method 0
        public string GetInstanceCreator()
        {
            if (!IL2Get.Method("GetInstanceCreator", Instance_Class, ref methods[0]))
                return null;

            return methods[0].Invoke(ptr)?.Unbox<string>();
        }

        private static IL2Constructor[] constructors = new IL2Constructor[1];
        private static IL2Method[] methods = new IL2Method[1];

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorldInstance", "VRC.Core");
    }
}
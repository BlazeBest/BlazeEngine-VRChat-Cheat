using System;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    internal class IL2GetType
    {
        internal static IL2TypeObject IL2Typeof(Type type) => IL2Typeof((IL2Type)type.GetField("Instance_Class").GetValue(null));
        internal static IL2TypeObject IL2Typeof(IL2Type klass)
        {
            IntPtr ptr = IL2Import.il2cpp_class_get_type(klass.ptr);
            if (ptr == IntPtr.Zero)
                return null;

            IntPtr result = IL2Import.il2cpp_type_get_object(ptr);
            if (ptr == IntPtr.Zero)
                return null;

            return result.MonoCast<IL2TypeObject>();
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Property : IL2Base
    {
        internal IL2Property(IntPtr newPtr) : base(newPtr) => ptr = newPtr;

        public string Name
        {
            get
            {
                if (sName == null)
                    sName = Marshal.PtrToStringAnsi(IL2Import.il2cpp_property_get_name(ptr));

                return sName;
            }
        }
        private string sName = null;

        public IL2BindingFlags GetFlags()
        {
            if(Flags == null)
            {
                Flags = (IL2BindingFlags)IL2Import.il2cpp_property_get_flags(ptr);
                if (Flags == null)
                    return IL2BindingFlags.METHOD_COMPILER_CONTROLLED;
            }
            return (IL2BindingFlags)Flags;
        }
        public bool HasFlag(IL2BindingFlags flag) => ((GetFlags() & flag) != 0);
        private IL2BindingFlags? Flags = null;
        public IL2Method GetGetMethod()
        {
            if(getMethod == null)
            {
                IntPtr method = IL2Import.il2cpp_property_get_get_method(ptr);
                if (method != IntPtr.Zero)
                    getMethod = new IL2Method(method);
            }
            return getMethod;
        }
        private IL2Method getMethod;
        public IL2Method GetSetMethod()
        {
            if (setMethod == null)
            {
                IntPtr method = IL2Import.il2cpp_property_get_set_method(ptr);
                if (method != IntPtr.Zero)
                    setMethod = new IL2Method(method);
            }
            return setMethod;
        }
        private IL2Method setMethod;
    }
}

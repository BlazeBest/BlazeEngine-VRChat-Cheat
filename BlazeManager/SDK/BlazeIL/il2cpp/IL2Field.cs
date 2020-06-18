using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2Field : IL2Base
    {
        internal IL2Field(IntPtr newPtr) : base(newPtr) => ptr = newPtr;
        
        public string Name
        {
            get
            {
                if (sName == null)
                    sName = Marshal.PtrToStringAnsi(IL2Import.il2cpp_field_get_name(ptr));

                return sName;
            }
        }
        private string sName = null;
        

        public int token
        {
            get
            {
                if (iToken == null)
                    iToken = IL2Import.il2cpp_field_get_offset(ptr);

                if (iToken == null)
                    return -1;
                
                return (int)iToken;
            }
        }
        private int? iToken = null;

        public IL2BindingFlags GetFlags()
        {
            if (Flags == null)
            {
                uint flags = 0;
                Flags = (IL2BindingFlags)IL2Import.il2cpp_field_get_flags(ptr, ref flags);
                if (Flags == null)
                    return IL2BindingFlags.FIELD_COMPILER_CONTROLLED;
            }
            return (IL2BindingFlags)Flags;
        }
        public bool HasFlag(IL2BindingFlags flag) => ((GetFlags() & flag) != 0);
        private IL2BindingFlags? Flags = null;

        public IL2ReturnType GetReturnType()
        {
            if (ReturnType == null)
                ReturnType = new IL2ReturnType(IL2Import.il2cpp_field_get_type(ptr));

            return ReturnType;
        }
        private IL2ReturnType ReturnType = null;

        public IL2Object GetValue() => GetValue(IntPtr.Zero);
        public IL2Object GetValue(IntPtr obj)
        {
            IntPtr returnval = IntPtr.Zero;
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                returnval = IL2Import.il2cpp_field_get_value_object(ptr, IntPtr.Zero);
            else
                returnval = IL2Import.il2cpp_field_get_value_object(ptr, obj);
            if (returnval != IntPtr.Zero)
                return new IL2Object(returnval, GetReturnType());
            return null;
        }
        public void SetValue(IntPtr value) => SetValue(IntPtr.Zero, value);
        public void SetValue(IntPtr obj, IntPtr value)
        {
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                IL2Import.il2cpp_field_static_set_value(ptr, value);
            else
                IL2Import.il2cpp_field_set_value(obj, ptr, value);
        }
    }
}

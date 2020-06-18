using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    public class IL2MethodBody : IL2Base
    {
        internal IL2MethodBody(IntPtr newPtr) : base(newPtr) => ptr = newPtr;

        public string Name
        {
            get
            {
                if (sName == null)
                    sName = Marshal.PtrToStringAnsi(IL2Import.il2cpp_method_get_name(ptr));

                return sName;
            }
        }
        private string sName = null;

        public int token
        {
            get
            {
                if (iToken == null)
                {
                    iToken = IL2Import.il2cpp_method_get_token(ptr);
                    if (iToken == null)
                        return -1;
                }
                return (int)iToken;
            }
        }
        private int? iToken = null;

        public IL2ReturnType GetReturnType()
        {
            if (ReturnType == null)
                ReturnType = new IL2ReturnType(IL2Import.il2cpp_method_get_return_type(ptr));

            return ReturnType;
        }
        private IL2ReturnType ReturnType = null;

        public IL2Param[] GetParameters()
        {
            if (Parameters == null)
            {
                Parameters = new List<IL2Param>();
                uint param_count = IL2Import.il2cpp_method_get_param_count(ptr);
                for (uint i = 0; i < param_count; i++)
                    Parameters.Add(new IL2Param(IL2Import.il2cpp_method_get_param(ptr, i), Marshal.PtrToStringAnsi(IL2Import.il2cpp_method_get_param_name(ptr, i))));
            }

            return Parameters.ToArray();
        }
        private List<IL2Param> Parameters = null;

        public IL2BindingFlags GetFlags()
        {
            if (Flags == null)
            {
                uint flags = 0;
                Flags = (IL2BindingFlags)IL2Import.il2cpp_method_get_flags(ptr, ref flags);
                if (Flags == null)
                    return IL2BindingFlags.METHOD_COMPILER_CONTROLLED;
            }
            return (IL2BindingFlags)Flags;
        }
        public bool HasFlag(IL2BindingFlags flag) => ((GetFlags() & flag) != 0);
        private IL2BindingFlags? Flags = null;

        public IL2Object Invoke() => Invoke(IntPtr.Zero, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(IntPtr obj) => Invoke(obj, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(params IntPtr[] paramtbl)
        {
            return Invoke(IntPtr.Zero, paramtbl);
        }
        public IL2Object Invoke(IL2Object obj) => Invoke(obj.ptr, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(params IL2Object[] paramtbl)
        {
            return Invoke(IntPtr.Zero, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl));
        }
        public IL2Object Invoke(IntPtr obj, params IL2Object[] paramtbl) => Invoke(obj, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl));
        public IL2Object Invoke(IL2Object obj, params IntPtr[] paramtbl) => Invoke(obj.ptr, paramtbl);
        public IL2Object Invoke(IntPtr obj, params IntPtr[] paramtbl)
        {
            IntPtr returnval = InvokeMethod(ptr, obj, paramtbl);
            if (returnval == IntPtr.Zero)
                return null;
            return new IL2Object(returnval, GetReturnType());
        }

        unsafe public static IntPtr InvokeMethod(IntPtr method, IntPtr obj, params IntPtr[] paramtbl)
        {
            if (method == IntPtr.Zero)
                return IntPtr.Zero;
            IntPtr[] intPtrArray;
            IntPtr returnval = IntPtr.Zero;
            intPtrArray = ((paramtbl != null) ? paramtbl : new IntPtr[0]);
            IntPtr intPtr = Marshal.AllocHGlobal(intPtrArray.Length * sizeof(void*));
            try
            {
                void** pointerArray = (void**)intPtr.ToPointer();
                for (int i = 0; i < intPtrArray.Length; i++)
                    pointerArray[i] = intPtrArray[i].ToPointer();
                returnval = IL2Import.il2cpp_runtime_invoke(method, obj, pointerArray, IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
            return returnval;
        }

    }
}

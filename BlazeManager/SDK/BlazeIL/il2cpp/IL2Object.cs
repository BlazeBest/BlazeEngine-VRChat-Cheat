using System;
using System.Linq;
using System.Collections.Generic;

namespace BlazeIL.il2cpp
{
    public class IL2Object : IL2Base
    {
        private IL2ReturnType ReturnType;

        public IL2Object(IntPtr newPtr, IL2ReturnType returntype) : base(newPtr)
        {
            ptr = newPtr;

            ReturnType = returntype;
        }

        internal IL2ReturnType GetReturnType() => ReturnType;
        internal T Unbox<T>() => ptr.MonoCast<T>();
        unsafe internal IntPtr[] UnboxArray()
        {
            long length = *((long*)ptr + 3);
            IntPtr[] result = new IntPtr[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = *(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size);
            }
            return result;
        }
        internal T[] UnboxArray<T>()
        {
            IntPtr[] result = UnboxArray();

            if (result != null)
                if (result.Length > 0)
                    return result.Select(x => x.MonoCast<T>()).ToArray();

            return new T[0];
        }

        internal Dictionary<T1, T2> UnboxDictionary<T1, T2>()
        {
            // Console.WriteLine("Test: " + Instance_Class)
            return null;
        }
    }
}

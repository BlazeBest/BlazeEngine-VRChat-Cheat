using System;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

unsafe public static class Execute
{
    public static T[] IntPtrToArray<T>(IntPtr ptr, uint len)
    {
        IntPtr iter = ptr;
        T[] arr = new T[len];

        for (uint i = 0; i < len; i++)
        {
            arr[i] = (T)Marshal.PtrToStructure(iter, typeof(T));
            iter += Marshal.SizeOf(typeof(T));
        }
        return arr;
    }

    public static IntPtr ArrayToIntPtr(this IntPtr[] array, IL2Type typeobject = null)
    {
        if (typeobject == null)
            typeobject = BlazeTools.IL2SystemClass.Object;

        int length = array.Length;
        IntPtr result = IL2Import.il2cpp_array_new(typeobject.ptr, length);
        for (int i = 0; i < length; i++)
        {
            *(IntPtr*)((IntPtr)((long*)result + 4) + i * IntPtr.Size) = array[i];
        }
        return result;
    }
}

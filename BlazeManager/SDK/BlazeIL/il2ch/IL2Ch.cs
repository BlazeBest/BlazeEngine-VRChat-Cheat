using System;
using System.Reflection;
using BlazeIL.il2cpp;

namespace BlazeIL.il2ch
{
    public class IL2Ch
    {
        public static IL2Patch Patch(IL2Method targetPtr, MethodInfo newPtr) => new IL2Patch(targetPtr, newPtr.MethodHandle.GetFunctionPointer());
        public static IL2Patch Patch(IL2Method targetPtr, IntPtr newPtr) => new IL2Patch(targetPtr, newPtr);
    }
}

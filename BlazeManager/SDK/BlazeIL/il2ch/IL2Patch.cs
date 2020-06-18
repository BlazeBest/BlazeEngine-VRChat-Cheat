using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;

namespace BlazeIL.il2ch
{
    unsafe public class IL2Patch : IL2Base
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal IL2Patch(IL2Method targetMethod, IntPtr newMethod) : base(newMethod)
        {
            ptr = newMethod;
            TargetMethod = targetMethod;
            // OriginalMethod = *(IntPtr*)TargetMethod.ptr.ToPointer();
            IL2Import.VRC_CreateHook(*(IntPtr*)targetMethod.ptr.ToPointer(), newMethod, out OriginalMethod);
            // Console.WriteLine("T1: " + ptr + " | T2: " + targetMethod.ptr + " | T3: " + OriginalMethod);
        }

        public IL2Object InvokeOriginal() => InvokeOriginal(IntPtr.Zero, new IntPtr[] { IntPtr.Zero });
        public IL2Object InvokeOriginal(IntPtr obj) => InvokeOriginal(obj, new IntPtr[] { IntPtr.Zero });
        public IL2Object InvokeOriginal(params IntPtr[] paramtbl)
        {
            if (paramtbl.Length == 1)
                return InvokeOriginal(paramtbl[0]);
            else
                return InvokeOriginal(IntPtr.Zero, paramtbl);
        }

        public IL2Object InvokeOriginal(IL2Object obj) => InvokeOriginal(obj.ptr, new IntPtr[] { IntPtr.Zero });
        public IL2Object InvokeOriginal(params IL2Object[] paramtbl)
        {
            if (paramtbl.Length == 1)
                return InvokeOriginal(paramtbl[0]);
            else
                return InvokeOriginal(IntPtr.Zero, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl));
        }
        public IL2Object InvokeOriginal(IntPtr obj, params IL2Object[] paramtbl) => InvokeOriginal(obj, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl));
        public IL2Object InvokeOriginal(IL2Object obj, params IntPtr[] paramtbl) => InvokeOriginal(obj.ptr, paramtbl);
        public IL2Object InvokeOriginal(IntPtr obj, params IntPtr[] paramtbl)
        {
            IL2Object returnval = null;
            List<IntPtr> sendList = new List<IntPtr>();
            if (obj == IntPtr.Zero)
            {
                foreach (IntPtr pointer in paramtbl)
                    sendList.Add(pointer);

                while (sendList.Count() < 9)
                    sendList.Add(IntPtr.Zero);
            }
            else
            {
                sendList.Add(obj);
                foreach (IntPtr pointer in paramtbl)
                    sendList.Add(pointer);

                while (sendList.Count() < 9)
                    sendList.Add(IntPtr.Zero);
            }
            returnval = PInvokeOriginal(sendList[0], sendList[1], sendList[2], sendList[3], sendList[4], sendList[5], sendList[6], sendList[7], sendList[8]);
            if (returnval != null)
                return returnval;

            return null;
        }
        public IL2Object PInvokeOriginal(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9)
        {
            IntPtr result = IL2Import.VRC_PInvoke(OriginalMethod, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            if (result == IntPtr.Zero)
                return null;

            return new IL2Object(result, TargetMethod.GetReturnType());
        }
    }
}

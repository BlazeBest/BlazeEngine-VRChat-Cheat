using System;
using System.Reflection;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.Events
{
    public delegate void UnityAction();
    public delegate void UnityAction<T0>(T0 arg0);
    public delegate void UnityAction<T0, T1>(T0 arg0, T1 arg1);
    public delegate void UnityAction<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void UnityAction<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3);

    public class _UnityAction
    {
        public unsafe static IntPtr CreateDelegate<T>(Delegate function, T instance, IL2Type klass = null)
        {
            if (klass == null)
                klass = Instance_Class;

            var obj = IL2Import.il2cpp_object_new(klass.ptr);
            if (instance == null || (typeof(T) == typeof(IntPtr) && (IntPtr)(object)instance == IntPtr.Zero))
            {
                var runtimeStaticMethod = Marshal.AllocHGlobal(8);
                *(IntPtr*)runtimeStaticMethod = function.Method.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 4) = IntPtr.Zero;
                *((IntPtr*)obj + 5) = runtimeStaticMethod;
                return obj;
            }

            IL2Method ctor = klass.GetMethod(".ctor");
            GCHandle handle1 = GCHandle.Alloc(instance);
            var runtimeMethod = Marshal.AllocHGlobal(80);
            //methodPtr
            *((IntPtr*)runtimeMethod) = function.Method.MethodHandle.GetFunctionPointer();
            byte paramCount = (byte)(function.Method.GetParameters()?.Length ?? 0);
            //Parameter count
            *((byte*)runtimeMethod + 75) = 0; // 0 parameter_count

            //Slot (65535)
            *((byte*)runtimeMethod + 74) = 0xFF;
            *((byte*)runtimeMethod + 73) = 0xFF;

            *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
            *((IntPtr*)obj + 4) = obj;
            *((IntPtr*)obj + 5) = runtimeMethod;
            *((IntPtr*)obj + 7) = GCHandle.ToIntPtr(handle1);

            return obj;
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityAction", "UnityEngine.Events");
    }
}

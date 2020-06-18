using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace BlazeIL
{
    public delegate object InvocationDelegate(object target, params object[] args);
    public static class IL2Tools
    {
        public static T MonoCast<T>(this IntPtr ptr)
        {
            #region MonoCast [IntPtr to Object]
            if (typeof(T) == typeof(string))
                return (T)(object)IL2Import.IntPtrToString(ptr);
            else if (BlazeTools.Types.unmanagedTypes.Contains(typeof(T)))
            {
                unsafe
                {
                    // SByte
                    if (typeof(T) == typeof(sbyte))
                        return (T)(object)ptr.Unbox<sbyte>();
                    // Byte
                    if (typeof(T) == typeof(byte))
                        return (T)(object)ptr.Unbox<byte>();
                    // Short
                    if (typeof(T) == typeof(short))
                        return (T)(object)ptr.Unbox<short>();
                    // UShort
                    if (typeof(T) == typeof(ushort))
                        return (T)(object)ptr.Unbox<ushort>();
                    // Int
                    if (typeof(T) == typeof(int))
                        return (T)(object)ptr.Unbox<int>();
                    // UInt
                    if (typeof(T) == typeof(uint))
                        return (T)(object)ptr.Unbox<uint>();
                    // Long
                    if (typeof(T) == typeof(long))
                        return (T)(object)ptr.Unbox<long>();
                    // ULong
                    if (typeof(T) == typeof(ulong))
                        return (T)(object)ptr.Unbox<ulong>();
                    // Char
                    if (typeof(T) == typeof(char))
                        return (T)(object)ptr.Unbox<char>();
                    // Float
                    if (typeof(T) == typeof(float))
                        return (T)(object)ptr.Unbox<float>();
                    // Double
                    if (typeof(T) == typeof(double))
                        return (T)(object)ptr.Unbox<double>();
                    // Decimal
                    if (typeof(T) == typeof(decimal))
                        return (T)(object)ptr.Unbox<decimal>();
                    // Bool
                    if (typeof(T) == typeof(bool))
                        return (T)(object)ptr.Unbox<bool>();
                }

            }
            else if (BlazeTools.Types.otherUnmanagedTypes.Contains(typeof(T)))
            {
                unsafe
                {
                    // UnityEngine.Color
                    if (typeof(T) == typeof(UnityEngine.Color))
                        return (T)(object)ptr.Unbox<UnityEngine.Color>();
                    // UnityEngine.Mathf
                    if (typeof(T) == typeof(UnityEngine.Mathf))
                        return (T)(object)ptr.Unbox<UnityEngine.Mathf>();
                    // UnityEngine.Quaternion
                    if (typeof(T) == typeof(UnityEngine.Quaternion))
                        return (T)(object)ptr.Unbox<UnityEngine.Quaternion>();
                    // UnityEngine.Ray
                    if (typeof(T) == typeof(UnityEngine.Ray))
                        return (T)(object)ptr.Unbox<UnityEngine.Ray>();
                    // UnityEngine.RaycastHit
                    if (typeof(T) == typeof(UnityEngine.RaycastHit))
                        return (T)(object)ptr.Unbox<UnityEngine.RaycastHit>();
                    // UnityEngine.Rect
                    if (typeof(T) == typeof(UnityEngine.Rect))
                        return (T)(object)ptr.Unbox<UnityEngine.Rect>();
                    // UnityEngine.Vector2
                    if (typeof(T) == typeof(UnityEngine.Vector2))
                        return (T)(object)ptr.Unbox<UnityEngine.Vector2>();
                    // UnityEngine.Vector3
                    if (typeof(T) == typeof(UnityEngine.Vector3))
                        return (T)(object)ptr.Unbox<UnityEngine.Vector3>();
                    // UnityEngine.Vector4
                    if (typeof(T) == typeof(UnityEngine.Vector4))
                        return (T)(object)ptr.Unbox<UnityEngine.Vector4>();
                }
            }
            else if (typeof(T).IsEnum)
                return (T)(object)ptr.Unbox<int>();

            InvocationDelegate fastInvoke = GetMethodInvoker(typeof(T).GetConstructors().First(x => x.GetParameters().Length == 1));
            return (T)fastInvoke(null, new object[] { ptr });
            #endregion
        }
        unsafe private static T Unbox<T>(this IntPtr ptr) where T : unmanaged => *(T*)IL2Import.il2cpp_object_unbox(ptr).ToPointer();
        unsafe public static T Cast<T>(this IntPtr obj) where T : unmanaged => *(T*)obj;
        unsafe public static IntPtr MonoCast<T>(this T obj) where T : unmanaged => new IntPtr(&obj);
        unsafe public static IntPtr Cast<T>(this T obj) where T : unmanaged => *(IntPtr*)&obj;

        public static InvocationDelegate GetMethodInvoker(MethodBase methodBase)
        {
            var dynamicMethod = CreateDynamicMethod(methodBase);
            var il = dynamicMethod.GetILGenerator();
            var parameters = methodBase.GetParameters();

            var paramTypes = parameters
                .Select(x => x.ParameterType)
                .Select(x => x.IsByRef ? x.GetElementType() : x)
                .ToArray();

            var locals = paramTypes.Select(x => il.DeclareLocal(x, true)).ToArray();

            for (int i = 0; i < paramTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                EmitFastInt(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastToReference(il, paramTypes[i]);
                il.Emit(OpCodes.Stloc, locals[i]);
            }

            if (!methodBase.IsStatic && !methodBase.IsConstructor)
            {
                il.Emit(OpCodes.Ldarg_0);
            }
            for (int i = 0; i < paramTypes.Length; i++)
            {
                if (parameters[i].ParameterType.IsByRef)
                    il.Emit(OpCodes.Ldloca_S, locals[i]);
                else
                    il.Emit(OpCodes.Ldloc, locals[i]);
            }


            if (methodBase is MethodInfo)
            {
                var methodInfo = methodBase as MethodInfo;

                EmitCallMethod(il, methodInfo);
                HandleReturn(il, methodInfo);
            }
            else if (methodBase is ConstructorInfo)
            {
                var ctorInfo = methodBase as ConstructorInfo;

                il.Emit(OpCodes.Newobj, ctorInfo);
            }

            for (int i = 0; i < paramTypes.Length; i++)
            {
                if (parameters[i].ParameterType.IsByRef)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    EmitFastInt(il, i);
                    il.Emit(OpCodes.Ldloc, locals[i]);
                    if (locals[i].LocalType.IsValueType)
                        il.Emit(OpCodes.Box, locals[i].LocalType);
                    il.Emit(OpCodes.Stelem_Ref);
                }
            }

            il.Emit(OpCodes.Ret);
            return (InvocationDelegate)dynamicMethod.CreateDelegate(typeof(InvocationDelegate));
        }

        private static void EmitCallMethod(ILGenerator il, MethodInfo methodInfo)
        {
            if (methodInfo.IsStatic)
                il.EmitCall(OpCodes.Call, methodInfo, null);
            else
                il.EmitCall(OpCodes.Callvirt, methodInfo, null);
        }

        private static void HandleReturn(ILGenerator il, MethodInfo methodInfo)
        {
            if (methodInfo.ReturnType == typeof(void))
                il.Emit(OpCodes.Ldnull);
            else
                EmitBoxIfNeeded(il, methodInfo.ReturnType);
        }

        private static DynamicMethod CreateDynamicMethod(MethodBase methodBase)
        {
            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object),
                new Type[] { typeof(object), typeof(object[]) }, MethodBase.GetCurrentMethod().Module, true);
            return dynamicMethod;
        }

        public static T[] IntPtrToStructureArray<T>(IntPtr ptr, uint len)
        {
            IntPtr iter = ptr;
            T[] array = new T[len];
            for (uint i = 0; i < len; i++)
            {
                array[i] = (T)Marshal.PtrToStructure(iter, typeof(T));
                iter += Marshal.SizeOf(typeof(T));
            }
            return array;
        }

        internal static void Emit(ILGenerator il, OpCode opcode)
        {
            il.Emit(opcode);
        }

        internal static void Emit(ILGenerator il, OpCode opcode, Type type)
        {
            il.Emit(opcode, type);
        }

        internal static void EmitCall(ILGenerator il, OpCode opcode, MethodInfo methodInfo)
        {
            il.EmitCall(opcode, methodInfo, null);
        }

        static void EmitUnboxIfNeeded(ILGenerator il, Type type)
        {
            if (type.IsValueType)
                Emit(il, OpCodes.Unbox_Any, type);
        }

        private static void EmitCastToReference(ILGenerator il, System.Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, type);
            }
            else
            {
                il.Emit(OpCodes.Castclass, type);
            }
        }

        private static void EmitBoxIfNeeded(ILGenerator il, System.Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Box, type);
            }
        }

        private static void EmitFastInt(ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    return;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    return;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    return;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    return;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    return;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    return;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    return;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    return;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    return;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    return;
            }

            if (value > -129 && value < 128)
            {
                il.Emit(OpCodes.Ldc_I4_S, (SByte)value);
            }
            else
            {
                il.Emit(OpCodes.Ldc_I4, value);
            }
        }

        public static bool IL2CPPSave = true;
    }
}

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BlazeIL.il2cpp;

namespace BlazeIL
{
    unsafe public static class IL2Import
    {
        // ---------------------- [ IL2CPP Domain ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_domain_get();
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_domain_get_assemblies(IntPtr domain, ref uint count);

        // ---------------------- [ IL2CPP Assembly ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_assembly_get_image(IntPtr assembly);

        // ---------------------- [ IL2CPP Image ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_image_get_name(IntPtr image);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_image_get_class_count(IntPtr image);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_image_get_class(IntPtr image, uint index);

        // ---------------------- [ IL2CPP Class ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_name(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_namespace(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_class_get_flags(IntPtr klass, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_methods(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_fields(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_nested_types(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_properties(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_interfaces(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_type(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_type_get_object(IntPtr type);


        // ---------------------- [ IL2CPP Method ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_name(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_return_type(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_method_get_flags(IntPtr method, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_method_get_param_count(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_param(IntPtr method, uint index);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_param_name(IntPtr method, uint index);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_method_get_token(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_class_get_type_token(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static IntPtr il2cpp_runtime_invoke(IntPtr method, IntPtr obj, void** param, IntPtr exc);

        // ---------------------- [ IL2CPP Field ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_field_get_name(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_field_get_flags(IntPtr field, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_field_get_type(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static IntPtr il2cpp_field_get_value_object(IntPtr field, IntPtr obj);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static void il2cpp_field_static_set_value(IntPtr field, IntPtr value);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static void il2cpp_field_set_value(IntPtr obj, IntPtr field, IntPtr value);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_field_get_offset(IntPtr field);

        // ---------------------- [ IL2CPP Property ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_name(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_property_get_flags(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_get_method(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_set_method(IntPtr property);

        // ---------------------- [ Other's ] ---------------------- //
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static string il2cpp_type_get_name(IntPtr type);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_unbox(IntPtr obj);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_string_new(string str);
        

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_string_new_len(string str, int length);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_new(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_array_new(IntPtr elementTypeInfo, int length);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_array_class_get(IntPtr element_class, uint rank);

        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr VRC_PInvoke(IntPtr orig, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9);
        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void VRC_CreateHook(IntPtr pTarget, IntPtr pDetour, out IntPtr ppOrig);
        public static IntPtr StringToIntPtr(string str) => il2cpp_string_new(str);
        unsafe public static string IntPtrToString(IntPtr ptr) => new string((char*)ptr.ToPointer() + 10);
        public static IntPtr[] IL2CPPObjectArrayToIntPtrArray(IL2Object[] objtbl) => objtbl.Select(x => x.ptr).ToArray();
        unsafe public static IntPtr ObjectToIntPtr(object obj) { if (obj == null) return IntPtr.Zero; TypedReference reference = __makeref(obj); TypedReference* pRef = &reference; return (IntPtr)pRef; }
        public static IntPtr[] ObjectArrayToIntPtrArray(object[] objtbl) => objtbl.Select(x => ObjectToIntPtr(x)).ToArray();
        public static IntPtr CreateNewObject<T>(T value, IL2Type type) where T : unmanaged
        {
            IntPtr result = il2cpp_object_new(type.ptr);
            *(T*)(result + 0x10) = value;
            return result;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Type : IL2Base
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        private List<IL2Method> MethodList = new List<IL2Method>();
        private List<IL2Field> FieldList = new List<IL2Field>();
        //private List<IL2CPP_Event> EventList = new List<IL2CPP_Event>();
        private List<IL2Type> NestedTypeList = new List<IL2Type>();
        private List<IL2Property> PropertyList = new List<IL2Property>();
        public IL2Type(IntPtr newPtr) : base(newPtr)
        {
            ptr = newPtr;
            Name = Marshal.PtrToStringAnsi(IL2Import.il2cpp_class_get_name(newPtr));
            Namespace = Marshal.PtrToStringAnsi(IL2Import.il2cpp_class_get_namespace(newPtr));
            // Find Methods
            IntPtr method_iter = IntPtr.Zero;
            IntPtr method = IntPtr.Zero;
            while ((method = IL2Import.il2cpp_class_get_methods(newPtr, ref method_iter)) != IntPtr.Zero)
                MethodList.Add(new IL2Method(method));

            // Find Fields
            IntPtr field_iter = IntPtr.Zero;
            IntPtr field = IntPtr.Zero;
            while ((field = IL2Import.il2cpp_class_get_fields(newPtr, ref field_iter)) != IntPtr.Zero)
                FieldList.Add(new IL2Field(field));
            /*

            // Map out Events
            IntPtr evt_iter = IntPtr.Zero;
            IntPtr evt = IntPtr.Zero;
            while ((evt = IL2CPP.il2cpp_class_get_events(Ptr, ref evt_iter)) != IntPtr.Zero)
                EventList.Add(new IL2CPP_Event(evt));

            */
            // Find Nested Class
            IntPtr nestedtype_iter = IntPtr.Zero;
            IntPtr nestedtype = IntPtr.Zero;
            while ((nestedtype = IL2Import.il2cpp_class_get_nested_types(newPtr, ref nestedtype_iter)) != IntPtr.Zero)
                NestedTypeList.Add(new IL2Type(nestedtype));

            // Find Property
            IntPtr property_iter = IntPtr.Zero;
            IntPtr property = IntPtr.Zero;
            while ((property = IL2Import.il2cpp_class_get_properties(newPtr, ref property_iter)) != IntPtr.Zero)
                PropertyList.Add(new IL2Property(property));
        }

        public int token
        {
            get
            {
                if (iToken == null)
                {
                    iToken = IL2Import.il2cpp_class_get_type_token(ptr);
                    if (iToken == null)
                        return -1;
                }
                return (int)iToken;
            }
        }
        public int? iToken = null;

        public IL2BindingFlags GetFlags()
        {
            if (Flags == null)
            {
                uint flags = 0;
                Flags = (IL2BindingFlags)IL2Import.il2cpp_class_get_flags(ptr, ref flags);
                if (Flags == null)
                    return IL2BindingFlags.TYPE_CLASS;
            }

            return (IL2BindingFlags)Flags;
        }
        public bool HasFlag(IL2BindingFlags flag) => ((GetFlags() & flag) != 0);
        private IL2BindingFlags? Flags = null;

        public IL2Constructor[] GetConstructors() => MethodList.Where(x => x.Name.StartsWith(".c")).Select(x => new IL2Constructor(x.ptr)).ToArray();
        public IL2Constructor[] GetConstructors(Func<IL2Constructor, bool> func) => GetConstructors().Where(x => func(x)).ToArray();
        public IL2Constructor GetConstructor(Func<IL2Constructor, bool> func) => GetConstructors().First(x => func(x));

        // Methods
        public IL2Method[] GetMethods() => MethodList.ToArray();
        public IL2Method[] GetMethods(IL2BindingFlags flags) => GetMethods(flags, null);
        public IL2Method[] GetMethods(Func<IL2Method, bool> func) => GetMethods().Where(x => func(x)).ToArray();
        public IL2Method[] GetMethods(IL2BindingFlags flags, Func<IL2Method, bool> func) => GetMethods().Where(x => (((x.GetFlags() & flags) != 0) && func(x))).ToArray();
        public IL2Method GetMethod(string name) => GetMethod(name, null);
        public IL2Method GetMethod(string name, IL2BindingFlags flags) => GetMethod(name, flags, null);
        public IL2Method GetMethod(string name, Func<IL2Method, bool> func)
        {
            IL2Method returnval = null;
            foreach (IL2Method method in GetMethods())
            {
                if (method.Name.Equals(name) && ((func == null) || func(method)))
                {
                    returnval = method;
                    break;
                }
            }
            return returnval;
        }
        public IL2Method GetMethod(string name, IL2BindingFlags flags, Func<IL2Method, bool> func)
        {
            IL2Method returnval = null;
            foreach (IL2Method method in GetMethods())
            {
                if (method.Name.Equals(name) && method.HasFlag(flags) && ((func == null) || func(method)))
                {
                    returnval = method;
                    break;
                }
            }
            return returnval;
        }

        // Fields
        public IL2Field[] GetFields() => FieldList.ToArray();
        public IL2Field[] GetFields(IL2BindingFlags flags) => GetFields(flags, null);
        public IL2Field[] GetFields(Func<IL2Field, bool> func) => GetFields().Where(x => func(x)).ToArray();
        public IL2Field[] GetFields(IL2BindingFlags flags, Func<IL2Field, bool> func) => GetFields().Where(x => (((x.GetFlags() & flags) != 0) && func(x))).ToArray();
        public IL2Field GetField(string name) => GetField(name, null);
        public IL2Field GetField(string name, IL2BindingFlags flags) => GetField(name, flags, null);
        public IL2Field GetField(string name, Func<IL2Field, bool> func)
        {
            IL2Field returnval = null;
            foreach (IL2Field field in GetFields())
            {
                if (field.Name.Equals(name) && ((func == null) || func(field)))
                {
                    returnval = field;
                    break;
                }
            }
            return returnval;
        }
        public IL2Field GetField(string name, IL2BindingFlags flags, Func<IL2Field, bool> func)
        {
            IL2Field returnval = null;
            foreach (IL2Field field in GetFields())
            {
                if (field.Name.Equals(name) && field.HasFlag(flags) && ((func == null) || func(field)))
                {
                    returnval = field;
                    break;
                }
            }
            return returnval;
        }

        /*
        // Events
        public IL2CPP_Event[] GetEvents() => EventList.ToArray();
        */

        // Properties
        public IL2Property[] GetProperties() => PropertyList.ToArray();
        public IL2Property[] GetProperties(IL2BindingFlags flags) => GetProperties().Where(x => ((x.GetFlags() & flags) != 0)).ToArray();
        public IL2Property GetProperty(string name)
        {
            IL2Property returnval = null;
            foreach (IL2Property prop in GetProperties())
            {
                if (prop.Name.Equals(name))
                {
                    returnval = prop;
                    break;
                }
            }
            return returnval;
        }

        public IL2Property GetProperty(string name, IL2BindingFlags flags)
        {
            IL2Property returnval = null;
            foreach (IL2Property prop in GetProperties())
            {
                if (prop.Name.Equals(name) && prop.HasFlag(flags))
                {
                    returnval = prop;
                    break;
                }
            }
            return returnval;
        }

        // Nested Types
        public IL2Type[] GetNestedTypes() => NestedTypeList.ToArray();
        public IL2Type[] GetNestedTypes(IL2BindingFlags flags) => GetNestedTypes().Where(x => ((x.GetFlags() & flags) != 0)).ToArray();
        public IL2Type GetNestedType(string name) => GetNestedType(name, null);
        public IL2Type GetNestedType(string name, IL2BindingFlags flags) => GetNestedType(name, null, flags);
        public IL2Type GetNestedType(string name, string name_space)
        {
            IL2Type returnval = null;
            foreach (IL2Type type in GetNestedTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }
        public IL2Type GetNestedType(string name, string name_space, IL2BindingFlags flags)
        {
            IL2Type returnval = null;
            foreach (IL2Type type in GetNestedTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)) && type.HasFlag(flags))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }
    }
}

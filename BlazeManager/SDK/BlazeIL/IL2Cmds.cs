using System;
using System.Collections.Generic;
using BlazeIL.il2cpp;

namespace BlazeIL
{
    public class IL2Cmds
    {
        private static IntPtr domain;
        private static List<IL2Assembly> listAssemblies = new List<IL2Assembly>();

        internal static void onLoad()
        {
            domain = IL2Import.il2cpp_domain_get();

            uint count = 0;
            IntPtr assemblies = IL2Import.il2cpp_domain_get_assemblies(domain, ref count);
            IntPtr[] assembliesarr = IL2Tools.IntPtrToStructureArray<IntPtr>(assemblies, count);
            foreach (IntPtr assembly in assembliesarr)
                if (assembly != IntPtr.Zero)
                    listAssemblies.Add(new IL2Assembly(IL2Import.il2cpp_assembly_get_image(assembly)));
        }

        public static IL2Assembly[] GetAssemblies()
        {
            if (listAssemblies.Count == 0)
                onLoad();

            return listAssemblies.ToArray();
        }

        public static IL2Assembly GetAssembly(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            IL2Assembly returnval = null;
            foreach (IL2Assembly asm in GetAssemblies())
            {
                if (asm.Name.Equals(name))
                {
                    returnval = asm;
                    break;
                }
            }
            return returnval;
        }

        public static IL2Type GetClass(IntPtr findPtr)
        {
            if (findPtr == IntPtr.Zero)
                return null;
            IL2Type returnval = null;
            foreach (IL2Assembly asm in GetAssemblies())
            {
                returnval = asm.GetClass(findPtr);
                if (returnval != null)
                    break;
            }
            return returnval;
        }

        public static IL2Type GetClass(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
                return null;
            string name = string.Empty;
            string name_space = string.Empty;
            int idx = fullname.LastIndexOf('.');
            if (idx != -1)
            {
                name_space = fullname.Substring(0, idx);
                name = fullname.Substring(idx + 1);
            }
            else
                name = fullname;
            IL2Type returnval = null;
            foreach (IL2Assembly asm in GetAssemblies())
            {
                if (idx != -1)
                    returnval = asm.GetClass(name, name_space);
                else
                    returnval = asm.GetClass(name);
                if (returnval != null)
                    break;
            }
            return returnval;
        }
    }
}

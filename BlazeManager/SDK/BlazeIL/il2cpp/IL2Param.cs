using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Param : IL2Base
    {
        public string Name { get; private set; }
        internal IL2Param(IntPtr newPtr, string name) : base(newPtr)
        {
            ptr = newPtr;

            Name = name;
        }

        public string typeName => IL2Import.il2cpp_type_get_name(ptr);
    }
}
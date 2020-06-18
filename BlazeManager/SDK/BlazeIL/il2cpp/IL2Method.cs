using System;
using BlazeIL.il2reflection;

namespace BlazeIL.il2cpp
{
    public class IL2Method : IL2MethodBody
    {
        internal IL2Method(IntPtr newPtr) : base(newPtr) => ptr = newPtr;
    }
}

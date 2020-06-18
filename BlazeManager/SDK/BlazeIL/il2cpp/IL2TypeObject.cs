using System;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2TypeObject : IL2Base
    {
        public IL2TypeObject(IntPtr newPtr) : base(newPtr) => ptr = newPtr;
    }
}

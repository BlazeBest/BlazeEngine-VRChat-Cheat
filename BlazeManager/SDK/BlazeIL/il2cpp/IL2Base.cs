using System;

namespace BlazeIL.il2cpp
{
    public class IL2Base
    {
        public IntPtr ptr { get; set; }

        public IL2Base(IntPtr newPtr) => ptr = newPtr;
        public override bool Equals(object obj)
        {
            if (obj == null) return this == null;
            if (obj is IL2Base b) return b.ptr == ptr;
            return false;
        }
        public T MonoCast<T>() => ptr.MonoCast<T>();
        public override int GetHashCode() => ptr.GetHashCode();
        public static bool operator !=(IL2Base x, IL2Base y) => !(x == y);
        public static bool operator ==(IL2Base x, IL2Base y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.ptr == y.ptr;
        }
    }
}

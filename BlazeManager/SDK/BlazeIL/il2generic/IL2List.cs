using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

namespace BlazeIL.il2generic
{
    unsafe public class IL2List : IL2Base
    {
        public IL2List(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;


        private static IL2Method methodToArray = null;
        public IntPtr[] ToArray()
        {
            if (methodToArray == null)
            {
                methodToArray = Instance_Class.GetMethod("ToArray");
                if (methodToArray == null)
                    return null;
            }

            IL2Object result = methodToArray.Invoke(ptr);
            if (result == null)
                return null;

            return result.UnboxArray();
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("List`1", "System.Collections.Generic");
    }
}

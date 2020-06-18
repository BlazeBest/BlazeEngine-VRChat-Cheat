using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazeIL.il2cpp
{
    public class IL2ReturnType : IL2Base
    {
        internal IL2ReturnType(IntPtr newPtr) : base(newPtr) => ptr = newPtr;

        public string Name
        {
            get
            {
                if (sName == null)
                    sName = IL2Import.il2cpp_type_get_name(ptr);

                return sName;
            }
        }
        private string sName = null;

    }
}

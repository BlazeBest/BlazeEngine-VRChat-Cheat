using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    public class IL2FastCall
    {
        public static IL2Object Execute(ref object[] objs, IntPtr[] invoked)
        {
            // string name, ref IL2Field field, IL2Type type
            if (objs.Length != 3)
                return null;

            if (invoked.Length < 1)
            {
                invoked = new IntPtr[] { IntPtr.Zero };
            }

            if (objs[1].GetType() == typeof(IL2Field))
            {
                IL2Field field = (IL2Field)objs[2];
                if (IL2Get.Field((string)objs[0], (IL2Type)objs[1], ref field))
                {
                    objs[2] = field;
                    return field.GetValue(invoked[0]);
                }
            }

            if (objs[1].GetType() == typeof(IL2Property))
            {
                IL2Property property = (IL2Property)objs[2];
                if (IL2Get.Property((string)objs[0], (IL2Type)objs[1], ref property))
                {
                    objs[2] = property;
                    return property.GetGetMethod().Invoke(invoked[0]);
                }
            }

            return null;
        }
    }
}

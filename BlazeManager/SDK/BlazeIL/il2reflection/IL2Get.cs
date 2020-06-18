using System;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    internal class IL2Get
    {
        public static bool Constructor(Func<IL2Constructor, bool> func, IL2Type il2type, ref IL2Constructor il2constructor)
        {
            if (il2constructor == null)
                il2constructor = il2type.GetConstructor(func);

            return il2constructor != null;
        }

        public static bool Constructor(IL2Type il2type, ref IL2Constructor il2constructor)
        {
            if (il2constructor == null)
                il2constructor = il2type.GetConstructors()[0];

            return il2constructor != null;
        }

        public static bool Property(string name, IL2Type il2type, ref IL2Property il2property)
        {
            if (il2property == null)
                il2property = il2type.GetProperty(name);

            return il2property != null;
        }

        public static bool Method(string name, IL2Type il2type, ref IL2Method il2method)
        {
            if (il2method == null)
                il2method = il2type.GetMethod(name);

            return il2method != null;
        }
        public static bool Field(string name, IL2Type il2type, ref IL2Field il2field)
        {
            if (il2field == null)
                il2field = il2type.GetField(name);

            return il2field != null;
        }
    }
}

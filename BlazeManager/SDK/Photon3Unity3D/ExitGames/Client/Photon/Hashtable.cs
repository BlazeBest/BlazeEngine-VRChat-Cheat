using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace ExitGames.Client.Photon
{
    public class Hashtable : IL2Base
    {
        public Hashtable(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyItem = null;
        public object this[object key]
        {
            get
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return null;
                }

                return propertyItem.GetGetMethod().Invoke(ptr, new IntPtr[] { IL2Import.il2cpp_string_new_len((string)key, ((string)key).Length) }).ptr;
            }
            set
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return;
                }

                if (value.GetType() == typeof(string))
                    propertyItem.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.il2cpp_string_new_len((string)key, ((string)key).Length), IL2Import.il2cpp_string_new_len((string)value, ((string)value).Length) });
                else if(value.GetType() == typeof(bool))
                    propertyItem.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.il2cpp_string_new_len((string)key, ((string)key).Length), IL2Import.CreateNewObject((bool)value, BlazeTools.IL2SystemClass.Boolean)});
                else if(value.GetType() == typeof(IntPtr))
                    propertyItem.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.il2cpp_string_new_len((string)key, ((string)key).Length), (IntPtr)value });
            }
        }

//        public new IEnumerator<DictionaryEntry> GetEnumerator()
//        {
//            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
//        }

        static IL2Method methodToString = null;
        public override string ToString()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            return methodToString.Invoke(ptr)?.Unbox<string>();
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public static IL2Type Instance_Class = Assemblies.a["Photon3Unity3D"].GetClass("Hashtable", "ExitGames.Client.Photon");
    }
}
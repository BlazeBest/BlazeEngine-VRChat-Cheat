using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class Resources
    {
        private static IL2Method methodFindObjectsOfTypeAll = null;
        public static T[] FindObjectsOfTypeAll<T>()
        {
            Object[] objects = FindObjectsOfTypeAll(typeof(T));
            T[] result = new T[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = objects[i].MonoCast<T>();
            }
            return result;
        }
        public static Object[] FindObjectsOfTypeAll(Type type)
        {
            if (methodFindObjectsOfTypeAll == null)
            {
                methodFindObjectsOfTypeAll = Instance_Class.GetMethods()
                    .Where(x => x.Name == "FindObjectsOfTypeAll")
                    .First(x => x.GetReturnType().Name == "UnityEngine.Object[]");
                if (methodFindObjectsOfTypeAll == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodFindObjectsOfTypeAll.Invoke(new IntPtr[] { typeObject.ptr }).UnboxArray<Object>();
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Resources", "UnityEngine");
    }
}

using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class Object : IL2Base
    {
        public Object(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodGetInstantiate = null;
        public static T Instantiate<T>(T original, Transform parent) where T : IL2Base => Instantiate(original.MonoCast<Object>(), parent, false).MonoCast<T>();
        public static Object Instantiate(Object original, Transform parent) => Instantiate(original, parent, false);
        public static T Instantiate<T>(Object original, Transform parent, bool instantiateInWorldSpace) => Instantiate(original, parent, instantiateInWorldSpace).MonoCast<T>();
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
        {
            if (methodGetInstantiate == null)
            {
                methodGetInstantiate = Instance_Class.GetMethods()
                    .Where(x => x.Name == "Instantiate"
                        && x.GetParameters().Length == 3
                        && x.GetReturnType().Name == "UnityEngine.Object")
                    .First(x => x.GetParameters()[2].typeName == "System.Boolean");
                if (methodGetInstantiate == null)
                    return null;
            }

            return methodGetInstantiate.Invoke(new IntPtr[] { original.ptr, parent.ptr, instantiateInWorldSpace.MonoCast() })?.MonoCast<Object>();
        }

        private static IL2Method methodFindObjectsOfType = null;
        public static T FindObjectOfType<T>() => FindObjectOfType(typeof(T)).ptr.MonoCast<T>();
        public static T[] FindObjectsOfType<T>()
        {
            Object[] result = FindObjectsOfType(typeof(T));

            if (result != null)
                if (result.Length > 0)
                    return result.Select(x => x.MonoCast<T>()).ToArray();

            return new T[0];
        }

        public static Object FindObjectOfType(Type type) => FindObjectsOfType(type)[0];
        public static Object[] FindObjectsOfType(Type type)
        {
            if (methodFindObjectsOfType == null)
            {
                methodFindObjectsOfType = Instance_Class.GetMethod("FindObjectsOfType", x => x.GetParameters().Length == 1);
                if (methodFindObjectsOfType == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodFindObjectsOfType.Invoke(new IntPtr[] { typeObject.ptr }).UnboxArray<Object>();
        }

        private static IL2Method methodDestroy = null;
        public void Destroy() => Destroy(0f);
        public void Destroy(float time) => Destroy(this, time);
        public static void Destroy(Object obj) => Destroy(obj, 0f);
        public static void Destroy(Object obj, float time)
        {
            if (methodDestroy == null)
            {
                methodDestroy = Instance_Class.GetMethod("Destroy", m => m.GetParameters().Length == 2);
                if (methodDestroy == null)
                    return;
            }
            if (obj == null || time < 0)
                return;

            methodDestroy.Invoke(new IntPtr[] { obj.ptr, time.MonoCast() });
        }

        private static IL2Method methodFindObjectFromInstanceID = null;
        public static Object FindObjectFromInstanceID(int instanceID)
        {
            if (methodFindObjectFromInstanceID == null)
            {
                methodFindObjectFromInstanceID = Instance_Class.GetMethod("FindObjectFromInstanceID");
                if (methodFindObjectFromInstanceID == null)
                    return null;
            }

            return methodFindObjectFromInstanceID.Invoke(new IntPtr[] { instanceID.MonoCast() })?.MonoCast<Object>();
        }

        private static IL2Method methodDontDestroyOnLoad = null;
        public static void DontDestroyOnLoad(Object target)
        {
            if (methodDontDestroyOnLoad == null)
            {
                methodDontDestroyOnLoad = Instance_Class.GetMethod("DontDestroyOnLoad");
                if (methodDontDestroyOnLoad == null)
                    return;
            }

            methodDontDestroyOnLoad.Invoke(new IntPtr[] { target.ptr });
        }

        private static IL2Property propertyName = null;
        public string name
        {
            get
            {
                if(propertyName == null)
                {
                    propertyName = Instance_Class.GetProperty("name");
                    if (propertyName == null)
                        return null;
                }

                return propertyName.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (propertyName == null)
                {
                    propertyName = Instance_Class.GetProperty("name");
                    if (propertyName == null)
                        return;
                }

                propertyName.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }


        private static IL2Method methodToString = null;
        public override string ToString()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            return methodToString.Invoke(ptr)?.Unbox<string>();
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Object", "UnityEngine");
    }
}

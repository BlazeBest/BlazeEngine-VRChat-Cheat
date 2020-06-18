using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class GameObject : Object
    {
        public GameObject(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodAddComponent = null;
        public Component AddComponent(Type type)
        {
            if (methodAddComponent == null)
            {
                methodAddComponent = Instance_Class.GetMethod("AddComponent", m => m.GetParameters().Length == 1);
                if (methodAddComponent == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodAddComponent.Invoke(ptr, new IntPtr[] { typeObject.ptr })?.MonoCast<Component>();
        }

        public T AddComponent<T>() => AddComponent(typeof(T)).MonoCast<T>();

        private static IL2Method methodCreatePremetive = null;
        public static GameObject CreatePrimitive(PrimitiveType type)
        {
            if (methodCreatePremetive == null)
            {
                methodCreatePremetive = Instance_Class.GetMethod("CreatePrimitive");
                if (methodCreatePremetive == null)
                    return null;
            }

            return methodCreatePremetive.Invoke(new IntPtr[] { type.MonoCast() })?.MonoCast<GameObject>();
        }

        public T GetComponent<T>() => GetComponent(typeof(T)).ptr.MonoCast<T>();
        public Component GetComponent(Type type)
        {
            Component[] components = GetComponents(type);

            if (components != null)
                if (components.Length > 0)
                    return components[0];

            return null;
        }

        private static IL2Method methodGetComponentByName = null;
        public Component GetComponent(string type)
        {
            if (methodGetComponentByName == null)
            {
                methodGetComponentByName = Instance_Class.GetMethod("GetComponentByName");
                if (methodGetComponentByName == null)
                    return null;
            }

            return methodGetComponentByName.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(type) })?.Unbox<Component>();
        }

        private static IL2Method methodGetComponentInChildren = null;
        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).ptr.MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).ptr.MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            if (methodGetComponentInChildren == null)
            {
                methodGetComponentInChildren = Instance_Class.GetMethod("GetComponentInChildren", x => x.GetParameters().Length == 2);
                if (methodGetComponentInChildren == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodGetComponentInChildren.Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() })?.MonoCast<Component>();
        }

        private static IL2Method methodGetComponentsByType = null;
        public T[] GetComponents<T>() => GetComponents(typeof(T)).Select(x => x.MonoCast<T>()).ToArray();
        public Component[] GetComponents(Type type)
        {
            if (methodGetComponentsByType == null)
            {
                methodGetComponentsByType = Instance_Class.GetMethods()
                    .Where(x => x.Name == "GetComponents" && x.GetParameters().Length == 1)
                    .First(x => IL2Import.il2cpp_type_get_name(x.GetReturnType().ptr) == "UnityEngine.Component[]");
                if (methodGetComponentsByType == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = methodGetComponentsByType.Invoke(ptr, new IntPtr[] { typeObject.ptr });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        private static IL2Method methodGetComponentsInChildren = null;
        public T[] GetComponentsInChildren<T>() => GetComponentsInChildren<T>(false);
        public T[] GetComponentsInChildren<T>(bool includeInactive)
        {
            Component[] components = GetComponentsInChildren(typeof(T), includeInactive);
            if (components != null)
                if (components.Length > 0)
                    return components.Select(x => x.MonoCast<T>()).ToArray();

            return new T[0];
        }
        public Component[] GetComponentsInChildren(Type type) => GetComponentsInChildren(type, false);
        public Component[] GetComponentsInChildren(Type type, bool includeInactive)
        {
            if (methodGetComponentsInChildren == null)
            {
                methodGetComponentsInChildren = Instance_Class.GetMethods()
                    .Where(x => x.Name == "GetComponentsInChildren")
                    .Where(x => x.GetParameters().Length == 2)
                    .First(x => x.GetReturnType().Name == "UnityEngine.Component[]");
                if (methodGetComponentsInChildren == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = methodGetComponentsInChildren.Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        private static IL2Method methodFindWithTag = null;
        public static GameObject FindWithTag(string tag)
        {
            if (methodFindWithTag == null)
            {
                methodFindWithTag = Instance_Class.GetMethod("FindWithTag");
                if (methodFindWithTag == null)
                    return null;
            }

            return methodFindWithTag.Invoke(new IntPtr[] { IL2Import.StringToIntPtr(tag) })?.MonoCast<GameObject>();
        }

        private static IL2Property propertyTransform = null;
        public Transform transform
        {
            get
            {
                if (propertyTransform == null)
                {
                    propertyTransform = Instance_Class.GetProperty("transform");
                    if (propertyTransform == null)
                        return null;
                }

                return propertyTransform.GetGetMethod().Invoke(ptr)?.Unbox<Transform>();
            }
        }

        private static IL2Property propertyLayer = null;
        public int layer
        {
            get
            {
                if (propertyLayer == null)
                {
                    propertyLayer = Instance_Class.GetProperty("layer");
                    if (propertyLayer == null)
                        return default;
                }

                return propertyLayer.GetGetMethod().Invoke(ptr).Unbox<int>();
            }
            set
            {
                if (propertyLayer == null)
                {
                    propertyLayer = Instance_Class.GetProperty("layer");
                    if (propertyLayer == null)
                        return;
                }

                propertyLayer.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyActive = null;
        public bool active
        {
            get
            {
                if (propertyActive == null)
                {
                    propertyActive = Instance_Class.GetProperty("active");
                    if (propertyActive == null)
                        return default;
                }

                return propertyActive.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyActive == null)
                {
                    propertyActive = Instance_Class.GetProperty("active");
                    if (propertyActive == null)
                        return;
                }

                propertyActive.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Method methodSetActive = null;
        public void SetActive(bool value)
        {
            if (methodSetActive == null)
            {
                methodSetActive = Instance_Class.GetMethod("SetActive");
                if (methodSetActive == null)
                    return;
            }

            methodSetActive.Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        private static IL2Property propertyActiveSelf = null;
        public bool activeSelf
        {
            get
            {
                if (propertyActiveSelf == null)
                {
                    propertyActiveSelf = Instance_Class.GetProperty("activeSelf");
                    if (propertyActiveSelf == null)
                        return default;
                }

                return propertyActiveSelf.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyActiveInHierarchy = null;
        public bool activeInHierarchy
        {
            get
            {
                if (propertyActiveInHierarchy == null)
                {
                    propertyActiveInHierarchy = Instance_Class.GetProperty("activeInHierarchy");
                    if (propertyActiveInHierarchy == null)
                        return default;
                }

                return propertyActiveInHierarchy.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Method methodSetActiveRecursively = null;
        public void SetActiveRecursively(bool value)
        {
            if (methodSetActiveRecursively == null)
            {
                methodSetActiveRecursively = Instance_Class.GetMethod("SetActiveRecursively");
                if (methodSetActiveRecursively == null)
                    return;
            }

            methodSetActiveRecursively.Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        private static IL2Property propertyIsStatic = null;
        public bool isStatic
        {
            get
            {
                if (propertyIsStatic == null)
                {
                    propertyIsStatic = Instance_Class.GetProperty("isStatic");
                    if (propertyIsStatic == null)
                        return default;
                }

                return propertyIsStatic.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyIsStatic == null)
                {
                    propertyIsStatic = Instance_Class.GetProperty("isStatic");
                    if (propertyIsStatic == null)
                        return;
                }

                propertyIsStatic.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyTag = null;
        public string tag
        {
            get
            {
                if (propertyTag == null)
                {
                    propertyTag = Instance_Class.GetProperty("tag");
                    if (propertyTag == null)
                        return null;
                }

                return propertyTag.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (propertyTag == null)
                {
                    propertyTag = Instance_Class.GetProperty("tag");
                    if (propertyTag == null)
                        return;
                }

                propertyTag.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        public GameObject gameObject
        {
            get => this;
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}

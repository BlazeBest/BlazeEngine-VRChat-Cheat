using System;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Component : Object
    {
        public Component(IntPtr ptrONew) : base(ptrONew) =>
            ptr = ptrONew;

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

        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive) => gameObject.GetComponentInChildren(type, includeInactive);
        public T GetComponent<T>() => gameObject.GetComponent<T>();
        public T[] GetComponents<T>() => gameObject.GetComponents<T>();
        public Component GetComponent(Type type) => gameObject.GetComponent(type);
        public Component GetComponent(string type) => gameObject.GetComponent(type);
        public Component[] GetComponents(Type type) => gameObject.GetComponents(type);

        public string tag
        {
            get => gameObject.tag;
            set => gameObject.tag = value;
        }

        private static IL2Property propertyGameObject = null;
        public GameObject gameObject
        {
            get
            {
                if (propertyGameObject == null)
                {
                    propertyGameObject = Instance_Class.GetProperty("gameObject");
                    if (propertyGameObject == null)
                        return null;
                }

                return propertyGameObject.GetGetMethod().Invoke(ptr)?.Unbox<GameObject>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Component", "UnityEngine");
    }
}

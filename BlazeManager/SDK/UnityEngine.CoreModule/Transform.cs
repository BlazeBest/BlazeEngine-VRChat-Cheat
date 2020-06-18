using System;
using System.Collections;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Transform : Component, IEnumerable
    {
        public Transform(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyForward = null;
        public Vector3 forward
        {
            get
            {
                if (propertyForward == null)
                {
                    propertyForward = Instance_Class.GetProperty("forward");
                    if (propertyForward == null)
                        return default;
                }

                return propertyForward.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
            }
        }

        private static IL2Property propertyRight = null;
        public Vector3 right
        {
            get
            {
                if (propertyRight == null)
                {
                    propertyRight = Instance_Class.GetProperty("right");
                    if (propertyRight == null)
                        return default;
                }

                return propertyRight.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
            }
        }

        private static IL2Property propertyPosition = null;
        public Vector3 position
        {
            get
            {
                if (propertyPosition == null)
                {
                    propertyPosition = Instance_Class.GetProperty("position");
                    if (propertyPosition == null)
                        return default;
                }

                return propertyPosition.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
            }
            set
            {
                if (propertyPosition == null)
                {
                    propertyPosition = Instance_Class.GetProperty("position");
                    if (propertyPosition == null)
                        return;
                }

                propertyPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyLocalPosition = null;
        public Vector3 localPosition
        {
            get
            {
                if (propertyLocalPosition == null)
                {
                    propertyLocalPosition = Instance_Class.GetProperty("localPosition");
                    if (propertyLocalPosition == null)
                        return default;
                }

                return propertyLocalPosition.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
            }
            set
            {
                if (propertyLocalPosition == null)
                {
                    propertyLocalPosition = Instance_Class.GetProperty("localPosition");
                    if (propertyLocalPosition == null)
                        return;
                }

                propertyLocalPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyRotation = null;
        public Quaternion rotation
        {
            get
            {
                if (propertyRotation == null)
                {
                    propertyRotation = Instance_Class.GetProperty("rotation");
                    if (propertyRotation == null)
                        return default;
                }

                return propertyRotation.GetGetMethod().Invoke(ptr).Unbox<Quaternion>();
            }
            set
            {
                if (propertyRotation == null)
                {
                    propertyRotation = Instance_Class.GetProperty("rotation");
                    if (propertyRotation == null)
                        return;
                }

                propertyRotation.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Method methodFind = null;
        public Transform Find(string name)
        {
            if (methodFind == null)
            {
                methodFind = Instance_Class.GetMethod("Find");
                if (methodFind == null)
                    return null;
            }

            return methodFind.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(name) } )?.Unbox<Transform>();
        }

        private static IL2Property propertyChildCount = null;
        public int childCount
        {
            get
            {
                if (propertyChildCount == null)
                {
                    propertyChildCount = Instance_Class.GetProperty("childCount");
                    if (propertyChildCount == null)
                        return default;
                }

                return propertyChildCount.GetGetMethod().Invoke(ptr).Unbox<int>();
            }
        }

        private static IL2Property propertyParent = null;
        public Transform parent
        {
            get
            {
                if (propertyParent == null)
                {
                    propertyParent = Instance_Class.GetProperty("parent");
                    if (propertyParent == null)
                        return null;
                }

                return propertyParent.GetGetMethod().Invoke(ptr)?.Unbox<Transform>();
            }
            set
            {
                if (propertyParent == null)
                {
                    propertyParent = Instance_Class.GetProperty("parent");
                    if (propertyParent == null)
                        return;
                }

                propertyParent.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
            }
        }

        private static IL2Method methodGetChild = null;
        public Transform GetChild(int index)
        {
            if (methodGetChild == null)
            {
                methodGetChild = Instance_Class.GetMethod("GetChild");
                if (methodGetChild == null)
                    return null;
            }

            return methodGetChild.Invoke(ptr, new IntPtr[] { index.MonoCast() })?.Unbox<Transform>();
        }

        private static IL2Method methodSetSiblingIndex = null;
        public void SetSiblingIndex(int index)
        {
            if (methodSetSiblingIndex == null)
            {
                methodSetSiblingIndex = Instance_Class.GetMethod("SetSiblingIndex");
                if (methodSetSiblingIndex == null)
                    return;
            }

            methodSetSiblingIndex.Invoke(ptr, new IntPtr[] { index.MonoCast() });
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private sealed class Enumerator : IEnumerator
        {
            internal Enumerator(Transform outer)
            {
                this.outer = outer;
            }

            public object Current
            {
                get
                {
                    return outer.GetChild(currentIndex);
                }
            }

            public bool MoveNext()
            {
                int childCount = outer.childCount;
                return ++currentIndex < childCount;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            private Transform outer;

            private int currentIndex = -1;
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Transform", "UnityEngine");
    }
}

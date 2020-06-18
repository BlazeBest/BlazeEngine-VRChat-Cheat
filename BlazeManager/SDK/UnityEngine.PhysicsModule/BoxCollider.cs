using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class BoxCollider : Collider
    {
        public BoxCollider(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

		private static IL2Property propertyCenter = null;
		public Vector3 center
		{
			get
			{
				if (!IL2Get.Property("center", Instance_Class, ref propertyCenter))
					return default;

				return propertyCenter.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
			}
			set
			{
				if (!IL2Get.Property("center", Instance_Class, ref propertyCenter))
					return;

				propertyCenter.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
		}

		private static IL2Property propertySize = null;
		public Vector3 size
		{
			get
			{
				if (!IL2Get.Property("size", Instance_Class, ref propertySize))
					return default;

				return propertySize.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
			}
			set
			{
				if (!IL2Get.Property("size", Instance_Class, ref propertySize))
					return;

				propertySize.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
		}

		private static IL2Property propertyExtents = null;
		public Vector3 extents
		{
			get
			{
				if (!IL2Get.Property("extents", Instance_Class, ref propertyExtents))
					return default;

				return propertySize.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
			}
			set
			{
				if (!IL2Get.Property("extents", Instance_Class, ref propertyExtents))
					return;

				propertySize.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
		}

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("BoxCollider", "UnityEngine");
    }
}

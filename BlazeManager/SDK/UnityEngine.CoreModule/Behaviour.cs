using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Behaviour : Component
	{
		public Behaviour(IntPtr ptrONew) : base(ptrONew) =>
			ptr = ptrONew;

		private static IL2Property propertyEnabled = null;
		public bool enabled
		{
			get
			{
				if (!IL2Get.Property("enabled", Instance_Class, ref propertyEnabled))
					return false;

				return propertyEnabled.GetGetMethod().Invoke(ptr).Unbox<bool>();
			}
			set
			{
				if (!IL2Get.Property("enabled", Instance_Class, ref propertyEnabled))
					return;

				propertyEnabled.GetGetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
		}

		private static IL2Property propertyIsActiveAndEnabled = null;
		public bool isActiveAndEnabled
		{
			get
			{
				if (!IL2Get.Property("propertyIsActiveAndEnabled", Instance_Class, ref propertyIsActiveAndEnabled))
					return false;

				return propertyIsActiveAndEnabled.GetGetMethod().Invoke(ptr).Unbox<bool>();
			}
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Behaviour", "UnityEngine");
	}
}

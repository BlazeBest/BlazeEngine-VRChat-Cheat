using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace BlazeIL.il2generic
{
    unsafe public class IL2Dictionary : IL2Base
	{
		public IL2Dictionary(IntPtr ptrNew) : base(ptrNew) =>
			ptr = ptrNew;

		private static IL2Property propertyCount = null;
		public int Count
		{
			get
			{
				if (propertyCount == null)
				{
					propertyCount = Instance_Class.GetProperty("Count");
					if (propertyCount == null)
						return default;
				}

				IL2Object result = propertyCount.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return result.Unbox<int>();
			}
		}

		private static IL2Method methodFindEntry = null;
		public int FindEntry(IntPtr key)
		{
			if (methodFindEntry == null)
			{
				methodFindEntry = Instance_Class.GetMethod("FindEntry");
				if (methodFindEntry == null)
					return default;
			}
			IL2Object result = methodRemove.Invoke(ptr, new IntPtr[] { key });
			if (result == null)
				return default;

			return result.Unbox<int>();
		}

		private static IL2Method methodAdd = null;
		public void Add(IntPtr key, IntPtr value)
		{
			if (methodAdd == null)
			{
				methodAdd = Instance_Class.GetMethod("Add");
				if (methodAdd == null)
					return;
			}
			methodAdd.Invoke(ptr, new IntPtr[] { key, value });
		}
		
		private static IL2Method methodRemove = null;
		public bool Remove(IntPtr key)
		{
			if (methodRemove == null)
			{
				methodRemove = Instance_Class.GetMethod("Remove");
				if (methodRemove == null)
					return default;
			}
			IL2Object result = methodRemove.Invoke(ptr, new IntPtr[] { key });
			if (result == null)
				return default;

			return result.Unbox<bool>();
		}

		private static IL2Method methodClear = null;
		public void Clear()
		{
			if (methodClear == null)
			{
				methodClear = Instance_Class.GetMethod("Clear");
				if (methodClear == null)
					return;
			}
			methodClear.Invoke(ptr);
		}

		public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("Dictionary`2", "System.Collections.Generic");
    }
}

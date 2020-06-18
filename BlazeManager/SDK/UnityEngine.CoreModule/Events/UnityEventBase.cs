using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine.Events
{
    public class UnityEventBase : IL2Base
    {
        public UnityEventBase(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodRemoveAllListeners = null;
        public void RemoveAllListeners()
        {
            if (!IL2Get.Method("RemoveAllListeners", Instance_Class, ref methodRemoveAllListeners))
                return;

            methodRemoveAllListeners.Invoke(ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}

using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    // Player : MonoBehavior -> Behavior -> Component
    unsafe public class VRC_PlayerApi : Component
    {
        public VRC_PlayerApi(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodGetIsMaster = null;
        public bool isMaster
        {
            get
            {
                if (methodGetIsMaster == null )
                {
                    methodGetIsMaster = Instance_Class.GetMethod("get_isMaster");
                    if (methodGetIsMaster == null)
                        return default;
                }

                IL2Object result = methodGetIsMaster.Invoke(ptr);
                if (result == null)
                    return default;

                return result.Unbox<bool>();
            }
        }

        private static IL2Method methodGetIsModerator = null;
        public bool isModerator
        {
            get
            {
                if (methodGetIsModerator == null)
                {
                    methodGetIsModerator = Instance_Class.GetMethod("get_isModerator");
                    if (methodGetIsModerator == null)
                        return default;
                }

                IL2Object result = null;
                result = methodGetIsModerator.Invoke(ptr);
                if (result == null)
                    return default;

                return result.Unbox<bool>();
            }
        }

        private static IL2Method methodGetIsSuper = null;
        public bool isSuper
        {
            get
            {
                if (methodGetIsSuper == null)
                {
                    methodGetIsSuper = Instance_Class.GetMethod("get_isSuper");
                    if (methodGetIsSuper == null)
                        return default;
                }

                IL2Object result = methodGetIsSuper.Invoke(ptr);
                if (result == null)
                    return default;

                return result.Unbox<bool>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("VRC_PlayerApi", "VRCSDK2");
    }
}

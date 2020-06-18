using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.Core;

namespace VRC
{
    public class Player : Component
    {
        public Player(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyGetInstance = null;
        public static Player Instance
        {
            get
            {
                if (propertyGetInstance == null)
                {
                    propertyGetInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Player");
                    if (propertyGetInstance == null)
                        return null;
                }

                return propertyGetInstance.GetGetMethod().Invoke()?.Unbox<Player>();
            }
        }

        internal static IL2Method methodUpdateModeration = null;
        public void UpdateModeration()
        {
            if (methodUpdateModeration == null)
                return;

            methodUpdateModeration.Invoke(ptr);
        }

        private static IL2Property propertyApiPlayer = null;
        public VRCSDK2.VRC_PlayerApi apiPlayer
        {
            get
            {
                if (propertyApiPlayer == null)
                {
                    propertyApiPlayer = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCSDK2.VRC_PlayerApi");
                    if (propertyApiPlayer == null)
                        return null;
                }

                return propertyApiPlayer.GetGetMethod().Invoke(ptr)?.Unbox<VRCSDK2.VRC_PlayerApi>();
            }
        }

        private static IL2Property propertyApiuser = null;
        public APIUser apiuser
        {
            get
            {
                if (propertyApiuser == null)
                {
                    propertyApiuser = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Core.APIUser");
                    if (propertyApiuser == null)
                        return null;
                }

                return propertyApiuser.GetGetMethod().Invoke(ptr)?.Unbox<APIUser>();
            }
        }

        private static IL2Property propertyPlayerNet = null;
        public IntPtr PlayerNet
        {
            get
            {
                if (propertyPlayerNet == null)
                {
                    propertyPlayerNet = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "PlayerNet");
                    if (propertyPlayerNet == null)
                        return IntPtr.Zero;
                }

                IL2Object result = propertyPlayerNet.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return IntPtr.Zero;

                return result.ptr;
            }
        }

        private static IL2Field fieldPhotonPlayer = null;
        public PhotonPlayer photonPlayer
        {
            get
            {
                if (fieldPhotonPlayer == null)
                {
                    fieldPhotonPlayer = Instance_Class.GetFields().First(x => x.GetReturnType().Name == PhotonPlayer.Instance_Class.Name);
                    if (fieldPhotonPlayer == null)
                        return null;
                }

                return fieldPhotonPlayer.GetValue(ptr)?.Unbox<PhotonPlayer>();
            }
        }

        private static IL2Field fieldVrcPlayer = null;
        public VRCPlayer vrcPlayer
        {
            get
            {
                if (fieldVrcPlayer == null)
                {
                    fieldVrcPlayer = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRCPlayer");
                    if (fieldVrcPlayer == null)
                        return null;
                }

                return fieldVrcPlayer.GetValue(ptr)?.Unbox<VRCPlayer>();
            }
        }

        private static IL2Field fieldUSpeaker = null;
        public USpeaker uSpeaker
        {
            get
            {
                if (fieldUSpeaker == null)
                {
                    fieldUSpeaker = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "USpeaker");
                    if (fieldUSpeaker == null)
                        return null;
                }

                return fieldUSpeaker.GetValue(ptr)?.Unbox<USpeaker>();
            }
        }

        public static IL2Method methodApplyMute = null;
        public void ApplyMute(bool status)
        {
            if (methodApplyMute == null)
                return;

            methodApplyMute.Invoke(ptr, status.MonoCast());
        }

        public static IL2Method methodApplyBlock = null;
        public void ApplyBlock(bool status)
        {
            if (methodApplyBlock == null)
                return;

            methodApplyBlock.Invoke(ptr, status.MonoCast());
        }

        private static IL2Method methodToString = null;
        public override string ToString()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            return methodToString.Invoke(ptr)?.Unbox<string>();
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Player", "VRC");
    }
}

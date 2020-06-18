using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    unsafe public class VRC_EventHandler : Component
    {
        public VRC_EventHandler(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodBooleanOp = null;
        public static bool BooleanOp(VRC_EventHandler.VrcBooleanOp Op, bool Current)
        {
            if (methodBooleanOp == null)
            {
                methodBooleanOp = Instance_Class.GetMethod("BooleanOp");
                if (methodBooleanOp == null)
                    return default;
            }
            return methodBooleanOp.Invoke(IntPtr.Zero, new IntPtr[] { new IntPtr(&Op), new IntPtr(&Current) }).Unbox<bool>();
        }


        private static IL2Property propertyNetworkID = null;
        public int NetworkID
        {
            get
            {
                if (propertyNetworkID == null)
                {
                    propertyNetworkID = Instance_Class.GetProperty("NetworkID");
                    if (propertyNetworkID == null)
                        return -1;
                }

                return propertyNetworkID.GetGetMethod().Invoke(ptr, new IntPtr[0]).Unbox<int>();
            }
            set
            {
                if (propertyNetworkID == null)
                {
                    propertyNetworkID = Instance_Class.GetProperty("NetworkID");
                    if (propertyNetworkID == null)
                        return;
                }

                propertyNetworkID.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        
        public class VrcEvent : IL2Base
        {
            public VrcEvent(IntPtr ptrNew) : base(ptrNew) =>
                ptr = ptrNew;

            private static IL2Method constructVrcEvent = null;
            public VrcEvent() : base(IntPtr.Zero)
            {
                if (constructVrcEvent == null)
                {
                    constructVrcEvent = Instance_Class.GetMethod(".ctor");
                    if (constructVrcEvent == null)
                        return;
                }
                ptr = constructVrcEvent.Invoke().ptr;
            }

            private static IL2Field fieldName = null;
            public string Name
            {
                get
                {
                    if (fieldName == null)
                    {
                        fieldName = Instance_Class.GetField("Name");
                        if (fieldName == null)
                            return null;
                    }

                    return fieldName.GetValue(ptr).Unbox<string>();
                }
                set
                {
                    if (fieldName == null)
                    {
                        fieldName = Instance_Class.GetField("Name");
                        if (fieldName == null)
                            return;
                    }

                    fieldName.SetValue(ptr, IL2Import.StringToIntPtr(value));
                }
            }

            private static IL2Field fieldEventType = null;
            public VrcEventType EventType
            {
                get
                {
                    if (fieldEventType == null)
                    {
                        fieldEventType = Instance_Class.GetField("EventType");
                        if (fieldEventType == null)
                            return VrcEventType.ActivateCustomTrigger;
                    }

                    return fieldEventType.GetValue(ptr).Unbox<VrcEventType>();
                }
                set
                {
                    if (fieldEventType == null)
                    {
                        fieldEventType = Instance_Class.GetField("EventType");
                        if (fieldEventType == null)
                            return;
                    }

                    fieldEventType.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Field fieldParameterString = null;
            public string ParameterString
            {
                get
                {
                    if (fieldParameterString == null)
                    {
                        fieldParameterString = Instance_Class.GetField("ParameterString");
                        if (fieldParameterString == null)
                            return null;
                    }

                    return fieldParameterString.GetValue(ptr).Unbox<string>();
                }
                set
                {
                    if (fieldParameterString == null)
                    {
                        fieldParameterString = Instance_Class.GetField("ParameterString");
                        if (fieldParameterString == null)
                            return;
                    }

                    fieldParameterString.SetValue(ptr, IL2Import.StringToIntPtr(value));
                }
            }

            private static IL2Field fieldParameterBoolOp = null;
            public VrcBooleanOp ParameterBoolOp
            {
                get
                {
                    if (fieldParameterBoolOp == null)
                    {
                        fieldParameterBoolOp = Instance_Class.GetField("ParameterBoolOp");
                        if (fieldParameterBoolOp == null)
                            return VrcBooleanOp.False;
                    }

                    return fieldParameterBoolOp.GetValue(ptr).Unbox<VrcBooleanOp>();
                }
                set
                {
                    if (fieldParameterBoolOp == null)
                    {
                        fieldParameterBoolOp = Instance_Class.GetField("ParameterBoolOp");
                        if (fieldParameterBoolOp == null)
                            return;
                    }

                    fieldParameterBoolOp.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Field fieldParameterBool = null;
            public bool ParameterBool
            {
                get
                {
                    if (fieldParameterBool == null)
                    {
                        fieldParameterBool = Instance_Class.GetField("ParameterBool");
                        if (fieldParameterBool == null)
                            return default;
                    }

                    return fieldParameterBool.GetValue(ptr).Unbox<bool>();
                }
                set
                {
                    if (fieldParameterBool == null)
                    {
                        fieldParameterBool = Instance_Class.GetField("ParameterBool");
                        if (fieldParameterBool == null)
                            return;
                    }
                    if (this == null)
                        return;

                    fieldParameterBool.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Field fieldParameterFloat = null;
            public float ParameterFloat
            {
                get
                {
                    if (fieldParameterFloat == null)
                    {
                        fieldParameterFloat = Instance_Class.GetField("ParameterFloat");
                        if (fieldParameterFloat == null)
                            return default;
                    }

                    return fieldParameterFloat.GetValue(ptr).Unbox<float>();
                }
                set
                {
                    if (fieldParameterFloat == null)
                    {
                        fieldParameterFloat = Instance_Class.GetField("ParameterFloat");
                        if (fieldParameterFloat == null)
                            return;
                    }

                    fieldParameterFloat.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Field fieldParameterInt = null;
            public int ParameterInt
            {
                get
                {
                    if (fieldParameterInt == null)
                    {
                        fieldParameterInt = Instance_Class.GetField("ParameterInt");
                        if (fieldParameterInt == null)
                            return default;
                    }

                    return fieldParameterInt.GetValue(ptr).Unbox<int>();
                }
                set
                {
                    if (fieldParameterInt == null)
                    {
                        fieldParameterInt = Instance_Class.GetField("ParameterInt");
                        if (fieldParameterInt == null)
                            return;
                    }

                    fieldParameterInt.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Field fieldParameterObject = null;
            public GameObject ParameterObject
            {
                get
                {
                    if (fieldParameterObject == null)
                    {
                        fieldParameterObject = Instance_Class.GetField("ParameterObject");
                        if (fieldParameterObject == null)
                            return null;
                    }

                    return fieldParameterObject.GetValue(ptr).ptr.MonoCast<GameObject>();
                }
                set
                {
                    if (fieldParameterObject == null)
                    {
                        fieldParameterObject = Instance_Class.GetField("ParameterObject");
                        if (fieldParameterObject == null)
                            return;
                    }

                    fieldParameterObject.SetValue(ptr, value.ptr);
                }
            }

            private static IL2Field fieldParameterObjects = null;
            public GameObject[] ParameterObjects
            {
                get
                {
                    if (fieldParameterObjects == null)
                    {
                        fieldParameterObjects = Instance_Class.GetField("ParameterObjects");
                        if (fieldParameterObjects == null)
                            return null;
                    }

                    IL2Object result = fieldParameterObjects.GetValue(ptr);
                    if (result == null)
                        return null;

                    return result.UnboxArray<GameObject>();
                }
                set
                {
                    if (fieldParameterObjects == null)
                    {
                        fieldParameterObjects = Instance_Class.GetField("ParameterObjects");
                        if (fieldParameterObjects == null)
                            return;
                    }

                    List<IntPtr> intPtrs = new List<IntPtr>();
                    for (int i = 0; i < value.Length; i++)
                        intPtrs.Add(value[i].ptr);

                    fieldParameterObjects.SetValue(ptr, intPtrs.ToArray().ArrayToIntPtr(GameObject.Instance_Class));
                }
            }

            private static IL2Field fieldParameterBytes = null;
            public byte[] ParameterBytes
            {
                get
                {
                    if (fieldParameterBytes == null)
                    {
                        fieldParameterBytes = Instance_Class.GetField("ParameterBytes");
                        if (fieldParameterBytes == null)
                            return null;
                    }
                    
                    IL2Object result = fieldParameterBytes.GetValue(ptr);
                    if (result == null)
                        return null;

                    return result.UnboxArray<byte>();
                }
                set
                {
                    if (fieldParameterBytes == null)
                    {
                        fieldParameterBytes = Instance_Class.GetField("ParameterBytes");
                        if (fieldParameterBytes == null)
                            return;
                    }
                    if (this == null)
                        return;


                    IntPtr[] pointerArray = new IntPtr[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        fixed (byte* pointer = &value[i])
                        {
                            pointerArray[i] = new IntPtr(pointer);
                        }
                    }
                    // Not work
                    // fieldParameterBytes.SetValue(ptr, Execute.IntPtrArrayToIntPtr(pointerArray));
                }
            }

            private static IL2Field fieldParameterBytesVersion = null;
            public int? ParameterBytesVersion
            {
                get
                {
                    if (fieldParameterBytesVersion == null)
                    {
                        fieldParameterBytesVersion = Instance_Class.GetField("ParameterBytesVersion");
                        if (fieldParameterBytesVersion == null)
                            return null;
                    }
                    if (this == null)
                        return null;

                    var result = fieldParameterBytesVersion.GetValue(ptr);
                    if (result == null)
                        return null;

                    return result.Unbox<int>();
                }
                set
                {
                    if (fieldParameterBytesVersion == null)
                    {
                        fieldParameterBytesVersion = Instance_Class.GetField("ParameterBytesVersion");
                        if (fieldParameterBytesVersion == null)
                            return;
                    }
                    if (this == null)
                        return;

                    var temp = (int)value;
                    fieldParameterBytesVersion.SetValue(ptr, value == null ? IL2Import.ObjectToIntPtr(null) : new IntPtr(&temp));
                }
            }

            private static IL2Field fieldTakeOwnershipOfTarget = null;
            public bool TakeOwnershipOfTarget
            {
                get
                {
                    if (fieldTakeOwnershipOfTarget == null)
                    {
                        fieldTakeOwnershipOfTarget = Instance_Class.GetField("TakeOwnershipOfTarget");
                        if (fieldTakeOwnershipOfTarget == null)
                            return false;
                    }
                    if (this == null)
                        return false;

                    return fieldTakeOwnershipOfTarget.GetValue(ptr).Unbox<bool>();
                }
                set
                {
                    if (fieldTakeOwnershipOfTarget == null)
                    {
                        fieldTakeOwnershipOfTarget = Instance_Class.GetField("TakeOwnershipOfTarget");
                        if (fieldTakeOwnershipOfTarget == null)
                            return;
                    }
                    if (this == null)
                        return;

                    fieldTakeOwnershipOfTarget.SetValue(ptr, new IntPtr(&value));
                }
            }

            private static IL2Type Instance = Assemblies.a["VRCSDK2"].GetClass("VRCSDK2.VRC_EventHandler.VrcEvent");
        }

        public enum VrcEventType
        {
            MeshVisibility,
            AnimationFloat,
            AnimationBool,
            AnimationTrigger,
            AudioTrigger,
            PlayAnimation,
            SendMessage,
            SetParticlePlaying,
            TeleportPlayer,
            RunConsoleCommand,
            SetGameObjectActive,
            SetWebPanelURI,
            SetWebPanelVolume,
            SpawnObject,
            SendRPC,
            ActivateCustomTrigger,
            DestroyObject,
            SetLayer,
            SetMaterial,
            AddHealth,
            AddDamage,
            SetComponentActive,
            AnimationInt,
            AnimationIntAdd = 24,
            AnimationIntSubtract,
            AnimationIntMultiply,
            AnimationIntDivide,
            AddVelocity,
            SetVelocity,
            AddAngularVelocity,
            SetAngularVelocity,
            AddForce,
            SetUIText,
            CallUdonMethod
        }

        public enum VrcBroadcastType
        {
            Always,
            Master,
            Local,
            Owner,
            AlwaysUnbuffered,
            MasterUnbuffered,
            OwnerUnbuffered,
            AlwaysBufferOne,
            MasterBufferOne,
            OwnerBufferOne
        }

        public enum VrcTargetType
        {
            All,
            Others,
            Owner,
            Master,
            AllBuffered,
            OthersBuffered,
            Local,
            AllBufferOne,
            OthersBufferOne,
            TargetPlayer
        }

        public enum VrcBooleanOp
        {
            Unused = -1,
            False,
            True,
            Toggle
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCSDK2"].GetClass("VRC_EventHandler", "VRCSDK2");
    }
}
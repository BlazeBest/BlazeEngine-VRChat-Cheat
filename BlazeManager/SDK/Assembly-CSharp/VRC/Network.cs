using System;
using System.Linq;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRCSDK2;

namespace VRC
{
    unsafe public static class Network
    {
        private static IL2Method methodGetOwnerId = null;
        public static int? GetOwnerId(GameObject obj)
        {
            if (methodGetOwnerId == null)
            {
                methodGetOwnerId = Instance_Class.GetMethods().First(x => x.GetReturnType().Name == "System.Nullable<System.Int32>");
                if (methodGetOwnerId == null)
                    return null;
            }

            return methodGetOwnerId.Invoke(IntPtr.Zero, new IntPtr[] { obj.ptr })?.Unbox<int>();
        }

        private static IL2Method methodGetNetworkDateTime = null;
        public static DateTime GetNetworkDateTime()
        {
            if (methodGetNetworkDateTime == null)
            {
                methodGetNetworkDateTime = Instance_Class.GetMethods().First(x => x.GetReturnType().Name == "System.DateTime");
                if (methodGetNetworkDateTime == null)
                    return DateTime.Now;
            }
            return methodGetNetworkDateTime.Invoke().Unbox<DateTime>();
        }

        private static IL2Method methodCalculateServerDeltaTime = null;
        public static double CalculateServerDeltaTime(double timeInSeconds, double previousTimeInSeconds)
        {
            if (methodCalculateServerDeltaTime == null)
            {
                methodCalculateServerDeltaTime = Instance_Class.GetMethods().First(
                    x =>
                        x.GetReturnType().Name == "System.Double" &&
                        x.GetParameters().Length == 2
                );
                if (methodCalculateServerDeltaTime == null)
                    return default;
            }
            return methodCalculateServerDeltaTime.Invoke(IntPtr.Zero, new IntPtr[] { new IntPtr(&timeInSeconds), new IntPtr(&previousTimeInSeconds) }).Unbox<double>();
        }

        private static IL2Method methodGetOwnershipTransferTime = null;
        public static double GetOwnershipTransferTime(GameObject go)
        {
            if (methodGetOwnershipTransferTime == null)
            {

                methodGetOwnershipTransferTime = Instance_Class.GetMethods().First(
                    x =>
                        x.GetReturnType().Name == "System.Double" &&
                        x.GetParameters().Length == 1 &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "UnityEngine.GameObject"
                );
                if (methodGetOwnershipTransferTime == null)
                    return default;
            }
            return methodGetOwnershipTransferTime.Invoke(IntPtr.Zero, new IntPtr[] { go.ptr }).Unbox<double>();
        }

        private static IL2Method methodTriggerEvent = null;
        public static void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered, int instagatorId = 0, float fastForward = 0f)
        {
            if (methodTriggerEvent == null)
            {
                methodTriggerEvent = Instance_Class.GetMethods()
                    .Where(x => x.GetParameters().Length == 4)
                    .First(x => x.GetParameters()[0].typeName.EndsWith(".VRC_EventHandler.VrcEvent"));
                if (methodTriggerEvent == null)
                    return;
            }
            methodTriggerEvent.Invoke(IntPtr.Zero, new IntPtr[] { e.ptr, new IntPtr(&broadcast), new IntPtr(&instagatorId), new IntPtr(&fastForward) });
        }

        private static IL2Method methodSendMessageToChildren = null;
        public static void SendMessageToChildren(GameObject obj, string message, SendMessageOptions options = SendMessageOptions.RequireReceiver, object value = null)
        {
            if (methodSendMessageToChildren == null)
            {
                methodSendMessageToChildren = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 4 &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "UnityEngine.GameObject" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[1].ptr) == "System.String" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[2].ptr) == "UnityEngine.SendMessageOptions" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[3].ptr) == "System.Object" &&
                        x.GetReturnType().Name == "System.Void"
                );
                if (methodSendMessageToChildren == null)
                    return;
            }
            methodSendMessageToChildren.Invoke(IntPtr.Zero, new IntPtr[] { obj.ptr, IL2Import.StringToIntPtr(message), new IntPtr(&options), IL2Import.ObjectToIntPtr(value) });
        }

        private static IL2Method methodInstantiate = null;
        public static GameObject Instantiate(VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3 position, Quaternion rotation)
        {
            if (methodInstantiate == null)
            {
                methodInstantiate = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.GetReturnType().Name == "UnityEngine.GameObject").First();
                if (methodInstantiate == null)
                    return null;
            }

            return methodInstantiate.Invoke(IntPtr.Zero, new IntPtr[] {
                new IntPtr(&broadcast),
                IL2Import.StringToIntPtr(prefabPathOrDynamicPrefabName),
                new IntPtr(&position),
                new IntPtr(&rotation)
            })?.MonoCast<GameObject>();
        }

        private static IL2Method methodRPC = null;
        public static void RPC(VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
        {
            if (methodRPC == null)
            {
                methodRPC = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.GetReturnType().Name == "System.Void").First(
                    x =>
                        x.GetParameters()[0].typeName.EndsWith(".RPC.Destination") &&
                        x.GetParameters()[1].typeName == "UnityEngine.GameObject" &&
                        x.GetParameters()[2].typeName == "System.String" &&
                        x.GetParameters()[3].typeName == "System.Object[]"
                );
                if (methodRPC == null)
                    return;
            }
            if (targetObject == null)
                return;

            methodRPC.Invoke(IntPtr.Zero, new IntPtr[] {
                new IntPtr(&targetClients),
                targetObject.ptr,
                IL2Import.StringToIntPtr(methodName),
                parameters.ArrayToIntPtr()
            });
        }

        private static IL2Method methodRPCToTargetEncrypt = null;
        public static bool RPC(VRC_EventHandler.VrcTargetType targetClients, Player targetPlayer, GameObject targetObject, string methodName, byte[] parameters)
        {
            if (methodRPCToTargetEncrypt == null)
            {
                methodRPCToTargetEncrypt = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 5 &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "VRC.Player" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[1].ptr) == "VRCSDK2.VRC_EventHandler.VrcTargetType" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[2].ptr) == "UnityEngine.GameObject" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[3].ptr) == "System.String" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[4].ptr) == "System.Byte[]" &&
                        x.GetReturnType().Name == "System.Boolean" &&
                        x.HasFlag(IL2BindingFlags.METHOD_PUBLIC)
                );
                if (methodRPCToTargetEncrypt == null)
                    return default;
            }
            IntPtr[] pointerArray = new IntPtr[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                fixed (byte* pointer = &parameters[i])
                {
                    pointerArray[i] = new IntPtr(pointer);
                }
            }
            return default;
            // Not work
            // methodRPCToTargetEncrypt.Invoke(IntPtr.Zero, new IntPtr[] { targetPlayer.ptr, new IntPtr(&targetClients), targetObject.ptr, IL2Import.StringToIntPtr(methodName), Execute.IntPtrArrayToIntPtr(pointerArray) }).Unbox<bool>();
        }
        private static IL2Method methodRPCToTarget = null;
        public static bool RPC(VRC_EventHandler.VrcTargetType targetClients, Player targetPlayer, GameObject targetObject, string methodName, object[] parameters)
        {
            if (methodRPCToTarget == null)
            {
                methodRPCToTarget = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 5 &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "VRC.Player" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[1].ptr) == "VRCSDK2.VRC_EventHandler.VrcTargetType" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[2].ptr) == "UnityEngine.GameObject" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[3].ptr) == "System.String" &&
                        IL2Import.il2cpp_type_get_name(x.GetParameters()[4].ptr) == "System.Object[]" &&
                        x.GetReturnType().Name == "System.Boolean" &&
                        x.HasFlag(IL2BindingFlags.METHOD_PRIVATE)
                );
                if (methodRPCToTarget == null)
                    return false;
            }
            return false;
            // Not work
            // methodRPCToTarget.Invoke(IntPtr.Zero, new IntPtr[] { targetPlayer.ptr, new IntPtr(&targetClients), targetObject.ptr, IL2Import.StringToIntPtr(methodName), Execute.IntPtrArrayToIntPtr(IL2Import.ObjectArrayToIntPtrArray(parameters)) }).Unbox<bool>();
        }

        private static IL2Field fieldObjectInstantiator = null;
        public static ObjectInstantiator Instantiator
        {
            get
            {
                if (fieldObjectInstantiator == null)
                {
                    fieldObjectInstantiator = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ObjectInstantiator");
                    if (fieldObjectInstantiator == null)
                        return null;
                }

                return fieldObjectInstantiator.GetValue()?.MonoCast<ObjectInstantiator>();
            }
            set
            {
                if (fieldObjectInstantiator == null)
                {
                    fieldObjectInstantiator = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ObjectInstantiator");
                    if (fieldObjectInstantiator == null)
                        return;
                }
                fieldObjectInstantiator.SetValue(value.ptr);
            }
        }
        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().Where(x => !x.Name.StartsWith("ObjectInstantiator") && !x.HasFlag(IL2BindingFlags.TYPE_INTERFACE)).Where(x => x.GetMethods().Where(y => y.GetReturnType().Name == "ObjectInstantiator").Count() > 0).First();
    }
}
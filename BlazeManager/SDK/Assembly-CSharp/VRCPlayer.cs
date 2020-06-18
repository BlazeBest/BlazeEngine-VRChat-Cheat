using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;

public class VRCPlayer : Component
{
    public VRCPlayer(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Field fieldInstance = null;
    public static VRCPlayer Instance
    {
        get
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRCPlayer" && x.HasFlag(IL2BindingFlags.FIELD_STATIC));
                if (fieldInstance == null)
                    return null;
            }

            return fieldInstance.GetValue()?.Unbox<VRCPlayer>();
        }
    }

    private static IL2Method methodRefresh_Properties = null;
    public static void Refresh_Properties()
    {
        if (methodRefresh_Properties == null)
        {
            unsafe
            {
                IL2Method[] iL2Methods = Instance_Class.GetMethods(x => x.GetReturnType().Name == "System.Void" && x.HasFlag(IL2BindingFlags.METHOD_STATIC) && x.HasFlag(IL2BindingFlags.METHOD_PRIVATE));
                foreach (var method in iL2Methods)
                {
                    var disasm = new Disassembler(*(IntPtr*)method.ptr, 0x1000, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.ptr).ToInt64()), true, Vendor.Intel);
                    var instructions = disasm.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > 400)
                    {
                        methodRefresh_Properties = method;
                        break;
                    }
                }

            }
            if (methodRefresh_Properties == null)
                return;
        }
        methodRefresh_Properties.Invoke();
    }

    // For Safety mode
    private static IL2Field fieldVRCInput = null;
    public VRCInput vrcInput
    {
        get
        {
            if (fieldVRCInput == null)
            {
                fieldVRCInput = Instance_Class.GetFields().First(x => x.GetReturnType().Name == VRCInput.Instance_Class.Name);
                if (fieldVRCInput == null)
                    return null;
            }

            return fieldVRCInput.GetValue(ptr)?.Unbox<VRCInput>();
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

    private static IL2Field fieldPlayerSelector = null;
    public PlayerSelector playerSelector
    {
        get
        {
            if (fieldPlayerSelector == null)
            {
                fieldPlayerSelector = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "PlayerSelector");
                if (fieldPlayerSelector == null)
                    return null;
            }

            return fieldPlayerSelector.GetValue(ptr)?.Unbox<PlayerSelector>();
        }
    }

    public void TeleportRPC(Vector3 vector, Quaternion quaternion, VRC_SceneDescriptor.SpawnOrientation spawnOrientation)
    {
        VRC.Network.RPC(VRCSDK2.VRC_EventHandler.VrcTargetType.TargetPlayer, gameObject, "TeleportRPC", new IntPtr[] {
            IL2Import.CreateNewObject(vector, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(quaternion, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(spawnOrientation, BlazeTools.IL2SystemClass.spawnOrientation)
        });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCPlayer");
}
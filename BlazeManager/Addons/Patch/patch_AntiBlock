using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;

namespace Addons.Patch
{
    public static class patch_AntiBlock
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("AntiBlock", !BlazeManager.GetForPlayer<bool>("AntiBlock"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("AntiBlock");
            BlazeManagerMenu.Main.togglerList["AntiBlock"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["AntiBlock"].btnOff.SetActive(!toggle);
            foreach (var player in UnityEngine.Object.FindObjectsOfType<VRC.Player>())
                player.UpdateModeration();
        }

        public static void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod("OnNetworkReady");
            try
            {

                unsafe
                {
                    var disasm = new Disassembler(*(IntPtr*)method.ptr, 16, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.ptr).ToInt64()), true, Vendor.Intel);
                    var instruction = disasm.Disassemble().First(x => x.ToString().StartsWith("jmp "));
                    IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);

                    VRC.Player.methodUpdateModeration = VRC.Player.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr);
                    if (VRC.Player.methodUpdateModeration == null)
                        throw new Exception();

                    // UpdateModeration()

                    disasm = new Disassembler(*(IntPtr*)VRC.Player.methodUpdateModeration.ptr, 0x1000, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)VRC.Player.methodUpdateModeration.ptr).ToInt64()), true, Vendor.Intel);
                    // disasm.Disassemble().ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
                    var instructions = disasm.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);

                    foreach (var instruction1 in instructions)
                    {
                        if (!instruction1.ToString().StartsWith("call "))
                            continue;

                        try
                        {
                            addr = new IntPtr((long)instruction1.Offset + instruction1.Length + instruction1.Operands[0].LvalSDWord);
                            method = ModerationManager.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr);

                            if (method.GetParameters().Length != 1 || method.GetReturnType().Name != "System.Boolean")
                                continue;

                            if (method.GetParameters()[0].typeName != "System.String")
                                continue;

                            pAntiBlock = IL2Ch.Patch(method, typeof(patch_AntiBlock).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                            break;
                        }
                        catch { continue; }
                    }
                }

                foreach (var ass in BlazeSDK.Main.listAssembly)
                    ConSole.Debug(ass.FullName);

                if (pAntiBlock == null)
                    throw new Exception();

                ConSole.Success("Patch: Anti-Block");
            }
            catch
            {
                ConSole.Error("Patch: Anti-Block");
            }
        }

        private static IntPtr patch_method(IntPtr instance, IntPtr userid)
        {
            if (instance == IntPtr.Zero || userid == IntPtr.Zero)
                return default;

            if (BlazeManager.GetForPlayer<bool>("AntiBlock"))
            {
                bool obj = false;
                return obj.Cast();
            }

            IL2Object result = pAntiBlock.InvokeOriginal(instance, new IntPtr[] { userid });
            if (result == null || result.ptr == IntPtr.Zero)
                return default;

            return result.ptr;
        }

        public static IL2Patch pAntiBlock;
    }
}

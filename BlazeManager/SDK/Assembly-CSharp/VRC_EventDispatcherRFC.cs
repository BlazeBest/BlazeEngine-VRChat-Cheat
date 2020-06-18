using System;
using BlazeIL;
using BlazeIL.il2cpp;
using VRC.SDKBase;

public class VRC_EventDispatcherRFC : IL2Base
{
    public VRC_EventDispatcherRFC(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    private static IL2Constructor constructVRC_EventDispatcherRFC = null;
    public VRC_EventDispatcherRFC() : base(IntPtr.Zero)
    {
        if (constructVRC_EventDispatcherRFC == null)
        {
            constructVRC_EventDispatcherRFC = Instance_Class.GetConstructors()[0];
            if (constructVRC_EventDispatcherRFC == null)
                return;
        }

        ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
        constructVRC_EventDispatcherRFC.Invoke(ptr);
    }

    private static IL2Method methodTriggerEvent = null;
    public void TriggerEvent(VRC_EventHandler handler, VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
    {

        if (methodTriggerEvent == null)
        {
            methodTriggerEvent = Instance_Class.GetMethod("TriggerEvent");
            if (methodTriggerEvent == null)
                return;
        }
        methodTriggerEvent.Invoke(ptr, new IntPtr[] { handler.ptr, e.ptr, broadcast.MonoCast(), instagatorId.MonoCast(), fastForward.MonoCast() });
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventDispatcherRFC");
}

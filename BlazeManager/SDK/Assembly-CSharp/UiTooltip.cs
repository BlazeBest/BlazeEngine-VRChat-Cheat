using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

unsafe public class UiTooltip : Component
{
    public UiTooltip(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Field fieldText = null;
    public string text
    {
        get
        {
            if (!IL2Get.Field("text", Instance_Class, ref fieldText))
                return null;

            return fieldText.GetValue(ptr)?.Unbox<string>();
        }
        set
        {
            if (!IL2Get.Field("text", Instance_Class, ref fieldText))
                return;

            fieldText.SetValue(ptr, IL2Import.StringToIntPtr(value));
        }
    }

    private static IL2Field fieldAlternateText = null;
    public string alternateText
    {
        get
        {
            if (!IL2Get.Field("alternateText", Instance_Class, ref fieldAlternateText))
                return null;

            return fieldAlternateText.GetValue(ptr)?.Unbox<string>();
        }
        set
        {
            if (!IL2Get.Field("alternateText", Instance_Class, ref fieldAlternateText))
                return;

            fieldAlternateText.SetValue(ptr, IL2Import.StringToIntPtr(value));
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiTooltip");
}

using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class YoutubeDLControl : Behaviour
{
    public YoutubeDLControl(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    private static IL2Field fieldInstance = null;
    public static YoutubeDLControl Instance
    {
        get
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "YoutubeDLControl");
                if (fieldInstance == null)
                    return null;
            }
            return fieldInstance.GetValue()?.MonoCast<YoutubeDLControl>();
        }
    }

    private static IL2Field fieldYoutubeDLVersion = null;
    public string YoutubeDLVersion
    {
        get
        {
            if (fieldYoutubeDLVersion == null)
            {
                fieldYoutubeDLVersion = Instance_Class.GetField("YoutubeDLVersion");
                if (fieldYoutubeDLVersion == null)
                    return null;
            }
            return fieldYoutubeDLVersion.GetValue(ptr)?.MonoCast<string>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("YoutubeDLControl");
}
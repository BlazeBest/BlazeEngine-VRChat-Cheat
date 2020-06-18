using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using BlazeSDK.Tools;
using BlazeSDK.Tools.JsonMini;
using BlazeTools;
using BlazeIL.il2cpp;
using Addons;
using Addons.Patch;

public class BlazeManager
{
    public static void Start()
    {
        Assemblies.a = new Dictionary<string, IL2Assembly>();
        // BlazeSDK.Main.LoadModule(Environment.CurrentDirectory + "\\BlazeEngine\\MonoLib\\SharpDisasm.dll", string.Empty, string.Empty, false);
        LoadDefaultSettings();

        Threads.Start();
        #region Patch
        // patch_UpdateYoutube_dl.Start();
        patch_AntiBlock.Start();
        patch_AntiKick.Start();
        patch_AvatarSteal.Start();
        patch_AvatarTools.Start();
        patch_EventManager.Start();
        patch_GlobalEvents.Start();
        patch_InvisAPI.Start();
        //patch_MorePortals.Start();
        patch_NoPortal.Start();
        patch_PhotonSerilize.Start();
        patch_Network.Start();
        // patch_NoUdon.Start();
        #endregion

        LoadSettings();
    }

    public static void SetIfNullForPlayer(string key, object value)
    {
        if (!settings.ContainsKey(key))
            SetForPlayer(key, value);
    }

    public static void SetForPlayer(string key, object value)
    {
        if (settings.ContainsKey(key))
            settings[key] = new JsonData(value);
        else
            settings.Add(key, new JsonData(value));
    }

    public static T GetForPlayer<T>(string key) => ((JsonData)GetForPlayer(key)).ReadData<T>();
    public static object GetForPlayer(string key)
    {
        if (settings.ContainsKey(key))
            return settings[key];

        return null;
    }

    public static void LoadDefaultSettings()
    {
        SetIfNullForPlayer("Fly Type", false);
        SetIfNullForPlayer("AntiKick", true);
        SetIfNullForPlayer("Photon Serilize", false);
        SetIfNullForPlayer("More Portals", false);
        SetIfNullForPlayer("Invis API", false);
        SetIfNullForPlayer("No Portal Join", false);
        SetIfNullForPlayer("No Portal Spawn", false);
        SetIfNullForPlayer("Global Events", false);
        SetIfNullForPlayer("AntiBlock", false);
        SetIfNullForPlayer("RPC Block", false);
        SetIfNullForPlayer("Hide Pickup", false);
        SetIfNullForPlayer("Fast Join", false);
        SetIfNullForPlayer("Steam Spoof", true);
        SetForPlayer("Fly Enable", false);
    }

    private static void OnApplicationQuit()
    {
        try
        {
            SaveSettings();
        }
        finally
        {
            Process.GetCurrentProcess().Kill();
        }
    }

    public static void SaveSettings()
    {
        string src = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");
        src += "\\data.json";

        LoadDefaultSettings();
        JsonManager.Create(src, settings);
    }

    public static void LoadSettings()
    {
        string src = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");
        src += "\\data.json";
        if (!File.Exists(src))
        {
            SaveSettings();
            ConSole.Print(ConsoleColor.Red, "[Config] Not found!", "Creating file!");
            return;
        }
        settings = JsonManager.Reader(src);
        LoadDefaultSettings();
        ConSole.Print(ConsoleColor.Green, "[Config] Found! File loaded!");
    }

    private static Dictionary<string, JsonData> settings = new Dictionary<string, JsonData>();
}

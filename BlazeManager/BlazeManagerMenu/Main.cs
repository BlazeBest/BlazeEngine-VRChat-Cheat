using System;
using System.Collections.Generic;
using VRC.Core;
using Addons.Mods;
using Addons.Patch;
using UnityEngine;
using UnityEngine.UI;
using Addons.Avatars;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class Main
    {
        /*
         * :: QuickMenu List ::
         * -> ShortcutMenu
         * -> UserInteractMenu
         * -> UIElementsMenu
         */
        internal static void CreateMenu()
        {
            QuickMenuStuff.CreateCustomMenu(new string[] {
                "UIElementsMenu2",
                "UIElementsMenu3",
                "UIElementsMenu4"
            });

            Edit_QuickMenu_UIElementsMenu.Start();
            Edit_QuickMenu_ShortcutMenu.Start();

            #region UIElement
            togglerList.Add("Fly Enabled", new QMToggleButton("UIElementsMenu", 4, 0, "Fly on", FlyMode.Toggle_Enable, "Fly off", "Toggle: Fly mode"));
            togglerList.Add("Invis API", new QMToggleButton("UIElementsMenu", 1, 1, "InvisAPI on", patch_InvisAPI.Toggle_Enable, "off", "Toggle: Offline mode"));
            patch_InvisAPI.RefreshStatus();
            togglerList.Add("No Portal Join", new QMToggleButton("UIElementsMenu", 2, 1, "NoPortalJoin\non", patch_NoPortal.Toggle_Enable_Join, "off", "Toggle: Block join in portal"));
            patch_NoPortal.RefreshStatusJoin();
            togglerList.Add("AntiBlock", new QMToggleButton("UIElementsMenu", 3, 1, "AntiBlock\non", patch_AntiBlock.Toggle_Enable, "off", "Toggle: Show blocked players"));
            patch_AntiBlock.RefreshStatus();
            togglerList.Add("Photon Serilize", new QMToggleButton("UIElementsMenu", 1, 2, "Serilize on", patch_PhotonSerilize.Toggle_Enable, "off", "Toggle: Photon Serilize"));
            patch_PhotonSerilize.RefreshStatus();
            togglerList.Add("No Portal Spawn", new QMToggleButton("UIElementsMenu", 2, 2, "NoPortalSpawn\non", patch_NoPortal.Toggle_Enable_Spawn, "off", "Toggle: Auto-remove spawned portals"));
            patch_NoPortal.RefreshStatusSpawn();
            togglerList.Add("Global Events", new QMToggleButton("UIElementsMenu", 3, 2, "Global Events\non", patch_GlobalEvents.Toggle_Enable, "off", "Toggle: Global Events"));
            patch_GlobalEvents.RefreshStatus();
            togglerList.Add("Fly Mode", new QMToggleButton("UIElementsMenu", 4, 1, "Fly:\nDirectional", FlyMode.Toggle_Mode, "Fly: Default", "Toggle: NoClip / Fly"));
            FlyMode.RefreshStatus();
            togglerList.Add("Infinity Jump", new QMToggleButton("UIElementsMenu", 4, 2, "Infinity\nJump", InfinityJump.Toggle_Enable, "disabled", "Toggle: Infinity jump"));
            #endregion

            #region UIElement4
            togglerList.Add("RPC Block", new QMToggleButton("UIElementsMenu4", 1, 0, "RPC Block\non", patch_EventManager.Toggle_Enable, "off", "Toggle: RPC Block"));
            patch_EventManager.RefreshStatus();
            togglerList.Add("Hide Pickup", new QMToggleButton("UIElementsMenu4", 2, 0, "Hide Pickup\non", NoLocalPickup.Toggle_Enable, "off", "Toggle: Hide all pickup objects"));
            NoLocalPickup.RefreshStatus();
            togglerList.Add("Fast Join", new QMToggleButton("UIElementsMenu4", 3, 0, "Fast Join\non", patch_Network.Toggle_FastJoin, "off", "Toggle: Fast Join in instance"));
            patch_Network.RefreshStatus_FastJoin();
            togglerList.Add("Steam Spoof", new QMToggleButton("UIElementsMenu4", 4, 0, "Steam Spoofer\non", patch_Network.Toggle_SteamSpoof, "off", "Toggle: Set you steamid is 0"));
            patch_Network.RefreshStatus_SteamSpoof();
            #endregion

            new QMSingleButton("ShortcutMenu", 5, 2, "Select\nyourself", () =>
            {
                QuickTools.SelectUserAPI(VRC.Player.Instance.apiuser);
            }, "Select yourself.");
            
            new QMSingleButton("UserInteractMenu", 6, 0, "<color=red>Download\n.vrca</color>", () =>
            {
                ApiAvatar apiAvatar = UnityEngine.Object.FindObjectOfType<UserInteractMenu>()?.menuController?.activeAvatar;
                if (apiAvatar != null)
                {
                    string url = apiAvatar.assetUrl;
                    if (AvatarStatus.IsValidUrl(url))
                        AvatarStatus.OpenUrlBrowser(url);
                    return;
                }
            }, "Open browse for download .vrca");

            // new Quaternion(0, 0, 45, 0) - верх ногами
            new QMLineButton("ShortcutMenu", -1.1f, -1, "Test Player", () => { Console.WriteLine("temp_player"); }, "Test", new Quaternion(0, -15, -5, 45));
            new QMLineButton("ShortcutMenu", 6.1f, -1, "Test Player 2", () => { Console.WriteLine("temp_player"); }, "Test", new Quaternion(0, 15, 5, 45));

            QuickMenuStuff.ChangeColorMenu(Color.green, Color.white);
            QuickMenuStuff.ChangeColorButtons(Color.green, Color.green);
        }

        internal static Dictionary<string, QMToggleButton> togglerList = new Dictionary<string, QMToggleButton>();
    }
}

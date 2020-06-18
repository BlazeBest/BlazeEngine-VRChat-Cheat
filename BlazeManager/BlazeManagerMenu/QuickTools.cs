using System;
using UnityEngine;
using VRC.Core;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class QuickTools
    {
        internal static void SelectUserAPI(APIUser user)
        {
            QuickMenu.Instance.SelectedUser = user;
            QuickMenuStuff.ShowQuickmenuPage("UserInteractMenu");
        }

        internal static Transform quickTransform { get; set; }
    }
}

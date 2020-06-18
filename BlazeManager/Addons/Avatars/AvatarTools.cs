using System;
using BlazeIL;
using BlazeTools;
using UnityEngine;
using UnityEngine.UI;

namespace Addons.Avatars
{
    public static class AvatarTools
    {
        public static UiAvatarList AddNewList(string title, int index)
        {
            UiAvatarList[] uiAvatarLists = Resources.FindObjectsOfTypeAll<UiAvatarList>();

            if (uiAvatarLists.Length == 0)
            {
                ConSole.Print(ConsoleColor.Red, "[Error]", "uiAvatarLists == 0!");
                return null;
            }

            UiAvatarList gameFavList = null;
            foreach (UiAvatarList list in uiAvatarLists)
            {
                if (list.name.Contains("Favorite") && !list.name.Contains("Quest"))
                {
                    gameFavList = list;
                    break;
                }
            }

            if (gameFavList == null)
            {
                ConSole.Print(ConsoleColor.Red, "[Error]", "gameFavList not found!");
                return null;
            }
            UiAvatarList newList = GameObject.Instantiate<UiAvatarList>(gameFavList, gameFavList.transform.parent);


            newList.GetComponentInChildren<Button>(true).GetComponentInChildren<Text>().text = title;
            newList.gameObject.SetActive(true);

            newList.transform.SetSiblingIndex(index);

            newList.category = UiAvatarList.Category.SpecificList;

            return newList;
        }
    }
}

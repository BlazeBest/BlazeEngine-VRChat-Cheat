using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.UI;
using BlazeWebAPI;

namespace Addons.Avatars
{
    public static class UIAvatar
    {
        private static void Start()
        {
            if (favList != null)
                return;

            Transform changeButton = null;
            pageAvatar = Resources.FindObjectsOfTypeAll<PageAvatar>().First(p => (changeButton = p.transform.Find("Change Button")) != null);

            favButton = GameObject.Instantiate<Transform>(changeButton, changeButton.parent);
            favButton.name = "ToggleFavorite";
            favButton.gameObject.SetActive(false);
            favButton.GetComponent<Button>().interactable = false;
            favButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            favButton.GetComponent<Button>().onClick.AddListener(onClickFavButton);

            avatarModel = pageAvatar.transform.Find("AvatarModel");
            baseAvatarModelPosition = avatarModel.localPosition;
            baseButtonFavPosition = changeButton.localPosition;
            favList = AvatarTools.AddNewList("Favorite (BlazeEngine)", 1);
            favButton.GetComponent<Button>().interactable = true;

            favButton.gameObject.SetActive(true);
            favButton.localPosition = baseButtonFavPosition + new Vector3(0, 80, 0);
            avatarModel.localPosition = baseAvatarModelPosition + new Vector3(0, 60, 0);

            foreach(var av in WebRequest.LoadAvatarFav())
                AddFavorite(av);
        }


        public static void Update()
        {
            if (favList == null)
            {
                Start();
                if (favList == null)
                    return;

                resfresh = 3;
            }

            if (resfresh > 0)
            {
                resfresh--;
                if (resfresh == 1)
                    UpdateAvatarList();
                return;
            }

            ApiAvatar apiAvatar = pageAvatar.avatar.apiAvatar;
            if (apiAvatar != null)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    favButton.GetComponentInChildren<Text>().text = "<color=red>Download .vrca</color>";
                    return;
                }

                if (UserUtils.Menu_AvatarsList.Contains(apiAvatar.id))
                {
                    if (!apiAvatar.releaseStatus.Equals("public") && apiAvatar.authorId != APIUser.CurrentUser.id)
                        favButton.GetComponentInChildren<Text>().text = "<color=red>Unfavorite</color>";
                    else
                        favButton.GetComponentInChildren<Text>().text = "Unfavorite";
                    return;
                }

                if (apiAvatar.authorId == APIUser.CurrentUser.id)
                {
                    if (apiAvatar.releaseStatus.Equals("public"))
                        favButton.GetComponentInChildren<Text>().text = "Make Private";
                    else
                        favButton.GetComponentInChildren<Text>().text = "Make Public";
                    return;
                }

                favButton.GetComponentInChildren<Text>().text = "Favorite";
            }
        }

        public static void UpdateAvatarList()
        {
            if (favList == null)
                return;

            favList.cacheSpecificList.Clear();
            favList.specificListIds = UserUtils.Menu_AvatarsList.ToArray();
            favList.expandedHeight = 850f;
            favList.extendRows = 4;
            favList.Refresh();
        }

        public static void onClickFavButton()
        {

            ApiAvatar apiAvatar = pageAvatar.avatar.apiAvatar;
            if (apiAvatar != null)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    string url = apiAvatar.assetUrl;
                    if (AvatarStatus.IsValidUrl(url))
                        AvatarStatus.OpenUrlBrowser(url);
                    return;
                }

                if (UserUtils.Menu_AvatarsList.Contains(apiAvatar.id))
                {
                    RemoveFavorite(apiAvatar.id);
                    WebRequest.DelAvatarFav(apiAvatar.id);
                    return;
                }

                if (apiAvatar.authorId == APIUser.CurrentUser.id)
                {
                    if (apiAvatar.releaseStatus.Equals("public"))
                        apiAvatar.releaseStatus = "private";
                    else
                        apiAvatar.releaseStatus = "public";
                    apiAvatar.SaveReleaseStatus();
                    return;
                }

                AddFavorite(apiAvatar.id);
                WebRequest.AddAvatarFav(apiAvatar.id);
            }
        }

        public static void AddFavorite(string avatarId)
        {
            if (UserUtils.Menu_AvatarsList.Contains(avatarId))
                return;

            UserUtils.Menu_AvatarsList.Insert(0, avatarId);
            UpdateAvatarList();
        }

        public static void RemoveFavorite(string avatarId)
        {
            if (!UserUtils.Menu_AvatarsList.Contains(avatarId))
                return;

            UserUtils.Menu_AvatarsList.Remove(avatarId);
            UpdateAvatarList();
        }

        public static int resfresh = 3;

        private static PageAvatar pageAvatar = null;
        internal static UiAvatarList favList = null;

        private static Transform avatarModel = null;
        private static Transform favButton = null;

        private static Vector3 baseAvatarModelPosition;
        private static Vector3 baseButtonFavPosition;
    }
}

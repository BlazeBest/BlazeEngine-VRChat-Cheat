using System;
using UnityEngine;
using UnityEngine.UI;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class Edit_QuickMenu_ShortcutMenu
    {
        internal static void Start()
        {
            Transform button = QuickTools.quickTransform.Find("ShortcutMenu/SitButton");

            RectTransform rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.anchoredPosition += Vector2.right * (420 * 1);
            rTransform.anchoredPosition += Vector2.down * (420 * 1);

            // RankColor
            button = QuickTools.quickTransform.Find("ShortcutMenu/Toggle_States_ShowTrustRank_Colors");
            rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.anchoredPosition += Vector2.right * (420 * -1);
            rTransform.anchoredPosition += Vector2.down * (420 * 1);

            // Settings
            button = QuickTools.quickTransform.Find("ShortcutMenu/SettingsButton");
            rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.anchoredPosition += Vector2.right * (420 * -1);

            // Emote
            button = QuickTools.quickTransform.Find("ShortcutMenu/EmoteButton");
            rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.sizeDelta = new Vector2(420, 210);
            rTransform.anchoredPosition += Vector2.down * (420 * -0.25f);

            // Emoji
            button = QuickTools.quickTransform.Find("ShortcutMenu/EmojiButton");
            rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.sizeDelta = new Vector2(420, 210);
            rTransform.anchoredPosition += Vector2.right * (420 * -1);
            rTransform.anchoredPosition += Vector2.down * (420 * 0.25f);

            button = QuickTools.quickTransform.Find("ShortcutMenu/ReportWorldButton");
            button.gameObject.Destroy();

            var boxCollider = QuickTools.quickTransform.GetComponent<BoxCollider>();
            boxCollider.size = new Vector3(4200, 1671.2f, 1);

        }
    }
}

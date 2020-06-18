using System;
using System.Linq;
using BlazeTools;
using UnityEngine;
using UnityEngine.UI;

namespace CustomQuickMenu
{
    public class QuickMenuStuff
    {
        public static void CreateCustomMenu(string[] menuName)
        {
            foreach (var x in menuName)
            {
                CreateCustomMenu(x);
            };
        }
        public static string CreateCustomMenu(string menuName)
        {
            Transform menu = UnityEngine.Object.Instantiate<Transform>(QuickMenu.Instance.transform.Find("CameraMenu"), QuickMenu.Instance.transform);
            menu.name = menuName;

            foreach (Transform transform in menu.transform)
                transform.gameObject.Destroy();

            return menuName;
        }

        public static void ShowQuickmenuPage(string pagename)
        {
            QuickMenu menu = QuickMenu.Instance;
            Transform transform = menu.transform.Find(pagename);
            if (transform == null)
            {
                ConSole.Print(ConSoleStatus.Error,"[QuickMenuStuff] Not found menu!");
                return;
            }

            menu._currentMenu = transform.gameObject;
            foreach (Transform element in menu.transform)
            {
                if (element.name.Contains("QuickMenu_NewElements"))
                    continue;

                if (element.gameObject.active)
                    element.gameObject.SetActive(false);
            }

            transform.gameObject.SetActive(true);
            menu.transform.Find("QuickMenu_NewElements/_InfoBar").gameObject.SetActive(false);
        }

        public static void ChangeColorButtons(Color? backgroundColor = null, Color? textColor = null)
        {
            if (backgroundColor == null && textColor == null)
            {
                ChangeColorButtons(Color.green, Color.green);
                return;
            }

            foreach (Transform child in QuickMenu.Instance.transform)
            {
                foreach (Button button in child.gameObject.GetComponentsInChildren<Button>())
                {
                    if (backgroundColor != null)
                    {
                        foreach (Image background in button.gameObject.GetComponentsInChildren<Image>(true))
                        {
                            background.color = (Color)backgroundColor;
                            //buttonBackgroundColor = (Color)backgroundColor;
                        }
                    }
                    if (textColor != null)
                    {
                        foreach (Text text in button.gameObject.GetComponentsInChildren<Text>(true))
                        {
                            text.color = (Color)textColor;
                            //StatusBuff.buttonTextColor = (Color)textColor;
                        }
                    }
                }
            }
        }
        public static void ChangeColorMenu(Color? backgroundColor = null, Color? textColor = null)
        {
            if (backgroundColor == null && textColor == null)
            {
                ChangeColorMenu(Color.green, Color.green);
                return;
            }

            foreach (Transform child in QuickMenu.Instance.transform)
            {
                if (backgroundColor != null)
                {
                    foreach (Image background in child.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        background.color = (Color)backgroundColor;
                        //StatusBuff.menuBackgroundColor = (Color)backgroundColor;
                    }
                }
                if (textColor != null)
                {
                    foreach (Text text in child.gameObject.GetComponentsInChildren<Text>(true))
                    {
                        text.color = (Color)textColor;
                        //StatusBuff.menuTextColor = (Color)textColor;
                    }
                }
            }
        }
    }
}

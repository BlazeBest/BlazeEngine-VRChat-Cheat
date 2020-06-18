using System;
using UnityEngine;
using UnityEngine.UI;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class Edit_QuickMenu_UIElementsMenu
    {
        internal static void Start()
        {
            QuickTools.quickTransform = QuickMenu.Instance.transform;

            imgPageUp = QuickTools.quickTransform.Find("EmojiMenu/PageUp").GetComponentInChildren<Image>();
            imgPageDown = QuickTools.quickTransform.Find("EmojiMenu/PageDown").GetComponentInChildren<Image>();

            EditMenu_1();
            EditMenu_2();
            EditMenu_3();
            EditMenu_4();
        }

        private static void EditMenu_1()
        {
            QMSingleButton tmpBtn = null;

            tmpBtn = new QMSingleButton("UIElementsMenu", 5, 0, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu4"); }, "Go to prev page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageUp.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageUp.material;

            tmpBtn = new QMSingleButton("UIElementsMenu", 5, 1, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu2"); }, "Go to next page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageDown.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageDown.material;

            button = QuickTools.quickTransform.Find("UIElementsMenu/BackButton");
            clickEvent = button.GetComponent<Button>().onClick;
            button.GetComponentInChildren<Text>().text = "Back\n(1 of 4)";

            RectTransform rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.anchoredPosition += Vector2.right * (420 * 1);
            rTransform.anchoredPosition += Vector2.down * (420 * 0);
        }

        private static void EditMenu_2()
        {
            QMSingleButton tmpBtn = null;

            tmpBtn = new QMSingleButton("UIElementsMenu2", 5, 0, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu"); }, "Go to prev page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageUp.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageUp.material;

            tmpBtn = new QMSingleButton("UIElementsMenu2", 5, 1, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu3"); }, "Go to next page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageDown.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageDown.material;

            GameObject UIEM2_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickTools.quickTransform.Find("UIElementsMenu2"), true);
            UIEM2_Back.GetComponentInChildren<Text>().text = "Back\n(2 of 4)";
            UIEM2_Back.GetComponent<Button>().onClick = clickEvent;
        }
        
        private static void EditMenu_3()
        {
            QMSingleButton tmpBtn = null;

            tmpBtn = new QMSingleButton("UIElementsMenu3", 5, 0, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu2"); }, "Go to prev page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageUp.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageUp.material;

            tmpBtn = new QMSingleButton("UIElementsMenu3", 5, 1, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu4"); }, "Go to next page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageDown.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageDown.material;

            GameObject UIEM3_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickTools.quickTransform.Find("UIElementsMenu3"), true);
            UIEM3_Back.GetComponentInChildren<Text>().text = "Back\n(3 of 4)";
            UIEM3_Back.GetComponent<Button>().onClick = clickEvent;
        }
        
        private static void EditMenu_4()
        {
            QMSingleButton tmpBtn = null;

            tmpBtn = new QMSingleButton("UIElementsMenu4", 5, 0, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu3"); }, "Go to prev page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageUp.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageUp.material;

            tmpBtn = new QMSingleButton("UIElementsMenu4", 5, 1, " ", () => { QuickMenuStuff.ShowQuickmenuPage("UIElementsMenu"); }, "Go to next page");

            tmpBtn.gameObject.GetComponentInChildren<Image>().sprite = imgPageDown.sprite;
            tmpBtn.gameObject.GetComponentInChildren<Image>().material = imgPageDown.material;

            GameObject UIEM4_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickTools.quickTransform.Find("UIElementsMenu4"), true);
            UIEM4_Back.GetComponentInChildren<Text>().text = "Back\n(4 of 4)";
            UIEM4_Back.GetComponent<Button>().onClick = clickEvent;
        }

        private static Image imgPageUp = null;
        private static Image imgPageDown = null;
        private static Transform button = null;
        private static Button.ButtonClickedEvent clickEvent = null;
    }
}

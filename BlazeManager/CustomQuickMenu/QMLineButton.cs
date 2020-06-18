using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomQuickMenu
{
    public class QMLineButton : QuickMenuBase
    {
        public QMLineButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Quaternion? quaternion = null, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            btnQMLoc = btnMenu;
            btnType = "LineButton";
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, quaternion, btnBackgroundColor, btnTextColor);
        }

        private void initButton(float btnXLocation, float btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Quaternion? quaternion = null, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            Transform btnTemplate = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton");

            button = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnQMLoc), true);

            initShift[0] = -1;
            initShift[1] = 0;

            button.transform.MonoCast<RectTransform>().sizeDelta = new Vector2(1440, 240);
            setLocation(btnXLocation, btnYLocation);
            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction, true);
            if (quaternion != null)
                button.transform.rotation = (Quaternion)quaternion;

            if (btnBackgroundColor != null)
                setBackgroundColor((Color)btnBackgroundColor);
            if (btnTextColor != null)
                setTextColor((Color)btnTextColor);

            setActive(true);
        }

        public void setButtonText(string text)
        {
            button.GetComponentInChildren<Text>().text = text;
        }

        public void setBackgroundColor(Color color)
        {
            button.GetComponentInChildren<Image>().color = color;
        }

        public void setTextColor(Color color)
        {
            button.GetComponentInChildren<Text>().color = color;
        }
    }
}

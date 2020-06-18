using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomQuickMenu
{
    public class QMSingleButton : QuickMenuBase
    {
        public QMSingleButton(string btnMenu, int btnXLocation, int btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            btnQMLoc = btnMenu;
            btnType = "SingleButton";
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
        }

        private void initButton(int btnXLocation, int btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            Transform btnTemplate = null;
            btnTemplate = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton");
            
            button = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnQMLoc), true);

            initShift[0] = -1;
            initShift[1] = 0;
            setLocation(btnXLocation, btnYLocation);
            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction, true);

            if (btnBackgroundColor != null)
                setBackgroundColor((Color)btnBackgroundColor);
            if (btnTextColor != null)
                setTextColor((Color)btnTextColor);

            setActive(true);
        }

        public void setButtonText(string buttonText)
        {
            button.GetComponentInChildren<Text>().text = buttonText;
        }

        public void setBackgroundColor(Color buttonBackgroundColor)
        {
            button.GetComponentInChildren<Image>().color = buttonBackgroundColor;
        }

        public void setTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<Text>().color = buttonTextColor;
        }
    }
}

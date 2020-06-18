using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomQuickMenu
{
    // Thanks old Ruby Button Api
    // Url: https://github.com/DubyaDude/ruby-button-api-vrchat/blob/master/Buttons_OLD.cs
    public class QuickMenuBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };

        public GameObject gameObject
        {
            get => button;
        }

        public void setActive(bool isActive)
        {
            button.SetActive(isActive);
        }

        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            RectTransform rTransform = button.transform.MonoCast<RectTransform>();
            rTransform.anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
            rTransform.anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        public void setAction(UnityAction buttonAction, bool newEvent = false)
        {
            Button button = this.button.GetComponent<Button>();
            if (newEvent)
                button.onClick = new Button.ButtonClickedEvent();

            Button.ButtonClickedEvent clickEvent = button.onClick;
            if (!newEvent)
                clickEvent.RemoveAllListeners();

            clickEvent.AddListener(buttonAction);
        }

        public void setAction<T, X>(UnityAction<T> buttonAction, X _this, bool newEvent = false)
        {
            Button button = this.button.GetComponent<Button>();
            if (newEvent)
                button.onClick = new Button.ButtonClickedEvent();

            Button.ButtonClickedEvent clickEvent = button.onClick;
            if (!newEvent)
                clickEvent.RemoveAllListeners();

            clickEvent.AddListener(buttonAction, _this);
        }

        public void setToolTip(string buttonToolTip)
        {
            UiTooltip uiTooltip = button.GetComponent<UiTooltip>();
            uiTooltip.text = buttonToolTip;
            uiTooltip.alternateText = buttonToolTip;
        }
    }
}

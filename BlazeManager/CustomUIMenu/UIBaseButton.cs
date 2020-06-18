using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomUIMenu
{
    public class UIBaseButton
    {
        protected GameObject button;

        public GameObject gameObject
        {
            get => button;
        }

        public void setText(string value)
        {
            button.GetComponentInChildren<Text>().text = value;
        }

        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            RectTransform rTransform = button.transform.MonoCast<RectTransform>();
            /*
            rTransform.anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
            rTransform.anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
            */
        }

        public void setSize(float buttonXSize, float buttonYSize)
        {

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
    }
}

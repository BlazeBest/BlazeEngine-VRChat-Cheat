using System;
using UnityEngine;

namespace Addons.Mods
{
    public static class InfinityJump
    {
        public static void Toggle_Enable()
        {
            isEnabled = !isEnabled;
            BlazeManagerMenu.Main.togglerList["Infinity Jump"].btnOn.SetActive(isEnabled);
            BlazeManagerMenu.Main.togglerList["Infinity Jump"].btnOff.SetActive(!isEnabled);
        }

        public static void EventJump()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.GetComponent("Renderer").Destroy();
            gameObject.transform.position = VRC.Player.Instance.transform.position;
            gameObject.Destroy(0.5f);
        }

        public static bool isEnabled = false;
    }
}

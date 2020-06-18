using System;
using UnityEngine;
using VRC;

namespace Addons.Mods
{
    public static class FlyMode
    {
        public static void Toggle_Enable()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("Fly Enable");
            BlazeManager.SetForPlayer("Fly Enable", toggle);
            RefreshStatus();
            Player.Instance.GetComponent<Collider>().enabled = !toggle;
            Physics.gravity = toggle ? Vector3.zero : new Vector3(0, -9.5f, 0);
        }
        public static void Toggle_Mode()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("Fly Type");
            BlazeManager.SetForPlayer("Fly Type", toggle);
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle1 = BlazeManager.GetForPlayer<bool>("Fly Enable");
            BlazeManagerMenu.Main.togglerList["Fly Enabled"].btnOn.SetActive(toggle1);
            BlazeManagerMenu.Main.togglerList["Fly Enabled"].btnOff.SetActive(!toggle1);

            bool toggle2 = BlazeManager.GetForPlayer<bool>("Fly Type");
            BlazeManagerMenu.Main.togglerList["Fly Mode"].btnOn.SetActive(toggle2);
            BlazeManagerMenu.Main.togglerList["Fly Mode"].btnOff.SetActive(!toggle2);
        }

        public static void Update()
        {
            if (!BlazeManager.GetForPlayer<bool>("Fly Enable")) return;
            if (BlazeManager.GetForPlayer<bool>("Fly Type"))
            {
                Player player = Player.Instance;
                Transform transform = Camera.main.transform;
                player.GetComponent<Collider>().enabled = false;
                float MultiSpeed = Input.GetKey(KeyCode.LeftShift) ? 2.5F : 1F;
                float calcTimes = MultiSpeed * Time.deltaTime;
                // NoClipMode
                if (Input.GetKey(KeyCode.E))
                {
                    player.transform.position += new Vector3(0, 1f, 0) * fNoClipSpeed * calcTimes;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    player.transform.position -= new Vector3(0, 1f, 0) * fNoClipSpeed * calcTimes;
                }

                Vector3 moveControl = Player.Instance.transform.position;
                if (Math.Abs(Input.GetAxis("Vertical")) > 0f)
                {
                    moveControl += calcTimes * fNoClipSpeed * transform.forward * Input.GetAxis("Vertical");
                }
                if (Math.Abs(Input.GetAxis("Horizontal")) > 0f)
                {
                    moveControl += calcTimes * fNoClipSpeed * transform.right * Input.GetAxis("Horizontal");
                }
                UserUtils.TeleportTo(moveControl);
            }
            else
            {
                Player player = Player.Instance;
                player.GetComponent<Collider>().enabled = true;
                if (Input.GetKey(KeyCode.Q))
                {
                    Physics.gravity = new Vector3(0, -9.5f, 0);
                    iCountBalance = 10;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Physics.gravity = new Vector3(0, 9.5f, 0);
                    iCountBalance = 10;
                }
                else if (iCountBalance >= 0)
                {
                    CharacterController controller = player.GetComponent<CharacterController>();
                    if (controller.velocity[1] != 0.0f)
                    {
                        iCountBalance = 10;
                        Physics.gravity = new Vector3(0, -controller.velocity[1] * 2.0f);
                    }
                    else
                    {
                        iCountBalance = -1;
                        Physics.gravity = Vector3.zero;
                    }
                }
            }
        }

        // NoClip Speed [Default: 4.0f]
        public static float fNoClipSpeed = 4.0f;

        public static int iCountBalance = -1;
    }
}
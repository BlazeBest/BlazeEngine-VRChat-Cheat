using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Addons.Mods
{
    public class Cam3th
    {
        public static void Toggle_Enable()
        {
            bCamEnable = !bCamEnable;
            if (bCamEnable == true)
            {
                CamOnHead = Camera.main;
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // gameObject.transform.localScale = CamOnHead.transform.localScale;
                if (gameObject.GetComponent<Collider>() != null)
                {
                    gameObject.GetComponent<Collider>().enabled = false;
                }
                // gameObject.GetComponent<Renderer>().enabled = false;
                // gameObject.AddComponent<Camera>();
                gameObject.transform.rotation = CamOnHead.transform.rotation;
                gameObject.transform.position = CamOnHead.transform.position;
                gameObject.transform.parent = CamOnHead.transform;
                Cam3thPerson = gameObject;
            }
            else
            {
            }
        }

        public void Update()
        {
            if (Cam3thPerson == null)
                return;

            CamOnHead.enabled = false;
        }
        public void LateUpdate()
        {
            if (Cam3thPerson == null)
                return;

            Cam3thPerson.transform.localPosition = (Vector3.up / 2) + (Vector3.back * 2);
        }

        private static bool bCamEnable = false;

        private static GameObject Cam3thPerson;
        private static Camera CamOnHead;
    }
}
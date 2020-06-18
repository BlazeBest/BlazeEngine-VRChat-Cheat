using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Addons.Mods;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;

namespace Addons
{
    public static class Threads
    {
        internal static void Start()
        {

            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("LocomotionInputController").GetMethod("Update");
                if (method == null)
                    throw new Exception();

                update = IL2Ch.Patch(method, typeof(Threads).GetMethod("patch_Control_Thread_Update", BindingFlags.Static | BindingFlags.NonPublic));
                if (update == null)
                    throw new Exception();

                ConSole.Debug("Is success patch #1");
            }
            catch
            {
                ConSole.Debug("Not working patch #1");
            }

            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("VRCApplication").GetMethod("OnApplicationQuit");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, typeof(BlazeManager).GetMethod("OnApplicationQuit", BindingFlags.Static | BindingFlags.NonPublic));

                ConSole.Debug("Is success patch #2 [FixFastQuit]");
            }
            catch
            {
                ConSole.Debug("Not working patch #2 [FixFastQuit]");
            }
        }

        private static IL2Patch update = null;

        private static void patch_Control_Thread_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            update.InvokeOriginal(instance);

            if (!bFirstThreadControl)
            {
                bFirstThreadControl = true;
                Application.targetFrameRate = 101;
                BlazeManagerMenu.Main.CreateMenu();
                return;
            }

            if (!bFirstThreadInRoom)
            {
                bFirstThreadInRoom = true;
                NoLocalPickup.ClearObjects();
                NoLocalPickup.Update();
                return;
            }
            Avatars.UIAvatar.resfresh = 3;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.F))
                    FlyMode.Toggle_Enable();
                
                if (Input.GetKeyDown(KeyCode.I))
                    InfinityJump.Toggle_Enable();

                if (Input.GetKeyDown(KeyCode.Mouse2))
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                        UserUtils.TeleportTo(hit.point);
                
                if (Input.GetKeyDown(KeyCode.Mouse3))
                {

                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    {
                        GameObject SelectColesion = hit.transform.gameObject;
                        if (SelectColesion != null)
                        {
                            ConSole.Message(SelectColesion.ToString() + " | " + SelectColesion.transform.position);
                            foreach(var comp in SelectColesion.GetComponents(typeof(Component)))
                                ConSole.Debug(comp.ToString());
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.J))
                {
                    UserUtils.RemoveInstiatorObjects();
                }

                /*
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Avatars.UIAvatar.AddFavorite("avtr_e1a33684-acc2-426d-8058-3ee6de630715");
                    Avatars.UIAvatar.AddFavorite("avtr_7c480631-b8c8-434d-8430-de8ca01ae250");
                }
                */

                if (Input.GetKey(KeyCode.T))
                {
                    Vector3 position = VRC.Player.Instance.transform.position;
                    UserUtils.SpawnPortal(position);
                    
                }
#if DEBUG
                if (Input.GetKey(KeyCode.Y))
                {
                    for (int i=0;i<=50;i++)
                        BlazeAttack.PortalSploit.Start();
                        // VRCPlayer.Instance.Refresh_Properties();
                }
                if (Input.GetKey(KeyCode.O))
                {
                    GameObject gameObject = VRC.Player.Instance.uSpeaker.gameObject;
                    for (int i = 0; i <= 50; i++)
                        BlazeAttack.PortalSploit.Test(gameObject);
                }
#endif

                if (Input.GetKeyDown(KeyCode.P))
                {
                    Console.WriteLine(VRCApplicationSetup.Instance.appVersion);
                    //ConSole.Debug(VRC.Player.Instance.photonPlayer.hashtable.ToString());
                    //ConSole.Debug(((IntPtr)VRC.Player.Instance.photonPlayer.hashtable["showSocialRank"]).MonoCast<bool>().ToString());
                    /*
                    foreach(var player in UnityEngine.Object.FindObjectsOfType<VRCPlayer>())
                    {
                        player.TeleportRPC(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation.AlignRoomWithSpawnPoint);
                    }
                    */
                }

            }

            if (InfinityJump.isEnabled)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    InfinityJump.EventJump();
                }
            }

            // For UpdateMods
            FlyMode.Update();
        }

#if DEBUG
        public static void GameObjects_scan()
        {
            gameObjects = GameObject.FindObjectsOfType<GameObject>();
        }

        public static GameObject[] gameObjects = new GameObject[0];
#endif
        private static bool bFirstThreadControl = false;
        public static bool bFirstThreadInRoom = false;
    }
}

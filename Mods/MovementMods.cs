using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR;

namespace StupidTemplate.Mods
{
    internal class MovementMods
    {

        public static void BallsOnHands()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            Object.Destroy(gameObject.GetComponent<SphereCollider>());
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            Object.Destroy(gameObject2.GetComponent<SphereCollider>());
            gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            gameObject2.GetComponent<Renderer>().material.color = Color.white;
            Object.Destroy(gameObject, Time.deltaTime);
            Object.Destroy(gameObject2, Time.deltaTime);
        }


        public static void Speedboost()
        {
            GorillaLocomotion.Player.Instance.jumpMultiplier = 7;
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7;
        }

        public static void RightgripSpeedboost()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.jumpMultiplier = 7; // change these numbers to change speed
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 7; // change these numbers to change speed, nnote for pureblood
            }
        }

        public static void LeftgripSpeedboost()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaLocomotion.Player.Instance.jumpMultiplier = 7;
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 7;
            }
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 15; // that number is to change the speed of the fly, note for pureblood
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void FasterFly()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void RightGripFly()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void LeftGripFly()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void GhostMonke()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                BallsOnHands();
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }

            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void NoClip()
        {
            bool disableColliders = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1;
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            foreach (MeshCollider collider in colliders)
            {
                collider.enabled = !disableColliders;
            }
        }

        public static void Platforms() // before you say i skidded, my friend let me use this code cause i was having a hard time making the code.
        {
            PlatformsThing(invisplat, stickyplatforms);
        }

        public static void InvisiblePlatforms()
        {
            PlatformsThing(true, false);
        }
        public static void invisStickyPlatforms()
        {
            PlatformsThing(true, true);
        }

        public static void StickyPlatforms()
        {
            PlatformsThing(false, true);
        }





        public static bool invisplat = false;
        public static bool stickyplatforms = false;

        private static void PlatformsThing(bool invis, bool sticky)
        {
            colorKeysPlatformMonke[0].color = new Color32(20, 50, 90, 0);
            colorKeysPlatformMonke[0].time = 0f;
            colorKeysPlatformMonke[1].color = new Color32(20, 50, 90, 0);
            colorKeysPlatformMonke[1].time = 0.5f;
            colorKeysPlatformMonke[2].color = new Color32(20, 50, 90, 0);
            colorKeysPlatformMonke[2].time = 1f;
            bool inputr;
            bool inputl;
            inputr = (ControllerInputPoller.instance.rightGrab);
            inputl = (ControllerInputPoller.instance.leftGrab);
            if (inputr)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    object[] eventContent = new object[2]
                    {
            new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
            GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    once_right = true;
                    once_right_false = false;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorKeysPlatformMonke;

                }


            }
            else if (!once_right_false && jump_right_local != null)
            {

                UnityEngine.Object.Destroy(jump_right_local);
                jump_right_local = null;
                once_right = false;
                once_right_false = true;
                RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
            }
            if (inputl)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    object[] eventContent2 = new object[2]
                    {
            new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
            GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                    once_left = true;
                    once_left_false = false;
                    Gradient gradient2 = new Gradient();
                    gradient2.colorKeys = colorKeysPlatformMonke;

                }
            }
            else if (!once_left_false && jump_left_local != null)
            {
                UnityEngine.Object.Destroy(jump_left_local);
                jump_left_local = null;
                once_left = false;
                once_left_false = true;
                RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    UnityEngine.Object.Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    UnityEngine.Object.Destroy(jump_left_network[j]);
                }
            }
        }

        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

        private static bool once_left;

        private static bool once_right;

        private static bool once_left_false;

        private static bool once_right_false;

        private static bool once_networking;

        private static GameObject[] jump_left_network = new GameObject[9999];

        private static GameObject[] jump_right_network = new GameObject[9999];

        private static GameObject jump_left_local = null;

        private static GameObject jump_right_local = null;

        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

        private static Vector3? checkpointPos;

        static ControllerInputPoller input;
        private static bool BothHands;

        public static void SkibidiSpeedboost()
        {
            GorillaLocomotion.Player.Instance.jumpMultiplier = 14;
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 14f;
        }

        public static void RandomTP()
        {
            GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<ControllerInputPoller>();
            if (GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").activeSelf == true)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = new Vector3(0f, 0f, 0f);
                }
                else
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = true;
                    }
                }
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = new Vector3(-60f, 20f, -90f);
                }
                else
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = true;
                    }
                }
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = new Vector3(-66f, 100f, -82f);
                }
                else
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = true;
                    }
                }
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = new Vector3(-66f, 11f, -82f);
                }
                else
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = true;
                    }
                }
            }
        }


        public static void InvisMonke()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.0)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 180f;

                GameObject primitive1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(primitive1.GetComponent<Rigidbody>());
                Object.Destroy(primitive1.GetComponent<SphereCollider>());
                primitive1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                primitive1.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                primitive1.GetComponent<Renderer>().material.color = new Color32(56, byte.MaxValue, 244, 251);
                Object.Destroy(primitive1, Time.deltaTime);

                GameObject primitive2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(primitive2.GetComponent<Rigidbody>());
                Object.Destroy(primitive2.GetComponent<SphereCollider>());
                primitive2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                primitive2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                primitive2.GetComponent<Renderer>().material.color = new Color32(56, byte.MaxValue, 244, 251);
                Object.Destroy(primitive2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0.0f;
            }
        }

        public static void AutoFunnyRun()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.1)
            {
                if (BothHands)
                {
                    float time = Time.frameCount;
                    GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + (GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(time) / 10) + new Vector3(0, -0.5f - (Mathf.Sin(time) / 7), 0) + (GorillaTagger.Instance.headCollider.transform.right * -0.05f);
                    GorillaTagger.Instance.leftHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + (GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(time + 180) / 10) + new Vector3(0, -0.5f - (Mathf.Sin(time + 180) / 7), 0) + (GorillaTagger.Instance.headCollider.transform.right * 0.05f);
                }
                else
                {
                    float time = Time.frameCount;
                    GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + (GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(time) / 10) + new Vector3(0, -0.5f - (Mathf.Sin(time) / 7), 0);
                }
            }
        }
    }
}
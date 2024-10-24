using GorillaLocomotion;
using GorillaLocomotion.Gameplay;
using Photon.Pun;
using POpusCodec.Enums;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Viveport;

namespace StupidTemplate.Mods
{
    internal class FunMods
    {
        private static Color bgColorA;
        private static float Delay;

        public static int QualityLevel { get; private set; }

        public static void SpinHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 10f;
        }

        public static void SpinHead2()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 10f;
        }

        public static void SpinHead3()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 10f;
        }

        public static void UpsideDownHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 180f;
        }

        public static void BrokenNeck()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 90f;
        }

        public static void BackwardsHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
        }

        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0;
        }

        public static void Daytime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }

        public static void NightTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(7);
        }

        public static void MorningTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void InstantHandTaps()
        {
            GorillaTagger.Instance.tapCoolDown = 0;
        }

        public static void DisableInstantHandTaps()
        {
            GorillaTagger.Instance.tapCoolDown = 0.33f;
        }

        public static void RightGripInstantHandTaps()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.tapCoolDown = 0f;
            }
        }

        public static void FastRopes()
        {
            foreach (GorillaRopeSwingSettings settings in GameObject.FindObjectsOfType(typeof(GorillaRopeSwingSettings)))
            {
                if (settings.name.Contains("Default"))
                {
                    settings.inheritVelocityMultiplier = 4f;
                }
            }
        }

        public static void RegularRopes()
        {
            foreach (GorillaRopeSwingSettings settings in GameObject.FindObjectsOfType(typeof(GorillaRopeSwingSettings)))
            {
                if (settings.name.Contains("Default"))
                {
                    settings.inheritVelocityMultiplier = 0.9f;
                }
            }
        }

        public static void BackwardBrooms()
        {
            NoncontrollableBroomstick[] broomsticks = UnityEngine.Object.FindObjectsOfType<NoncontrollableBroomstick>();
            if (broomsticks.Length > 0)
            {
                foreach (var broomstick in broomsticks)
                {
                    broomstick.lookForward = false;
                }
            }
        }

        public static void ForwardBrooms()
        {
            NoncontrollableBroomstick[] broomsticks = UnityEngine.Object.FindObjectsOfType<NoncontrollableBroomstick>();
            if (broomsticks.Length > 0)
            {
                foreach (var broomstick in broomsticks)
                {
                    broomstick.lookForward = true;
                }
            }
        }

        public static void AutoDance() // the most not working thing on earth
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                Vector3 bodyOffset = (GorillaTagger.Instance.bodyCollider.transform.right * (Mathf.Cos((float)Time.frameCount / 20f) * 0.3f)) + (new Vector3(0f, Mathf.Abs(Mathf.Sin((float)Time.frameCount / 20f) * 0.2f), 0f));
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f) + bodyOffset;
                try
                {
                }
                catch { }
                try
                {
                }
                catch { }

                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 0.2f + GorillaTagger.Instance.offlineVRRig.transform.right * -0.4f + GorillaTagger.Instance.offlineVRRig.transform.up * (0.3f + (Mathf.Sin((float)Time.frameCount / 20f) * 0.2f));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 0.2f + GorillaTagger.Instance.offlineVRRig.transform.right * 0.4f + GorillaTagger.Instance.offlineVRRig.transform.up * (0.3f + (Mathf.Sin((float)Time.frameCount / 20f) * -0.2f));

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;

                GameObject l = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(l.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(l.GetComponent<SphereCollider>());

                l.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                l.transform.position = GorillaTagger.Instance.leftHandTransform.position;

                GameObject r = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(r.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(r.GetComponent<SphereCollider>());

                r.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                r.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                l.GetComponent<Renderer>().material.color = bgColorA;
                r.GetComponent<Renderer>().material.color = bgColorA;

                UnityEngine.Object.Destroy(l, Time.deltaTime);
                UnityEngine.Object.Destroy(r, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void GripQuitGorillaTag() // was there even a point of adding this
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Application.Quit();
            }
        }

        public static void GripDisconnect()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void FPSBoost()
        {
            QualityLevel = 0; // this is a joke. it doesn't work
        }

        public static void GreenSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.green;
            }
        }

        public static void BlackSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.black;
            }
        }

        public static void PinkSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.magenta;
            }
        }

        public static void RedSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.red;
            }
        }

        public static void GraySky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.gray;
            }
        }

        public static void CyanSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.cyan;
            }
        }

        public static void ClearSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.clear;
            }
        }

        public static void WhiteSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.white;
            }
        }

        public static void YellowSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.yellow;
            }
        }

        public static void BlueSky()
        {
            {
                Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
                SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                SkyObject.material.color = (UnityEngine.Color)Color.blue;
            }
        }

        public static void TagGun()
        {
            RaycastHit raycastHit;
            if (!ControllerInputPoller.instance.rightGrab ||
                !Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                                 -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit))
            {
                return;
            }
            if (GunLibShit.GunMain != null)
                UnityEngine.Object.Destroy(GunLibShit.GunMain);
            if (GunLibShit.LineMain != null)
                UnityEngine.Object.Destroy(GunLibShit.LineMain.gameObject);
            GunLibShit.GunMain = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GunLibShit.GunMain.GetComponent<Renderer>().material.color = Color.blue;
            GunLibShit.GunMain.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            GunLibShit.GunMain.transform.position = raycastHit.point;
            UnityEngine.Object.Destroy(GunLibShit.GunMain.GetComponent<Collider>());
            UnityEngine.Object.Destroy(GunLibShit.GunMain.GetComponent<Rigidbody>());
            GunLibShit.LineMain = new GameObject("Line").AddComponent<LineRenderer>();
            GunLibShit.LineMain.startColor = Color.blue;
            GunLibShit.LineMain.endColor = Color.blue;
            GunLibShit.LineMain.startWidth = 0.025f;
            GunLibShit.LineMain.endWidth = 0.025f;
            GunLibShit.LineMain.positionCount = 2;
            GunLibShit.LineMain.useWorldSpace = true;
            Transform handTransform = GorillaLocomotion.Player.Instance.rightControllerTransform;
            GunLibShit.LineMain.SetPosition(0, handTransform.position);
            GunLibShit.LineMain.SetPosition(1, raycastHit.point);
            Material lineMaterial = new Material(Shader.Find("GUI/Text Shader"));
            lineMaterial.color = Color.blue;
            GunLibShit.LineMain.material = lineMaterial;
            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.0f && GunLibShit.GunMain != null)
            {
                VRRig hitVRRig = raycastHit.collider?.GetComponentInParent<VRRig>();
                if (hitVRRig != null)
                {
                    if (!PhotonNetwork.IsMasterClient)
                    {
                        GorillaLocomotion.Player.Instance.rightControllerTransform.position = hitVRRig.transform.position;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = hitVRRig.transform.position;
                    }
                    else
                    {
                        GameObject.Find("Gorilla Tag Manager").GetComponent<GorillaTagManager>().AddInfectedPlayer(hitVRRig.Creator);
                    }

                    GunLibShit.GunPointerShit = true;
                }
            }
            else
            {
                GunLibShit.GunPointerShit = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
            Player.Instance.StartCoroutine((System.Collections.IEnumerator)DestroyAfterDelay());
        }

        public static void TPGun()
        {
            RaycastHit raycastHit;
            if (!ControllerInputPoller.instance.rightGrab ||
                !Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                                 -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit))
            {
                return;
            }
            if (GunLibShit.GunMain != null)
                UnityEngine.Object.Destroy(GunLibShit.GunMain);
            if (GunLibShit.LineMain != null)
                UnityEngine.Object.Destroy(GunLibShit.LineMain.gameObject);
            GunLibShit.GunMain = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GunLibShit.GunMain.GetComponent<Renderer>().material.color = Color.blue;
            GunLibShit.GunMain.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            GunLibShit.GunMain.transform.position = raycastHit.point;
            UnityEngine.Object.Destroy(GunLibShit.GunMain.GetComponent<Collider>());
            UnityEngine.Object.Destroy(GunLibShit.GunMain.GetComponent<Rigidbody>());
            GunLibShit.LineMain = new GameObject("Line").AddComponent<LineRenderer>();
            GunLibShit.LineMain.startColor = Color.blue;
            GunLibShit.LineMain.endColor = Color.blue;
            GunLibShit.LineMain.startWidth = 0.025f;
            GunLibShit.LineMain.endWidth = 0.025f;
            GunLibShit.LineMain.positionCount = 2;
            GunLibShit.LineMain.useWorldSpace = true;
            Transform handTransform = GorillaLocomotion.Player.Instance.rightControllerTransform;
            GunLibShit.LineMain.SetPosition(0, handTransform.position);
            GunLibShit.LineMain.SetPosition(1, raycastHit.point);
            Material lineMaterial = new Material(Shader.Find("GUI/Text Shader"));
            lineMaterial.color = Color.blue;
            GunLibShit.LineMain.material = lineMaterial;
            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && Time.time > Delay)
            {
                Delay = Time.time + 0.55f;
                GorillaLocomotion.Player.Instance.transform.position = GunLibShit.GunMain.transform.position;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (raycastHit.collider != null && raycastHit.collider.GetComponentInParent<VRRig>() != null)
            {
                GunLibShit.GunShitLock = raycastHit.collider.GetComponentInParent<VRRig>();
            }
            Player.Instance.StartCoroutine((System.Collections.IEnumerator)DestroyAfterDelay());
        }

        public static void RemoveAllTrees()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(false);
            }
            else
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(true);
            }
        }

        public static void TagSelf()
        {
            if (!PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gorillaTagManager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            if (!gorillaTagManager.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.rightHandTransform.position;
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (GorillaTagManager gorillaTagManager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    gorillaTagManager.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    Main.GetIndex("Tag Self").enabled = false;
                }
            }
        }
        private static object DestroyAfterDelay()
        {
            throw new NotImplementedException();
        }
    }
}
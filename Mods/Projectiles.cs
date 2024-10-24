using GorillaLocomotion;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    internal class Projectiles
    {
        public static int projectileSpeedCycle = 0;
        public static float projectileSpeed = 0.0f;
        public static int projColorCycle = 0;
        public static float projDelay = 0.0f;
        public static float projShootDelay = 0.15f;
        public static int projShootDelayCycle = 0;
        public static Color32 projColor = Color.white;
        public static int projCycle = 0;
        public static string[] fullProjectileNames = new string[6]
        {
      "Snowball",
      "WaterBalloon",
      "LavaRock",
      "ThrowableGift",
      "ScienceCandy",
      "FishFood"
        };
        public static int ProjectileType = 1;

        public static void Projectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            UnityEngine.Object.Destroy(primitive, 0.1f);
            primitive.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            primitive.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            primitive.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;

            int[] overrideIndices = new int[] { 32, 204, 231, 240, 249, 252 };
            int projectileIndex = Array.IndexOf(Projectiles.fullProjectileNames, projectileName);
            if (projectileIndex == -1) return;

            primitive.AddComponent<GorillaSurfaceOverride>().overrideIndex = overrideIndices[projectileIndex];
            primitive.GetComponent<Renderer>().enabled = false;

            if (Time.time <= Projectiles.projDelay)
                return;

            try
            {
                Vector3 originalVelocity = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                string[] anchorNames = new string[] { "LMACE.", "LMAEX.", "LMAGD.", "LMAHQ.", "LMAIE.", "LMAIO." };
                SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + Projectiles.fullProjectileNames[projectileIndex] + "LeftAnchor").transform.Find(anchorNames[projectileIndex]).GetComponent<SnowballThrowable>();

                Vector3 originalPosition = component.transform.position;
                component.randomizeColor = true;
                component.transform.position = position;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity;
                GorillaTagger.Instance.offlineVRRig.LeftThrowableProjectileColor = color;
                GorillaTagger.Instance.offlineVRRig.RightThrowableProjectileColor = color;
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = originalVelocity;
                component.transform.position = originalPosition;
                component.randomizeColor = false;
                SafetyMods.FlushRPCs();
            }
            catch
            {
            }

            if (Projectiles.projShootDelay > 0.0f && !noDelay)
                Projectiles.projDelay = Time.time + Projectiles.projShootDelay;
        }

        public static void SnowballSpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[0], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }

        public static void WaterSpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[1], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }

        public static void LavaSpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[2], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }

        public static void GiftSpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[3], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }

        public static void CandySpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[4], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }

        public static void FishSpammer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;
            Color color = Projectiles.projColor;
            Projectiles.Projectile(Projectiles.fullProjectileNames[5], Player.Instance.rightControllerTransform.position, Vector3.down, color);
        }
    }
}
using StupidTemplate.Notifications;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {

        public static void EnterSettings()
        {
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
        }

        public static void SafetyMods()
        {
            buttonsType = 5;
        }

        public static void MovementMods()
        {
            buttonsType = 6;
        }

        public static void FunMods()
        {
            buttonsType = 7;
        }

        public static void OverpoweredMods()
        {
            buttonsType = 8;
        }

        public static void ImportantMods()
        {
            buttonsType = 9;
        }

        public static void Experiments()
        {
            buttonsType = 10;
        }

        public static void SoundMods()
        {
            buttonsType = 11;
        }

        public static void RigMods()
        {
            buttonsType = 12;
        }

        public static void VisualMods()
        {
            buttonsType = 13;
        }

        public static void AllFlysLol()
        {
            buttonsType = 14;
        }

        public static void Advantages()
        {
            buttonsType = 15;
        }

        public static void ProjectileMods()
        {
            buttonsType = 16;
        }

        public static void RoomMods()
        {
            buttonsType = 17;
        }
        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void FreezePlayerInMenu()
        {
            if (menu != null)
            {
                if (closePosition == Vector3.zero)
                {
                    closePosition = GorillaTagger.Instance.rigidbody.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.rigidbody.transform.position = closePosition;
                }
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            }
            else
            {
                closePosition = Vector3.zero;
            }
        }

        public static void FreezePlayerInMenuEnabled()
        {
            closePosition = GorillaTagger.Instance.rigidbody.transform.position;
        }

        public static void DisablePageButtons()
        {
            if (GetIndex("Joystick Menu").enabled)
            {
                disablePageButtons = true;
            }
            else
            {
                GetIndex("Disable Page Buttons").enabled = false;
                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> <color=white>Disable Page Buttons can only be used when using Joystick Menu.</color>");
            }
        }

        public static void EnablePageButtons()
        {
            disablePageButtons = false;
        }

        private static Vector3 closePosition;
        private static bool disablePageButtons;
    }
}

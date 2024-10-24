using UnityEngine.InputSystem;
using UnityEngine;
using GorillaLocomotion;

namespace StupidTemplate.Mods
{
    internal class RigMods
    {
        public static void IronMonke()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Transform leftController = Player.Instance.leftControllerTransform;
                Vector3 forceDirection = -leftController.forward;
                Player.Instance.AddForce(forceDirection * 10f, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, 1f, 1);
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                Transform rightController = Player.Instance.rightControllerTransform;
                Vector3 forceDirection = -rightController.forward;
                Player.Instance.AddForce(forceDirection * 10f, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, 1f, 1);
            }
        }
    }
}

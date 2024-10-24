using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Experiments // remember, these are just experiments probably not that much stuff actually works. 
    {
        public static void CarMonkey()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 15;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.Player.Instance.transform.position -= (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 15;
                    GorillaLocomotion.Player.Instance.transform.position = Vector3.zero;
                }
            }
            // lol
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30;
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
            // lol again
            {
                if (ControllerInputPoller.instance.rightControllerSecondaryButton)
                {
                    GorillaLocomotion.Player.Instance.transform.position -= (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30;
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
    }
}

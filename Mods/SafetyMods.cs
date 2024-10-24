using Photon.Pun;
using StupidTemplate.Notifications;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class SafetyMods
    {
        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.rightControllerGripFloat = 0;
            ControllerInputPoller.instance.leftControllerGripFloat = 0;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
        }

        public static void Antireport() // this kinda took a while i kept messing up lol
        {
            {
                try
                {
                    foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
                    {
                        if (gorillaPlayerScoreboardLine.linePlayer == NetworkSystem.Instance.LocalPlayer)
                        {
                            Transform transform = gorillaPlayerScoreboardLine.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float num = Vector3.Distance(vrrig.rightHandTransform.position, transform.position);
                                    float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform.position);
                                    float num3 = 0.35f;
                                    if (num < num3 || num2 < num3)
                                    {

                                        PhotonNetwork.Disconnect();

                                        NotifiLib.SendNotification("<color=grey>[</color><color=red>Somebody Tried To Report You, so we saved Anti Report saved you.</color>");
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public static void DisableGamemodeButtons()
        {
            GameObject.Find("Enviroment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/ModeSelector_Group").SetActive(false);
        }

        public static void EnableGamemodeButtons()
        {
            GameObject.Find("Enviroment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/ModeSelector_Group").SetActive(true);
        }

        public static void FlushRPCs()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
            PhotonNetwork.QuickResends = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig.GetView);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }
    }
}

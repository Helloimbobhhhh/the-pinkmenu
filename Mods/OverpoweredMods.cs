using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Notifications;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class OverpoweredMods
    {
        public static void MasterCheck()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You are master client.</color>");
            }
            else
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
        }

        public static void SpawnRedLucy()
        {
            HalloweenGhostChaser hgc = GameObject.Find("Environment Objects/05Maze_PersistentObjects/Halloween2024_PersistentObjects/Halloween Ghosts/Lucy/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>();
            if (hgc.IsMine)
            {
                hgc.timeGongStarted = Time.time;
                hgc.currentState = HalloweenGhostChaser.ChaseState.Gong;
                hgc.isSummoned = true;
            }
            else { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); }
        }

        public static void SpawnBlueLucy()
        {
            HalloweenGhostChaser hgc = GameObject.Find("Environment Objects/05Maze_PersistentObjects/Halloween2024_PersistentObjects/Halloween Ghosts/Lucy/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>();
            if (hgc.IsMine)
            {
                hgc.timeGongStarted = Time.time;
                hgc.currentState = HalloweenGhostChaser.ChaseState.Gong;
                hgc.isSummoned = false;
            }
            else { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); }
        }

        public static void SpawnBlueAndRedLucyGrips()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                HalloweenGhostChaser hgc = GameObject.Find("Environment Objects/05Maze_PersistentObjects/Halloween2024_PersistentObjects/Halloween Ghosts/Lucy/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>();
                if (hgc.IsMine)
                {
                    hgc.timeGongStarted = Time.time;
                    hgc.currentState = HalloweenGhostChaser.ChaseState.Gong;
                    hgc.isSummoned = true;
                }
                else { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); }
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                HalloweenGhostChaser hgc = GameObject.Find("Environment Objects/05Maze_PersistentObjects/Halloween2024_PersistentObjects/Halloween Ghosts/Lucy/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>();
                if (hgc.IsMine)
                {
                    hgc.timeGongStarted = Time.time;
                    hgc.currentState = HalloweenGhostChaser.ChaseState.Gong;
                    hgc.isSummoned = false;
                }
                else { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); }
            }
        }

        public static void PlayEyeMonsterMoonEvent()
        {
            if (!PhotonNetwork.IsMasterClient) return;
            GreyZoneManager.Instance?.ActivateGreyZoneAuthority();
            foreach (var summoner in Object.FindObjectsOfType<GreyZoneSummoner>()) summoner.OnGreyZoneActivated();
            foreach (var controller in Object.FindObjectsOfType<MoonController>())
            {
                var traverse = Traverse.Create(controller);
                traverse.Field("openMoon").GetValue<Transform>().gameObject.SetActive(true);
                traverse.Field("defaultMoon").GetValue<Transform>().gameObject.SetActive(false);
                controller.SetEyeOpenAnimation();
                traverse.Field("crackProgress").SetValue(1f);
            }
        }

        public void PlayEyeMonsterMoonEvent2()
        {
            var greyZoneManager = GreyZoneManager.Instance;
            greyZoneManager.ActivateGreyZoneAuthority();

            var greyZoneSummoners = Object.FindObjectsOfType<GreyZoneSummoner>();
            foreach (var greyZoneSummoner in greyZoneSummoners)
            {
                var summoner = greyZoneSummoner;
                summoner.OnGreyZoneActivated();
            }

            var moonControllers = Object.FindObjectsOfType<MoonController>();
            foreach (var moonController in moonControllers)
            {
                var controller = moonController;
                var traverseController = Traverse.Create(controller);

                var defaultMoonField = traverseController.Field("defaultMoon");
                var defaultMoonTransform = (Transform)defaultMoonField.GetValue();
                var defaultMoonGameObject = defaultMoonTransform.gameObject;
                defaultMoonGameObject.SetActive(false);

                var openMoonField = traverseController.Field("openMoon");
                var openMoonTransform = (Transform)openMoonField.GetValue();
                var openMoonGameObject = openMoonTransform.gameObject;
                openMoonGameObject.SetActive(true);

                controller.SetEyeOpenAnimation();

                var crackProgressField = traverseController.Field("crackProgress");
                crackProgressField.SetValue(1f);
            }
        }

        public static void Rightgripplayevent()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                {
                    if (!PhotonNetwork.IsMasterClient) return;
                    GreyZoneManager.Instance?.ActivateGreyZoneAuthority();
                    foreach (var summoner in Object.FindObjectsOfType<GreyZoneSummoner>()) summoner.OnGreyZoneActivated();
                    foreach (var controller in Object.FindObjectsOfType<MoonController>())
                    {
                        var traverse = Traverse.Create(controller);
                        traverse.Field("openMoon").GetValue<Transform>().gameObject.SetActive(true);
                        traverse.Field("defaultMoon").GetValue<Transform>().gameObject.SetActive(false);
                        controller.SetEyeOpenAnimation();
                        traverse.Field("crackProgress").SetValue(1f);
                    }
                }
            }
        }

        public static void TagAll()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                VRRig component = GorillaGameManager.instance.FindPlayerVRRig(PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, 10)]).gameObject.GetComponent<VRRig>();
                if (!component.mainSkin.material.name.Contains("fected"))
                {
                    if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        return;

                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = component.headMesh.transform.position + new Vector3(0.0f, 1f, 0.0f);
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = component.headMesh.transform.position;
                    GorillaLocomotion.Player.Instance.leftControllerTransform.position = component.headMesh.transform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = component.headMesh.transform.position;
                    GorillaTagger.Instance.offlineVRRig.leftHandTransform.position = component.headMesh.transform.position;
                    SafetyMods.FlushRPCs();
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void UnTagAll()
        {
            if (PhotonNetwork.LocalPlayer != PhotonNetwork.MasterClient)
                return;

            foreach (GorillaTagManager GorillaTagShit in Object.FindObjectsOfType<GorillaTagManager>())
            {
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                {
                    GorillaTagShit.currentInfected.Remove(player);
                    GorillaTagShit.UpdateState();
                }
            }
        }
    }
}

using Photon.Pun;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class VisualMods
    {

        public static void GreenScreen()
        {
            Color bgcolor = Color.green;

            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-54.0404f, 16.2321f, -124.5915f);
            a.transform.localScale = new Vector3(14.0131f, 0.0347f, 15.8359f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-52.7365f, 17.5233f, -122.333f);
            a.transform.localScale = new Vector3(14.0131f, 6.4907f, 0.0305f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-51.6623f, 17.5233f, -125.9925f);
            a.transform.localScale = new Vector3(15.5363f, 6.4907f, 0.0305f);
            a.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-54.0606f, 18.8161f, -124.6264f);
            a.transform.localScale = new Vector3(14.0131f, 0.0347f, 15.5983f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);
        }

        public static void Tracers()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject line = new GameObject("Line");
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    liner.SetPosition(1, vrrig.transform.position);
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void BoxESP()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                VRRig[] VrRigShit = GameObject.FindObjectsOfType<VRRig>();
                foreach (VRRig rig in VrRigShit)
                {
                    if (rig != null && !rig.isOfflineVRRig && !rig.isMyPlayer)
                    {
                        GameObject espBox = new GameObject("BoxESP");
                        espBox.transform.position = rig.transform.position;
                        espBox.transform.SetParent(rig.transform);
                        GameObject topLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        GameObject bottomLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        GameObject leftLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        GameObject rightLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        Object.Destroy(topLine.GetComponent<BoxCollider>());
                        Object.Destroy(bottomLine.GetComponent<BoxCollider>());
                        Object.Destroy(leftLine.GetComponent<BoxCollider>());
                        Object.Destroy(rightLine.GetComponent<BoxCollider>());
                        topLine.transform.SetParent(espBox.transform);
                        bottomLine.transform.SetParent(espBox.transform);
                        leftLine.transform.SetParent(espBox.transform);
                        rightLine.transform.SetParent(espBox.transform);
                        topLine.transform.localPosition = new Vector3(0.0f, 0.49f, 0.0f);
                        topLine.transform.localScale = new Vector3(1f, 0.02f, 0.02f);
                        bottomLine.transform.localPosition = new Vector3(0.0f, -0.49f, 0.0f);
                        bottomLine.transform.localScale = new Vector3(1f, 0.02f, 0.02f);
                        leftLine.transform.localPosition = new Vector3(-0.49f, 0.0f, 0.0f);
                        leftLine.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
                        rightLine.transform.localPosition = new Vector3(0.49f, 0.0f, 0.0f);
                        rightLine.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
                        Shader espShader = Shader.Find("GorillaTag/UberShaderr");
                        topLine.GetComponent<Renderer>().material.shader = espShader;
                        bottomLine.GetComponent<Renderer>().material.shader = espShader;
                        leftLine.GetComponent<Renderer>().material.shader = espShader;
                        rightLine.GetComponent<Renderer>().material.shader = espShader;
                        Color playerColor = rig.playerColor;
                        topLine.GetComponent<Renderer>().material.color = playerColor;
                        bottomLine.GetComponent<Renderer>().material.color = playerColor;
                        leftLine.GetComponent<Renderer>().material.color = playerColor;
                        rightLine.GetComponent<Renderer>().material.color = playerColor;
                        espBox.transform.LookAt(Camera.main.transform);
                        Object.Destroy(espBox, Time.deltaTime);
                    }
                }
            }
        }

        public static void Beacons()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                VRRig[] VrRigShit = GameObject.FindObjectsOfType<VRRig>();
                foreach (VRRig rig in VrRigShit)
                {
                    if (rig != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject beacon = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        beacon.transform.localScale = new Vector3(0.05f, 350f, 0.05f);
                        beacon.transform.position = rig.transform.position;
                        GameObject.Destroy(beacon.GetComponent<Collider>());
                        beacon.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        beacon.GetComponent<Renderer>().material.color = rig.playerColor;
                        GameObject.Destroy(beacon, Time.deltaTime);
                    }
                }
            }
        }


    }
}

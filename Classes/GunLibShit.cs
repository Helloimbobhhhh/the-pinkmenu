using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Classes
{
    internal class GunLibShit
    {


        public static VRRig PlayerGun;
        public static GameObject GunMain;
        public static LineRenderer LineMain;
        public static Color GunPointerColor1 = Color.magenta;
        public static GameObject pointer = null;
        public static VRRig GunShitLock;
        public static Color GunColorShit = Color.blue;
        public static bool GunPointerShit;
        public static VRRig GunLockRig;

        public static GameObject CreateGun(Vector3 position, Color color, float scale)
        {
            GameObject gun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gun.GetComponent<Renderer>().material.color = color;
            gun.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            gun.transform.localScale = new Vector3(scale, scale, scale);
            gun.transform.position = position;

            UnityEngine.Object.Destroy(gun.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(gun.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gun.GetComponent<Collider>());

            return gun;
        }

        public static LineRenderer CreateLine(Vector3 startPosition, Vector3 endPosition, Color color, float width)
        {
            GameObject lineObject = new GameObject("Line");
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.shader = Shader.Find("GUI/Text Shader");

            return lineRenderer;
        }

        public static void DestroyObject(GameObject obj)
        {
            if (obj != null)
            {
                UnityEngine.Object.Destroy(obj);
            }
        }

        public static IEnumerator DestroyAfterDelay(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            DestroyObject(obj);
        }
    }
}

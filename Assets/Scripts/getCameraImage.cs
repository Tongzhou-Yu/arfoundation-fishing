using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class getCameraImage : MonoBehaviour
{
    [SerializeField]
    ARCameraBackground arCamBg;
    [SerializeField]
    GameObject planePrefab;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    RenderTexture capturedTex;
    bool saved = false;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        // ������`�󥵥����ǳ��ڻ�
        capturedTex = new RenderTexture(Screen.width, Screen.height, 0);
    }

    public void SaveTex()
    {
        if (arCamBg.material != null)
        {
            // RenderTexture�� deep copy
            Graphics.Blit(null, capturedTex, arCamBg.material);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // ����Ŀ�Υ��åפǥƥ������㱣��
                if (!saved)
                {
                    SaveTex();
                    saved = true;
                }
                // ����Ŀ�Խ��Υ��åפ�ƽ���O��
                else
                {
                    if (raycastManager.Raycast(touch.position, hitResults))
                    {
                        var plane = Instantiate(planePrefab, hitResults[0].pose.position, hitResults[0].pose.rotation);
                        var mat = plane.GetComponent<Renderer>().material;
                        mat.mainTexture = capturedTex;
                        // Billboard
                        if (Camera.main != null)
                        {
                            Vector3 target = new Vector3(
                                Camera.main.transform.position.x,
                                plane.transform.position.y,
                                Camera.main.transform.position.z
                            );
                            plane.transform.LookAt(target);
                            // �Y�����򤭤ˤʤäƤ��ޤ��ΤǷ�ܞ
                            var angles = plane.transform.localEulerAngles;
                            angles.y += 180;
                            plane.transform.localEulerAngles = angles;
                        }
                    }
                }
            }
        }
    }
}

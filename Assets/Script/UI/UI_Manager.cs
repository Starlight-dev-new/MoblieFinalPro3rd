using System.Diagnostics;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] uiElementsCameras;
    [SerializeField] GameObject uiCCTVCameras;
    [SerializeField] GameObject uiBackCameras;
    private int mainUIElement = -1;
    private bool steteCCTV = true;
    private CameraManagr cameraManagr;
    void Awake()
    {
        cameraManagr = FindObjectOfType<CameraManagr>();
        uiCCTVCameras.SetActive(true);
        uiBackCameras.SetActive(true);
    }
    // Hide UI Elements Cameras
    public void UiHideCam(int mainUIElement)
    {
        switch (steteCCTV)
        {
            case true:
            for (int i = 0; i < uiElementsCameras.Length; i++)
        {
            if (i != mainUIElement)
            {
                uiElementsCameras[i].SetActive(true);
            }
            else
            {
                uiElementsCameras[i].SetActive(false);
            }
        }
                break;
            case false:
            foreach(GameObject ui in uiElementsCameras)
                {
                    ui.SetActive(false);
                }
                break;
        }

    }
    // โชว์ UIหลัง  Cameras
    public void UiBackCam()
    {
        bool currentState = uiCCTVCameras.activeSelf;
        uiCCTVCameras.SetActive(!currentState);
    }
    // โชว์ UI กล้องCCTV
    public void UiCCTVCam()
    {
        bool currentState = uiBackCameras.activeSelf;
        uiBackCameras.SetActive(!currentState);
        switch (currentState)
        {
            case true:
                steteCCTV = true;
                UiHideCam(cameraManagr.lastCamera - 1);
                break;
            case false:
                steteCCTV = false;
                UiHideCam(mainUIElement);
                break;
        }
    }
    

}

using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] PowerBattery powerBattery;
    [SerializeField] GameObject[] cameras;
    private int mainCamera;
    public int lastCamera = 1;
    public bool steteOpenCam = true;
    void Awake()
    {
        SetMainCamera();
    }
    public void ChangeCamera(int cameraIndex)
    {
        mainCamera = cameraIndex;
        SetMainCamera();
    }
    public void SetMainCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == mainCamera)
            {
                cameras[i].SetActive(true);
            }
            else
            {
                cameras[i].SetActive(false);
            }
        }
    }
    public void CCTVCameraTigger()
    {
        switch (steteOpenCam)
        {
            case true:
                steteOpenCam = false;
                powerBattery.OnCamera();
                ChangeCamera(lastCamera);
                break;
            case false:
                steteOpenCam = true;
                powerBattery.OffCamera();
                lastCamera = mainCamera;
                ChangeCamera(0);
                break;
        }
    }
    public void BackCameraTigger()
    {
        switch (steteOpenCam)
        {
            case true:
                steteOpenCam = false;
                ChangeCamera(9);
                break;
            case false:
                steteOpenCam = true;
                ChangeCamera(0);
                break;
        }
    }
}

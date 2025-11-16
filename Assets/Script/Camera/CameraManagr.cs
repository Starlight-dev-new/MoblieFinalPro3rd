using UnityEngine;

public class CameraManagr : MonoBehaviour
{

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
        Debug.Log("Main Camera: " + mainCamera);
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
                ChangeCamera(lastCamera);
                break;
            case false:
                steteOpenCam = true;
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

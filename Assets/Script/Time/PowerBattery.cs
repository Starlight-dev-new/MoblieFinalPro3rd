using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerBattery : MonoBehaviour
{
    [Header("Power Settings")]
    [SerializeField] float currentBattery = 100f;
    [SerializeField] float drainRate = 0.417f;
    [SerializeField] float bootDrainRate = 0.433f;
    [SerializeField] Battery battery;
    
    [Header("Other")]
    public bool isCameraOn = false;
    public bool isDoorOpen = true;
    
    private float totalDrain;
    void Update()
    {
       
        if (currentBattery < 0f)
        {
            currentBattery = 0;
            ZeroBattery();
            return;
        }
        CalculateDrainRate();
        float drainAmount = totalDrain * Time.deltaTime;
        currentBattery -= drainAmount;

        //เปลี่ยนตัวแสดงแบต
        if (currentBattery >= 76)
        {
            battery.BatteryBar(100);
        }
        else if(currentBattery >= 51)
        {
            battery.BatteryBar(75);
        }
         else if(currentBattery >= 26)
        {
            battery.BatteryBar(50);
        }
        else if(currentBattery >= 1)
        {
            battery.BatteryBar(25);
        }
        
    }
    void CalculateDrainRate()
    {
        totalDrain = drainRate;

        if(isCameraOn) totalDrain += bootDrainRate;
        if(isDoorOpen) totalDrain += bootDrainRate;
    }
    public void OnCamera()
    {
     isCameraOn = true;
   
        
    }
    public void OffCamera()
    {
     isCameraOn = false;
     Debug.Log("Camera "+ isCameraOn);
    }
    void ZeroBattery()
    {
        SceneManager.LoadScene("BadEnd"); 
        return;
    }
    [ContextMenu("FillBAT")]
    public void FillBat()
    {
        currentBattery = battery.FillBattery(currentBattery) ;
    }
}

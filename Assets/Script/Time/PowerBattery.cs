using UnityEngine;
using UnityEngine.Rendering;

public class PowerBattery : MonoBehaviour
{
    [Header("Power Settings")]
    [SerializeField] float currentBattery = 100f;
    [SerializeField] float drainRate = 1f;
    [SerializeField] float bootDrainRate = 0.5f;
    [SerializeField] Battery battery;
    
    [Header("Other")]
    public bool isCameraOn = false;
    private float totalDrain;
    void Update()
    {
        if (currentBattery < 0f)
        {
            currentBattery = 0;
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

        if(isCameraOn) totalDrain += bootDrainRate * 2f;
    }
    public void OnCamera()
    {
     isCameraOn = true;
     Debug.Log("Camera "+ isCameraOn);
        
    }
    public void OffCamera()
    {
     isCameraOn = false;
     Debug.Log("Camera "+ isCameraOn);
    }
    void ZeroBattery()
    {
        return;
    }
        void ResetBattery()
    {
        currentBattery = 100f;
    }
}

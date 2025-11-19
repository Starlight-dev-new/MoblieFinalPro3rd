using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] GameObject[] batteryBar;
    [SerializeField] GameObject[] batteryTank;


    public int tankNum = 0;

    
    public void BatteryBar(int persen)
    {
         switch (persen)
            {
                case 100:
                BatteryBarConfig(0);
                break;

                case 75:
                BatteryBarConfig(1);
                break;

                case 50:
                BatteryBarConfig(2);
                break;

                case 25:
                BatteryBarConfig(3);
                break;
                
                default:
                break;
            }
    }
    private void BatteryBarConfig(int bettery)
    {
        for(int i = 0; i < batteryBar.Length; i++)
        {
            if (i != bettery)
            {
               batteryBar[i].SetActive(false); 
            }else
            {
                batteryBar[i].SetActive(true); 
            }

        }   
    }
    public float FillBattery(float currentBattery)
    {
   
        if(tankNum < batteryTank.Length)
        {
            Destroy(batteryTank[tankNum]);
            tankNum++;
            return 100f;
        }
        return currentBattery;

    } 
}

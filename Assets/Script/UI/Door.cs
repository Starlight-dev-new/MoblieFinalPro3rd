using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject[] doorElement;

    public void ChangDoorStat(bool isDoorOpen = true)
    {
        switch (isDoorOpen)
        {
            case true:
            doorElement[0].SetActive(true);
            doorElement[1].SetActive(false);
            break;
            case false:
            doorElement[0].SetActive(false);
            doorElement[1].SetActive(true);
            break;

        }
    }
    

    
}

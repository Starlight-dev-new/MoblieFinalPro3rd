using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;



public class TimerInGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timer;
    [SerializeField] float timerScals = 36f;
    private int hour;
    private int minute;
    void Update()
    {
        if (timer < 6 * 3600)
        {
            timer += Time.deltaTime * timerScals;
            hour = (int)(timer/3600);
            minute =(int)((timer % 3600) /60);
            timerText.text = string.Format($"{hour}:{minute:00}AM ");
        }
        else
        {
            Debug.Log("6AM");
        }
    }
}

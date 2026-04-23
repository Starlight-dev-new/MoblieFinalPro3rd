using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class TimerInGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timer;
    [SerializeField] float timerScals = 36f;
    [SerializeField] Enemy enemy;
    public float timeForPlay;
    private int hour;
    private int minute;
    void Start()
    {
        AnalyticManager.Instance.sessionTime = 0;
    }

    void Update()
    {
        AnalyticManager.Instance.sessionTime += Time.deltaTime;
        if (timer < 6 * 3600)
        {
            timer += Time.deltaTime * timerScals;
            hour = (int)(timer/3600);
            AnalyticManager.Instance.failureTime = hour;
            minute =(int)((timer % 3600) /60);
            timerText.text = string.Format($"{hour}:{minute:00}AM ");
        }
        else
        {
           SceneManager.LoadScene("GoodEnd"); 
           AnalyticManager.Instance.Session_Length();
        }
    }
}

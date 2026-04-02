using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine.UnityConsent;
public class AnalyticManager : MonoBehaviour
{
    public static AnalyticManager analytic {get; private set;}
    private float timePlay = 0;
    public int retryCount = 0;
    public float failureTime = 0;
    public float retryTimeAve = 0;
    void Awake()
    {
        if(analytic != null && analytic != this )
        {
            Destroy(gameObject);
        }else
        {
            analytic = this;
            DontDestroyOnLoad(gameObject);
        }
        Initialize();
    }
    void Update()
    {
        timePlay +=Time.deltaTime;
    }
    void OnApplicationQuit()
    {
        SentAnalyticOnQuit();
    }
    [ContextMenu("SentAnalyticOnQuit")]
    void SentAnalyticOnQuit()
    {
        Debug.Log("Quit");
        float averateTimeReplay = 0;
        if (retryCount >0)
        {
            averateTimeReplay = retryTimeAve / retryCount;
        }       
            CustomEvent session_Length = new CustomEvent("Session_Length")
            {
                {"sessionTime",timePlay},
            };
            CustomEvent retryRate = new CustomEvent("retryRate")
            {
              {"retryCount",retryCount},
              {"retryAver",averateTimeReplay}  
            };

            AnalyticsService.Instance.RecordEvent(session_Length);
            AnalyticsService.Instance.RecordEvent(retryRate);
            AnalyticsService.Instance.Flush();
            
            Debug.Log("SentAnalyticOnQuit");

        
    }
    public void SentFailureRateAnalytic(string cause,float remainPower)
    {
          CustomEvent failuer_Rate = new CustomEvent("failuer_Rate")
            {
                {"deathCause",cause},
                {"failureTime",failureTime},
                {"remainPower",remainPower}
            };
         AnalyticsService.Instance.RecordEvent(failuer_Rate);
         AnalyticsService.Instance.Flush();
         Debug.Log("SentFailureRateAnalytic");
    }

     private async void Initialize()
    {
         try
       {
            // ✅ Set consent ก่อน Initialize
            EndUserConsent.SetConsentState(new ConsentState
            {
                AnalyticsIntent = ConsentStatus.Granted
            });

            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");
        }
         catch (System.Exception e)
        {
            Debug.LogError($"Unity Services Init Failed: {e.Message}");
        }
        
    
    }

}

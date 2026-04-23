using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine.UnityConsent;
public class AnalyticManager : MonoBehaviour
{
    public static AnalyticManager Instance {get; private set;}
    public float sessionTime = 0;
    public float failureTime = 0;
    public float retryTime = 0;

    void Awake()
    {
        if(Instance != null && Instance != this )
        {
            Destroy(gameObject);
        }else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Initialize();
    }

    public void Session_Length()
    {
        CustomEvent session_Length = new CustomEvent("Session_Length")
        {
            {"sessionTime",sessionTime},
        };
        AnalyticsService.Instance.RecordEvent(session_Length);
        AnalyticsService.Instance.Flush();
        Debug.Log("Session_Length"); 
    }
    
    public void SentRetryRate(float time)
    {
        retryTime = time;
        CustomEvent retryRate = new CustomEvent("retryRate")
         {
             {"failuer_Rate",retryTime},
         };
        AnalyticsService.Instance.RecordEvent(retryRate);
        AnalyticsService.Instance.Flush();
        Debug.Log("SentRetryRate"); 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class NextNavInterfaceDemo : MonoBehaviour
{
    public static NextNavInterfaceDemo Instance;

    public string Key = "";

    public string Host = "api.nextnav.io"; 


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitObsever();
    }

    public void SetDeveloperKey()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.InitSdk();
#elif UNITY_IOS
                NextNavIos.Instance.InitSdk();
#endif

    }

    public void InitSdk()
    {
        UIManager.Instance.AddTextToDebugScroll("Start SDK Init");

#if UNITY_ANDROID
        NextNavAndroid.Instance.SetDeveloperKey(Key);
        NextNavAndroid.Instance.SetHostURL(Host);
        NextNavAndroid.Instance.InitSdk();
#elif UNITY_IOS
        NextNavIos.Instance.SetDeveloperKey(Key);
        NextNavIos.Instance.SetHostURL(Host);
        NextNavIos.Instance.InitSdk();
#endif
    }

    public void InitObsever()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.InitObsever();
#endif
    }

    public void StartAltitudeCalculationOnce()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.StartAltitudeCalculationOnce();
#elif UNITY_IOS
        NextNavIos.Instance.StartAltitudeCalculationOnce();
#endif
    }

    public void StartAltitudeCalculationEachSecond()
    {
        UIManager.Instance.AddTextToDebugScroll("Start Altitude Calculation");

#if UNITY_ANDROID
        NextNavAndroid.Instance.StartAltitudeCalculationEachSecond();
#elif UNITY_IOS
        NextNavIos.Instance.StartAltitudeCalculationEachSecond();
#endif

        UIManager.Instance.SwitchAltitudeFromStartToStop();
    }

    public void StartAltitudeCalculationEvery30Seconds()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.StartAltitudeCalculationEvery30Seconds();
#elif UNITY_IOS
         NextNavIos.Instance.StartAltitudeCalculationEvery30Seconds();
#endif
    }

    public void StartAltitudeCalculationEvery60Seconds()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.StartAltitudeCalculationEvery60Seconds();
#elif UNITY_IOS
         NextNavIos.Instance.StartAltitudeCalculationEvery60Seconds();
#endif
    }

    public void Start2DLocationInjection()
    {
        string latitude = UIManager.Instance.Get2DLatitude();
        string longitude = UIManager.Instance.Get2DLongitude();

#if UNITY_ANDROID
        NextNavAndroid.Instance.Start2DLocationInjection(latitude, longitude);
#elif UNITY_IOS
         NextNavIos.Instance.Start2DLocationInjection(latitude, longitude);
#endif
    }

    public void StopAltitudeCalculation()
    {
        UIManager.Instance.AddTextToDebugScroll("Stop Altitude Calculation");

#if UNITY_ANDROID
        NextNavAndroid.Instance.StopAltitudeCalculation();
#elif UNITY_IOS
        NextNavIos.Instance.StopAltitudeCalculation();
#endif

        UIManager.Instance.SwitchAltitudeFromStopToStart();
    }

    public void ShowCalibrationUI()
    {
        UIManager.Instance.AddTextToDebugScroll("Launch UI Calibration");

#if UNITY_ANDROID
        NextNavAndroid.Instance.ShowCalibrationUI();
#elif UNITY_IOS
         NextNavIos.Instance.ShowCalibrationUI();
#endif

    }

    public void Stop()
    {
        UIManager.Instance.AddTextToDebugScroll("Stop SDK");

#if UNITY_ANDROID
        NextNavAndroid.Instance.Stop();
#elif UNITY_IOS
         NextNavIos.Instance.Stop();
#endif

        UIManager.Instance.SwitchFromStopToInit();

    }

    public void DebugFromObserver(string messageToDebug)
    {
        UIManager.Instance.AddTextToDebugScroll(messageToDebug);
    }

}

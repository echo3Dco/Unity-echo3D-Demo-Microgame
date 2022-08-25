using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class NextNavAndroid : MonoBehaviour
{
    public static NextNavAndroid Instance;

    const string internalPluginName = "com.trick.nextnavlibrary.NextNavInterfaceNative";

    #region Android variables

    AndroidJavaClass _nextNavSdkClass;
    AndroidJavaObject _nextNavSdkInstance;
    AndroidJavaObject _unityContext;
    static AndroidJavaClass _nextNavInternalPluginClass;
    static AndroidJavaObject _nextNavInternalPluginInstance;

    public static AndroidJavaClass NextNavInternalPluginClass
    {
        get
        {
            if (_nextNavInternalPluginClass == null)
            {
                _nextNavInternalPluginClass = new AndroidJavaClass(internalPluginName);
            }
            return _nextNavInternalPluginClass;
        }
    }

    public static AndroidJavaObject NextNavInternalPluginInstance
    {
        get
        {
            if (_nextNavInternalPluginInstance == null)
            {
                //AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                //var unityActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
                //var context = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

                _nextNavInternalPluginInstance = NextNavInternalPluginClass.GetStatic<AndroidJavaObject>("Companion").Call<AndroidJavaObject>("getInstance");
            }
            return _nextNavInternalPluginInstance;
        }
    }

    #endregion



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

    private void Start()
    {
        SetContext();
    }

    public void SetContext()
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
        var context = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

        NextNavInternalPluginInstance.Call("SetContext", context);

        if(NextNavInterface.Instance != null && NextNavInterface.Instance.IsRequestPermissionsAuto())
        {
            NextNavInterface.Instance.RequestPermissionBtn();
        }
    }


    public void SetDeveloperKey(string key)
    {
        NextNavInternalPluginInstance.Call("SetDeveloperKey", key);
    }

    public void SetHostURL(string hostURL)
    {
        NextNavInternalPluginInstance.Call("SetHostUrl", hostURL);
    }

    public void InitSdk()
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
        var context = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

        NextNavInternalPluginInstance.Call("Init", context);
    }

    public void RequestPermission()
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityActivity = up.GetStatic<AndroidJavaObject>("currentActivity");

        NextNavInternalPluginInstance.Call("RequestPermission", unityActivity);
    }

    public void InitObsever()
    {
        InitObserverAltitude();
        InitObserverStatus();
    }

    public void InitObserverAltitude()
    {
#if !UNITY_EDITOR
            //AndroidJavaClass nextNavObserverAltitudeClass = new AndroidJavaClass("com.trick.nextnavlibrary.NextNavObserverAltitude");
            //var nextNavObserverAltitudeInstance = nextNavObserverAltitudeClass.CallStatic<AndroidJavaObject>("getInstance");
            //nextNavObserverAltitudeInstance.Call("InitObsever");

            AndroidJavaClass nextNavObserverStatusClass = new AndroidJavaClass("com.trick.nextnavlibrary.NextNavObserverAltitude");
            var companionObject = nextNavObserverStatusClass.GetStatic<AndroidJavaObject>("Companion");
            var nextNavObserverAltitudeInstance = companionObject.Call<AndroidJavaObject>("getInstance");
            nextNavObserverAltitudeInstance.Call("InitObsever");
#endif
    }

    public void InitObserverStatus()
    {
#if !UNITY_EDITOR
            AndroidJavaClass nextNavObserverStatusClass = new AndroidJavaClass("com.trick.nextnavlibrary.NextNavObserverStatus");
            var companionObject = nextNavObserverStatusClass.GetStatic<AndroidJavaObject>("Companion");
            var nextNavObserverStatusInstance = companionObject.Call<AndroidJavaObject>("getInstance");
            nextNavObserverStatusInstance.Call("InitObsever");
#endif
    }

    public string GetDeveloperKey()
    {
        string key = NextNavInternalPluginInstance.Call<string>("GetDeveloperKey");

        return key;
    }

    public void StartAltitudeCalculationOnce()
    {
        NextNavInternalPluginInstance.Call("StartAltitudeCalculationOnce");
    }

    public void StartAltitudeCalculationEachSecond()
    {
        NextNavInternalPluginInstance.Call("StartAltitudeCalculationEachSecond");
    }

    public void StartAltitudeCalculationEvery30Seconds()
    {
        NextNavInternalPluginInstance.Call("StartAltitudeCalculationFor30Seconds");
    }

    public void StartAltitudeCalculationEvery60Seconds()
    {
        NextNavInternalPluginInstance.Call("StartAltitudeCalculationFor60Seconds");
    }

    public void Start2DLocationInjection(string latitude, string longitude)
    {
        NextNavInternalPluginInstance.Call("Start2DLocationInjection", latitude, longitude);
    }

    public void StopAltitudeCalculation()
    {
        NextNavInternalPluginInstance.Call("StopAltitudeCalculation");
    }

    public void ShowCalibrationUI()
    {
        NextNavInternalPluginInstance.Call("ShowCalibrationUI");
    }

    public void StartAltitudeCalculation(string calculationType, string lat, string lon, string altitude)
    {
        NextNavInternalPluginInstance.Call("StartAltitudeCalculation", calculationType, lat, lon, altitude);
    }

    public void Stop()
    {
        NextNavInternalPluginInstance.Call("Stop");
    }
}

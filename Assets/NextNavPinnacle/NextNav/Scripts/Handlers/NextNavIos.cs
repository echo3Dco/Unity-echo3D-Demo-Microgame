using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class NextNavIos : MonoBehaviour
{
    public static NextNavIos Instance;

    private string _key = "";



#if UNITY_IOS

    [DllImport("__Internal")]
    private static extern int _setDeveloperKey(string key);

    [DllImport("__Internal")]
    private static extern int _setHostURL(string hostURL);

    [DllImport("__Internal")]
    private static extern int _initSdk();

    [DllImport("__Internal")]
    private static extern int _stop();

    [DllImport("__Internal")]
    private static extern int _launchUICalibration();

    [DllImport("__Internal")]
    private static extern int _startAltitudeCalculationOnce();

    [DllImport("__Internal")]
    private static extern int _startAltitudeCalculationEachSecond();

    [DllImport("__Internal")]
    private static extern int _startAltitudeCalculationEvery30Seconds();

    [DllImport("__Internal")]
    private static extern int _startAltitudeCalculationEvery60Seconds();

    [DllImport("__Internal")]
    private static extern int _start2DLocationInjection(string latitude, string longitude);

    [DllImport("__Internal")]
    private static extern int _stopAltitudeCalculation();

#endif



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

    public void SetDeveloperKey(string key)
    {
        _key = key;

#if UNITY_IOS
            _setDeveloperKey(_key);
#endif
    }

    public void SetHostURL(string hostURL)
    {
#if UNITY_IOS
        _setHostURL(hostURL);
#endif
    }



    public void InitSdk()
    {
        #if UNITY_IOS
            _initSdk();
        #endif
    }

    public void StartAltitudeCalculationOnce()
    {
#if UNITY_IOS
            _startAltitudeCalculationOnce();
#endif
    }

    public void StartAltitudeCalculationEachSecond()
    {
#if UNITY_IOS
            _startAltitudeCalculationEachSecond();
#endif
    }

    public void StartAltitudeCalculationEvery30Seconds()
    {
#if UNITY_IOS
            _startAltitudeCalculationEvery30Seconds();
#endif
    }

    public void StartAltitudeCalculationEvery60Seconds()
    {
#if UNITY_IOS
            _startAltitudeCalculationEvery60Seconds();
#endif
    }

    public void Start2DLocationInjection(string latitude, string longitude)
    {
#if UNITY_IOS
            _start2DLocationInjection(latitude, longitude);
#endif
    }

    public void StopAltitudeCalculation()
    {
#if UNITY_IOS
            _stopAltitudeCalculation();
#endif
    }

    public void ShowCalibrationUI()
    {
        #if UNITY_IOS
            _launchUICalibration();
        #endif
    }

    public void Stop()
    {
#if UNITY_IOS
                    _stop();
#endif
    }
}

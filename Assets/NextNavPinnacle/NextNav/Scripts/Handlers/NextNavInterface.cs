using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class NextNavInterface : MonoBehaviour
{
    public static NextNavInterface Instance;

    public string Key = "";

    public string Host = "api.nextnav.io";

    public bool RequestPermissionsAutomatically;

    private Constants.SdkStatus _sdkStatus = Constants.SdkStatus.NotInitialized;

    #if UNITY_ANDROID
        GameObject dialog = null;
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

    void Start()
    {  

        InitObsever();

        // echo3D added this area /

        // Added to calibrate
        InitSdk();

        // Delay ShowCalibrationUI for  seconds to give time for status code to confirm, looking for code 870 to confirm everything worked
        Invoke("ShowCalibrationUI", 15.0f);
        // 
        Invoke("StartAltitudeCalculationEachSecond", 45.0f); // /


    }

    public void SetDeveloperKey()
    {
#if UNITY_ANDROID
                NextNavAndroid.Instance.SetDeveloperKey(Key);
#elif UNITY_IOS
                NextNavIos.Instance.SetDeveloperKey(Key);
#endif
    }

    public bool IsRequestPermissionsAuto()
    {
        return RequestPermissionsAutomatically;
    }

    public void RequestPermissionBtn()
    {
        RequestPermissions();
    }

    public void InitSdk()
    {
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
#if UNITY_ANDROID
        NextNavAndroid.Instance.StartAltitudeCalculationEachSecond();
#elif UNITY_IOS
        NextNavIos.Instance.StartAltitudeCalculationEachSecond();
#endif
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

    public void Start2DLocationInjection(string latitude = "0", string longitude = "0")
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.Start2DLocationInjection(latitude, longitude);
#elif UNITY_IOS
         NextNavIos.Instance.Start2DLocationInjection(latitude, longitude);
#endif
    }

    public void StopAltitudeCalculation()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.StopAltitudeCalculation();
#elif UNITY_IOS
        NextNavIos.Instance.StopAltitudeCalculation();
#endif
    }

    public void ShowCalibrationUI()
    {
#if UNITY_ANDROID
        NextNavAndroid.Instance.ShowCalibrationUI();
#elif UNITY_IOS
         NextNavIos.Instance.ShowCalibrationUI();
#endif
    }

    public void Stop()
    {
#if UNITY_ANDROID
         NextNavAndroid.Instance.Stop();
#elif UNITY_IOS
         NextNavIos.Instance.Stop();
#endif
    }

    public void Callback(string stringData)
    {
        try
        {
            //Data expected:
            //string callbackType, int sdkStatus = 0, string sdkStatusCode = "", string heightHat = "", string heightUncertaintyHat = "", string height = "", string heightUncertainty = "", string timeStamp = "", string error = ""
            var stringDataArray = stringData.Split(',');

            string callbackType = stringDataArray[0];
            string sdkStatus = stringDataArray[1];
            string sdkStatusCode = stringDataArray[2];
            string heightHat = stringDataArray[3];
            string heightUncertaintyHat = stringDataArray[4];
            string timeStamp = stringDataArray[5];
            string error = stringDataArray[6];

            Constants.CallbackType callbackTypeParsed = (Constants.CallbackType)System.Enum.Parse(typeof(Constants.CallbackType), callbackType);


            switch (callbackTypeParsed)
            {
                case Constants.CallbackType.SDK_Status:
                    try
                    {
                        Constants.SdkStatus sdkStatusEnum = (Constants.SdkStatus)System.Enum.Parse(typeof(Constants.SdkStatus), sdkStatus);

                        var _sdkStatusCode = int.Parse(stringDataArray[2]);

                        if (_sdkStatus != sdkStatusEnum)
                        {
                            if(_sdkStatusCode == 800 || _sdkStatusCode == 896 || _sdkStatusCode == 811 || _sdkStatusCode == 870)
                                _sdkStatus = sdkStatusEnum;
                        }

                        CallbackStatus(_sdkStatus, _sdkStatusCode);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case Constants.CallbackType.Data:
                    CallackData(heightHat, heightUncertaintyHat, timeStamp);
                    break;
                case Constants.CallbackType.Error:
                    CallbackError(error);
                    break;
            }
        }
        catch
        {
            return;
        }
    }


    private void CallbackStatus(Constants.SdkStatus status, int statusCode)
    {
        //You can replace this code with yours
        // If status code is x, do this (run game mechanics), get it to status code 800 so it's running correctly

        UIManager.Instance.UpdateUIBasedOnSdkStatus(status);
        UIManager.Instance.AddTextToDebugScroll("Sdk Status Code: " + statusCode);
    }

    private void CallackData(string heightHat, string heightUncertaintyHat, string timeStamp)
    {
        //You can replace this code with yours

        if (UIManager.Instance == null)
            return;

        float _heightHat;
        float _heightUncertaintyHat;

        if (float.TryParse(heightHat, out _heightHat) && float.TryParse(heightUncertaintyHat, out _heightUncertaintyHat))
        {
            if (PlayerController.Instance != null)
                PlayerController.Instance.SetPlayerHeight(_heightHat);

            UIManager.Instance.UpdateHeightsHat(_heightHat, _heightUncertaintyHat);

            string heightWithTimeText = _heightHat + " - TimeStamp: " + timeStamp;
            UIManager.Instance.AddTextToDebugScroll(heightWithTimeText);
        }
        else
        {
            UIManager.Instance.AddTextToDebugScroll("Error: Error trying To Parse the heights hats");
        }
    }

    private void CallbackError(string error)
    {
        //You can replace this code with yours

        if(UIManager.Instance != null)
            UIManager.Instance.AddTextToDebugScroll(error);
    }

    public void DebugFromObserver(string messageToDebug)
    {
        if (UIManager.Instance != null)
            UIManager.Instance.AddTextToDebugScroll(messageToDebug);
    }

    private void RequestPermissions()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            dialog = new GameObject();
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.CoarseLocation);
            dialog = new GameObject();
        }

        NextNavAndroid.Instance.RequestPermission();
#endif

    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
                if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                {
                    // Display a message explaining why you need it with Yes/No buttons.
                    // If the user says yes then present the request again
                    // Display a dialog here.
                    if (dialog != null)
                        dialog.AddComponent<PermissionsRationaleDialog>();
                    return;
                }
                else if (dialog != null)
                {
                    Destroy(dialog);
                }

                if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
                {
                    // Display a message explaining why you need it with Yes/No buttons.
                    // If the user says yes then present the request again
                    // Display a dialog here.
                    if (dialog != null)
                        dialog.AddComponent<PermissionsRationaleDialog>();
                    return;
                }
                else if (dialog != null)
                {
                    Destroy(dialog);
                }
#endif

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("SDK Status")]
    public Sprite SDK_Status_Red;
    public Sprite SDK_Status_Yellow;
    public Sprite SDK_Status_Green;
    public Image SDK_Status_Image;

    [Space(10)]
    [Header("Buttons References")]
    public Button Init_Btn;
    public Button Calibration_Btn;
    public Button StartAltitude_Btn;

    [Space(10)]
    [Header("Buttons Icon States")]
    public Sprite Init_Btn_Off;
    public Sprite Init_Btn_On;
    public Sprite Calibration_Btn_Off;
    public Sprite Calibration_Btn_On;
    public Sprite StartAltitude_Btn_Off;
    public Sprite StartAltitude_Btn_On;

    [Space(10)]
    [Header("Buttons Icon References")]
    public Image Init_Icon;
    public Image StartAltitude_Icon;
    public Image Calibration_Icon;

    [Space(10)]
    [Header("Height Hat Bar References")]
    public Slider HeightHat_Slider;
    public TMP_Text HeightHat_Text;

    [Space(10)]
    [Header("2D Location Injection")]
    public InputField LatitudeInputField;
    public InputField LongitudeInputField;
    public GameObject LocationInjectionPopUp;


    [Space(10)]
    [Header("Height Indicators Reference")]
    public TMP_Text Height_10_Text;
    public TMP_Text Height_9_Text;
    public TMP_Text Height_8_Text;
    public TMP_Text Height_7_Text;
    public TMP_Text Height_6_Text;
    public TMP_Text Height_5_Text;
    public TMP_Text Height_4_Text;
    public TMP_Text Height_3_Text;
    public TMP_Text Height_2_Text;
    public TMP_Text Height_1_Text;
    public TMP_Text Height_N1_Text;
    public TMP_Text Height_N2_Text;
    public TMP_Text Height_N3_Text;
    public TMP_Text Height_N4_Text;
    public TMP_Text Height_N5_Text;
    public TMP_Text Height_N6_Text;
    public TMP_Text Height_N7_Text;
    public TMP_Text Height_N8_Text;
    public TMP_Text Height_N9_Text;
    public TMP_Text Height_N10_Text;


    [Space(10)]
    [Header("Height Rings & Icon References")]
    public Image HeightRing;
    public Sprite RingRed;
    public Sprite RingYellow;
    public Sprite RingGreen;

    [Space(10)]
    [Header("Debug Scroll Text")]
    public TMP_Text DebugText;
    public RectTransform ScrollContent;


    private float _lastHeightValue = 0f;

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
        if(Init_Btn != null)
            Init_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.InitSdk);
        
        if(StartAltitude_Btn != null)
            StartAltitude_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.StartAltitudeCalculationEachSecond);

        ResetSliders();

    }


    private void ResetSliders()
    {
        if (HeightHat_Slider == null || HeightHat_Text == null)
            return;

        HeightHat_Slider.value = HeightHat_Slider.minValue;
        HeightHat_Text.text = "0.00";
    }

    public void SetNewLocationPopUpState()
    {
        if (LocationInjectionPopUp == null)
            return;

        var state = LocationInjectionPopUp.activeSelf;

        LocationInjectionPopUp.SetActive(!state);
    }

    public string Get2DLatitude()
    {
        if (LatitudeInputField == null)
            return "0";

        var value = "0";

        if (!string.IsNullOrEmpty(LatitudeInputField.text))
            value = LatitudeInputField.text;

        return value;
    }

    public string Get2DLongitude()
    {
        if (LongitudeInputField == null)
            return "0";

        var value = "0";

        if (!string.IsNullOrEmpty(LongitudeInputField.text))
            value = LongitudeInputField.text;

        return value;
    }

    public void UpdateUIBasedOnSdkStatus(Constants.SdkStatus sdkStatus)
    {
        if (SDK_Status_Image == null || Init_Btn == null || Init_Icon == null || StartAltitude_Btn == null || StartAltitude_Icon == null
            || Calibration_Btn == null || Calibration_Icon == null)
            return;

        switch(sdkStatus)
        {
            case Constants.SdkStatus.NotInitialized:
                SDK_Status_Image.sprite = SDK_Status_Red;

                //Init
                Init_Btn.interactable = true;

                Init_Icon.sprite = Init_Btn_Off;
                Init_Icon.SetNativeSize();

                //Start Altitude
                StartAltitude_Btn.interactable = false;

                StartAltitude_Icon.sprite = StartAltitude_Btn_Off;
                StartAltitude_Icon.SetNativeSize();

                //Calibration 
                Calibration_Btn.interactable = false;

                Calibration_Icon.sprite = Calibration_Btn_Off;
                Calibration_Icon.SetNativeSize();

                break;
            case Constants.SdkStatus.Initialized:
                SDK_Status_Image.sprite = SDK_Status_Yellow;

                SwitchFromInitToStop();

                //Init
                //Init_Btn.interactable = false;

                //Init_Icon.sprite = Init_Btn_On;
                //Init_Icon.SetNativeSize();

                //Start Altitude
                StartAltitude_Btn.interactable = false;

                //Calibration
                Calibration_Btn.interactable = true;

                break;
            case Constants.SdkStatus.CalibrationSuccess:
                SDK_Status_Image.sprite = SDK_Status_Green;

                //Init
                Init_Btn.interactable = false;

                //Start Altitude
                StartAltitude_Btn.interactable = true;

                //Calibration
                Calibration_Btn.interactable = false;

                Calibration_Icon.sprite = Calibration_Btn_On;
                Calibration_Icon.SetNativeSize();

                break;
        }
    }

    public void AddTextToDebugScroll(string textToAdd)
    {
        if (DebugText == null)
            return;

        DebugText.text += "\n";
        DebugText.text += textToAdd;

        var debugTextRectTransform = DebugText.gameObject.GetComponent<RectTransform>();

        if(debugTextRectTransform != null)
        {
            debugTextRectTransform.sizeDelta = new Vector2(debugTextRectTransform.sizeDelta.x, debugTextRectTransform.sizeDelta.y + 47);

            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 47);
            ScrollContent.position = new Vector3(ScrollContent.position.x, ScrollContent.position.y + 47, ScrollContent.position.z);
        }
    }

    public void UpdateHeightsHat(float heightHat, float heightUncertaintyHat)
    {
        if (HeightHat_Slider == null || HeightHat_Text == null)
            return;

        if (heightUncertaintyHat < 8)
        {
            HeightRing.sprite = RingGreen;
        }
        else if (heightUncertaintyHat > 8 && heightUncertaintyHat < 11)
        {
            HeightRing.sprite = RingYellow;
        }
        else if (heightUncertaintyHat > 11)
        {
            HeightRing.sprite = RingRed;
        }

        HeightHat_Slider.value = Mathf.Clamp(heightHat, HeightHat_Slider.minValue, HeightHat_Slider.maxValue);
        HeightHat_Text.text = heightHat.ToString("F2") + " HAT";

        UpdateHeightMinAndMax(heightHat);
    }

    public void UpdateHeightMinAndMax(float newHeight)
    {
        if (Height_10_Text == null || Height_9_Text == null || Height_8_Text == null || Height_7_Text == null || Height_6_Text == null || Height_5_Text == null ||
            Height_4_Text == null || Height_3_Text == null || Height_2_Text == null || Height_1_Text == null || Height_N1_Text == null || Height_N2_Text == null ||
            Height_N3_Text == null || Height_N4_Text == null || Height_N5_Text == null || Height_N6_Text == null || Height_N7_Text == null || Height_N8_Text == null ||
            Height_N9_Text == null || Height_N10_Text == null)
            return;

        var newMaxValue = Mathf.FloorToInt(newHeight + 10);
        var newMinValue = Mathf.FloorToInt(newHeight - 10);

        HeightHat_Slider.maxValue = newHeight + 10;
        HeightHat_Slider.minValue = newHeight - 10;

        Height_10_Text.text = newMaxValue.ToString();
        Height_9_Text.text = Mathf.FloorToInt(newHeight + 9).ToString();
        Height_8_Text.text = Mathf.FloorToInt(newHeight + 8).ToString();
        Height_7_Text.text = Mathf.FloorToInt(newHeight + 7).ToString();
        Height_6_Text.text = Mathf.FloorToInt(newHeight + 6).ToString();
        Height_5_Text.text = Mathf.FloorToInt(newHeight + 5).ToString();
        Height_4_Text.text = Mathf.FloorToInt(newHeight + 4).ToString();
        Height_3_Text.text = Mathf.FloorToInt(newHeight + 3).ToString();
        Height_2_Text.text = Mathf.FloorToInt(newHeight + 2).ToString();
        Height_1_Text.text = Mathf.FloorToInt(newHeight + 1).ToString();

        Height_N1_Text.text = Mathf.FloorToInt(newHeight - 1).ToString();
        Height_N2_Text.text = Mathf.FloorToInt(newHeight - 2).ToString();
        Height_N3_Text.text = Mathf.FloorToInt(newHeight - 3).ToString();
        Height_N4_Text.text = Mathf.FloorToInt(newHeight - 4).ToString();
        Height_N5_Text.text = Mathf.FloorToInt(newHeight - 5).ToString();
        Height_N6_Text.text = Mathf.FloorToInt(newHeight - 6).ToString();
        Height_N7_Text.text = Mathf.FloorToInt(newHeight - 7).ToString();
        Height_N8_Text.text = Mathf.FloorToInt(newHeight - 8).ToString();
        Height_N9_Text.text = Mathf.FloorToInt(newHeight - 9).ToString();
        Height_N10_Text.text = newMinValue.ToString();

        _lastHeightValue = newHeight;
    }

    public void SwitchAltitudeFromStartToStop()
    {
        if (StartAltitude_Btn == null || StartAltitude_Icon == null)
            return;

        StartAltitude_Btn.onClick.RemoveAllListeners();
        StartAltitude_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.StopAltitudeCalculation);

        StartAltitude_Icon.sprite = StartAltitude_Btn_On;
        StartAltitude_Icon.SetNativeSize();
    }

    public void SwitchAltitudeFromStopToStart()
    {
        if (StartAltitude_Btn == null || StartAltitude_Icon == null)
            return;

        StartAltitude_Btn.onClick.RemoveAllListeners();
        StartAltitude_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.StartAltitudeCalculationEachSecond);

        StartAltitude_Icon.sprite = StartAltitude_Btn_Off;
        StartAltitude_Icon.SetNativeSize();
    }

    public void SwitchFromInitToStop()
    {
        if (Init_Btn == null || Init_Icon == null)
            return;

        Init_Btn.onClick.RemoveAllListeners();
        Init_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.Stop);

        Init_Icon.sprite = Init_Btn_On;
        Init_Icon.SetNativeSize();
    }

    public void SwitchFromStopToInit()
    {
        if (Init_Btn == null || Init_Icon == null)
            return;

        Init_Btn.onClick.RemoveAllListeners();
        Init_Btn.onClick.AddListener(NextNavInterfaceDemo.Instance.InitSdk);

        Init_Icon.sprite = Init_Btn_Off;
        Init_Icon.SetNativeSize();
    }



}

#if UNITY_EDITOR

using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;
using UnityEngine.VspAttribution.NextNav;

public class NextNavAutoConfiguration
{
    public static void AutoConfiguration()
    {
        if (!PlayerPrefs.HasKey("NextNavConfiguration"))
            PlayerPrefs.SetInt("NextNavConfiguration", 0);

        //Set the graphic api for ios
        if (PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.iOS) || PlayerSettings.GetGraphicsAPIs(BuildTarget.iOS)[0] != GraphicsDeviceType.Metal)
        {
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.iOS, false);

            //Set the graphics api for ios
            GraphicsDeviceType[] apis = new GraphicsDeviceType[1];
            apis[0] = GraphicsDeviceType.Metal;

            PlayerSettings.SetGraphicsAPIs(BuildTarget.iOS, apis);
        }

        //Set the min sdk target
        if (PlayerSettings.Android.minSdkVersion < AndroidSdkVersions.AndroidApiLevel22)
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel22;

        #if UNITY_2021_1_OR_NEWER
                if (PlayerSettings.Android.targetSdkVersion > AndroidSdkVersions.AndroidApiLevel29)
                    PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel29;
        #else
                if (PlayerSettings.Android.targetSdkVersion > AndroidSdkVersions.AndroidApiLevel28)
                    PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel28;
        #endif



        if (PlayerPrefs.GetInt("NextNavConfiguration") == 0) 
        {
            //VSP Unity to upload new user event
            var customerUid = AnalyticsSessionInfo.userId;

            if(!string.IsNullOrEmpty(customerUid))
            {
                var result = VspAttribution.SendAttributionEvent("New User", "NextNav", customerUid);
                //Debug.Log($"[VSP Attribution] Attribution Event returned status: {result}!");
            }

            //Move the files needed to build successfully
#if UNITY_2022_1_OR_NEWER
            var filesPath = Application.dataPath + "/NextNavPinnacle/NextNav/Unity Different Versions Support/" + "2022/";

            var directory = new DirectoryInfo(filesPath);
            var filesInDirectory = directory.GetFiles();

            foreach (var file in filesInDirectory)
            {
                //To avoid reading meta files
                if (!file.Name.Contains("meta"))
                {
                    var filePath = filesPath + file.Name;
                    var finalPath = Application.dataPath + "/Plugins/Android/" + file.Name;

                    File.Copy(filePath, finalPath, true);
                } 
            }
             
            PlayerPrefs.SetInt("NextNavConfiguration", 1); 
            Debug.Log("NextNav: AutoConfiguration Success."); 

            
#elif UNITY_2021_1_OR_NEWER

            var filesPath = Application.dataPath + "/NextNavPinnacle/NextNav/Unity Different Versions Support/" + "2021/";
           
            var directory = new DirectoryInfo(filesPath);  
            var filesInDirectory = directory.GetFiles();

            foreach (var file in filesInDirectory)
            { 
                //To avoid reading meta files
                if (!file.Name.Contains("meta"))
                {
                    var filePath = filesPath + file.Name;
                    var finalPath = Application.dataPath + "/Plugins/Android/" + file.Name;

                    File.Copy(filePath, finalPath, true);
                }
            }

            PlayerPrefs.SetInt("NextNavConfiguration", 1);
            Debug.Log("NextNav: AutoConfiguration Success.");

#elif UNITY_2020_3_OR_NEWER

            var filesPath = Application.dataPath + "/NextNavPinnacle/NextNav/Unity Different Versions Support/" + "2020/";

            var directory = new DirectoryInfo(filesPath);
            var filesInDirectory = directory.GetFiles();
             
            foreach (var file in filesInDirectory)
            {
                //To avoid reading meta files
                if (!file.Name.Contains("meta"))
                {
                    var filePath = filesPath + file.Name;
                    var finalPath = Application.dataPath + "/Plugins/Android/" + file.Name;

                    File.Copy(filePath, finalPath, true);
                }
            }

            PlayerPrefs.SetInt("NextNavConfiguration", 1);
            Debug.Log("NextNav: AutoConfiguration Success.");

#elif UNITY_2019_1_OR_NEWER

            var filesPath = Application.dataPath + "/NextNavPinnacle/NextNav/Unity Different Versions Support/" + "2019/";

            var directory = new DirectoryInfo(filesPath);
            var filesInDirectory = directory.GetFiles();

            foreach (var file in filesInDirectory)
            {
                //To avoid reading meta files
                if (!file.Name.Contains("meta"))
                {
                    var filePath = filesPath + file.Name;
                    var finalPath = Application.dataPath + "/Plugins/Android/" + file.Name;

                    File.Copy(filePath, finalPath, true);
                }
            }

            PlayerPrefs.SetInt("NextNavConfiguration", 1);
            Debug.Log("NextNav: AutoConfiguration Success.");
#endif

        }
    }

    [UnityEditor.Callbacks.DidReloadScripts]
    private static void OnScriptsReloaded()
    {
        try
        {
            AutoConfiguration();
        }
        catch
        {
            Debug.LogError("NextNav: AutoConfiguration Failed.");
        }
    }
}
#endif
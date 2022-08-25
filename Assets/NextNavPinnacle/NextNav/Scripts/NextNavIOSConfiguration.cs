#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NextNavIOSConfiguration : MonoBehaviour
{
    [MenuItem("NextNav/Choose iOS Map API/Apple Maps")]
    static void SetAppleMaps()
    {
        try
        {
            //Delete the plugin files
            var appleFiles = Application.dataPath + "/NextNavPinnacle/NextNav/iOS Maps/Apple/NextNavLibrary/Source/";
            var pluginioOSPath = Application.dataPath + "/Plugins/iOS/";

            var NNGoogleMapsManagerPath = pluginioOSPath + "NNGoogleMapsManager.swift";
            var unityPluginPath = pluginioOSPath + "UnityPlugin.swift";
            var unityPluginBridgePath = pluginioOSPath + "UnityPluginBridge.mm";
            var unityPluginBridgingHeaderPath = pluginioOSPath + "UnityPlugin-Bridging-Header.h";

            if (File.Exists(NNGoogleMapsManagerPath))
                File.Delete(NNGoogleMapsManagerPath);

            if (File.Exists(unityPluginPath))
                File.Delete(unityPluginPath);

            if (File.Exists(unityPluginBridgePath))
                File.Delete(unityPluginBridgePath);

            if (File.Exists(unityPluginBridgingHeaderPath))
                File.Delete(unityPluginBridgingHeaderPath);

            //Copy the new ones
            File.Copy(appleFiles + "UnityPlugin.swift", unityPluginPath);
            File.Copy(appleFiles + "UnityPluginBridge.mm", unityPluginBridgePath);
            File.Copy(appleFiles + "UnityPluginBridge.mm", unityPluginBridgingHeaderPath);
        }
        catch
        {
            Debug.LogError("Error trying to change the map api");
        }
    }

    [MenuItem("NextNav/Choose iOS Map API/Google Maps")]
    static void SetGoogleMaps()
    {
        try
        {
            //Delete the plugin files
            var appleFiles = Application.dataPath + "/NextNavPinnacle/NextNav/iOS Maps/Google/NextNavLibrary/Source/";
            var pluginioOSPath = Application.dataPath + "/Plugins/iOS/";

            var NNGoogleMapsManagerPath = pluginioOSPath + "NNGoogleMapsManager.swift";
            var unityPluginPath = pluginioOSPath + "UnityPlugin.swift";
            var unityPluginBridgePath = pluginioOSPath + "UnityPluginBridge.mm";
            var unityPluginBridgingHeaderPath = pluginioOSPath + "UnityPlugin-Bridging-Header.h";

            if (File.Exists(NNGoogleMapsManagerPath))
                File.Delete(NNGoogleMapsManagerPath);

            if (File.Exists(unityPluginPath))
                File.Delete(unityPluginPath);

            if (File.Exists(unityPluginBridgePath))
                File.Delete(unityPluginBridgePath);

            if (File.Exists(unityPluginBridgingHeaderPath))
                File.Delete(unityPluginBridgingHeaderPath);

            //Copy the new ones
            File.Copy(appleFiles + "NNGoogleMapsManager.swift", NNGoogleMapsManagerPath);
            File.Copy(appleFiles + "UnityPlugin.swift", unityPluginPath);
            File.Copy(appleFiles + "UnityPluginBridge.mm", unityPluginBridgePath);
            File.Copy(appleFiles + "UnityPluginBridge.mm", unityPluginBridgingHeaderPath);
        }
        catch
        {
            Debug.LogError("Error trying to change the map api");
        }
    }
}

#endif

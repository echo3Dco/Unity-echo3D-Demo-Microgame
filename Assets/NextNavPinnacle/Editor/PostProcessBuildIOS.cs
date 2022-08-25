using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using UnityEditor.iOS.Xcode;
using System.IO;

public class PostProcessBuildIOS : MonoBehaviour
{
    [PostProcessBuild]
    public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            // Get plist
            string plistPath = pathToBuiltProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            // Get root
            PlistElementDict rootDict = plist.root;

            // background location useage key (new in iOS 8)
            //rootDict.SetString("NSLocationAlwaysUsageDescription", "Uses background location");

            rootDict.SetString("NSLocationWhenInUseUsageDescription", "Your current location will be used to calculate height");

            rootDict.SetString("NSMotionUsageDescription", "Your motion Activity will be used to calculate height");

            // background modes
            PlistElementArray bgModes = rootDict.CreateArray("UIBackgroundModes");
            bgModes.AddString("location");
            bgModes.AddString("fetch");

            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}

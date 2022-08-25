//
//  UnityPlugin.swift
//  NextNavLibrary
//
//  Created by Trick on 26/10/2020.
//  Copyright © 2020 Trick. All rights reserved.
//

import Foundation
import NextNavPlus
import UIKit
import CoreLocation
import MapKit

@objc public class UnityPlugin : NSObject {
    
    @objc public static let shared = UnityPlugin()

    @objc public var _key = ""
    @objc public var _hostURL = ""

    //CALLBACK TYPES
    //SDK_Status
    //Data
    //Error

    //SDK STATUS
    //NotInitialized
    //Initialized
    //CalibrationSuccess

    //Example method callback on unity side
    //public void Callback(string callbackType, int sdkStatus = 0, string sdkStatusCode = "", string heightHat = "", string heightUncertaintyHat = "", string timeStamp = "", string error = "")

    //Create a string with the params divided by "," here an example:
    //   let stringData = "callbackType, sdkStatus, sdkStatusCode, heightHat, heightUncertaintyHat, timeStamp, error"
    // UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)


    @objc public func SetDeveloperKey(key : String)
    {
        _key = key
    }

    @objc public func SetHostURL(hostURL : String)
    {
        _hostURL = hostURL
    }

    @objc public func InitSdk()
    {
        NNSDK.start(baseURL: _hostURL, secretKey: _key, success: initSuccess, failure: initFailure)
    }
    
    var initSuccess: ((Int, Int) -> Void) = { statusCode, timestamp in
        //UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "DebugFromObserver", message: String(statusCode))
        
        if(statusCode == 800)
        {
            let stringData = "SDK_Status, Initialized, " + String(statusCode) + ", heightHat, heightUncertaintyHat, timeStamp, error"
            
            UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
        }
        else if (statusCode == 870)
        {
            let stringData = "SDK_Status, CalibrationSuccess, " + String(statusCode) + ", heightHat, heightUncertaintyHat, timeStamp, error"
            
            UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
        }
        else
        {
            let stringData = "SDK_Status, NotInitialized, " + String(statusCode) + ", heightHat, heightUncertaintyHat, timeStamp, error"
            
            UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
        }
        
    }
    
    var initFailure: ((Int, Int) -> Void) = { statusCode, timestamp in
        //UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "DebugFromObserver", message: String(statusCode))
        
        let stringData = "SDK_Status, NotInitialized, " + String(statusCode) + ", heightHat, heightUncertaintyHat, timeStamp, error"
        
        UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
    }
    

    @objc public func LaunchUICalibration()
    {
        NNSDKUI.initiateNativeManualBarocalUI(mode: NNManualBarocalMode.thirtySeconds) { uiViewController in
            
            UIApplication.topViewController()?.present(uiViewController, animated: true, completion: nil)
            
        } mapHandler: { NNManualBarocalState in
            
        }
    }

    @objc public func StartAltitudeCalculationOnce()
    {
        NNSDK.startAltitudeCalculation(mode: NNAltitudeMode.oneTime, handler: altitudeCalculationHandler)
    }

    @objc public func StartAltitudeCalculationEachSecond()
    {
        NNSDK.startAltitudeCalculation(mode: NNAltitudeMode.oneSecond, handler: altitudeCalculationHandler)
    }

    @objc public func StartAltitudeCalculationEvery30Seconds()
    {
        NNSDK.startAltitudeCalculation(mode: NNAltitudeMode.thirtySeconds, handler: altitudeCalculationHandler)
    }

    @objc public func StartAltitudeCalculationEvery60Seconds()
    {
        NNSDK.startAltitudeCalculation(mode: NNAltitudeMode.oneMinute, handler: altitudeCalculationHandler)
    }

    @objc public func Start2DLocationInjection(latitude : String, longitude : String)
    {
        let _latitude = Double(latitude) ?? 0.00
        let _longitude = Double(longitude) ?? 0.00

        let location = CLLocation(latitude : _latitude, longitude : _longitude)

        NNSDK.setAltitude(location: location, pressure: 0)
    }

    @objc public func StopAltitudeCalculation()
    {
        NNSDK.stopAltitudeCalculation(handler: altitudeCalculationHandler)
    }

    @objc public func Stop()
    {
        NNSDK.stop()
    }
    
    var altitudeCalculationHandler: ((Int?, NNAltitudeContext?) -> Void) = { statusCode, object in
        
        if statusCode != nil {
            //UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "DebugFromObserver", message: String(statusCode!))
            
            if(statusCode == 800)
            {
                let stringData = "SDK_Status, Initialized, " + String(statusCode!) + ", heightHat, heightUncertaintyHat, timeStamp, error"
                
                UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
            }
            else if (statusCode == 870)
            {
                let stringData = "SDK_Status, CalibrationSuccess, " + String(statusCode!) + ", heightHat, heightUncertaintyHat, timeStamp, error"
                
                UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
            }
            else
            {
                let stringData = "SDK_Status, NotInitialized, " + String(statusCode!) + ", heightHat, heightUncertaintyHat, timeStamp, error"
                
                UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
            }
        }
        
        if object != nil {           
            let heightHat : Double = object?.heightAboveTerrain ?? 0
            let heightHatParsed: String = String(format: "%f", heightHat)
            
            let heightUncertaintyHat : Double = object?.heightAboveTerrainUncertainty ?? 0
            let heightUncertaintyHatParsed: String = String(format: "%f", heightUncertaintyHat)
            
            let timeStamp: String = String(object?.timestampOfAltitude ?? 0);

            let stringData = "Data, Initialized, sdkStatusCode, " +  heightHatParsed + "," + heightUncertaintyHatParsed + "," + timeStamp + ", error"
            
            UnityFramework.getInstance().sendMessageToGO(withName: "NextNavInterface", functionName: "Callback", message: stringData)
        }

        if statusCode == 870 {
            UserDefaults.standard.removeObject(forKey: "manualBarocalRequired")
            UserDefaults.standard.synchronize()
        }
    }
}

extension UIApplication {
    class func topViewController(viewController: UIViewController? = UIApplication.shared.keyWindow?.rootViewController) -> UIViewController? {
        if let nav = viewController as? UINavigationController {
            return topViewController(viewController: nav.visibleViewController)
        }
        if let tab = viewController as? UITabBarController {
            if let selected = tab.selectedViewController {
                return topViewController(viewController: selected)
            }
        }
        if let presented = viewController?.presentedViewController {
            return topViewController(viewController: presented)
        }
        return viewController
    }
}

//
//  UnityPluginBridge.m
//  NextNavLibrary
//
//  Created by Trick on 26/10/2020.
//  Copyright © 2020 Trick. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "UnityFramework/UnityFramework-Swift.h"

extern "C" {
    
#pragma mark - Functions

    void _initSdk() {
        
        [[UnityPlugin shared] InitSdk];
    }

    void _stop()
    {
        [[UnityPlugin shared] Stop];
    }

    void _launchUICalibration()
    {
        [[UnityPlugin shared] LaunchUICalibration];
    }

    void _startAltitudeCalculationOnce()
    {
        [[UnityPlugin shared] StartAltitudeCalculationOnce];
    }

    void _startAltitudeCalculationEachSecond()
    {
        [[UnityPlugin shared] StartAltitudeCalculationEachSecond];
    }

    void _startAltitudeCalculationEvery30Seconds()
    {
        [[UnityPlugin shared] StartAltitudeCalculationEvery30Seconds];
    }

    void _startAltitudeCalculationEvery60Seconds()
    {
        [[UnityPlugin shared] StartAltitudeCalculationEvery60Seconds];
    }

    void _start2DLocationInjection(const char *latitude, const char *longitude)
    {
        [[UnityPlugin shared] Start2DLocationInjectionWithLatitude:([NSString stringWithUTF8String:latitude]) longitude:([NSString stringWithUTF8String:longitude])];
    }

    void _stopAltitudeCalculation()
    {
        [[UnityPlugin shared] StopAltitudeCalculation];
    }

    void _setDeveloperKey(const char *key)
    {
        [[UnityPlugin shared] SetDeveloperKeyWithKey:([NSString stringWithUTF8String:key])];
    }

    void _setHostURL(const char *hostURL)
    {
        [[UnityPlugin shared] SetHostURLWithHostURL:([NSString stringWithUTF8String:hostURL])];
    }
}

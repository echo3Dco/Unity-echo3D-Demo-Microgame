//
//  NNSDK.swift
//

import CoreLocation

public enum NNSDKState: Int {
    case authorizationError = 401
    case authorizationFailure = 403

    case sdkInitialized = 800
    case sdkInitializing = 801
    case pressureInitializing = 802
    case locationInitializing = 803
    case noPressureAvailable = 804
    case noLocationAvailable = 805
    case sdkAlreadyInitialized = 808
    case sdkInitializingFailed = 806
    case sdkNotInitialized = 810
    case sdkStopped = 811
    case sdkInvalidURL = 815
    case sdkRegistrationCompleted = 901
    
    case altitudeModeActivated = 830
    case waitingForPhonePressure = 832
    case locationWaitingStatus  = 833
    case altitudeModeDeactivated = 835
    case highDeltaInPressure = 836
    case highDeltaInLocation = 837
    case outOfGeofence = 838
    case inGeofence = 839

    case unableToReachServer = 851
    case stalePressure = 852

    case motionPermissionNotGranted = 897
    case motionWaitingStatus  = 807
    
    case manualCalibirationSuccess = 870
    case manualCalibirationInProgress = 871
    case manualCalibirationFailed = 872
    case manualCalibirationLocation = 873
    case manualCalibirationLocationUncertainty = 874
    case manualCalibirationInvalidLocationMovemement = 875
    case manualCalibirationInvalidPhoneMovement = 876
    case manualCalibirationNotFullyCompleted = 878
    case manualCalibirationInvalidLocation = 879

    case locationPermissionNotGranted = 898
    
    case noUserIDAvailable = 1101
    case noUsersAvailable = 1102
    case invalidScaleHeight = 1103
    case duplicateUserIDAvailable = 1104
}

public enum NNAltitudeMode: Double {
    case oneTime = 0
    case oneSecond = 1
    case thirtySeconds = 30
    case oneMinute = 60
}

public enum NNConsistenyFilter: Int {
    case location = 0
    case activity
    case pressure
}

public typealias NNSDKHandler = (_ code: Int, _ timeStamp: Int) -> Void
public typealias NNAltitudeHandler = (_ code: Int?, _ context: NNAltitudeContext?) -> Void
public typealias NNSDKCompletionHandler = (_ status: Bool) -> Void

public class NNSDK {
    
    public init() {}
    
    public static func start( baseURL: String, secretKey: String, location: CLLocation? = nil, success: NNSDKHandler?, failure: NNSDKHandler?) {
        NNSDKInitializer.shared.start(baseURL: baseURL, secretKey: secretKey, location: location, success: success, failure: failure)
    }

    public static func stop() {
        NNSDKInitializer.shared.stop()
    }

    public static func startAltitudeCalculation(mode: NNAltitudeMode, handler: @escaping NNAltitudeHandler) {
        NNSDKInitializer.shared.startAltitudeCalculation(mode: mode, handler: handler)
    }
  
    public static func stopAltitudeCalculation(handler: @escaping NNAltitudeHandler) {
        NNSDKInitializer.shared.stopAltitudeCalculation(handler: handler)
    }
    
    public static func version() -> String {
        return NNSDKInitializer.shared.version()
    }
    
    public static func sdkInitializationStatus() -> (Bool, Int) {
        return NNSDKInitializer.shared.sdkInitializationStatus()
    }

    public static func setAltitude(location: CLLocation? = nil, pressure: Double? = nil) // Pressure needs to be in pascal
    {
        NNSDKInitializer.shared.setAltitude(location: location, pressure: pressure)
    }
    
    public static func startBarocalUpload(handler: @escaping NNSDKCompletionHandler) {
        NNSDKInitializer.shared.startBarocalUpload(handler: handler)
    }
    
    public static func startManualCalibration(mode: NNManualBarocalMode, location: CLLocation, floorNumber: Int? = nil, groundMSLHeight: Double? = nil, pressure: Double? = nil) {
        NNSDKInitializer.shared.manualCalibirationUpload(mode: mode, location: location, floorNumber: floorNumber, groundMSLHeight: groundMSLHeight, pressure: pressure)
    }
    
    public static func setManualCalibration(location: CLLocation, floorNumber: Int? = nil, groundMSLHeight: Double? = nil, pressure: Double? = nil) {
        NNSDKInitializer.shared.manualCalibrationLocation(location: location, floorNumber: floorNumber, groundMSLHeight: groundMSLHeight, pressure: pressure)
    }
    
    public static func deviceID() -> String {
        return NNSDKInitializer.shared.deviceID()
    }
    
    public static func loggerMode(mode: NNLoggerOutput) {
        NNSDKInitializer.shared.loggerMode(mode: mode)
    }
    
    public static func setSDKConsistencyFilters(_ filters: [NNConsistenyFilter]) {
        NNSDKInitializer.shared.setSDKConsistencyFilters(filters: filters)
    }
}

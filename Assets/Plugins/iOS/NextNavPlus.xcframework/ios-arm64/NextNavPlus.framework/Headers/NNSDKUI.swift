//
//  NNSDK.swift
//
import UIKit
import CoreLocation

public enum NNManualBarocalState: Int {
    case calibrationSetup
    case calibrationStarted
    case calibrationCancelled
    case calibrationSuccess
    case calibrationFailed
}

public enum NNAltimeterMode: Int {
    case allUsers
    case deltaUsers
}

public enum NNAltimeterUnitMode: String {
    case feet = "ft"
    case meter = "m"
    
    func toggle() -> NNAltimeterUnitMode {
        if self == .feet {
            return .meter
        }
        return .feet
    }
}

public typealias NNSDKUIManualBarocalHandler = (_ parentController: UIViewController) -> Void
public typealias NNSDKUIMapHandler = (_ mapContainer: UIView, _ location: CLLocation?, _ state: NNManualBarocalState) -> Void
public typealias NNSDKUIMapNativeHandler = (_ state: NNManualBarocalState) -> Void

public typealias NNSDKUIAltimeterHandler = (_ altimeterView: UIView?, _ statusMessage: Int?, _ context: NNAltitudeContext?) -> Void

public class NNSDKUI {
    
    public init() {}
    
    public static func initiateManualBarocalUI( mode: NNManualBarocalMode, success: @escaping NNSDKUIManualBarocalHandler, mapHandler: @escaping NNSDKUIMapHandler) {
        NNSDKInitializer.shared.initiateManualBarocalUI(mode: mode, success: success, mapHandler: mapHandler, nativeMapHandler: nil)
    }

    public static func initiateNativeManualBarocalUI( mode: NNManualBarocalMode, success: @escaping NNSDKUIManualBarocalHandler, mapHandler: @escaping NNSDKUIMapNativeHandler) {
        NNSDKInitializer.shared.initiateManualBarocalUI(mode: mode, success: success, mapHandler: nil, nativeMapHandler: mapHandler)
    }
    
    public static func altimeterView(mode: NNAltimeterMode, unitMode: NNAltimeterUnitMode, users: [NNAltitudeUser],
                                     scaleHeight: Double, handler: @escaping NNSDKUIAltimeterHandler) {
        NNSDKInitializer.shared.altimeterView(mode: mode, unitMode: unitMode, users: users, scaleHeight: scaleHeight, handler: handler)
    }
    
    public static func showMyLocation( mode: NNAltitudeMode, showLocation: Bool, loggedInUserName: String? = nil) {
        NNSDKInitializer.shared.showMyLocation(mode: mode, showLocation: showLocation, loggedInUserName: loggedInUserName)
    }
    
    public static func updateAltimeterUsers(users: [NNAltitudeUser]) {
        NNSDKInitializer.shared.updateAltimeterUsers(users: users)
    }
    
    public static func removeAltimeterView() {
        NNSDKInitializer.shared.removeAltimeterView()
    }
}

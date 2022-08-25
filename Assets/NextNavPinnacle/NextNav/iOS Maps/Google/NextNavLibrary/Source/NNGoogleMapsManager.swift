//
//  NNGoogleMapsManager.swift
//  NNCode
//
//

import UIKit
import GoogleMaps


import NextNavPlus


class NNGoogleMapsManager:NSObject, GMSMapViewDelegate {
    private static let GOOGLEMAPSAPIKEY = ""
    private let _focusLevel = Float(18.0)
    private var _mapView:GMSMapView?
    private var _pinMarker:UIImageView?
    
    static func initializeGoogleMaps() {
        GMSServices.provideAPIKey(GOOGLEMAPSAPIKEY)
    }
    
    func setUPMapView(container:UIView, location:CLLocation, mapState:NNManualBarocalState) {
        _mapView?.isUserInteractionEnabled = true
        switch mapState {
        case .calibrationSetup:
            _mapView?.removeFromSuperview()
            _mapView = nil
            addMapView(container: container, location: location)
            addLocationSelectedMarker()
            _mapView?.isMyLocationEnabled = true
        //case .calibrationSuccess, .calibrationFailed:
            //let camera = GMSCameraPosition.camera(withLatitude: location.coordinate.latitude, longitude: location.coordinate.longitude, zoom: _focusLevel)
            //_mapView?.animate(to: camera)
            //_mapView?.isMyLocationEnabled = true
        case .calibrationStarted:
            _mapView?.isUserInteractionEnabled = false
            _mapView?.isMyLocationEnabled = false
        case .calibrationCancelled:
            _mapView?.animate(toZoom: _focusLevel)
            _mapView?.isMyLocationEnabled = true
        @unknown default:
            _mapView?.removeFromSuperview()
            _mapView = nil
            addMapView(container: container, location: location)
            addLocationSelectedMarker()
            _mapView?.isMyLocationEnabled = true
        }
    }
    
    private func addMapView(container:UIView, location:CLLocation) {
        let mapView = GMSMapView(frame: container.bounds)
        container.addSubview(mapView)
        fill(containerView: container, with: mapView)
        let camera = GMSCameraPosition.camera(withLatitude: location.coordinate.latitude, longitude: location.coordinate.longitude, zoom: _focusLevel)
        mapView.camera = camera
        mapView.delegate = self
        mapView.settings.compassButton = true
        mapView.settings.myLocationButton = true
        _mapView = mapView
    }
    
    private func addLocationSelectedMarker() {
        _mapView?.clear()
        _pinMarker?.removeFromSuperview()
        if let mapView = _mapView {
            let imageView = UIImageView()
            mapView.addSubview(imageView)
            imageView.translatesAutoresizingMaskIntoConstraints = false
            imageView.centerYAnchor.constraint(equalTo: mapView.centerYAnchor).isActive = true
            imageView.centerXAnchor.constraint(equalTo: mapView.centerXAnchor).isActive = true
            if #available(iOS 11.0, *) {
                imageView.safeAreaLayoutGuide.widthAnchor.constraint(equalToConstant: 50).isActive = true
            } else {
                // Fallback on earlier versions
            }
            if #available(iOS 11.0, *) {
                imageView.safeAreaLayoutGuide.heightAnchor.constraint(equalToConstant: 50).isActive = true
            } else {
                // Fallback on earlier versions
            }
            imageView.image = UIImage(named: "markerPin")
            _pinMarker = imageView
        }
    }
}

extension NNGoogleMapsManager {
    func fill(containerView: UIView, with childView: UIView, withInsets insets: UIEdgeInsets = .zero) -> Void {
        childView.translatesAutoresizingMaskIntoConstraints = false
        childView.leadingAnchor.constraint(equalTo: containerView.leadingAnchor, constant: insets.left).isActive = true
        containerView.trailingAnchor.constraint(equalTo: childView.trailingAnchor, constant: insets.right).isActive = true
        childView.topAnchor.constraint(equalTo: containerView.topAnchor, constant: insets.top).isActive = true
        containerView.bottomAnchor.constraint(equalTo: childView.bottomAnchor, constant: insets.bottom).isActive = true
    }
    
    func mapView(_ mapView: GMSMapView, idleAt position: GMSCameraPosition) {
        NNSDK.setManualCalibrationLocation(location: CLLocation(latitude: position.target.latitude, longitude: position.target.longitude))
      }
}

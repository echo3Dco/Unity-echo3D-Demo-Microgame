//
//  NNSDK.swift
//

public struct NNAltitudeUser {
    public let userID: String
    public var name: String
    public var imageName: String?
    public var imageURL: String?
    public var altitudeValue: Double
    public var altitudeUncertainty: Double?
    public var delete: Bool
    let currentUser: Bool
    
    public init( userID: String,
                 name: String,
                 imageName: String? = nil,
                 imageURL: String? = nil,
                 altitudeValue: Double,
                 altitudeUncertainty: Double? = nil,
                 currentUser: Bool = false,
                 delete: Bool = false) {
        self.userID = userID
        self.name = name
        self.imageName = imageName
        self.imageURL = imageURL
        self.altitudeValue = altitudeValue
        self.delete = delete
        self.currentUser = currentUser
        self.altitudeUncertainty = altitudeUncertainty
    }
}

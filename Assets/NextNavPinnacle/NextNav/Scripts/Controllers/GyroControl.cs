using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    public bool IsFeatureEnabled;

    private bool _gyroEnabled;
    private Gyroscope _gyro;

    private GameObject _cameraContainer;
    private Quaternion _rotation;

    private void Start()
    {
        _cameraContainer = new GameObject("Camera Container");
        _cameraContainer.transform.position = transform.position;
        transform.SetParent(_cameraContainer.transform);
        _cameraContainer.transform.SetParent(PlayerController.Instance.GetPlayerTransform());

        _gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope && IsFeatureEnabled)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;

            _cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            _rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }

    private void Update()
    {
        if(_gyroEnabled && IsFeatureEnabled)
        {
            transform.localRotation = _gyro.attitude * _rotation;
        }
    }
}

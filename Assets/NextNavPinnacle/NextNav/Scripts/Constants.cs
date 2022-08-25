using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This have all the enums or variables the type static
/// </summary>
public static class Constants
{
    
    public enum CallbackType
    {
        SDK_Status,
        Data,
        Error
    }

    public enum SdkStatus
    {
        NotInitialized,
        Initialized,
        CalibrationSuccess
    }

}

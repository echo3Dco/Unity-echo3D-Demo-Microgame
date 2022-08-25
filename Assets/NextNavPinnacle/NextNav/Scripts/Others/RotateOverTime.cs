using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public Vector3 RotationDirection;
    public float SmoothTime;
    private float convertedTime = 200;
    private float smooth;
    public Transform Pivot; 

    void Update()
     {
        if (Pivot != null)
          {
              smooth = Time.deltaTime * SmoothTime * convertedTime;

              //transform.Rotate(RotationDirection * smooth);
              transform.RotateAround(Pivot.position, RotationDirection, smooth);
          } 
    } 
}

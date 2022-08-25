using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyGOPosition : MonoBehaviour
{
    public Transform GOPositionReference;


    void FixedUpdate()
    {
        CopyPositionFromGOReference();
    }


    private void CopyPositionFromGOReference()
    {
        if(GOPositionReference != null)
        {
            transform.position = new Vector3(GOPositionReference.position.x, transform.position.y, GOPositionReference.transform.position.z);
        }
    }
}

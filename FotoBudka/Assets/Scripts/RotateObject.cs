using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float rotationSpeed = 3.0f;
    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.down, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    
    }

}

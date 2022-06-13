using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Awake()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 lookDirection = (transform.position - cameraTransform.position).normalized;

        transform.rotation = Quaternion.LookRotation(lookDirection, transform.up);
    }
}

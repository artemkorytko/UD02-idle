using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Start()
    {
        var cameraPosition = FindObjectOfType<Camera>().transform.position;
        var lookDirection = (transform.position - cameraPosition).normalized;

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}

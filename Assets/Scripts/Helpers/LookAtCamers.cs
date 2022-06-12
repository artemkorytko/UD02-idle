using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamers : MonoBehaviour
{
    private void Start()
    {
        var cameraPosition = FindObjectOfType<Camera>().transform.position;    
        var lookDirection = (transform.position - cameraPosition).normalized;   //получаем вектор

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
 
    //transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
  

}

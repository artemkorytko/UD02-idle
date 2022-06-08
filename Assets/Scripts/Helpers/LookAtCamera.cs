using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    //кнопки смотрят на камеру
    void Start()
    {
        var cameraPos = FindObjectOfType<Camera>().transform.position;
        var lookDirection = (transform.position - cameraPos);

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}

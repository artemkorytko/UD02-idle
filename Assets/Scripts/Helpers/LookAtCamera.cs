using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    //кнопки смотрят на камеру
    void Start()
    {
        //объект камера найдена
        var cameraPos = FindObjectOfType<Camera>().transform.position;
        //направление между объетом, который есть и куда надо смотреть. Пооучаем вектор.
        var lookDirection = (transform.position - cameraPos).normalized;

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}

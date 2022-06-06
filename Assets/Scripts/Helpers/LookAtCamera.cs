using System;
using UnityEngine;

namespace Helpers
{
    public class LookAtCamera : MonoBehaviour
    {
        private void Start()
        {
            var cameraPosition = FindObjectOfType<Camera>().transform.position;
            var lookDirection = (transform.position - cameraPosition).normalized;
            
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
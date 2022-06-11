using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class LookAtCamera : MonoBehaviour
    {
        private void Start()
        {
            var cameraPosition = FindObjectOfType<Camera>().transform.position;
            var lookDirecrion = (transform.position - cameraPosition).normalized;

            transform.rotation = Quaternion.LookRotation(lookDirecrion);
        }
    }
}


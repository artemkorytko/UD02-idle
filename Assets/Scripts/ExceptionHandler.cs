using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExceptionHandler: MonoBehaviour
    {
        [SerializeField] private MyCrashClass crash;
        private void Start()
        {
            Debug.Log("Method Start");
            try
            {
                Debug.Log("First log");
                Debug.Log("f");
            }
            catch (NullReferenceException e)
            {
                Debug.Log("NullReferenceException");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
           
           
        }
    }

    [Serializable]
    public class MyCrashClass
    {
        
    }
}
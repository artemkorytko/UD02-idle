using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceContainer", menuName = "ResourceContainer", order = 0)]
public class ResourceContainer : ScriptableObject
{
    [SerializeField] private GameObject prefab;

    public GameObject Prefab => prefab;
}

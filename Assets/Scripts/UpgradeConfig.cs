using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Config", menuName = "Configs/Upgrade Config")]
public class UpgradeConfig : ScriptableObject
{
    [SerializeField] private GameObject _model = null;
    [SerializeField] private int _processResuilt = 0;

    public GameObject Model => _model;
    public int ProcessResuilt => _processResuilt;
}

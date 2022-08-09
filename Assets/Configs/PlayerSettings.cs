using UnityEngine;

namespace Installers.Configs
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Configs/PlayerSettings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float moveSpeed;// по игровому полю, из настроек гейм менеджера 
        [SerializeField] private float rotate; // для примера;

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }
    }
}
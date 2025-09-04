using Thronefall.Gameplay.Combat;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Enemies
{
    [CreateAssetMenu(menuName = "Thronefall/EnemyConfig", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
        [field: SerializeField] public EntityBehaviour View { get; private set; }
        [field: SerializeField] public WeaponConfig WeaponConfig { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MaxHp { get; private set; }
    }
}
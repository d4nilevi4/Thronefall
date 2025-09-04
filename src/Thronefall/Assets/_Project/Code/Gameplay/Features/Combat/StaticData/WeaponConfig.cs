using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    [CreateAssetMenu(menuName = "Thronefall/WeaponConfig", fileName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public EntityBehaviour View { get; private set; }
        [field: SerializeField] public WeaponTypeId WeaponTypeId { get; private set; }
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public float AttackRadius { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public Damage Damage { get; private set; }
    }
}
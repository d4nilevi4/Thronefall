using Thronefall.Gameplay.Combat;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Thronefall/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; } = 5f;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 5f;
        [field: SerializeField] public WeaponConfig WeaponConfig { get; private set; }
        [field: SerializeField] public float MaxHp { get; private set; }
    }
}
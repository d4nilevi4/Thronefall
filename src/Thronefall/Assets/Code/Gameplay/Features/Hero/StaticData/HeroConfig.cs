using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Thronefall/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; } = 5f;
    }
}
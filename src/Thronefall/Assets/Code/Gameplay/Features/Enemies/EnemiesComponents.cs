using Entitas;

namespace Thronefall.Gameplay.Enemies
{
    [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
    [Game] public class TakeDamageAnimatorComponent : IComponent { public ITakeDamageAnimator Value; }
    [Game] public class Enemy : IComponent { }
}
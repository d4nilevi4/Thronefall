using Entitas;

namespace Thronefall.Gameplay.Targeting
{
    [Game] public class Target : IComponent { public int Value; }
    [Game] public class CopyTargetPosition : IComponent {}
    [Game] public class LerpToTargetPosition : IComponent {}
    [Game] public class ChooseClosestEnemyTarget : IComponent {}
    [Game] public class ChooseHeroTarget : IComponent {}
} 
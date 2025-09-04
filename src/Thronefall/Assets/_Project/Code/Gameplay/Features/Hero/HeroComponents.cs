using Entitas;

namespace Thronefall.Gameplay.Hero
{
    [Game] public class Hero : IComponent { }
    [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
}
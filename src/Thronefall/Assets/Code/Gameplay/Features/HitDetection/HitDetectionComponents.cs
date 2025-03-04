using Entitas;

namespace Thronefall.Gameplay.HitDetection
{
    [Game] public class WeaponHit : IComponent { }
    [Game] public class VerifiedWeaponHit : IComponent { }
    [Game] public class HitLayerMask : IComponent { public int Value; }
}
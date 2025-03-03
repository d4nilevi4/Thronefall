using Entitas;

namespace Thronefall.Gameplay.Combat
{
    [Game] public class WeaponAnimatorComponent : IComponent { public WeaponAnimator Value; }
    [Game] public class WeaponOwner : IComponent { public int Value; }
    [Game] public class EquippedWeapon : IComponent { public int Value; }
    [Game] public class WeaponTypeIdComponent : IComponent { public WeaponTypeId Value; }
    [Game] public class Attacking : IComponent { }
    [Game] public class Attacker : IComponent { }
    [Game] public class Equipped : IComponent { }
    [Game] public class MeleeWeapon : IComponent { }
    [Game] public class RotateWeaponWhileAttacking : IComponent { }
    [Game] public class AttackRadius : IComponent { public float Value; }
}
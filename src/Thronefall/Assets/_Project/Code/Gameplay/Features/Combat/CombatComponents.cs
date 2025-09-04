using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    [Game] public class WeaponAnimatorComponent : IComponent { public WeaponAnimator Value; }
    [Game] public class WeaponOwner : IComponent { public int Value; }
    [Game] public class EquippedWeapon : IComponent { public int Value; }
    [Game] public class Weapon : IComponent { }
    [Game] public class WeaponTypeIdComponent : IComponent { public WeaponTypeId Value; }
    [Game] public class Attacking : IComponent { }
    [Game] public class Attacker : IComponent { }
    [Game] public class Equipped : IComponent { }
    [Game] public class MeleeWeapon : IComponent { }
    [Game] public class RotateWeaponWhileAttacking : IComponent { }
    [Game] public class AttackRadius : IComponent { public float Value; }
    [Game] public class WeaponSphereBladeTransform : IComponent { public Transform Value; }
    [Game] public class WeaponSphereBladeRadius : IComponent { public float Value; }
    [Game] public class DamageComponent : IComponent { public Damage Value; }
    [Game] public class Causer : IComponent { public int Value; }
}
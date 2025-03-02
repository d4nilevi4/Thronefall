using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    [Game] public class PhysXMovable : IComponent { }
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Velocity : IComponent { public Vector3 Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class MovementAvailable : IComponent { }
    [Game] public class SlideOnSurface : IComponent { }
    [Game] public class AffectedByGravity : IComponent { }
    [Game] public class SyncTransformPosition : IComponent { }
}
using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class SurfaceNormal : IComponent { public Vector3 Value; }
    [Game] public class SlideOnSurface : IComponent { }
}
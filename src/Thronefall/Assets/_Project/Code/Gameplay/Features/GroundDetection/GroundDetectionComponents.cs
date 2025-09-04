using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.GroundDetection
{
    [Game] public class SurfaceNormal : IComponent { public Vector3 Value; }
    [Game] public class GroundHit : IComponent { public RaycastHit Value; }
    [Game] public class Grounded : IComponent { }
}
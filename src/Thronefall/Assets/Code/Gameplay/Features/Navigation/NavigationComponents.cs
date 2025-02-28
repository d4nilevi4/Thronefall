using Entitas;
using Pathfinding;
using UnityEngine;

namespace Thronefall.Gameplay.Navigation
{
    [Game] public class Agent : IComponent { }
    [Game] public class RichNavigationComponent : IComponent { public RichNavigation Value; }
    [Game] public class SeekerComponent : IComponent { public Seeker Value; }
    [Game] public class AgentDestination : IComponent { public Vector3 Value; }
}
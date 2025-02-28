using Entitas;
using Pathfinding;

namespace Thronefall.Gameplay.Navigation
{
    [Game] public class RichNavigationComponent : IComponent { public RichNavigation Value; }
    [Game] public class SeekerComponent : IComponent { public Seeker Value; }
}
using Entitas;
using Thronefall.Infrastructure;

namespace Thronefall.Common
{
    [Game, Input] public class Destructed : IComponent { }
    [Game] public class View : IComponent { public IEntityView Value; }
    [Game] public class ViewPath : IComponent { public string Value; }
    [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
}
using Entitas;

namespace Thronefall.Common
{
    [Game, Input] public class Destructed : IComponent { }
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
}
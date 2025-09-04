﻿using Entitas;

namespace Thronefall.Gameplay.Lifetime
{
    [Game] public class MaxHp : IComponent { public float Value; }
    [Game] public class CurrentHp : IComponent { public float Value; }
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}
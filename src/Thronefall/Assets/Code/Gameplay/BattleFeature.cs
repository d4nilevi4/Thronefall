using Thronefall.Common.Destruct;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Input;
using Thronefall.Gameplay.Movement;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<BindViewFeature>());
            
            Add(systemFactory.Create<HeroFeature>());
            
            Add(systemFactory.Create<MovementFeature>());
            
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}
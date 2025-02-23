using Thronefall.Common.Destruct;
using Thronefall.Gameplay.Input;
using Thronefall.Gameplay.Movement;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessDestructedFeature>());
            
            Add(systemFactory.Create<InputFeature>());
            
            Add(systemFactory.Create<MovementFeature>());
        }
    }
}
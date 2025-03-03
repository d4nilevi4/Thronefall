using Thronefall.Common;
using Thronefall.Common.Destruct;
using Thronefall.Gameplay.Cameras;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Input;
using Thronefall.Gameplay.Navigation;
using Thronefall.Gameplay.PhysXMovement;
using Thronefall.Gameplay.Rotation;
using Thronefall.Gameplay.Targeting;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay
{
    public sealed class BattleFeature : DrawGizmoFeature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<NavigationFeature>());
            Add(systemFactory.Create<BindViewFeature>());

            Add(systemFactory.Create<HeroFeature>());

            Add(systemFactory.Create<TargetingFeature>());
            Add(systemFactory.Create<CombatFeature>());

            Add(systemFactory.Create<PhysXMovementFeature>());
            Add(systemFactory.Create<RotationFeature>());

            Add(systemFactory.Create<CamerasFeature>());
            
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}
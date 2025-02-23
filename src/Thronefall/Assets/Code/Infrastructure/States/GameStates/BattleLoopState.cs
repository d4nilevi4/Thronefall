using Thronefall.Gameplay;

namespace Thronefall.Infrastructure
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private BattleFeature _battleFeature;
        private readonly GameContext _gameContext;

        public BattleLoopState(ISystemFactory systems, GameContext gameContext)
        {
            _systems = systems;
            _gameContext = gameContext;
        }

        protected override void Enter()
        {
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();

            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}
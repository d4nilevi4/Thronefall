using Thronefall.Common;
using Thronefall.Gameplay;

namespace Thronefall.Infrastructure
{
    public class BattleLoopState : EndOfFrameExitState, ILocalState, IFixedUpdatableState
    {
        private readonly ISystemFactory _systems;
        private BattleFeature _battleFeature;
        private readonly GameContext _gameContext;
        private readonly IDrawGizmoReceiver _drawGizmoReceiver;

        public BattleLoopState(
            ISystemFactory systems, 
            GameContext gameContext,
            IDrawGizmoReceiver drawGizmoReceiver)
        {
            _systems = systems;
            _gameContext = gameContext;
            _drawGizmoReceiver = drawGizmoReceiver;
        }

        protected override void Enter()
        {
            _drawGizmoReceiver.EventDrawGizmo += OnDrawGizmo;
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void FixedUpdate()
        {
            _battleFeature.FixedExecute();
        }

        protected override void ExitOnEndOfFrame()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();

            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
            
            _drawGizmoReceiver.EventDrawGizmo -= OnDrawGizmo;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }

        private void OnDrawGizmo()
        {
            _battleFeature.DrawGizmo();
        }
    }
}
namespace Thronefall.Infrastructure
{
    public class BattleEnterState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;

        public BattleEnterState(
            IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        protected override void Enter()
        {
            _stateMachine.Enter<BattleLoopState>();
        }
    }
}
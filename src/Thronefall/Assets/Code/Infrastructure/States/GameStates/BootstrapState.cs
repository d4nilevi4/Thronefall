namespace Thronefall.Infrastructure
{
    public class BootstrapState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        protected override void Enter()
        {
            _stateMachine.Enter<LoadingBattleState, string>("Battle");
        }
    }
}
using Thronefall.Gameplay.StaticData;

namespace Thronefall.Infrastructure
{
    public class BootstrapState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(
            IGameStateMachine stateMachine,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        protected override void Enter()
        {
            _staticDataService.LoadAll();
            
            _stateMachine.Enter<LoadingBattleState, string>("Battle");
        }
    }
}
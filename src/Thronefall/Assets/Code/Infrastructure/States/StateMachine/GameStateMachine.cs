using Cysharp.Threading.Tasks;
using Thronefall.Gameplay;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class GameStateMachine : IGameStateMachine, ITickable
    {
        private readonly IStateFactory _stateFactory;
        private readonly ITimeService _timeService;
        private IExitableState _activeState;

        public GameStateMachine(
            IStateFactory stateFactory,
            ITimeService timeService)
        {
            _stateFactory = stateFactory;
            _timeService = timeService;
        }

        public void Tick()
        {
            if (_activeState is IUpdatableState updatableState)
                updatableState.Update(_timeService.DeltaTime);
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            TState state = await ChangeState<TState>();
            await state.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = await ChangeState<TState>();
            await state.Enter(payload);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
                await _activeState.Exit();

            TState state = _stateFactory.GetState<TState>();
            _activeState = state;

            return state;
        }
    }
}
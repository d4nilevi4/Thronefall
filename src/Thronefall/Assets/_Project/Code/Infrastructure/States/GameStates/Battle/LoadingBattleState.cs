using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public class LoadingBattleState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingBattleState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter(string sceneName)
        {
            await _sceneLoader.LoadSceneAsync(sceneName);
            await _stateMachine.Enter<EnterBattleState>();
        }

        public UniTask Exit() =>
            default;
    }
}
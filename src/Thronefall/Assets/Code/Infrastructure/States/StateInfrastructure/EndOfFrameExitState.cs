using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public class EndOfFrameExitState: IState, IUpdatableState
    {
        private UniTaskCompletionSource _taskCompletionSource;
        
        UniTask IState.Enter()
        {
            Enter();
            return default;
        }

        async UniTask IExitableState.Exit()
        {
            _taskCompletionSource = new UniTaskCompletionSource();
            
            await _taskCompletionSource.Task;

            ExitOnEndOfFrame();
        }

        void IUpdatableState.Update(float dt)
        {
            OnUpdate();
            _taskCompletionSource?.TrySetResult();
        }

        protected virtual void Enter() { }

        protected virtual void ExitOnEndOfFrame() { }

        protected virtual void OnUpdate() { }
    }
}
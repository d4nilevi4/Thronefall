using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public interface IGameStateMachine
    {
        UniTask Enter<TState>() where TState : class, IState;
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}
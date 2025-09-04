using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}
using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}
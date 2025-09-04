using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public interface IPayloadState<in TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}
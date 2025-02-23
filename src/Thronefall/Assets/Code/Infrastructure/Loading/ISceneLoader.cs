using Cysharp.Threading.Tasks;

namespace Thronefall.Infrastructure
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string name);
    }
}
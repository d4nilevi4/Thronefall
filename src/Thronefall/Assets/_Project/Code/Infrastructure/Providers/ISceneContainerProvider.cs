using Zenject;

namespace Thronefall.Infrastructure;

public interface ISceneContainerProvider
{
    DiContainer Container { get; }
    void SetContainer(DiContainer container);
}
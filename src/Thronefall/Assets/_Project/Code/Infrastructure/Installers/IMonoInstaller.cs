using Zenject;

namespace Thronefall.Infrastructure;

public interface IMonoInstaller
{
    void InstallBindings(DiContainer container);
}
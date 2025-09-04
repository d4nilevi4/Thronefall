using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure;

public abstract class BindingsInstaller : MonoBehaviour, IMonoInstaller
{
    public abstract void InstallBindings(DiContainer container);
}
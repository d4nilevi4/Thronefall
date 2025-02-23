using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            UniTask task = gameStateMachine.Enter<BootstrapState>();
            task.Forget();
        }
    }
}
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}
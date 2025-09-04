using Thronefall.Common.Entity;
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class SelfInitializedEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifierService.Next());

            EntityBehaviour.SetEntity(entity);
        }

        private void OnDestroy() =>
            EntityBehaviour.ReleaseEntity();
    }
}
using Thronefall.Gameplay;
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        public GameEntity Entity => _entity;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }
        
        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();

            foreach (Collider col in GetComponentsInChildren<Collider>(includeInactive: true)) 
                _collisionRegistry.Register(col.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents();
            
            foreach (Collider col in GetComponentsInChildren<Collider>(includeInactive: true)) 
                _collisionRegistry.Unregister(col.GetInstanceID());
            
            _entity.Release(this);
            _entity = null;
        }
    }
}
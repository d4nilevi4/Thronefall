using UnityEngine;

namespace Thronefall.Infrastructure
{
    public class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;

        public GameEntity Entity => EntityView?.Entity;

        private void Awake()
        {
            if (!EntityView)
                EntityView = GetComponent<EntityBehaviour>();
        }
    }
}
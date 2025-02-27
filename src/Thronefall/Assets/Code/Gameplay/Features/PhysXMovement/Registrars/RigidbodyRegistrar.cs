using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class RigidbodyRegistrar : EntityComponentRegistrar
    {
        public Rigidbody Rigidbody;
        
        public override void RegisterComponents()
        {
            Entity.AddRigidbody(Rigidbody);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHeroAnimator)
                Entity.RemoveRigidbody();
        }
    }
}
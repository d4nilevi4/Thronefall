using System;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class RigidbodyRegistrar : EntityComponentRegistrar
    {
        public Rigidbody Rigidbody;

        private void Awake()
        {
            Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        }

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
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Enemies
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;
        
        public override void RegisterComponents()
        {
            Entity.AddTakeDamageAnimator(EnemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasTakeDamageAnimator)
                Entity.RemoveTakeDamageAnimator();
        }
    }
}
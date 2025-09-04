using Pathfinding;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Navigation
{
    public class SeekerRegistrar : EntityComponentRegistrar
    {
        public Seeker Seeker;
        
        public override void RegisterComponents()
        {
            Entity.AddSeeker(Seeker);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasSeeker)
                Entity.RemoveSeeker();
        }
    }
}
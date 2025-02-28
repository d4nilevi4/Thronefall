using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Navigation
{
    public class RichNavigationRegistrar : EntityComponentRegistrar
    {
        public RichNavigation RichNavigation;
        
        public override void RegisterComponents()
        {
            Entity.AddRichNavigation(RichNavigation);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasSeeker)
                Entity.RemoveRichNavigation();
        }
    }
}
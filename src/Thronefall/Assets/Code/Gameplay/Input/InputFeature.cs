using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeInputSystem>());
            
            Add(systemFactory.Create<EmitWorldInputSystem>());
            Add(systemFactory.Create<EmitCameraRelativeInputSystem>());
            
            Add(systemFactory.Create<TearDownInputSystem>());
        }
    }
}
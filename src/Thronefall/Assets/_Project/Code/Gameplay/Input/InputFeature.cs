using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Input
{
    public sealed class InputFeature : CustomFeature
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
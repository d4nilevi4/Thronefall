using Entitas;
using Thronefall.Common;
using Thronefall.Common.Entity;

namespace Thronefall.Gameplay.Input
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateInputEntity.Empty()
                .With(x => x.isInput = true)
                .With(x => x.isWorldInput = true);
            
            CreateInputEntity.Empty()
                .With(x => x.isInput = true)
                .With(x => x.isCameraRelativeInput = true);
        }
    }
}
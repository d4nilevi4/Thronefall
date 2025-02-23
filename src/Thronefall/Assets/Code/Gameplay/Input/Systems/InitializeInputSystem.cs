using Entitas;
using Thronefall.Common.Entity;

namespace Thronefall.Gameplay.Input
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateInputEntity.Empty()
                .isInput = true;
        }
    }
}
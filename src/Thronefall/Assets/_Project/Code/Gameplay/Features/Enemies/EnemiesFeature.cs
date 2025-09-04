using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Enemies
{
    public sealed class EnemiesFeature : CustomFeature
    {
        public EnemiesFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<EnemyDeathSystem>());
            Add(systemFactory.Create<ProcessEnemyWeaponDeathSystem>());
            
            Add(systemFactory.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}
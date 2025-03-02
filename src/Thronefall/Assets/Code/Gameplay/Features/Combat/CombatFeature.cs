using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Combat
{
    public sealed class CombatFeature : DrawGizmoFeature
    {
        public CombatFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<EquipUnattendedWeaponsSystem>());
            
            Add(systemFactory.Create<WeaponEnableAttackReactiveSystem>());
            Add(systemFactory.Create<WeaponDisableAttackReactiveSystem>());
        }
    }
}
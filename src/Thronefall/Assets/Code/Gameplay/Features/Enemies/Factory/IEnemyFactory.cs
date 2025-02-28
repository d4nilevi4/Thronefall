using UnityEngine;

namespace Thronefall.Gameplay.Enemies
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
    }
}
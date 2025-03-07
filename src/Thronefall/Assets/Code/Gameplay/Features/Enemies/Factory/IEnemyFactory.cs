using UnityEngine;

namespace Thronefall.Gameplay.Enemies
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyConfig enemyConfig, Vector3 at);
    }
}
using System;
using System.Collections.Generic;
using Thronefall.Common;
using Thronefall.Gameplay.Combat;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<SpawnData> SpawnData = new();
        public float StartCooldown;
        
        private IEnemyFactory _enemyFactory;
        private IWeaponFactory _weaponFactory;

        private float _spawnTimer;
        private int _currentSpawnDataIndex;

        [Inject]
        private void Construct(
            IEnemyFactory enemyFactory,
            IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            _enemyFactory = enemyFactory;
        }

        private void Awake()
        {
            _spawnTimer = StartCooldown;
        }

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0 && _currentSpawnDataIndex < SpawnData.Count)
            {
                SpawnData spawnData = SpawnData[_currentSpawnDataIndex];
                
                for (int i = 0; i < spawnData.Count; i++)
                {
                    GameEntity enemy = _enemyFactory.CreateEnemy(spawnData.EnemyTypeId, transform.position);
                    _weaponFactory.CreateWeapon(WeaponTypeId.SmallAxe, enemy.Id, CollisionLayer.Hero.AsMask());
                }

                _spawnTimer = SpawnData[_currentSpawnDataIndex].Cooldown;
                _currentSpawnDataIndex++;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawSphere(transform.position, 0.2f);
            
            Gizmos.color = Color.white;
        }
    }

    [Serializable]
    public struct SpawnData
    {
        public EnemyTypeId EnemyTypeId;
        public int Count;
        public float Cooldown;

        public SpawnData(EnemyTypeId enemyTypeId, int count, float cooldown)
        {
            EnemyTypeId = enemyTypeId;
            Count = count;
            Cooldown = cooldown;
        }
    }
}
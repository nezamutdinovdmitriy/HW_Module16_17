using Scripts.Entities.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Entities.Spawning
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnBehaviorConfig> _spawnPoints;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private Transform _target;

        private void Awake()
        {
            foreach (SpawnBehaviorConfig spawnConfig in _spawnPoints)
            {
                Enemy enemy = CreateEnemy(spawnConfig);

                switch (spawnConfig.IdleBehaviors)
                {
                    case IdleBehaviors.Stay:
                        enemy.SetIdleBehaviorStrategy(new Stay());
                        break;

                    case IdleBehaviors.Patrol:
                        enemy.SetIdleBehaviorStrategy(new Patrol(enemy.transform, _patrolPoints, enemy.Mover, enemy.Rotator));
                        break;

                    case IdleBehaviors.RandomWalk:
                        enemy.SetIdleBehaviorStrategy(new RandomWalk(enemy.Mover, enemy.Rotator));
                        break;
                }

                switch (spawnConfig.AgroBehaviors)
                {
                    case AgroBehaviors.Chase:
                        enemy.SetAgroBehaviorStrategy(new Chase(_target, enemy.transform, enemy.Mover, enemy.Rotator, enemy.AgroDistance));
                        break;

                    case AgroBehaviors.Escape:
                        enemy.SetAgroBehaviorStrategy(new Escape(_target, enemy.transform, enemy.Mover, enemy.Rotator, enemy.AgroDistance));
                        break;

                    case AgroBehaviors.Fear:
                        enemy.SetAgroBehaviorStrategy(new Fear(_target, enemy.transform, enemy.AgroDistance));
                        break;
                }
            }
        }

        private Enemy CreateEnemy(SpawnBehaviorConfig spawnConfig)
        {
            Enemy enemy = Instantiate(spawnConfig.EnemyPrefab, spawnConfig.transform.position, Quaternion.identity);
            
            enemy.Initiliaze(_target);
            
            return enemy;
        }
    }
}

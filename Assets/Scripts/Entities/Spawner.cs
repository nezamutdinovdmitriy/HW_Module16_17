using Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnBehaviorConfig> _spawnPoints;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        foreach (var enemyConfig in _spawnPoints)
        {
            Enemy enemy = CreateEnemy(enemyConfig);

            switch (enemyConfig.IdleBehaviors)
            {
                case IdleBehaviors.Stay:
                    enemy.SetIdleBehaviorStrategy(new Stay());
                    break;
                case IdleBehaviors.Patrol:
                    enemy.SetIdleBehaviorStrategy(new Patrol(enemy.transform, _patrolPoints, enemy.Mover, enemy.Rotator));
                    break;
                case IdleBehaviors.RandomWalk:
                    break;
            }

            switch (enemyConfig.AgroBehaviors)
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

    private Enemy CreateEnemy(SpawnBehaviorConfig behaviorConfig)
    {
        Enemy enemy = Instantiate(behaviorConfig.EnemyPrefab, this.transform.position, Quaternion.identity);
        enemy.Initiliaze(_target);
        return enemy;
    }
}

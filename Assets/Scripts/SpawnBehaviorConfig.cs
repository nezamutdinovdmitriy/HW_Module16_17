using Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

public enum IdleBehaviors
{
    Stay,
    Patrol,
    RandomWalk
}

public enum AgroBehaviors
{
    Chase,
    Escape,
    Fear
}

public class SpawnBehaviorConfig : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    [SerializeField] private IdleBehaviors _idleBehaviors;
    [SerializeField] private AgroBehaviors _agroBehaviors;
    

    private void Awake()
    {
        Enemy enemy = CreateEnemy();

        switch (_idleBehaviors)
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

        switch (_agroBehaviors)
        {
            case AgroBehaviors.Chase:
                enemy.SetAgroBehaviorStrategy(new Chase(_player, enemy.transform, enemy.Mover, enemy.Rotator, enemy.AgroDistance));
                break;
            case AgroBehaviors.Escape:
                enemy.SetAgroBehaviorStrategy(new Escape(_player, enemy.transform, enemy.Mover, enemy.Rotator, enemy.AgroDistance));
                break;
            case AgroBehaviors.Fear:
                enemy.SetAgroBehaviorStrategy(new Fear(_player, enemy.transform, enemy.AgroDistance));
                break;
        }
    }

    private Enemy CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, this.transform.position, Quaternion.identity);
        enemy.Initiliaze(_player);
        return enemy;
    }
}

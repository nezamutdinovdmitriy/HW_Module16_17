using Scripts.Entities;
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
    [SerializeField] private IdleBehaviors _idleBehaviors;
    [SerializeField] private AgroBehaviors _agroBehaviors;

    private void Awake()
    {
        switch (_idleBehaviors)
        {
            case IdleBehaviors.Stay:
                break;
            case IdleBehaviors.Patrol:
                break;
            case IdleBehaviors.RandomWalk:
                break;
        }

        switch (_agroBehaviors)
        {
            case AgroBehaviors.Chase:
                break;
            case AgroBehaviors.Escape:
                break;
            case AgroBehaviors.Fear:
                break;
        }
    }
}

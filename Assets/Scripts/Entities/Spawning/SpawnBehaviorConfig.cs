using Scripts.Entities;
using Scripts.Entities.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Entities.Spawning
{
    public class SpawnBehaviorConfig : MonoBehaviour
    {
        [field: SerializeField] public IdleBehaviors IdleBehaviors { get; private set; }
        [field: SerializeField] public AgroBehaviors AgroBehaviors { get; private set; }

        [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
    }
}
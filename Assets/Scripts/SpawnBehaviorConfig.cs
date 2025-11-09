using Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviorConfig : MonoBehaviour
{
    [field: SerializeField] public IdleBehaviors IdleBehaviors { get; private set; }
    [field: SerializeField] public AgroBehaviors AgroBehaviors { get; private set; }

    [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
}

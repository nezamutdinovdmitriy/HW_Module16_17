using Scripts.Control;
using UnityEngine;

namespace Scripts.Entities
{
    public class Enemy : MonoBehaviour
    {
        private IBehaviorStrategy _idleBehaviorStrategy;
        private IBehaviorStrategy _agroBehaviorStrategy;

        private Transform _agroTarget;

        [field: SerializeField] public float AgroDistance { get; private set; }
        [field: SerializeField] public Mover Mover { get; private set; }
        [field: SerializeField] public Rotator Rotator { get; private set; }

        private void Update()
        {
            if (IsAgro())
                _agroBehaviorStrategy.UpdateBehavior();
            else
                _idleBehaviorStrategy.UpdateBehavior();
        }

        private bool IsAgro()
        {
            float distance = Vector3.Distance(_agroTarget.position, transform.position);

            return distance <= AgroDistance;
        }

        public void Initiliaze(Transform target) => _agroTarget = target;

        public void SetIdleBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _idleBehaviorStrategy = behaviorStrategy;

        public void SetAgroBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _agroBehaviorStrategy = behaviorStrategy;
    }
}
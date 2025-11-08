using Scripts.Control;
using UnityEngine;

namespace Scripts.Entities
{
    public class Enemy : MonoBehaviour
    {
        private IBehaviorStrategy _idleBehaviorStrategy;
        private IBehaviorStrategy _agroBehaviorStrategy;
        private Transform _agroTarget;
        private bool _isAgro;

        [field: SerializeField] public float AgroDistance { get; private set; }
        [field: SerializeField] public Mover Mover { get; private set; }
        [field: SerializeField] public Rotator Rotator { get; private set; }

        private void Update()
        {
            float distance = Vector3.Distance(_agroTarget.position, transform.position);
            _isAgro = distance <= AgroDistance;

            if (_isAgro)
            {
                _agroBehaviorStrategy.UpdateBehavior();
            }
            else
            {
                _idleBehaviorStrategy.UpdateBehavior();
            }
        }

        public void Initiliaze(Transform target) => _agroTarget = target;

        public void SetIdleBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _idleBehaviorStrategy = behaviorStrategy;

        public void SetAgroBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _agroBehaviorStrategy = behaviorStrategy;
    }
}
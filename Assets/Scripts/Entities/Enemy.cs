using Scripts.Control;
using Scripts.Entities.Behaviors;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathVFXPrefab;

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

        public void Die()
        {
            Vector3 vfxPosition = gameObject.transform.position;
            vfxPosition.y = 1.25f;

            Instantiate(_deathVFXPrefab, vfxPosition, Quaternion.identity);
            Destroy(gameObject);
        }

        public void Initiliaze(Transform target) => _agroTarget = target;

        public void SetIdleBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _idleBehaviorStrategy = behaviorStrategy;

        public void SetAgroBehaviorStrategy(IBehaviorStrategy behaviorStrategy) => _agroBehaviorStrategy = behaviorStrategy;

        private bool IsAgro()
        {
            float distance = Vector3.Distance(_agroTarget.position, transform.position);

            return distance <= AgroDistance;
        }
    }
}
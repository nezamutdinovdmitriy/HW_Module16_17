using Scripts.Control;
using UnityEngine;

namespace Scripts.Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Mover _enemyMover;
        [SerializeField] private Rotator _enemyRotator;
        [SerializeField] private float _agroDistance;
        [SerializeField] private Transform _target;

        private void Update()
        {
            FearState(_target);
        }

        private void ChaseState(Transform target)
        {
            Vector3 Direction = (target.position - transform.position).normalized;

            _enemyMover.Move(Direction);
        }

        private void FearState(Transform target)
        {
            float distance = (target.position - transform.position).magnitude;

            if (distance <= _agroDistance)
            {
                float scale = gameObject.transform.localScale.x;
                scale -= Time.deltaTime;
                gameObject.transform.localScale = new Vector3(scale, scale, scale);

                if (scale <= 0)
                    Destroy(gameObject);
            }
        }

        private void EspaceState(Transform target)
        {
            Vector3 Direction = (target.position - transform.position).normalized;
            float distance = (target.position - transform.position).magnitude;

            if (distance <= _agroDistance)
                _enemyMover.Move(-Direction);
        }

        private void StayState(Transform target)
        {
            Vector3 Direction = (target.position - transform.position).normalized;

            _enemyMover.Move(Direction);
        }

        private void PatrolState(Transform target)
        {

        }

        private void RandomWalkState(Transform target)
        {

        }
    }
}
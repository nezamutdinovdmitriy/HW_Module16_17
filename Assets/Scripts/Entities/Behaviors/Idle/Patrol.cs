using Scripts.Control;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Entities.Behaviors
{
    public class Patrol : IBehaviorStrategy
    {
        private float _minDistanceToPoint = 0.5f;

        private Queue<Transform> _targets;
        private Transform _currentTarget;

        private Transform _enemy;
        private Mover _mover;
        private Rotator _rotator;

        public Patrol(Transform enemy, List<Transform> patrolPoints, Mover mover, Rotator rotator)
        {
            _enemy = enemy;
            _mover = mover;
            _rotator = rotator;
            _targets = new Queue<Transform>();

            foreach (Transform point in patrolPoints)
                _targets.Enqueue(point);

            UpdateTarget();
        }

        public void UpdateBehavior()
        {
            Vector3 moveVector = _currentTarget.transform.position - _enemy.transform.position;
            float distanceToPoint = moveVector.magnitude;

            if (distanceToPoint <= _minDistanceToPoint)
                UpdateTarget();

            _mover.Move(moveVector);
            _rotator.Rotate(moveVector);
        }

        private void UpdateTarget()
        {
            _currentTarget = _targets.Dequeue();
            _targets.Enqueue(_currentTarget);
        }
    }
}
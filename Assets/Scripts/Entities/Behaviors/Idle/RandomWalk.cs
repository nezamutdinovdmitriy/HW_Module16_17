using Scripts.Control;
using UnityEngine;

namespace Scripts.Entities.Behaviors
{
    public class RandomWalk : IBehaviorStrategy
    {
        private Mover _mover;
        private Rotator _rotator;

        private Vector3 _moveVector;
        private float _directionChangeTimer = 1f;
        private float _currentTimer;

        public RandomWalk(Mover mover, Rotator rotator)
        {
            _mover = mover;
            _rotator = rotator;
        }

        public void UpdateBehavior()
        {
            _currentTimer += Time.deltaTime;

            if (_currentTimer >= _directionChangeTimer)
            {
                _currentTimer = 0;

                _moveVector = Random.insideUnitSphere;
                _moveVector.y = 0;
            }

            _mover.Move(_moveVector);
            _rotator.Rotate(_moveVector);
        }
    }
}
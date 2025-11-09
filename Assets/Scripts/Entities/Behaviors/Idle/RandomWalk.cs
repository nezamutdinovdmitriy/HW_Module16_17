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

                _moveVector = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            }

            _mover.Move(_moveVector);
            _rotator.Rotate(_moveVector);
        }
    }
}
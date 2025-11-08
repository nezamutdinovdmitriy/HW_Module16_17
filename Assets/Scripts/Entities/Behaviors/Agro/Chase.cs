using Scripts.Control;
using UnityEngine;

public class Chase : IBehaviorStrategy
{
    private Transform _target;
    private Transform _enemy;

    private Mover _mover;
    private Rotator _rotator;

    private float _agroDistance;

    public Chase(Transform target, Transform enemy, Mover mover, Rotator rotator, float agroDistance)
    {
        _target = target;
        _enemy = enemy;
        _mover = mover;
        _rotator = rotator;
        _agroDistance = agroDistance;
    }

    public void UpdateBehavior()
    {
        Vector3 moveVector = _target.position - _enemy.position;

        float distance = moveVector.magnitude;

        if (distance <= _agroDistance)
        {
            _mover.Move(moveVector);
            _rotator.Rotate(moveVector);
        }
    }
}

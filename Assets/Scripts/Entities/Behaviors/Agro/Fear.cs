using UnityEngine;

public class Fear : IBehaviorStrategy
{
    private Transform _target;
    private Transform _enemy;

    private float _agroDistance;
    private float _timeMultiplier = 5;

    public Fear(Transform target, Transform enemy, float agroDistance)
    {
        _target = target;
        _enemy = enemy;
        _agroDistance = agroDistance;
    }

    public void UpdateBehavior()
    {
        float distance = (_target.position - _enemy.position).magnitude;

        if (distance <= _agroDistance)
        {
            float scale = _enemy.transform.localScale.x;
            scale -= Time.deltaTime * _timeMultiplier;
            _enemy.transform.localScale = new Vector3(scale, scale, scale);

            if (scale <= 0)
                Object.Destroy(_enemy.gameObject);
        }
    }

}

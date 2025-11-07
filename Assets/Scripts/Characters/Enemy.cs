using Scripts.Control;
using UnityEngine;

namespace Scripts.Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Mover _enemyMover;
        [SerializeField] private Rotator _enemyRotator;
        [SerializeField] private Transform _target;

        private void Update()
        {
            Vector3 Direction = (_target.position - transform.position).normalized;

            _enemyMover.Move(Direction);
        }
    }
}
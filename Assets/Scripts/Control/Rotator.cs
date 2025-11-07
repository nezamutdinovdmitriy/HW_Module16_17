using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Scripts.Control
{
    public class Rotator : MonoBehaviour
    {
        private Quaternion _targetRotation;

        [field: SerializeField] public float RotateSpeed { get; private set; }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotateSpeed * Time.deltaTime);
        }
    }
}


using UnityEngine;

namespace Scripts.Control
{
    public class Rotator : MonoBehaviour
    {
        [field: SerializeField] public float RotateSpeed { get; private set; }

        public void Rotate(Vector3 moveVector)
        {
            Vector3 direction = moveVector.normalized;

            if (direction == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotateSpeed * Time.deltaTime);
        }
    }
}


using UnityEngine;

namespace Scripts.Control
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        [field: SerializeField] public float MoveSpeed { get; private set; }

        public void Move(Vector3 moveVector)
        {
            Vector3 direction = moveVector.normalized;
            if (direction != Vector3.zero)
                _characterController.Move(direction * MoveSpeed * Time.deltaTime);
        }
    }
}


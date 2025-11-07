using UnityEngine;

namespace Scripts.Control
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        [field: SerializeField] public float MoveSpeed { get; private set; }

        public void Move(Vector3 direction)
        {
            if (direction != Vector3.zero)
                _characterController.Move(direction.normalized * MoveSpeed * Time.deltaTime);
        }
    }
}


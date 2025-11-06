using UnityEngine;

namespace Scripts.Character
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CharacterController _characterController;

        private void Update()
        {
            if (_player.InputHandler.IsMoving)
                _characterController.Move(_player.InputHandler.MoveVector.normalized * _player.MoveSpeed * Time.deltaTime);
        }
    }
}


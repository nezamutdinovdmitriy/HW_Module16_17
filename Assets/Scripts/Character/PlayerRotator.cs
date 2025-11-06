using UnityEngine;

namespace Scripts.Character
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Quaternion _targetRotation;

        private void Update()
        {
            if (_player.InputHandler.IsMoving)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_player.InputHandler.MoveVector);

                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _player.RotateSpeed * Time.deltaTime);
            }          
        }
    }
}


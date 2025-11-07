using UnityEngine;
using Scripts.Control;

namespace Scripts.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Mover _playerMover;
        [SerializeField] private Rotator _playerRotator;

        [field: SerializeField] public InputHandler InputHandler { get; private set; }

        private void Update()
        {
            _playerMover.Move(InputHandler.MoveVector);
            _playerRotator.Rotate(InputHandler.MoveVector);
        }
    }
}


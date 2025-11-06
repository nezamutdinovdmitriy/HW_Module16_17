using UnityEngine;

namespace Scripts.Character
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public InputHandler InputHandler { get; private set; }
    }
}


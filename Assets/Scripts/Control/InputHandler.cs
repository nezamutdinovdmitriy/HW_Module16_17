using UnityEngine;

namespace Scripts.Control
{
    public class InputHandler : MonoBehaviour
    {
        private const string AXIS_HORIZONTAL = "Horizontal";
        private const string AXIS_VERTICAL = "Vertical";
        
        public Vector3 MoveVector { get; private set; }

        private void Update()
        {
            MoveVector = new Vector3(Input.GetAxisRaw(AXIS_HORIZONTAL), 0, Input.GetAxisRaw(AXIS_VERTICAL));
        }
    }
}

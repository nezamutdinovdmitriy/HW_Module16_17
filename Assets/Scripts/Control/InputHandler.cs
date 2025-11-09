using UnityEngine;

namespace Scripts.Control
{
    public class InputHandler : MonoBehaviour
    {
        private const string AxisHorizontal = "Horizontal";
        private const string AxisHVertical = "Vertical";
        
        public Vector3 MoveVector { get; private set; }

        private void Update() => MoveVector = new Vector3(Input.GetAxisRaw(AxisHorizontal), 0, Input.GetAxisRaw(AxisHVertical));
    }
}

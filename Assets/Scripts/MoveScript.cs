using UnityEngine;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {
        public float Speed;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = Vector2.ClampMagnitude(new Vector2(moveHorizontal, moveVertical), 1);
            _rb.velocity = movement * Speed;
        }
    }
}

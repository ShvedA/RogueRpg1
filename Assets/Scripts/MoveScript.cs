using System.Linq;
using UnityEditor;
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
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            _rb.velocity = movement * Speed;

        }

    }
}

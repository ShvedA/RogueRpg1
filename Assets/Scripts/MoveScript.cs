using UnityEngine;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {
        public float Speed;
        private Rigidbody2D rb;
        private GameObject inventoryPanel;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            inventoryPanel = GameObject.Find("InventoryPanel");
        }

        private void Update()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            var movement = Vector2.ClampMagnitude(new Vector2(moveHorizontal, moveVertical), 1);
            rb.velocity = movement * Speed;

            if (Input.GetKeyDown("i"))
            {
                inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


       
    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        rb.velocity = movement * speed;

    }

}

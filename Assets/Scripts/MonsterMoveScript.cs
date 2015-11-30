using UnityEngine;
using System.Collections;

public class MonsterMoveScript : MonoBehaviour {

    public float life;

    public float Speed;

    private Rigidbody2D _rb;

    public GameObject character;

    private void Start()
    {

        _rb = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        var position = character.transform.position;
        Vector2 movement = Vector2.ClampMagnitude(new Vector2(position.x - transform.position.x, position.y - transform.position.y), 0.001f) * 1000;
        _rb.velocity = movement * Speed;

    }

}

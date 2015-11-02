using System.Linq;
using System;
using UnityEditor;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveScript : MonoBehaviour {

    public float speed;

    public Texture2D[] skins;

    public int activeSkin;

    private Rigidbody2D rb;


    public Sprite[] sprites;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Console.Write("test");
        sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/tree_stable.png").OfType<Sprite>().ToArray();
        Console.WriteLine(sprites.Count());
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        rb.velocity = movement * speed;

        if (movement.x > 0 || movement.y > 0)
        {
            replaceMatchingSprite(MoveSprite.LEFT);
        }
    }

    void replaceMatchingSprite (MoveSprite newSprite)
    {
        rb.GetComponent<SpriteRenderer>().sprite = sprites[(int)newSprite];
    }

    public enum MoveSprite
    {
        LEFT=6,
        LEFTUP=5,
        UP=4,
        RIGHTUP=3,
        RIGHT=2,
        RIGHTDOWN=1,
        DOWN=0,
        LEFTDOWN=7
    }
}

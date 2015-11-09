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

    public Vector2 zeroVector;

    public Sprite[] sprites;

    public int numOfSpriteTurns;

    public double round = 360;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/tree_stable.png").OfType<Sprite>().ToArray();
        zeroVector = new Vector2(0, -1);
        numOfSpriteTurns = 8;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        rb.velocity = movement * speed;

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        Vector2 mouse = new Vector2(pz.x, pz.y);

        Vector2 vectorToCenter = new Vector2(mouse.x - rb.position.x, mouse.y - rb.position.y);

        double angle = Vector2.Angle(vectorToCenter, zeroVector);

        if (vectorToCenter.x < 0)
        {
            angle = 360 - angle;
        }
        turnCharacter(angle);
    }

    private void turnCharacter(double angle)
    {
        double angleFromSectorBeginning = angle + (round / numOfSpriteTurns) / 2;
        int spriteNum = (int)(angleFromSectorBeginning / (round / numOfSpriteTurns));
        if (spriteNum < 0 || spriteNum == numOfSpriteTurns)
        {
            spriteNum = 0;
        } 
        replaceMatchingSprite(spriteNum);
    }

    void replaceMatchingSprite (int newSprite)
    {
        rb.GetComponent<SpriteRenderer>().sprite = sprites[newSprite];
    }


    public enum MoveSprite
    {
        DOWN = 0,
        RIGHTDOWN = 1,
        RIGHT = 2,
        RIGHTUP = 3,
        UP = 4,
        LEFTUP = 5,
        LEFT=6,
        LEFTDOWN=7
    }
}

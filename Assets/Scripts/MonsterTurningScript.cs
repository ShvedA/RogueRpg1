using UnityEngine;
using System.Collections;

public class MonsterTurningScript : MonoBehaviour {

    private Texture2D[] Skins;

    private int ActiveSkin;

    private Rigidbody2D _rb;

    private Vector2 ZeroVector = new Vector2(0, -1);

    public Sprite[] Sprites;

    private int NumOfSpriteTurns = 8;

    private double Round = 360;

    public GameObject character;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        var position = character.transform.position;
        Vector2 lol = new Vector2(position.x - transform.position.x, position.y - transform.position.y);

        double angle = GetAngle(lol);

        TurnCharacter(angle);

    }

    private double GetAngle(Vector2 vectorToCenter)
    {
        double angle = Vector2.Angle(vectorToCenter, ZeroVector);

        if (vectorToCenter.x < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }

    private void TurnCharacter(double angle)
    {
        double angleFromSectorBeginning = angle + (Round / NumOfSpriteTurns) / 2;
        int spriteNum = (int)(angleFromSectorBeginning / (Round / NumOfSpriteTurns));
        if (spriteNum < 0 || spriteNum == NumOfSpriteTurns)
        {
            spriteNum = 0;
        }
        ReplaceMatchingSprite(spriteNum);
    }

    private void ReplaceMatchingSprite(int newSprite)
    {
        _rb.GetComponent<SpriteRenderer>().sprite = Sprites[newSprite];
    }

    public enum MoveSprite
    {
        Down = 0,
        RightDown = 1,
        Right = 2,
        RightUp = 3,
        Up = 4,
        LeftUp = 5,
        Left = 6,
        LeftDown = 7
    }
}

using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class TurningAroundScript : MonoBehaviour {

    public Texture2D[] Skins;

    public int ActiveSkin;

    private Rigidbody2D _rb;

    public Vector2 ZeroVector;

    public Sprite[] Sprites;

    public int NumOfSpriteTurns;

    public double Round = 360;

    void Start () {

        _rb = GetComponent<Rigidbody2D>();
        Sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/tree_stable.png").OfType<Sprite>().ToArray();
        ZeroVector = new Vector2(0, -1);
        NumOfSpriteTurns = 8;

    }
	

	void Update () {

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        Vector2 mouse = new Vector2(pz.x, pz.y);

        Vector2 vectorToCenter = new Vector2(mouse.x - _rb.position.x, mouse.y - _rb.position.y);

        double angle = GetAngle(vectorToCenter);

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

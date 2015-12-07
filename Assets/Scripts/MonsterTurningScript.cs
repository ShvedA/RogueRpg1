using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterTurningScript : MonoBehaviour {

        private Texture2D[] _skins;

        private int _activeSkin;

        private Rigidbody2D _rb;

        private static readonly Vector2 ZeroVector = new Vector2(0, -1);

        private Sprite[] _sprites;

        public String FilePath = "Assets/Sprites/spider.png";

        private const int NumOfSpriteTurns = 8;

        private const double Round = 360;

        public GameObject Character;

        void Start()
        {

            _rb = GetComponent<Rigidbody2D>();
            _sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(FilePath).OfType<Sprite>().ToArray();

        }


        void Update()
        {

            var position = Character.transform.position;
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
            _rb.GetComponent<SpriteRenderer>().sprite = _sprites[newSprite];
        }

    }
}

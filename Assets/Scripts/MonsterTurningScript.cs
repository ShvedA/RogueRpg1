using System;
using System.Linq;
using Assets.Scripts.Helper;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterTurningScript : MonoBehaviour {

        private Texture2D[] _skins;

        private int _activeSkin;

        private Rigidbody2D _rb;

        private Sprite[] _sprites;

        public String FilePath = "Assets/Sprites/spider.png";

        private const int NumOfSpriteTurns = 8;

        public GameObject Character;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(FilePath).OfType<Sprite>().ToArray();
        }


        void Update()
        {
            var position = Character.transform.position;
            Vector2 vectorFromCenter = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);

            TurnCharacter(angle);
        }

        private void TurnCharacter(double angle)
        {
            double angleFromSectorBeginning = angle + (Constants.Round / NumOfSpriteTurns) / 2;
            int spriteNum = (int)(angleFromSectorBeginning / (Constants.Round / NumOfSpriteTurns));
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

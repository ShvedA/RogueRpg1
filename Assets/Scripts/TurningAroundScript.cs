using System;
using System.Linq;
using Assets.Scripts.Helper;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class TurningAroundScript : MonoBehaviour
    {
        private Texture2D[] _skins;
        private int _activeSkin;
        private Rigidbody2D _rb;
        private Sprite[] _sprites;
        public String FilePath = "Assets/Sprites/tree-16side.png";
        private const int NumOfSpriteTurns = 16;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(FilePath).OfType<Sprite>().ToArray();
        }


        private void Update()
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse = new Vector2(pz.x, pz.y);
            Vector2 vectorFromCenter = new Vector2(mouse.x - _rb.position.x, mouse.y - _rb.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            TurnCharacter(angle);
        }

        private void TurnCharacter(double angle)
        {
            double angleFromSectorBeginning = angle + (Constants.Round / NumOfSpriteTurns) / 2;
            int spriteNum = (int) (angleFromSectorBeginning / (Constants.Round / NumOfSpriteTurns));
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

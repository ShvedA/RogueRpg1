using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {

        public float Speed;

        public float projectileSpeed;

        public Texture2D[] Skins;

        public int ActiveSkin;

        private Rigidbody2D _rb;

        public Vector2 ZeroVector;

        public Sprite[] Sprites;

        public int NumOfSpriteTurns;

        public double Round = 360;

        public GameObject Projectile;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/tree-8side.png").OfType<Sprite>().ToArray();
            ZeroVector = new Vector2(0, -1);
            NumOfSpriteTurns = 8;
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            _rb.velocity = movement * Speed;

            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            Vector2 mouse = new Vector2(pz.x, pz.y);

            Vector2 vectorToCenter = new Vector2(mouse.x - _rb.position.x, mouse.y - _rb.position.y);

            double angle = GetAngle(vectorToCenter);

            if (Input.GetMouseButton(0))
            {
                Fire();
            }

            

            TurnCharacter(angle);
        }

        private void Fire()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var go = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            if (projectileVector.x >= 0)
            {
                go.transform.Rotate(new Vector3(0, 0, Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
            }
            else if (projectileVector.x < 0)
            {
                go.transform.Rotate(new Vector3(0, 0, 180 + Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
            }
            go.transform.parent = transform;
            //go.transform.LookAt(position);
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.ClampMagnitude(projectileVector, 0.01f) * 100 * projectileSpeed);
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
            double angleFromSectorBeginning = angle + (Round/NumOfSpriteTurns)/2;
            int spriteNum = (int) (angleFromSectorBeginning/(Round/NumOfSpriteTurns));
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
}

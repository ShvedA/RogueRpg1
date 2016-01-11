using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterMoveScript : MonoBehaviour {

        public float Life;

        public float Speed;

        private Rigidbody2D _rb;

        public GameObject Character;

        int count=0;

        public Vector2 randomMove = new Vector2(0,0);

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            count++;
            var position = Character.transform.position;
            if (((int)transform.position.x).Equals((int)position.x)||((int)transform.position.y).Equals((int)position.y)||(count<=0))
            {
                if (count > 0)
                {
                    count = -100;
                }
                else if ((transform.position.y > position.y)&&((int)transform.position.x).Equals((int)position.x))
                {
                    randomMove = new Vector2(0,-3);
                }
                else if ((transform.position.y < position.y) && ((int) transform.position.x).Equals((int) position.x))
                {
                    randomMove = new Vector2(0,3);
                }
                else if ((transform.position.x > position.x) && ((int) transform.position.y).Equals((int) position.y))
                {
                    randomMove = new Vector2(-3,0);
                }
                else if ((transform.position.x < position.x) && ((int) transform.position.y).Equals((int) position.y))
                {
                    randomMove = new Vector2(3,0);
                }
            }
            else if(count>0)
            {
                if (count == 40)
                {
                    randomMove = Vector2.ClampMagnitude(new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)), 1);
                }
                else if (count == 90)
                {
                    randomMove = new Vector2(0,0);
                    count = 0;
                }
            }
            _rb.velocity = randomMove * Speed;

            /*
            var position = Character.transform.position;
            Vector2 movement = Vector2.ClampMagnitude(new Vector2(position.x - transform.position.x, position.y - transform.position.y), 0.001f) * 1000;
            _rb.velocity = movement * Speed;
            */
        }
    }
}

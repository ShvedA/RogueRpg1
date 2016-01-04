using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterMoveScript : MonoBehaviour {

        public float Life;

        public float Speed;

        private Rigidbody2D _rb;

        public GameObject Character;

        int count=0;

        Vector2 randomMove;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            
            count++;
            if (count == 1)
            {
                var charPosition = Character.transform.position;
                randomMove = Vector2.ClampMagnitude(new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)), 1);
                count = 0;
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

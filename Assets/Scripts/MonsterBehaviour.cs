using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterBehaviour : MonoBehaviour
    {
        public float Life;
        public float Speed;
        private Rigidbody2D _rb;
        public GameObject Character;
        private int _count = 0;
        private Vector2 _randomMove = new Vector2(0, 0);
        public Transform sightStart, sightTopEnd, sightRightEnd, sightDownEnd, sightLeftEnd;
        public bool spottedUp, spottedRight, spottedDown, spottedLeft;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            RayCasting();
            Behaviours();
            _count++;
            switch (_count)
            {
                case 20:
                    _randomMove = Vector2.ClampMagnitude(
                        new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)), 1);
                    break;
                case 40:
                    _randomMove = new Vector2(0, 0);
                    _count = 0;
                    break;
            }
            _rb.velocity = _randomMove * Speed;
            //FollowBehaviour();
            //ChaseWhenOnSameLine();
        }

        private void ChaseWhenOnSameLine()
        {
            var position = Character.transform.position;
            if (((int)transform.position.x).Equals((int)position.x) || ((int)transform.position.y).Equals((int)position.y) || (_count <= 0))
            {
                if (_count > 0)
                {
                    _count = -100;
                }
                else if ((transform.position.y > position.y) && ((int)transform.position.x).Equals((int)position.x))
                {
                    _randomMove = new Vector2(0, -3);
                }
                else if ((transform.position.y < position.y) && ((int)transform.position.x).Equals((int)position.x))
                {
                    _randomMove = new Vector2(0, 3);
                }
                else if ((transform.position.x > position.x) && ((int)transform.position.y).Equals((int)position.y))
                {
                    _randomMove = new Vector2(-3, 0);
                }
                else if ((transform.position.x < position.x) && ((int)transform.position.y).Equals((int)position.y))
                {
                    _randomMove = new Vector2(3, 0);
                }
            }
        }

        private void FollowBehaviour()
        {
            var position = Character.transform.position;
            Vector2 movement = Vector2.ClampMagnitude(new Vector2(position.x - transform.position.x, position.y - transform.position.y), 0.001f) * 1000;
            _rb.velocity = movement * Speed;
        }

        private void RayCasting()
        {
            Debug.DrawLine(sightStart.position, sightTopEnd.position, Color.green);
            Debug.DrawLine(sightStart.position, sightRightEnd.position, Color.green);
            Debug.DrawLine(sightStart.position, sightDownEnd.position, Color.green);
            Debug.DrawLine(sightStart.position, sightLeftEnd.position, Color.green);
            spottedUp = Physics2D.Linecast(sightStart.position, sightTopEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedRight = Physics2D.Linecast(sightStart.position, sightRightEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedDown = Physics2D.Linecast(sightStart.position, sightDownEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedLeft = Physics2D.Linecast(sightStart.position, sightLeftEnd.position, 1 << LayerMask.NameToLayer("Character"));

        }

        private void Behaviours()
        {
            if (spottedUp)
            {
                _count = -50;
                _randomMove = new Vector2(0, 2);
            }
            else if (spottedDown)
            {
                _count = -50;
                _randomMove = new Vector2(0, -2);
            }
            else if (spottedRight)
            {
                _count = -50;
                _randomMove = new Vector2(2, 0);
            }
            else if (spottedLeft)
            {
                _count = -50;
                _randomMove = new Vector2(-2, 0);
            }
        }
    }
}

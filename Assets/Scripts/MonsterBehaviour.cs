using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterBehaviour : MonoBehaviour
    {
        public float Life;
        public float Speed;
        private Rigidbody2D _rb;
        public GameObject Character;
        public GameObject Walls;
        private int _count;
        Vector2 _randomMove = new Vector2(0,0);
        public Transform sightStart, sightTopEnd, sightRightEnd, sightDownEnd, sightLeftEnd;
        public bool spottedUp, spottedRight, spottedDown, spottedLeft = false;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public virtual void Update()
        {
            RayCasting();
            Behaviours();
            
            _rb.velocity = _randomMove * Speed; 
        }
        
        void RayCasting()
        {
            Debug.DrawLine(sightStart.position, sightTopEnd.position, Color.red);
            Debug.DrawLine(sightStart.position, sightRightEnd.position, Color.blue);
            Debug.DrawLine(sightStart.position, sightDownEnd.position, Color.green);
            Debug.DrawLine(sightStart.position, sightLeftEnd.position, Color.yellow);
            spottedUp = Physics2D.Linecast(sightStart.position, sightTopEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedRight = Physics2D.Linecast(sightStart.position, sightRightEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedDown = Physics2D.Linecast(sightStart.position, sightDownEnd.position, 1 << LayerMask.NameToLayer("Character"));
            spottedLeft = Physics2D.Linecast(sightStart.position, sightLeftEnd.position, 1 << LayerMask.NameToLayer("Character"));
        }
        
        Transform GetClosestObject()
        {
            Transform closestWall = null;
            float searchDistance = Mathf.Infinity;
            Vector2 currentPosition = transform.position;
            foreach (var near in WallPlacer.walls)
            {
                Vector2 directionToWall = new Vector2(near.position.x - currentPosition.x, near.position.y - currentPosition.y);
                float dSqrToTarget = directionToWall.sqrMagnitude;
                if (dSqrToTarget < searchDistance)
                {
                    searchDistance = dSqrToTarget;
                    closestWall = near;
                }
            }
            return closestWall;
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
            else
            {
                _count++;
                if (_count == 40)
                {
                    Transform wall = GetClosestObject();
                    if (wall == null)
                    {
                        _randomMove = Vector2.ClampMagnitude(new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)),
                            1);
                    }
                    else
                    {
                        var positionWall = wall.position;
                        _randomMove =
                            Vector2.ClampMagnitude(
                                new Vector2(positionWall.x - transform.position.x, positionWall.y - transform.position.y),1f)*-1;
                    }
                }
                else if (_count == 100)
                {
                    _randomMove = new Vector2(0, 0);
                    _count = 0;
                }
            }
        }
    }
}

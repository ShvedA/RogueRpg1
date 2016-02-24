using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class MonsterBehaviour : MonoBehaviour
    {
        public GameObject Character;
        public float Speed;
        public float RushSpeed;
        public float LookDistance;

        private Rigidbody2D _rb;
        private int _count;
        private Vector2 _randomMove = Vector2.zero;
        private int _spotted = -1;
        private readonly Vector2[] _directions = new Vector2[4] {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public virtual void Update()
        {
            RayCasting();
            Behaviours();
            _spotted = -1;
            _rb.velocity = _randomMove * Speed; 
        }
        
        void RayCasting()
        {
            for (int n = 0; n < _directions.Length; n++)
            {
                var hit = Physics2D.Raycast(transform.position, _directions[n], LookDistance);
                try
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        _spotted = n;
                        break;
                    }
                }
                catch (NullReferenceException) { }
            }
        }
        
        Transform GetClosestObject()
        {
            Transform closestWall = null;
            float searchDistance = 3f;
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
            if (_spotted >= 0 && _count >= 7)
            {
                _count = -50;
                _randomMove = _directions[_spotted] * RushSpeed;
            }
            else
            {
                _count++;
                if (_count == 40)
                {
                    Transform wall = GetClosestObject();
                    if (wall == null)
                    {
                        _randomMove = Vector2.ClampMagnitude(new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)), 1f);
                    }
                    else
                    {
                        var positionWall = wall.position;
                        _randomMove =
                            Vector2.ClampMagnitude(
                                new Vector2(positionWall.x - transform.position.x, positionWall.y - transform.position.y), 1f)*-1;
                    }
                }
                else if (_count == 100)
                {
                    _randomMove = Vector2.zero;
                    _count = 0;
                }
            }
        }
    }
}

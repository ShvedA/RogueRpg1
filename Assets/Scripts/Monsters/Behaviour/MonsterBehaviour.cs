using System;
using Assets.Scripts.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Monsters.Behaviour
{
    public class MonsterBehaviour : MonoBehaviour
    {
        public GameObject Character;
        public float Speed;
        public float RushSpeed;
        public float LookDistance;
        public Animator Animator;
        public int PrevBehaviour = 0;

        protected const int NumOfSpriteTurns = 8;

        private Rigidbody2D rb;
        private int count;
        private Vector2 randomMove = Vector2.zero;
        private int spotted = -1;
        private readonly Vector2[] directions = new Vector2[4] {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

        public void Awake() {
            Animator.GetComponent<Animator>();
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public virtual void Update()
        {
            RayCasting();
            Behaviours();
            spotted = -1;
            rb.velocity = randomMove * Speed; 
        }
        
        void RayCasting()
        {
            for (var n = 0; n < directions.Length; n++)
            {
                var hit = Physics2D.Raycast(transform.position, directions[n], LookDistance);
                try
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        spotted = n;
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
            foreach (var near in WallPlacer.Walls)
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

        protected void ChangeAnimation(Vector2 vectorFromCenter) {
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            var angleFromSectorBeginning = angle + (Constants.Round / NumOfSpriteTurns) / 2;

            int spriteNr = (int)(angleFromSectorBeginning / (Constants.Round / NumOfSpriteTurns));
            if (spriteNr < 0 || spriteNr == NumOfSpriteTurns) {
                spriteNr = 0;
            }
            if (PrevBehaviour == spriteNr)
            {
                return;
            }
            Debug.Log(Animator.GetInteger("angle"));
            Animator.SetInteger("angle", spriteNr); //throwing warning - need to expect this
            PrevBehaviour = spriteNr;
        }

        private void Behaviours()
        {
            if (spotted >= 0 && count >= 7)
            {
                count = -50;
                randomMove = directions[spotted] * RushSpeed;
            }
            else
            {
                count++;
                if (count == 40)
                {
                    Transform wall = GetClosestObject();
                    if (wall == null)
                    {
                        randomMove = Vector2.ClampMagnitude(new Vector2(Random.Range(-10, 11), Random.Range(-10, 11)), 1f);
                    }
                    else
                    {
                        var positionWall = wall.position;
                        randomMove =
                            Vector2.ClampMagnitude(
                                new Vector2(positionWall.x - transform.position.x, positionWall.y - transform.position.y), 1f)*-1;
                    }
                }
                else if (count == 100)
                {
                    randomMove = Vector2.zero;
                    count = 0;
                }
            }
        }
    }
}

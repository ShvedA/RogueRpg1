using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpiderBehaviour : MonsterBehaviour
    {
        public Animator Animator;
        private const int NumOfSpriteTurns = 8;

        public void Awake()
        {
            Animator.GetComponent<Animator>();
        }

        public override void Update()
        {
            base.Update();
            Movement();
            //Animator.transform.position += new Vector3(0, -0.01f, 0);
        }

        public void Movement()
        {
            var position = Character.transform.position;
            var vectorFromCenter = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            var angleFromSectorBeginning = angle + (Constants.Round / NumOfSpriteTurns) / 2;

            int spriteNr = (int)(angleFromSectorBeginning / (Constants.Round / NumOfSpriteTurns));
            if (spriteNr < 0 || spriteNr == NumOfSpriteTurns) {
                spriteNr = 0;
            }
            Animator.SetInteger("angle", spriteNr);
        }
    }
}

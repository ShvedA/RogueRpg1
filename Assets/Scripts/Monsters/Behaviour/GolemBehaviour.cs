using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Monsters.Behaviour {
    public class GolemBehaviour : MonsterBehaviour {
        public override void Update() {
            base.Update();
            Movement();
        }

        private void Movement() {
            var position = Character.transform.position;
            var vectorFromCenter = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            var angleFromSectorBeginning = angle + (Constants.Round / NumOfSpriteTurns) / 2;

            int spriteNr = (int) (angleFromSectorBeginning / (Constants.Round / NumOfSpriteTurns));
            if (spriteNr < 0 || spriteNr == NumOfSpriteTurns) {
                spriteNr = 0;
            }
        }
    }
}
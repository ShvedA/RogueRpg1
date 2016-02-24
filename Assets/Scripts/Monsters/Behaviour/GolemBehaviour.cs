using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Monsters.Behaviour {
    public class GolemBehaviour : MonsterBehaviour {

        public override void Update() {
            base.Update();
            Movement();
        }

        private void Movement()
        {
            throw new NotImplementedException();
        }
    }
}

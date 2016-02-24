using UnityEngine;

namespace Assets.Scripts.Monsters.Model {
    public class Golem : Monster {
        public Golem() : base(500, 0.5, 10){}

        void OnCollisionStay2D(Collision2D col) {
            if (col.gameObject.tag == "Player") {
                col.gameObject.GetComponent<CharHealth>().Damage(Attack);
            }

        }
    }
}

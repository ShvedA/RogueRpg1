using UnityEngine;

namespace Assets.Scripts.Monsters.Model {
    public class Golem : Monster {
        public Golem() : base(500, 0.5, 10) {}

        [SerializeField] private GameObject drop;

        protected override void OnDeath() {
            Instantiate(drop).transform.position = transform.position;
            base.OnDeath();
        }

        private void OnCollisionStay2D(Collision2D col) {
            if (col.gameObject.tag == "Player") {
                col.gameObject.GetComponent<CharHealth>().Damage(Attack);
            }
        }
    }
}
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Monsters.Model
{
    public class Spider : Monster
    {
        public Spider() : base(100, 1, 1){}

        [SerializeField]
        private GameObject drop;

        protected override void OnDeath()
        {
            Instantiate(drop).transform.position = transform.position;
            base.OnDeath();
            if (CanAddMonster())
            {
                Random random = new Random();
                var rand = random.Next(3);
                for (int i = 0; i < rand; i++)
                {
                    CreateNewMonster();
                }
            }
            else
            {
                Debug.LogWarning("Too much monsters, can't create another one");
            }
        }

        void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<CharHealth>().Damage(Attack);
            }
        }
    }
}

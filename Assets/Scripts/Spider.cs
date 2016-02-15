using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spider : Monster
    {

        public Spider() : base(100, 1, 1){}

        protected override void OnDeath()
        {
            base.OnDeath();
            if (CanAddMonster())
            {
                CreateNewMonster();
                CreateNewMonster();
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
                col.gameObject.GetComponent<CharHealth>().GetDamage(1);
            }

        }

    }
}

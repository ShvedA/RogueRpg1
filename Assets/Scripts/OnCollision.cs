using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class OnCollision : MonoBehaviour {

        public float damage;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name != "Character"){
                foreach (var fire in col.contacts.Where(x => x.otherCollider.gameObject.name == "Fire Projectile(Clone)"))
                {
                    Destroy(fire.otherCollider.gameObject);
                }
                /*foreach (var monster in col.contacts.Where(x => x.otherCollider.gameObject.tag == "monster"))
                {
                    monster.
                }*/
            }
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage(5);
            } 


                //col.gameObject.GetComponent<LifeScript>().life -= damage;

        }

    }
}

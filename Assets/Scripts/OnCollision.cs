using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class OnCollision : MonoBehaviour
    {

        public GameObject Character;

        public float Damage;

        void Awale()
        {
            //Physics2D.IgnoreCollision(Character.GetComponent<Collider2D>(), GetComponent<ParticleSystem>());
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name != "Character"){
                foreach (var fire in col.contacts.Where(x => x.otherCollider.gameObject.name == "Fire Projectile(Clone)"))
                {
                    Destroy(fire.otherCollider.gameObject);
                }
            }
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage((int)Damage);
            } 
        }

        void OnParticleCollision(GameObject col)
        {
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage((int)Damage);
            }
        }
    }
}

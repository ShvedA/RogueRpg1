using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class OnCollision : MonoBehaviour {

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "Wall(Clone)"){
                foreach (var fire in col.contacts.Where(x => x.otherCollider.gameObject.name == "Fire Projectile(Clone)"))
                {
                    Destroy(fire.otherCollider.gameObject);
                }
            }
            
        }

    }
}

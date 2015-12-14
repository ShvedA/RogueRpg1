using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class OnCollision : MonoBehaviour
    {

        public GameObject Character;

        public float Damage;

        void OnParticleCollision(GameObject col)
        {
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage((int)Damage);
            }
        }
    }
}

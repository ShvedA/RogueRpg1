using Assets.Scripts.Monsters.Model;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public class OnCollision : MonoBehaviour
    {
        [SerializeField] private int damage = 0;

        private void OnParticleCollision(GameObject col)
        {
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage(damage);
            }
        }
    }
}

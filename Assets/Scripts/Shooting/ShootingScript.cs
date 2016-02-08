using System.Collections;
using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public abstract class ShootingScript : MonoBehaviour
    {
        protected int Damage;

        public abstract void Init();

        public abstract void Play();

        public abstract void Stop();

        private void OnParticleCollision(GameObject col) {
            if (col.gameObject.tag == "Monster") {
                col.gameObject.GetComponent<Monster>().Damage(Damage);
            }
        }
    }
}

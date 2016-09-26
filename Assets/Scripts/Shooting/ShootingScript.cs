using System.Collections;
using Assets.Scripts.Helper;
using Assets.Scripts.Monsters.Model;
using UnityEngine;

namespace Assets.Scripts.Shooting {
    public abstract class ShootingScript : MonoBehaviour {
        protected int Damage;

        public abstract void Init();

        public abstract void Play();

        public abstract void Stop();

        protected void DealDamage(GameObject col) {
            if (col.gameObject.tag == "Monster") {
                col.gameObject.GetComponent<Monster>().Damage(Damage);
            }
        }
    }
}
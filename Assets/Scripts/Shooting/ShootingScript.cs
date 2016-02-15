using System.Collections;
using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public abstract class ShootingScript : MonoBehaviour
    {
        protected int Damage;
        protected float Arc = 0;

        public abstract void Init();

        public abstract void Play();

        public abstract void Stop();

        protected void DealDamage(GameObject col)
        {
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage(Damage);
            }
        }

        protected void CursorHandle()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, AngleHelper.GetAngleForParticles(projectileVector) - Arc / 2);
        }

    }
}

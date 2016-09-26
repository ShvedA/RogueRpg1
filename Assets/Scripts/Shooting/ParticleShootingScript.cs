using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ParticleShootingScript : ShootingScript
    {
        [HideInInspector]
        public ParticleSystem ParticleSystem;

        private float arc;

        void Update()
        {
            CursorHandle();
        }

        protected ParticleShootingScript(int damage)
        {
            Damage = damage;
        }

        public override void Init()
        {
            ParticleSystem = gameObject.GetComponent<ParticleSystem>();
            arc = ParticleSystem.shape.arc;
        }

        public override void Play()
        {
            ParticleSystem.Play();
        }

        public override void Stop()
        {
            ParticleSystem.Stop();
        }

        private void OnParticleCollision(GameObject col)
        {
            DealDamage(col);
        }

        private void CursorHandle()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, AngleHelper.GetAngleForParticles(projectileVector) - arc / 2);
        }
    }
}

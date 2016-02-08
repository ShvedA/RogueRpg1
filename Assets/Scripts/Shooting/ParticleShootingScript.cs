using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ParticleShootingScript : ShootingScript
    {

        private ParticleSystem _particleSystem;
        private float _arc = 0;

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
            _particleSystem = gameObject.GetComponent<ParticleSystem>();
            _arc = _particleSystem.shape.arc;
        }

        public override void Play()
        {
            _particleSystem.Play();
        }

        public override void Stop()
        {
            _particleSystem.Stop();
        }

        public void CursorHandle()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, AngleHelper.GetAngleForParticles(projectileVector) - _arc / 2);
        }

    }
}

using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ParticleShootingScript : ShootingScript
    {

        private ParticleSystem _particleSystem;
        

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
            Arc = _particleSystem.shape.arc;
        }

        public override void Play()
        {
            _particleSystem.Play();
        }

        public override void Stop()
        {
            _particleSystem.Stop();
        }

        private void OnParticleCollision(GameObject col)
        {
            DealDamage(col);
        }



    }
}

using System;
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
        private bool isActive;

        void Update()
        {
            CursorHandle();
            chargeLeft = Math.Min(ShootingHandler.MaxCharge, chargeLeft += chargeCharging);
            if (isActive && chargeLeft >= chargeCost) {
                chargeLeft -= chargeCost;
                ParticleSystem.Play();
            } else {
                ParticleSystem.Stop();
            }
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

        public override void Play() {
            isActive = true;
        }

        public override void Stop() {
            isActive = false;
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

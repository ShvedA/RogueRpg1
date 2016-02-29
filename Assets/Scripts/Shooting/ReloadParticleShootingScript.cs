using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ReloadParticleShootingScript : ShootingScript
    {
        [HideInInspector]
        public ParticleSystem ParticleSystem;

        private float arc;
        private bool firing;
        protected float ReloadTime;
        protected bool ReloadStarted;
        protected bool Reloaded;
        protected bool Fired;

        private IEnumerator StartReload(float seconds)
        {
            ReloadStarted = true;
            yield return new WaitForSeconds(seconds);
            Reloaded = true;
            ReloadStarted = false;
        }

        void Start()
        {
            ParticleSystem = gameObject.GetComponent<ParticleSystem>();
        }

        protected void ToUpdate()
        {
            if (Fired)
            {

                ParticleSystem.Stop();
            }
            
            if (!ReloadStarted && !Reloaded)
            {
                StartCoroutine(StartReload(ReloadTime));
            }
            CursorHandle();
            if (firing && Reloaded)
            {
                Reloaded = false;
                Fired = true;
                ParticleSystem.Play();
            }
        }

        protected ReloadParticleShootingScript(int damage, float reloadTime = 0f)
        {
            Damage = damage;
            ReloadTime = reloadTime;
        }

        public override void Init()
        {
            ParticleSystem = gameObject.GetComponent<ParticleSystem>();
            arc = ParticleSystem.shape.arc;
            Reloaded = false;
            ReloadStarted = false;
        }

        public override void Play()
        {
            firing = true;
        }

        public override void Stop()
        {
            firing = false;
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

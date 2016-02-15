using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ReloadParticleShootingScript : ShootingScript
    {

        private ParticleSystem _particleSystem;
        private float _arc;
        private bool _firing;
        protected float ReloadTime;
        protected bool ReloadStarted;
        protected bool Reloaded;

        private IEnumerator StartReload(float seconds)
        {
            ReloadStarted = true;
            yield return new WaitForSeconds(seconds);
            Reloaded = true;
            ReloadStarted = false;
        }

        protected void ToUpdate()
        {
            if (_firing && Reloaded)
            {
                _particleSystem.Stop();
                Reloaded = false;
            }
            if (!ReloadStarted && !Reloaded)
                StartCoroutine(StartReload(ReloadTime));
            CursorHandle();
            if (_firing && Reloaded)
            {
                _particleSystem.Play();
            }
        }

        protected ReloadParticleShootingScript(int damage, float reloadTime = 0f)
        {
            Damage = damage;
            ReloadTime = reloadTime;
        }

        public override void Init()
        {
            _particleSystem = gameObject.GetComponent<ParticleSystem>();
            _arc = _particleSystem.shape.arc;
            Reloaded = false;
            ReloadStarted = false;
        }

        public override void Play()
        {
            _firing = true;
        }

        public override void Stop()
        {
            _firing = false;
        }

        private void CursorHandle()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, AngleHelper.GetAngleForParticles(projectileVector) - _arc / 2);
        }

    }
}

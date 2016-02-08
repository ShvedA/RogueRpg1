using UnityEngine;
using System.Collections;
using Assets.Scripts.Helper;

namespace Assets.Scripts.Shooting
{
    public abstract class ReloadParticleShootingScript : ShootingScript
    {

        private ParticleSystem _particleSystem;
        private float _arc = 0;
        private bool _firing;
        private bool _waitingForReload;
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
            if (_firing)
            {
                _particleSystem.Stop();
                _firing = false;
                Reloaded = false;
            }
            if (!ReloadStarted && !Reloaded)
                StartCoroutine(StartReload(ReloadTime));
            CursorHandle();
            if (_waitingForReload)
            {
                Play();
            }
            if (_firing)
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
        }

        public override void Play()
        {
            if (Reloaded)
            {
                _firing = true;
            }
            else
            {
                _waitingForReload = true;
            }
        }

        public override void Stop()
        {
            _particleSystem.Stop();
            _firing = false;
            _waitingForReload = false;
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

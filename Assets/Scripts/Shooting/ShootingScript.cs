using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public abstract class ShootingScript : MonoBehaviour
    {
        protected int Damage;
        private ParticleSystem _particleSystem;
        private float _arc = 0;

        protected ShootingScript(int damage)
        {
            Damage = damage;
        }

        public void Init()
        {
            _particleSystem = gameObject.GetComponent<ParticleSystem>();
            _arc = _particleSystem.shape.arc;
        }

        public void Play()
        {
            _particleSystem.Play();
        }

        public void Stop()
        {
            _particleSystem.Stop();
        }

        public void ShootParticle()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, AngleHelper.GetAngleForParticles(projectileVector) - _arc / 2);
        }

        public void ShootProjectile()
        {
            var projectile = new GameObject();
            const int projectileSpeed = 10;
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var go = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            go.transform.Rotate(new Vector3(0, 0, AngleHelper.GetAngleForParticles(projectileVector)));
            go.transform.parent = transform;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.ClampMagnitude(projectileVector, 0.001f) * 1000 * projectileSpeed);
        }

        private void OnParticleCollision(GameObject col) {
            if (col.gameObject.tag == "Monster") {
                col.gameObject.GetComponent<Monster>().Damage(Damage);
            }
        }
    }
}

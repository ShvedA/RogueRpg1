using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShootingScript : MonoBehaviour {

        private float _particleSpeed;

        private float _arc;

        private void Awake()
        {
            UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(gameObject.GetComponent<ParticleSystem>());
            _arc = so.FindProperty("ShapeModule.arc").floatValue;
        }

        public void Play()
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            Debug.Log(gameObject.GetComponent<ParticleSystem>().IsAlive());
            Debug.Log(gameObject.GetComponent<ParticleSystem>().isPlaying);
            Debug.Log(gameObject.GetComponent<ParticleSystem>().isStopped);
        }

        public void Stop()
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }

        public void ShootPartice()
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

    }
}

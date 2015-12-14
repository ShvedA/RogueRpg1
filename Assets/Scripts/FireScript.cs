using UnityEngine;

namespace Assets.Scripts
{
    public class FireScript : MonoBehaviour {

        public float ProjectileSpeed;

        public GameObject Projectile;

        public GameObject Particles;

        public float ParticleSpeed;

        void Start () {
	
        }
	
        void Update () {
            if (Input.GetMouseButton(0))
            {
                Fire3();
            }
        }

        private void Fire()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var go = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            if (projectileVector.x >= 0)
            {
                go.transform.Rotate(new Vector3(0, 0, Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
            }
            else if (projectileVector.x < 0)
            {
                go.transform.Rotate(new Vector3(0, 0, 180 + Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
            }
            go.transform.parent = transform;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.ClampMagnitude(projectileVector, 0.001f) * 1000 * ProjectileSpeed);
        }

        private void Fire2()
        {

            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[Particles.GetComponent<ParticleSystem>().particleCount];
            int count = Particles.GetComponent<ParticleSystem>().GetParticles(particles);
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            for (int i = 0; i < count; i++)
            {
                particles[i].velocity = new Vector3(position.x - transform.position.x, 0, position.y - transform.position.y) * ParticleSpeed;
            }

            Particles.GetComponent<ParticleSystem>().SetParticles(particles, count);
        }

        private void Fire3()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);

            if (projectileVector.x >= 0)
            {
                Particles.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180);
            }
            else if (projectileVector.x < 0)
            {
                Particles.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180 + Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180);
            }
        }


    }
}

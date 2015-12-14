using UnityEngine;

namespace Assets.Scripts
{
    public class FireScript : MonoBehaviour {

        public float ProjectileSpeed;

        public GameObject Projectile;

        public GameObject Particles;

        public float ParticleSpeed;

        private float _arc;

        private void Awake()
        {

            UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(Particles.GetComponent<ParticleSystem>());
            _arc = so.FindProperty("ShapeModule.arc").floatValue;
        }

        void Update () {
            if (Input.GetMouseButton(0))
            {
                Fire3();
            }
            if (Input.GetButton("Fire1"))
                Particles.GetComponent<ParticleSystem>().Play();
            else if (Input.GetButtonUp("Fire1"))
                Particles.GetComponent<ParticleSystem>().Stop();
            
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

        private void Fire3()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            if (projectileVector.x >= 0)
            {
                Particles.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180 - _arc / 2);
            }
            else if (projectileVector.x < 0)
            {
                Particles.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180 + Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180 - _arc / 2);
            }
        }
    }
}

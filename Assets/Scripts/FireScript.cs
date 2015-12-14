﻿using UnityEngine;

namespace Assets.Scripts
{
    public class FireScript : MonoBehaviour {

        public float ProjectileSpeed;

        public GameObject Projectile;

        public GameObject Particles;

        public float ParticleSpeed;

        private float arc;

        private static readonly Vector2 ZeroVector = new Vector2(1, 0);

        private void Awake()
        {

            UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(Particles.GetComponent<ParticleSystem>());
            /*
            UnityEditor.SerializedProperty it = so.GetIterator();
            while (it.Next(true))
                Debug.Log(it.propertyPath);*/
            arc = so.FindProperty("ShapeModule.arc").floatValue;
        }

        void Update () {
            /*if (Input.GetButton("Fire1"))
            {
                Fire();
            }*/
            
            if (Input.GetMouseButton(0))
            {
                Fire3();
            }
            if (Input.GetButton("Fire1"))
                Particles.GetComponent<ParticleSystem>().Play();
            else if (Input.GetButtonUp("Fire1"))
                Particles.GetComponent<ParticleSystem>().Stop();
            
        }

        private float GetAngle(Vector2 vectorToCenter)
        {
            float angle = Vector2.Angle(vectorToCenter, ZeroVector);
            
            if (vectorToCenter.y < 0)
            {
                angle = 360 - angle;
            }
            return angle;
        }

        private void Fire()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var go = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            go.transform.Rotate(new Vector3(0, 0, GetAngle(projectileVector)));
            go.transform.parent = transform;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.ClampMagnitude(projectileVector, 0.001f) * 1000 * ProjectileSpeed);
        }

        private void Fire3()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            position = Camera.main.ScreenToWorldPoint(position);
            var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            Particles.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, GetAngle(projectileVector) - arc / 2);

        }


    }
}

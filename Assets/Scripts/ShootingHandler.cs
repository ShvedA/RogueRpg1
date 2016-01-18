using UnityEngine;

namespace Assets.Scripts
{
    public class ShootingHandler : MonoBehaviour
    {
        public GameObject Particle;
        private ShootingScript _shootingScript;

        private void Start()
        {
            _shootingScript = Particle.GetComponent<ShootingScript>();
            _shootingScript.Init();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("131");
                _shootingScript.Play();
            }
            if (Input.GetButton("Fire1"))
            {
                _shootingScript.ShootParticle();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                _shootingScript.Stop();
            }
        }
    }
}

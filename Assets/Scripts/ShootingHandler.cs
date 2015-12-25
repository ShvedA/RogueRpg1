using UnityEngine;

namespace Assets.Scripts
{
    public class ShootingHandler : MonoBehaviour
    {

        public GameObject Particle;

        private ShootingScript _shootingScript;

        void Start ()
        {
            _shootingScript = Particle.GetComponent<ShootingScript>();
        }
	
        void Update () {
            if (Input.GetButton("Fire1"))
            {
                _shootingScript.ShootPartice();
                _shootingScript.Play();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                _shootingScript.Stop();
            }
        }
    }
}

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
            _shootingScript.Init();
        }
	
        void Update () {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("131");
                _shootingScript.Play();
            }
            if (Input.GetButton("Fire1"))
            {
                _shootingScript.ShootPartice();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                _shootingScript.Stop();
            }
        }
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class ShootingHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject Particle;

        private ShootingScript _shootingScript;

        void Start ()
        {
            _shootingScript = Particle.GetComponent<ShootingScript>();
            _shootingScript.Init();
        }
	
        void Update () {
            if (Input.GetButtonDown("Fire1"))
            {
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

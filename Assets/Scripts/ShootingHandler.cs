using UnityEngine;

namespace Assets.Scripts
{
    public class ShootingHandler : MonoBehaviour
    {
        public GameObject[] Particle;
        private GameObject _mainParticle;
        private ShootingScript _shootingScript;

        private void Start()
        {
            _mainParticle = Particle[0];
            _shootingScript = _mainParticle.GetComponent<ShootingScript>();
            _shootingScript.Init();
        }

        private void ChangeWeapon(int weaponNumber)
        {
            _mainParticle = Particle[weaponNumber];
            _shootingScript = _mainParticle.GetComponent<ShootingScript>();
            _shootingScript.Init();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                _shootingScript.Stop();
                ChangeWeapon(1);
                if (Input.GetButton("Fire1"))
                {
                    _shootingScript.Play();
                }
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                _shootingScript.Stop();
                ChangeWeapon(0);
                if (Input.GetButton("Fire1"))
                {
                    _shootingScript.Play();
                }
            }

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

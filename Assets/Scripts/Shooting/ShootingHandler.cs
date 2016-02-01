using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public class ShootingHandler : MonoBehaviour
    {
        public GameObject[] Particle;
        private GameObject _mainParticle;
        private ShootingScript _shootingScript;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _mainParticle = Particle[0];
            _shootingScript = _mainParticle.GetComponent<ShootingScript>();
            _shootingScript.Init();
        }

        private void ChangeWeapon(int weaponNumber)
        {
            _shootingScript.Stop();
            _mainParticle = Particle[weaponNumber];
            _shootingScript = _mainParticle.GetComponent<ShootingScript>();
            _shootingScript.Init();
            if (Input.GetButton("Fire1"))
            {
                _shootingScript.Play();
            }
        }

        private void LookingAngle()
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse = new Vector2(pz.x, pz.y);
            Vector2 vectorFromCenter = new Vector2(mouse.x - _rb.position.x, mouse.y - _rb.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            AnalyzeAngle(angle);
        }

        private void AnalyzeAngle(double angle)
        {
            double angleFromSectorBeginning = angle + (Constants.Round / Particle.Length) / 2;
            int weaponNumber = (int)(angleFromSectorBeginning / (Constants.Round / Particle.Length));
            if (weaponNumber < 0 || weaponNumber == Particle.Length)
            {
                weaponNumber = 0;
            }
            ChangeWeapon(weaponNumber);
        }

        private void Update()
        {
            LookingAngle();
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

using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public class ShootingHandler : MonoBehaviour
    {
        public GameObject[] Particle;
        private GameObject mainParticle;
        private ShootingScript shootingScript;
        private Rigidbody2D rb;
        private int weaponNumber = 0;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            mainParticle = Particle[weaponNumber];
            shootingScript = mainParticle.GetComponent<ShootingScript>();
            shootingScript.Init();
        }

        private void ChangeWeapon(int weaponNr)
        {
            if (weaponNr == weaponNumber)
            {
                return;
            }
            shootingScript.Stop();
            weaponNumber = weaponNr;
            mainParticle = Particle[weaponNr];
            shootingScript = mainParticle.GetComponent<ShootingScript>();
            shootingScript.Init();
            if (Input.GetButton("Fire1"))
            {
                shootingScript.Play();
            }
        }

        private void LookingAngle()
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse = new Vector2(pz.x, pz.y);
            Vector2 vectorFromCenter = new Vector2(mouse.x - rb.position.x, mouse.y - rb.position.y);
            double angle = AngleHelper.GetAngleForTurningAround(vectorFromCenter);
            AnalyzeAngle(angle);
        }

        private void AnalyzeAngle(double angle)
        {
            var angleFromSectorBeginning = angle + (Constants.Round / Particle.Length) / 2;
            var weaponNr = (int)(angleFromSectorBeginning / (Constants.Round / Particle.Length));
            if (weaponNr < 0 || weaponNr == Particle.Length)
            {
                weaponNr = 0;
            }
            ChangeWeapon(weaponNr);
        }

        private void Update()
        {
            LookingAngle();
            if (Input.GetButtonDown("Fire1"))
            {
                shootingScript.Play();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                shootingScript.Stop();
            }
        }
    }
}

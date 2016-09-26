using System.Collections;
using Assets.Scripts.Helper;
using Assets.Scripts.Monsters.Model;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public abstract class ShootingScript : MonoBehaviour
    {
        protected int Damage;

        public abstract void Init();
        public abstract void Play();
        public abstract void Stop();
        
        protected double chargeLeft;
        protected double chargeCost;
        protected double chargeCharging;

        //public double 

        protected ShootingScript()
        {
            chargeLeft = ShootingHandler.MaxCharge;
            chargeCost = 1;
            chargeCharging = 1;
        }

        public double ChargeLeft() {
            return chargeLeft;
        }

        protected void DealDamage(GameObject col)
        {
            if (col.gameObject.tag == "Monster")
            {
                col.gameObject.GetComponent<Monster>().Damage(Damage);
            }
        }

        public virtual string GetName() {
            return "Noname";
        } 
    }
}

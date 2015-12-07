using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Monster : MonoBehaviour
    {

        private int _health = 100;
        private double _speed;
        //private double rotationSpeed;
        private int _attack;

        public Boolean IsDead()
        {
            return _health <= 0;
        }

        public void Damage(int damage)
        {
            _health -= damage;
        }

    }
}

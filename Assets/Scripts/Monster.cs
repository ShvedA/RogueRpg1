using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Monster : MonoBehaviour
    {
        private int _health = 100;
        private double _speed;
        private int _attack;
        private static int _numOfMonsters = 1;
        public const int MaxNumOfMonsters = 100;

        protected virtual void Update()
        {
            CheckForDeath();
        }

        public void CheckForDeath()
        {
            if (_health <= 0)
            {
                OnDeath();
                Die();
            }
        }

        protected virtual void OnDeath()
        {
            _numOfMonsters--;
        }

        public bool IsDead()
        {
            return _health <= 0;
        }

        public void Damage(int damage)
        {
            _health -= damage;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public bool CanAddMonster()
        {
            if (MaxNumOfMonsters > _numOfMonsters)
            {
                return true;
            }
            return false;
        }

        public void CreateNewMonster()
        {
            Instantiate(gameObject, gameObject.transform.localPosition, gameObject.transform.localRotation);
            _numOfMonsters++;
        }

    }
}

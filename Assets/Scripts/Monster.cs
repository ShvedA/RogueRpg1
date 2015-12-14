using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Monster : MonoBehaviour
    {
        private int _health = 100;
        private double _speed;
        private int _attack;
        private static int numOfMonsters = 1;
        public const int MaxNumOfMonsters = 100;

        public Boolean IsDead()
        {
            return _health <= 0;
        }

        public void Damage(int damage)
        {
            _health -= damage;
        }

        public void Die()
        {
            numOfMonsters--;
            Destroy(gameObject);
        }

        public bool CanAddMonster()
        {
            if (MaxNumOfMonsters > numOfMonsters)
            {
                return true;
            }
            return false;
        }

        public void CreateNewSpider()
        {
            Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
            numOfMonsters++;
        }

    }
}

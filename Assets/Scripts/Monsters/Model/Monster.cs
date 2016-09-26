using UnityEngine;

namespace Assets.Scripts.Monsters.Model
{
    public abstract class Monster : MonoBehaviour
    {
        protected int Health;
        protected double Speed;
        protected int Attack;
        private static int numOfMonsters = 1;
        public const int MaxNumOfMonsters = 100;

        protected Monster(int health, double speed, int attack)
        {
            Health = health;
            Speed = speed;
            Attack = attack;
        }

        protected virtual void Update()
        {
            CheckForDeath();
        }

        public void CheckForDeath()
        {
            if (IsDead())
            {
                OnDeath();
                Die();
            }
        }

        protected virtual void OnDeath()
        {
            numOfMonsters--;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public void Damage(int damage)
        {
            Health -= damage;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public bool CanAddMonster()
        {
            return MaxNumOfMonsters > numOfMonsters;
        }

        public void CreateNewMonster()
        {
            Instantiate(gameObject, gameObject.transform.localPosition, gameObject.transform.localRotation);
            numOfMonsters++;
        }
    }
}

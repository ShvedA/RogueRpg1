using UnityEngine;

namespace Assets.Scripts
{
    public class Spider : Monster {

        void Start()
        {
            transform.position = new Vector3(15f, 7f);
        }

        private void Update()
        {
            CheckForDeath();
        }

        protected override void OnDeath()
        {
            base.OnDeath();
            if (CanAddMonster())
            {
                CreateNewMonster();
                CreateNewMonster();
            }
            else
            {
                Debug.LogWarning("Too much monsters, can't create another one");
            }
        }


    }
}

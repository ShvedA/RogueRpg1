using UnityEngine;

namespace Assets.Scripts
{
    public class Spider : Monster
    {
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

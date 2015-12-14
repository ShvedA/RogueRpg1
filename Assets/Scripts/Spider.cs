using UnityEngine;

namespace Assets.Scripts
{
    public class Spider : Monster {

        void Start()
        {
            transform.position = new Vector3(15f, 7f);
        }

        void Update () {
            if (IsDead())
            {

                if (CanAddMonster())
                {
                    CreateNewSpider();
                    CreateNewSpider();
                }

                Die();
            }
        }

        
    }
}

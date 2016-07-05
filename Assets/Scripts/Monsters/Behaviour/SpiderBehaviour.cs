using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.Monsters.Behaviour
{
    public class SpiderBehaviour : MonsterBehaviour
    {
        public override void Update()
        {
            base.Update();
            Movement();
        }

        private void Movement()
        {
            var position = Character.transform.position;
            var vectorFromCenter = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
            ChangeAnimation(vectorFromCenter);
        }

        
    }
}

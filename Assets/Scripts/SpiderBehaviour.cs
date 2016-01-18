using UnityEngine;

namespace Assets.Scripts
{
    public class SpiderBehaviour : MonoBehaviour
    {
        public Animator Animator;

        public void Awake()
        {
            Animator.GetComponent<Animator>();
        }

        public void Update()
        {
            Animator.transform.position += new Vector3(0, -0.01f, 0);
        }
    }
}

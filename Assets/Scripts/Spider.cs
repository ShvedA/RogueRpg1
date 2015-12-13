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
                Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
                Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);

                //Instantiate(gameObject, transform.position, Quaternion.identity);

                Destroy(gameObject);
                //Spider spider = new Spider();
            }
        }
    }
}

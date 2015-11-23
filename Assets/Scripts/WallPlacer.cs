using UnityEngine;

namespace Assets.Scripts
{
    public class WallPlacer : MonoBehaviour {

        public GameObject Brick;

        void Start()
        {
        
            for (int x = -22; x <= 22; x++)
            {
                for (int y = -10; y <= 10; y++)
                {
                    if (x == -22 || x == 22 || y == -10 || y == 10)
                    {
                        GameObject each = Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                    }
                }
            }
        }
    }
}

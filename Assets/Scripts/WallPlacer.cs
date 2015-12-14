using System.Linq.Expressions;
using UnityEngine;

namespace Assets.Scripts
{
    public class WallPlacer : MonoBehaviour {
        private const int Width = 50;
        private const int Height = 50;

        public GameObject Brick;
        void Start()
        {
            CreateRectangleField();
            //RandomSquaresAroundTheMap();
        }

        private void CreateRectangleField()
        {
            for (int x = -Width; x <= Width; x++)
            {
                for (int y = -Height; y <= Height; y++)
                {
                    if (x == -Width || x == Width || y == -Height || y == Height)
                    {
                        GameObject each = Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                    }
                }
            }
        }

        private void RandomSquaresAroundTheMap()
        {
            for (int i = 0; i < 100; i++)
            {
                GameObject each = Instantiate(Brick, new Vector3((int)Random.Range(-30f, 30f), (int)Random.Range(-30f, 30f), 0), Quaternion.identity) as GameObject;
                each.transform.parent = transform;
            }
        }
    }
}

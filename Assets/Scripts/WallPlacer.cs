using System.Linq.Expressions;
using UnityEngine;
using Assets.Scripts.Helper;

namespace Assets.Scripts
{
    public class WallPlacer : MonoBehaviour {
        private const int Width = 50;
        private const int Height = 50;

        [SerializeField]
        private int mapOffset;

        public GameObject Brick;
        void Start()
        {
            //CreateRectangleField();
            //RandomSquaresAroundTheMap();
            CreateCaveLikeMap();
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

        private void CreateCaveLikeMap()
        {
            MapHandler handler = new MapHandler(100, 100, 123);
            handler.MakeCaverns();
            for (int column = 0, row = 0; row <= handler.MapHeight - 1; row++)
            {
                for (column = 0; column <= handler.MapWidth - 1; column++)
                {
                    if (handler.Map[column, row] == 1)
                    {
                        GameObject each = Instantiate(Brick, new Vector3(column - mapOffset, row - mapOffset, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                    }
                }
            }
        }
    }
}

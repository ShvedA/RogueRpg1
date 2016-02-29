using UnityEngine;
using Assets.Scripts.Helper;

namespace Assets.Scripts
{
    public class WallPlacer : MonoBehaviour
    {
        [SerializeField]
        private int mapOffsetX;
        [SerializeField]
        private int mapOffsetY;
        private const int Width = 50;
        private const int Height = 50;

        public static Transform[] Walls;
        public GameObject Brick;

        private void Start()
        {
            //CreateRectangleField();
            //RandomSquaresAroundTheMap();
            CreateCaveLikeMap();
            Walls = new Transform[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                Walls[i] = transform.GetChild(i).transform;
            }
        }

        private void CreateRectangleField()
        {
            for (var x = -Width; x <= Width; x++)
            {
                for (var y = -Height; y <= Height; y++)
                {
                    if (x == -Width || x == Width || y == -Height || y == Height)
                    {
                        var each = Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                    }
                }
            }
        }

        private void RandomSquaresAroundTheMap()
        {
            for (var i = 0; i < 100; i++)
            {
                var each =
                    Instantiate(Brick, new Vector3((int) Random.Range(-30f, 30f), (int) Random.Range(-30f, 30f), 0), Quaternion.identity) as
                        GameObject;
                each.transform.parent = transform;
            }
        }

        private void CreateCaveLikeMap()
        {
            var handler = new MapHandler(100, 100, 657);
            handler.MakeCaverns();
            handler.MakeCaverns();
            handler.MakeCaverns();
            for (var row = 0; row <= handler.MapHeight - 1; row++)
            {
                for (var column = 0; column <= handler.MapWidth - 1; column++)
                {
                    if (handler.Map[column, row] == 1)
                    {
                        var each = Instantiate(Brick, new Vector3(column - mapOffsetX, row - mapOffsetY, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                    }
                }
            }
        }
    }
}

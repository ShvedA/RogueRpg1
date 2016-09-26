using UnityEngine;

namespace Assets.Scripts.Helper
{
    public class MapHandler
    {
        public int[,] Map;

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public int PercentAreWalls { get; set; }

        public MapHandler()
        {
            MapWidth = 40;
            MapHeight = 21;
            PercentAreWalls = 80;

            RandomFillMap();
        }

        public void MakeCaverns()
        {
            var tempMap = BlankMap();
            for (var row = 0; row <= MapHeight - 1; row++)
            {
                for (var column = 0; column <= MapWidth - 1; column++)
                {
                    
                    tempMap[column, row] = PlaceWallLogic(column, row);
                }
            }
            Map = tempMap;
        }

        public void FillHugeSpaces()
        {
            var tempMap = BlankMap();
            for (var row = 0; row <= MapHeight - 1; row++)
            {
                for (var column = 0; column <= MapWidth - 1; column++)
                {
                    tempMap[column, row] = FillSpaceLogic(column, row);
                }
            }
            Map = tempMap;
        }

        public int FillSpaceLogic(int x, int y)
        {
            if (Map[x, y] == 1)
            {
                return 1;
            }
            var numWalls = GetAdjacentWalls(x, y, 2, 2);
            return numWalls <= 2 ? 1 : 0;
        }

        public int PlaceWallLogic(int x, int y)
        {
            var numWalls = GetAdjacentWalls(x, y, 1, 1);
            return numWalls >= 5 ? 1 : 0;
        }

        public float GetAdjacentWalls(int x, int y, int scopeX, int scopeY)
        {
            var startX = x - scopeX;
            var startY = y - scopeY;
            var endX = x + scopeX;
            var endY = y + scopeY;

            float wallCounter = 0;

            for (var iY = startY; iY <= endY; iY++)
            {
                for (var iX = startX; iX <= endX; iX++)
                {
                    wallCounter += IsWall(iX, iY);
                }
            }
            return wallCounter;
        }

        private float IsWall(int x, int y)
        {
            // Consider out-of-bound a wall
            if (IsOutOfBounds(x, y))
            {
                return 0.5f;
            }

            return Map[x, y] == 1 ? 1f : 0f;
        }

        private bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || y < 0 || x > MapWidth - 1 || y > MapHeight - 1;
        }

        private bool IsEdge(int column, int row)
        {
            return column == 0 || row == 0 || column == MapHeight - 1 || row == MapHeight - 1;
        }

        public int[,] BlankMap()
        {
            var tempMap = new int[this.MapWidth, this.MapHeight];
            for (var row = 0; row < MapHeight; row++)
            {
                for (var column = 0; column < MapWidth; column++)
                {
                    tempMap[column, row] = 0;
                }
            }
            return tempMap;
        }

        public void RandomFillMap()
        {

            for (var row = 0; row < MapHeight; row++)
            {
                for (var column = 0; column < MapWidth; column++)
                {
                    Map[column, row] = RandomPercent(PercentAreWalls);
                }
            }
        }

        private static int RandomPercent(int percent)
        {
            return percent >= Random.Range(1f, 100f) ? 1 : 0;
        }

        public MapHandler(int mapWidth, int mapHeight, int seed, int percentWalls = 45)
        {
            Random.InitState(seed);
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;
            this.PercentAreWalls = percentWalls;
            this.Map = new int[this.MapWidth, this.MapHeight];
            RandomFillMap();
        }

        public MapHandler(int mapWidth, int mapHeight, int[,] map, int percentWalls = 40)
        {
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;
            this.PercentAreWalls = percentWalls;
            this.Map = new int[this.MapWidth, this.MapHeight];
            this.Map = map;
        }
    }
}

using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Helper
{
    public class MapHandler
    {
        //Random rand = new Random();

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
            int[,] TempMap = BlankMap();
            for (int column = 0, row = 0; row <= MapHeight - 1; row++)
            {
                for (column = 0; column <= MapWidth - 1; column++)
                {
                    
                    TempMap[column, row] = PlaceWallLogic(column, row);
                }
            }
            Map = TempMap;
        }

        public void FillHugeSpaces()
        {
            int[,] TempMap = BlankMap();
            for (int column = 0, row = 0; row <= MapHeight - 1; row++)
            {
                for (column = 0; column <= MapWidth - 1; column++)
                {
                    TempMap[column, row] = FillSpaceLogic(column, row);
                }
            }
            Map = TempMap;
        }

        public int FillSpaceLogic(int x, int y)
        {
            if (Map[x, y] == 1)
            {
                return 1;
            }
            int numWalls = GetAdjacentWalls(x, y, 2, 2);

            if (numWalls <= 2)
            {
                return 1;
            }
                return 0;
        }

        public int PlaceWallLogic(int x, int y)
        {
            int numWalls = GetAdjacentWalls(x, y, 1, 1);

            if (numWalls >= 5)
            {
                return 1;
            }
                return 0;
        }

        public int GetAdjacentWalls(int x, int y, int scopeX, int scopeY)
        {
            int startX = x - scopeX;
            int startY = y - scopeY;
            int endX = x + scopeX;
            int endY = y + scopeY;

            int iX = startX;
            int iY = startY;

            int wallCounter = 0;

            for (iY = startY; iY <= endY; iY++)
            {
                for (iX = startX; iX <= endX; iX++)
                {
                    if (IsWall(iX, iY))
                    {
                        wallCounter += 1;
                    }
                }
            }
            return wallCounter;
        }

        bool IsWall(int x, int y)
        {
            // Consider out-of-bound a wall
            if (IsOutOfBounds(x, y))
            {
                return true;
            }

            if (Map[x, y] == 1)
            {
                return true;
            }

            if (Map[x, y] == 0)
            {
                return false;
            }
            return false;
        }

        bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return true;
            }
            else if (x > MapWidth - 1 || y > MapHeight - 1)
            {
                return true;
            }
            return false;
        }

        bool IsEdge(int column, int row)
        {
            if (column == 0)
            {
                return true;
            }
            else if (row == 0)
            {
                return true;
            }
            else if (column == MapWidth - 1)
            {
                return true;
            }
            else if (row == MapHeight - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[,] BlankMap()
        {
            int [,] TempMap = new int[this.MapWidth, this.MapHeight];
            for (int column = 0, row = 0; row < MapHeight; row++)
            {
                for (column = 0; column < MapWidth; column++)
                {
                    TempMap[column, row] = 0;
                }
            }
            return TempMap;
        }

        public void RandomFillMap()
        {

            for (int column = 0, row = 0; row < MapHeight; row++)
            {
                for (column = 0; column < MapWidth; column++)
                {
                    // If coordinants lie on the the edge of the map (creates a border)
                    if (IsEdge(column, row))
                    {
                        Map[column, row] = 1;
                    }
                    // Else, fill with a wall a random percent of the time
                    else
                    {
                        Map[column, row] = RandomPercent(PercentAreWalls);
                    }
                }
            }
        }

        int RandomPercent(int percent)
        {
            if (percent >= Random.Range(1f, 100f))
            {
                return 1;
            }
                return 0;
        }

        public MapHandler(int mapWidth, int mapHeight, int seed, int percentWalls = 45)
        {
            Random.seed = seed;
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

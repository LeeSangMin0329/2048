using System.Collections.Generic;

namespace _2048
{
    class TileMap
    {
        public enum DIRECTION { RIGHT, LEFT, UP, DOWN }

        public int[,] Tiles { get; private set; }
        public readonly int MAP_SIZE = 4;

        private List<Point> mBlankTiles;

        private readonly Point[] mOffset;

        public TileMap()
        {
            Tiles = new int[MAP_SIZE, MAP_SIZE];
            mBlankTiles = new List<Point>();

            mOffset = new Point[4];
            mOffset[(int)DIRECTION.RIGHT] = new Point(-1, 0);
            mOffset[(int)DIRECTION.LEFT] = new Point(1, 0);
            mOffset[(int)DIRECTION.DOWN] = new Point(0, -1);
            mOffset[(int)DIRECTION.UP] = new Point(0, 1);

            GenerateTileRandomly(2);
            GenerateTileRandomly(2);
        }

        public void MoveRight()
        {
            Move(DIRECTION.RIGHT);
        }

        public void MoveLeft()
        {
            Move(DIRECTION.LEFT);
        }

        public void MoveUp()
        {
            Move(DIRECTION.UP);
        }

        public void MoveDown()
        {
            Move(DIRECTION.DOWN);
        }

        private void Move(DIRECTION dir)
        {
            PushTiles(dir);
            GenerateTileRandomly(2);
        }

        private void PushTiles(DIRECTION dir)
        {
            for(int i=0; i < MAP_SIZE; i++)
            {
                PushLine(i, mOffset[(int)dir]);
            }
        }

        private void PushLine(int index, Point p)
        {
            int pivot;
            if(p.X != 0)
            {
                if(p.X > 0)
                {
                    pivot = 0;
                }
                else
                {
                    pivot = MAP_SIZE - 1;
                }

                while (pivot < MAP_SIZE && pivot >= 0)
                {
                    for (int i = pivot; i < MAP_SIZE && i >= 0; i += p.X)
                    {
                        if (Tiles[index, i] != 0)
                        {
                            int temp = Tiles[index, pivot];
                            Tiles[index, pivot] = Tiles[index, i];
                            Tiles[index, i] = temp;
                            break;
                        }
                    }

                    for (int i = pivot + p.X; i < MAP_SIZE && i >= 0; i += p.X)
                    {
                        int cur = Tiles[index, i];

                        if(cur != 0)
                        {
                            if (Tiles[index, pivot] == cur)
                            {
                                Tiles[index, pivot] += cur;
                                Tiles[index, i] = 0;
                            }
                            break;
                        }
                    }

                    pivot += p.X;
                }
            }
            else if(p.Y != 0)
            {
                if (p.Y > 0)
                {
                    pivot = 0;
                }
                else
                {
                    pivot = MAP_SIZE - 1;
                }

                while (pivot < MAP_SIZE && pivot >= 0)
                {
                    for (int i = pivot; i < MAP_SIZE && i >= 0; i += p.Y)
                    {
                        if (Tiles[i, index] != 0)
                        {
                            int temp = Tiles[pivot, index];
                            Tiles[pivot, index] = Tiles[i, index];
                            Tiles[i, index] = temp;
                            break;
                        }
                    }

                    for (int i = pivot + p.Y; i < MAP_SIZE && i >= 0; i += p.Y)
                    {
                        int cur = Tiles[i, index];

                        if (cur != 0)
                        {
                            if (Tiles[pivot, index] == cur)
                            {
                                Tiles[pivot, index] += cur;
                                Tiles[i, index] = 0;
                            }
                            break;
                        }
                    }

                    pivot += p.Y;
                }
            }
        }

        private void FindBlankTiles()
        {
            mBlankTiles.Clear();
            for(int y=0; y < MAP_SIZE; y++)
            {
                for(int x=0; x < MAP_SIZE; x++)
                {
                    if(Tiles[y, x] == 0)
                    {
                        mBlankTiles.Add(new Point(x, y));
                    }
                }
            }
        }

        private void GenerateTileRandomly(int value)
        {
            FindBlankTiles();
            if (mBlankTiles.Count == 0)
            {
                return;
            }

            int index = RandomGenerator.Next(0, mBlankTiles.Count - 1);
            Point p = mBlankTiles[index];

            Tiles[p.Y, p.X] = value;
        }
    }
}

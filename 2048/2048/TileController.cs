using System;

namespace _2048
{
    static class TileController
    {
        private static TileMap mTileMap = new TileMap();

        public static void Run()
        {
            ConsoleKeyInfo keys;

            do
            {
                if (Console.KeyAvailable)
                {
                    keys = Console.ReadKey(true);
                    switch (keys.Key)
                    {
                        case ConsoleKey.UpArrow:
                            mTileMap.MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            mTileMap.MoveDown();
                            break;
                        case ConsoleKey.RightArrow:
                            mTileMap.MoveRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            mTileMap.MoveLeft();
                            break;
                    }
                    PrintTiles();
                }
            } while (true);
        }

        private static void PrintTiles()
        {
            var map = mTileMap.Tiles;
            int length = mTileMap.MAP_SIZE;

            Console.Clear();
            for(int y=0; y<length; y++)
            {
                for(int x=0; x<length; x++)
                {
                    Console.Write(map[y, x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

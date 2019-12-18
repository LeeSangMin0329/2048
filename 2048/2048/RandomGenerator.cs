using System;

namespace _2048
{

    static class RandomGenerator
    {
        private static readonly Random mRandom = new Random();

        public static int Next(int min, int max)
        {
            return mRandom.Next(min, max);
        }
    }
}

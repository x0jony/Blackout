using System;
using System.Threading;

namespace Blackout
{
    public static class SeriouslyRandom
    {
        private static int seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() =>
                new Random(Interlocked.Increment(ref seed)));

        public static int Next(int minValue, int maxValue)
        {
            return random.Value.Next(minValue, maxValue);
        }
    }
}
using System;
namespace CodeExecution
{
    public static class IntRandomizer
    {
        public static int Randomize(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max);
        }

        public static int Randomize(int max)
        {
            var rnd = new Random();
            return rnd.Next(max);
        }
    }
}
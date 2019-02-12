using System;

namespace CodeExecution
{
    [Serializable]
    public class Limit
    {
        public int Min { get; }
        public int Max { get; }

        public Limit(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}

namespace CodeExecution
{
    public class Limit
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public Limit(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}

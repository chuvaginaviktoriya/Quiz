using System.Collections.Generic;

namespace CodeExecution
{
    public class Question
    {
        private Code _code;
        private Limit[] _limits;
        public object[] InputData { get; private set; }
        public string Answer { get; private set; }

        public Question(string code, Limit [] limits)
        {
            _code = new Code(code);
            _limits = limits;
        }

        public void GenerateInputs()
        {
            var inputs = new List<object>();

            foreach (var limit in _limits)
                inputs.Add(IntRandomizer.Randomize(limit.Min, limit.Max));

            InputData = inputs.ToArray();
        }

        public void Solve()
        {
            Answer = _code.GetSolution(InputData);
        }
    }
  
}

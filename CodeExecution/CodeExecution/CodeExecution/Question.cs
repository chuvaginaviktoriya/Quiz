using System;
using System.Collections.Generic;

namespace CodeExecution
{
    public class Question
    {
        private Code _code;
        private Limit[] _limits;
        public List<object> InputData { get; private set; }
        public string Answer { get; private set; }

        public Question(Code code, Limit [] limits)
        {
            _code = code;
            _limits = limits;
        }

        public void GenerateInputs()
        {
            var inputs = new List<object>();
            var randomizer = new Random();

            foreach (var limit in _limits)
                inputs.Add(randomizer.Next(limit.Min, limit.Max));

            InputData = inputs;
        }

        public void Solve()
        {
            Answer = _code.GetSolution(InputData.ToArray());
        }
    }
  
}

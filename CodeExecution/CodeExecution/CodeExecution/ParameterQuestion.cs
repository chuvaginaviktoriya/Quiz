using System;
using System.Collections.Generic;

namespace CodeExecution
{
    [Serializable]
    public class ParameterQuestion:Question
    {
        public Code Code { get; private set; }
        public Statement Statement { get; private set; }

        public List<object> InputData { get; private set; }

        public ParameterQuestion(Code code, Statement statement)
        {
            Code = code;
            Statement = statement;
        }

        private void GenerateInputs()
        {
            var inputs = new List<object>();
            var randomizer = new Random();

            foreach (var limit in Statement.Limits)
                inputs.Add(randomizer.Next(limit.Min, limit.Max));

            InputData = inputs;
        }

        public string GetStatement()
        {
            GenerateInputs();
            var result = Statement.Text[0];

            for (int i=1; i<Statement.Text.Count;i++)
            {
                result += InputData[i-1];
                result += Statement.Text[i];
            }

            return result;
        }

        public string GetAnswer()
        {
            return Code.GetSolution(InputData.ToArray());
        }
    }
}

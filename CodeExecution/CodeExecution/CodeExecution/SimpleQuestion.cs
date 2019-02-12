using System;

namespace CodeExecution
{
    [Serializable]
    public class SimpleQuestion : IQuestion
    {
        private readonly string _statement;
        private readonly string _answer;

        public SimpleQuestion(string statement, string answer)
        {
            _statement = statement;
            _answer = answer;
        }

        public string GetStatement()
        {
            return _statement;
        }

        public string GetAnswer()
        {
            return _answer;
        }
    }
}

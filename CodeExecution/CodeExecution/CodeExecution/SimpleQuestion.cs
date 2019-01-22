using System;

namespace CodeExecution
{
    [Serializable]
    public class SimpleQuestion : Question
    {
        private string _statement;
        private string _answer;

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

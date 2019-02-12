using System;
using System.Collections.Generic;

namespace CodeExecution
{
    [Serializable]
    public class AnswerChoiceQuestion : IQuestion
    {
        private readonly string _statement;
        private readonly List<string> _variants;
        private readonly int _answer;

        public AnswerChoiceQuestion(string statement, List<string> variants, int answer)
        {
            _statement = statement;
            _variants = variants;
            _answer = answer;
        }

        public string GetStatement()
        {
            return _statement;
        }

        public List<string> GetVariants()
        {
            return _variants;
        }

        public string GetAnswer()
        {
            return _variants[_answer];
        }
    }
}

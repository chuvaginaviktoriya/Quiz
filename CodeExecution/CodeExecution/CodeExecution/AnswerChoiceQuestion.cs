using System;
using System.Collections.Generic;

namespace CodeExecution
{
    [Serializable]
    public class AnswerChoiceQuestion : Question
    {
        private string _statement;
        private List<string> _variants;
        private int _answer;

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

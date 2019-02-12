using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace CodeExecution
{
    public static class QuastionCreation
    {
        public static bool TryCreateParameterQuestion(string code, string text, List<Limit> limits, out ParameterQuestion question, out CompilerErrorCollection errors)
        {
            var isCodeValid = CodeCreation.TryCreateCode(code, out var compieledCode, out errors);
            var isTextValid = StatementCreation.TryCreateStatement(text, limits, out var statement);

            if (isCodeValid && isTextValid)
            {
                question = new ParameterQuestion(compieledCode, statement);
                return true;
            }

            question = null;
            return false;
        }

        public static SimpleQuestion CreateSimpleQuestion(string text, string answer)
        { 
            var question = new SimpleQuestion(text, answer);
            return question;
        }

        public static AnswerChoiceQuestion CreateAnswerChoiceQuestion(string text, List<string> answers, int answer)
        {
            var question = new AnswerChoiceQuestion(text, answers, answer);
            return question;
        }
    }
}

using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace CodeExecution
{
    public static class QuastionCreation
    {
        public static bool TryCreateParameterQuestion(string code, string text, List<Limit> limits, out ParameterQuestion question, out CompilerErrorCollection errors)
        {
            if (!CodeCreation.TryCreateCode(code, out Code compieledCode, out errors))
            {
                question = null;
                return false;
            }

            if (!StatementCreation.TryCreateStatement(text, limits, out Statement statement))
            {
                question = null;
                return false;
            }

            question = new ParameterQuestion(compieledCode, statement);
            return true;
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

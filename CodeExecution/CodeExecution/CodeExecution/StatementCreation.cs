using System.Collections.Generic;

namespace CodeExecution
{
    public static class StatementCreation
    {
        public static bool TryCreateStatement(string text, List<Limit> questionLimits, out Statement statement)
        {
            var questionText = new List<string>();
            var textParts = text.Split('#');

            foreach (var part in textParts)
                questionText.Add(part);          

            var isValidCount = questionText.Count - questionLimits.Count < 2 && questionText.Count - questionLimits.Count > 0;

            if (!isValidCount)
            {
                statement = null;
                return false;
            }

            statement = new Statement(questionText, questionLimits);
            return true;
        }
    }
}

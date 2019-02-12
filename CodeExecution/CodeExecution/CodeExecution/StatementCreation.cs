using System.Collections.Generic;
using System.Linq;

namespace CodeExecution
{
    public static class StatementCreation
    {
        public static bool TryCreateStatement(string text, List<Limit> questionLimits, out Statement statement)
        {
            text = " " + text + " ";
            var textParts = text.Split('#');

            var questionText = textParts.ToList();

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

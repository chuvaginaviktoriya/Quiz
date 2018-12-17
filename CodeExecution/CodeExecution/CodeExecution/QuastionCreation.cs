namespace CodeExecution
{
    public static class QuastionCreation
    {
        public static bool TryCreateQuestion(string code, Limit[] limits, out Question question)
        {
            Code compieledCode;
            if (!CodeCreation.TryCreateCode(code, out compieledCode))
            {
                question = null;
                return false;
            }

            question = new Question(compieledCode, limits);
            return true;
        }
    }
}

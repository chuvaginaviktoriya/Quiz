using System;
using System.Collections.Generic;

namespace CodeExecution
{
    [Serializable]
    public class Topic
    {
        public string Title { get; private set; }
        public List<ParameterQuestion> ParameterQuestions { get; private set; }
        public List<SimpleQuestion> SimpleQuestions { get; private set; }
        public List<AnswerChoiceQuestion> AnswerChoiceQuestions { get; private set; }

        public Topic(string title)
        {
            Title = title;
            ParameterQuestions = new List<ParameterQuestion>();
            SimpleQuestions = new List<SimpleQuestion>();
            AnswerChoiceQuestions = new List<AnswerChoiceQuestion>();

        }

        public void AddParameterQuestion(ParameterQuestion question)
        {
            ParameterQuestions.Add(question);
        }

        public void AddSimpleQuestion(SimpleQuestion question)
        {
            SimpleQuestions.Add(question);
        }

        public void AddAnswerChoiceQuestion(AnswerChoiceQuestion question)
        {
            AnswerChoiceQuestions.Add(question);
        }
    }
}

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
            AnswerChoiceQuestions = new List<AnswerChoiceQuestion>();
            SimpleQuestions = new List<SimpleQuestion>();
        }

        public void AddParameterQuestion(ParameterQuestion question)
        {
            ParameterQuestions.Add(question);
        }

        public void AddAnswerChoiceQuestion(AnswerChoiceQuestion question)
        {
            AnswerChoiceQuestions.Add(question);
        }

        public void AddSimpleQuestion(SimpleQuestion question)
        {
            SimpleQuestions.Add(question);
        }

        public void RemoveAt(int index)
        {
            if (index < ParameterQuestions.Count)
            {
                ParameterQuestions.RemoveAt(index);
                return;
            }
            index = index - ParameterQuestions.Count;

            if (index < AnswerChoiceQuestions.Count)
            {
                AnswerChoiceQuestions.RemoveAt(index);
                return;
            }

            index = index - AnswerChoiceQuestions.Count;

            if (index < SimpleQuestions.Count)
            {
                SimpleQuestions.RemoveAt(index);
                return;
            }
        }
    }
}

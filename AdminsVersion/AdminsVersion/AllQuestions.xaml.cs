using System.Windows;
using CodeExecution;
using System.Collections.Generic;
using System;

namespace AdminsVersion
{

    public partial class AllQuestions : Window
    {
        public AllQuestions(List<Topic> topics)
        {
            InitializeComponent();

            foreach (var topic in topics)
            {
                foreach (var question in topic.ParameterQuestions)
                {
                    var result = "";
                    result += question.GetStatement() + Environment.NewLine;
                    result += question.GetAnswer();
                    Questions.Items.Add(result);
                }
                foreach (var question in topic.AnswerChoiceQuestions)
                {
                    var result = "";
                    result += question.GetStatement() + Environment.NewLine;
                    var variants = question.GetVariants();

                    foreach (var variant in variants)
                        result += variant + Environment.NewLine;

                    result += question.GetAnswer();
                    Questions.Items.Add(result);
                }
                foreach (var question in topic.SimpleQuestions)
                {
                    var result = "";
                    result += question.GetStatement() + Environment.NewLine;
                    result += question.GetAnswer();
                    Questions.Items.Add(result);
                }

            }
           

        }
    }
}

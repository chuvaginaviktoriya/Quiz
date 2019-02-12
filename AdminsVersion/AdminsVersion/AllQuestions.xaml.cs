using System.Windows;
using CodeExecution;
using System.Collections.Generic;
using System;
using System.Windows.Input;

namespace AdminsVersion
{
    public partial class AllQuestions : Window
    {
        private List<Topic> _topics;
        private int _currentTopic = -1;

        public AllQuestions(ref List<Topic> topics)
        {
            InitializeComponent();
            _topics = topics;

            foreach (var topic in topics)
                Topics.Items.Add(topic.Title);
        }

        private void ShowQuestions_Click(object sender, RoutedEventArgs e)
        {
            Questions.Items.Clear();

            if (Topics.SelectedIndex == -1) return;

            _currentTopic = Topics.SelectedIndex;
            var topic = _topics[_currentTopic];

            foreach (var question in topic.ParameterQuestions)
            {
                var result = "";
                result += question.GetStatement() + Environment.NewLine;
                result += "Ответ: " + question.GetAnswer();

                Questions.Items.Add(result);
            }

            foreach (var question in topic.AnswerChoiceQuestions)
            {
                var result = "";
                result += question.GetStatement() + Environment.NewLine;
                var variants = question.GetVariants();

                foreach (var variant in variants)
                    result += variant + Environment.NewLine;

                result += "Ответ: " + question.GetAnswer();

                Questions.Items.Add(result);
            }

            foreach (var question in topic.SimpleQuestions)
            {
                var result = "";
                result += question.GetStatement() + Environment.NewLine;
                result += "Ответ: " +  question.GetAnswer();

                Questions.Items.Add(result);
            } 
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Questions_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var index = Questions.SelectedIndex;

            if (e.Key == Key.Delete)
            {
                _topics[_currentTopic].RemoveAt(index);
                ShowQuestions_Click(sender, e);
            }
        }
    }
}

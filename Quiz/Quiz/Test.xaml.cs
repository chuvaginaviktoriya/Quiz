﻿using CodeExecution;
using System.Collections.Generic;
using System.Windows;


namespace Quiz
{
    public class CustomTopic
    {
        public List<Question> Questions{ get; private set; }

        public CustomTopic(Topic topic)
        {
            Questions = new List<Question>();

            foreach (var question in topic.ParameterQuestions)
                Questions.Add(question);

            foreach (var question in topic.AnswerChoiceQuestions)
                Questions.Add(question);

            foreach (var question in topic.SimpleQuestions)
                Questions.Add(question);

        }
    }

    public partial class Test : Window
    {
        private CustomTopic _topic;
        private int _currentIndex=-1;
        private Question _currentQuestion;
        private int _correctAnswers = 0;

        public float GetPercent()
        {
            return _correctAnswers* 100 / _topic.Questions.Count ;
        }

        public Test(Topic topic)
        {
            InitializeComponent();
            _topic = new CustomTopic(topic);

            ShowNextQuestion();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var correctAnswer = _currentQuestion.GetAnswer();
            string studentsAnswer;

            if (_currentQuestion is AnswerChoiceQuestion)
            {
                if (Variants.SelectedIndex == -1)
                {
                    MessageBox.Show("Не выбран ответ");
                    return;
                }
                studentsAnswer = Variants.Items[Variants.SelectedIndex].ToString();
            }

            else studentsAnswer = StudentsAnswer.Text;

            if (correctAnswer == studentsAnswer)
            {
                MessageBox.Show("Правильно");
                _correctAnswers++;
            }

            else MessageBox.Show("Неверно");

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            ClearFields();

            _currentIndex++;

            if (_topic.Questions.Count == _currentIndex)
            {
                DialogResult = true;
                return;
            }

            _currentQuestion = _topic.Questions[_currentIndex];

            QuestionStatement.Text = _currentQuestion.GetStatement();

            if (_currentQuestion is AnswerChoiceQuestion)
            {
                Variants.Visibility = Visibility.Visible;

                var answerChoice = _currentQuestion as AnswerChoiceQuestion;
                foreach (var answer in answerChoice.GetVariants())
                    Variants.Items.Add(answer);
            }
            else
                StudentsAnswer.Visibility = Visibility.Visible;

        }

        private void ClearFields()
        {
            QuestionStatement.Text = "";
            Variants.Items.Clear();
            StudentsAnswer.Text = "";

            StudentsAnswer.Visibility = Visibility.Hidden;
            Variants.Visibility = Visibility.Hidden;
        }
    }
}

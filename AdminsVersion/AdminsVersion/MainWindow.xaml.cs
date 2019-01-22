using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using CodeExecution;
using Microsoft.Win32;

namespace AdminsVersion
{
    public partial class MainWindow : Window
    {
        public List<Topic> Topics;

        public MainWindow()
        {
            InitializeComponent();
            Topics = BinarySaver.LoadFromBinnary();
        }

        private void AddTopic_Click(object sender, RoutedEventArgs e)
        {
            var newTopic = new TopicAddition();

            if (newTopic.ShowDialog() == true)
            {
                if (!Topics.Any(s => s.Title.Equals(newTopic.Topic)))
                {
                    Topics.Add(new Topic(newTopic.Topic));
                    MessageBox.Show("Тема добавлена");
                }
                else
                    MessageBox.Show("Такая тема существует");
            }    
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var newQuestion = new QuestionAddition(Topics);

            if (newQuestion.ShowDialog() == true)
            {
                var topic = newQuestion.GetTopic();
                var code = newQuestion.GetCode();
                var text = newQuestion.GetText();
                var limits = newQuestion.GetLimits();

                if (QuastionCreation.TryCreateParameterQuestion(code, text, limits, out var question, out var errors))
                {
                    Topics[topic].AddParameterQuestion(question);
                    MessageBox.Show("Вопрос добавлен");
                }
                else MessageBox.Show("Вопрос не добавлен");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allQuestions = new AllQuestions(ref Topics);

            allQuestions.ShowDialog();
                    
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BinarySaver.SaveToBinnary(Topics);
                MessageBox.Show("Сохранение выполнено");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void AddSimpleQuestion_Click(object sender, RoutedEventArgs e)
        {
            var newQuestion = new SimpleQuestionAddition(Topics);

            if (newQuestion.ShowDialog() == true)
            {
                var topic = newQuestion.GetTopic();
                var text = newQuestion.GetText();
                var answer = newQuestion.GetAnswer();

                var question = QuastionCreation.CreateSimpleQuestion(text, answer);
                Topics[topic].AddSimpleQuestion(question);
                MessageBox.Show("Вопрос добавлен");
            }
            else MessageBox.Show("Вопрос не добавлен");
        }

        private void AddAnswerChoiceQuestion_Click(object sender, RoutedEventArgs e)
        {
            var newQuestion = new AnswerChoiceQuestionAddition(Topics);
            if (newQuestion.ShowDialog() == true)
            {
                var topic = newQuestion.GetTopic();
                var text = newQuestion.GetText();
                var answers = newQuestion.GetAnswers();
                var answer = newQuestion.GetCorrectAnswer();

                var question = QuastionCreation.CreateAnswerChoiceQuestion(text, answers,answer);
                Topics[topic].AddAnswerChoiceQuestion(question);
                MessageBox.Show("Вопрос добавлен");
            }
            else MessageBox.Show("Вопрос не добавлен");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                var currentDir = Directory.GetCurrentDirectory();
                saveFileDialog.InitialDirectory = currentDir;
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.Copy(currentDir + "/questions", saveFileDialog.FileName,true);
                    MessageBox.Show("Сохранение выполнено");
                }
                else MessageBox.Show("Не выбран путь");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
          
        }
    }
}

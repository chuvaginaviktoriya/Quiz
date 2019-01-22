using CodeExecution;
using System.Collections.Generic;
using System.Windows;

namespace AdminsVersion
{
    public partial class AnswerChoiceQuestionAddition : Window
    {
        public AnswerChoiceQuestionAddition(List<Topic> topics)
        {
            InitializeComponent();

            foreach (var topic in topics)
                Topics.Items.Add(topic.Title);
        }

        private void AddAnswer_Click(object sender, RoutedEventArgs e)
        {
            Answers.Items.Add(Answer.Text);
            Answer.Text = "";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Topics.SelectedIndex == -1)
                MessageBox.Show("Не выбрана тема");
            else if (Answers.SelectedIndex == -1)
                MessageBox.Show("Не выбран правильный ответ");
            else DialogResult = true;
        }

        public int GetTopic()
        {
            return Topics.SelectedIndex;
        }

        public string GetText()
        {
            return Text.Text;
        }

        public int GetCorrectAnswer()
        {
            return Answers.SelectedIndex;
        }

        public List<string> GetAnswers()
        {
            var answers = new List<string>();

            foreach (var answer in Answers.Items)
                answers.Add(answer.ToString());

            return answers;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

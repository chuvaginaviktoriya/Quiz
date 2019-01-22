using System.Windows;
using CodeExecution;
using System.Collections.Generic;

namespace AdminsVersion
{
    public partial class SimpleQuestionAddition : Window
    {
        public SimpleQuestionAddition(List<Topic> topics)
        {
            InitializeComponent();
            foreach (var topic in topics)
                Topics.Items.Add(topic.Title);
        }

        public int GetTopic()
        {
            return Topics.SelectedIndex;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Topics.SelectedIndex==-1)
                MessageBox.Show("Не выбрана тема");
            else DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string GetText()
        {
            return Text.Text;
        }


        public string GetAnswer()
        {
            return Answer.Text;
        }
    }
}

using System.Collections.Generic;
using System.Windows;
using CodeExecution;

namespace Quiz
{
    public partial class MainWindow : Window
    {
        private List<Topic> _topics;

        public MainWindow()
        {
            InitializeComponent();
            
            _topics = BinarySaver.LoadFromBinnary();

            foreach (var topic in _topics)
                Topics.Items.Add(topic.Title);

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Topics.SelectedIndex == -1)
                MessageBox.Show("Выберите тему");
            else if (Student.Text == "")
                MessageBox.Show("Введите фамилию");
            else
            {
                var test = new Test(_topics[Topics.SelectedIndex]);
                if (test.ShowDialog() == true)
                    MessageBox.Show("Ваш результат: " + test.GetPercent() + "%");
            }
        }
    }
}

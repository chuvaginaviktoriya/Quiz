using System;
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
            {
                var message = new Message("Выберите тему");
                message.ShowDialog();
            }
            else if (Student.Text == "")
            {
                var message = new Message("Введите фамилию");
                message.ShowDialog();
            }
            else
            {
                try
                {
                    var test = new Test(_topics[Topics.SelectedIndex]);
                    if (test.ShowDialog() == true)
                    {
                        var message = new Message("Ваш результат: " + test.GetPercent() + " % ");
                        message.ShowDialog();
                    }
                }
                catch (InvalidOperationException)
                {
                    var message = new Message("Вопросов по выбранной теме не найдено");
                    message.ShowDialog();
                }              
            }
        }
    }
}

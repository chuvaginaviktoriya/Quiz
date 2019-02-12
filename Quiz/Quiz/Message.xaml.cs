using System.Windows;


namespace Quiz
{
    public partial class Message : Window
    {
        public Message(string message)
        {
            InitializeComponent();

            Text.Text = message;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

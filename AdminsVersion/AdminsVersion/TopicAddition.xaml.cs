using System.Windows;


namespace AdminsVersion
{
    public partial class TopicAddition : Window
    {
        public TopicAddition()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string Topic
        {
            get { return topic.Text; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

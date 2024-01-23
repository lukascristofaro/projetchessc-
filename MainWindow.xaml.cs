using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void CreateRoom_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine("Create Room");
        }

        private void JoinRoom_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine("Join Room");
        }
    }
}
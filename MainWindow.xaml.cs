using System.Windows;

namespace chess
{
    public partial class MainViewModel : Window
    {
        public MainViewModel()
        {
            InitializeComponent();
        }

        private void CreateRoom_Click(object sender, RoutedEventArgs e)
        {
            // Charger la nouvelle page (GameView)
            contentFrame.Content = new Views.GameView();

            // Masquer les boutons
            buttonsGrid.Visibility = Visibility.Collapsed;
        }

        private void JoinRoom_Click(object sender, RoutedEventArgs e)
        {
            // Charger la nouvelle page (GameView)
            contentFrame.Content = new Views.GameView();

            // Masquer les boutons
            buttonsGrid.Visibility = Visibility.Collapsed;
        }
    }
}
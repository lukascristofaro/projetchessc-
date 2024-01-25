<<<<<<< HEAD
﻿using System.Text;
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
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Label label = (Label)this.FindName("placeholderLabel");
            if (label != null)
            {
                label.Visibility = Visibility.Collapsed;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Label label = (Label)this.FindName("placeholderLabel");

            if (textBox != null && label != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    label.Visibility = Visibility.Visible;
                }
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_JoinRoom_Click(object sender, RoutedEventArgs e)
        {

        }
    }
=======
﻿using System.Windows;

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
>>>>>>> e4642a86aedb02d04b494d84945ea61e9c80a923
}
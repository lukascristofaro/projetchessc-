using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chess.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour createRoomView.xaml
    /// </summary>
    public partial class createRoomView
    {
        public createRoomView()
        {
            InitializeComponent();
        }

        public void CreateRoom_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine("createRoom");
        }

        public void JoinRoom_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine("joinRoom");
        }
    }
}

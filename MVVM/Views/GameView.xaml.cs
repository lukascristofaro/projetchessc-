using System.Windows.Controls;
using chess.ViewModel;

namespace chess.Views
{
    public partial class GameView : UserControl
    {

        public GameView()
        {
            InitializeComponent();
            GameViewModel.CreateChessboard(ChessGrid);
        }
    }
}

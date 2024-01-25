using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace chess.Views
{
    public partial class GameView : UserControl
    {
        private string[,] chessPieces = new string[8, 8]
        {
            {"[2,1]", "[3,1]", "[4,1]", "[5,1]", "[6,1]", "[4,1]", "[3,1]", "[2,1]"},
            {"[1,1]", "[1,1]", "[1,1]", "[1,1]", "[1,1]", "[1,1]", "[1,1]", "[1,1]"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"[7,2]", "[7,2]", "[7,2]", "[7,2]", "[7,2]", "[7,2]", "[7,2]", "[7,2]"},
            {"[8,2]", "[9,2]", "[10,2]", "[11,2]", "[12,2]", "[10,2]", "[9,2]", "[8,2]"}
        };

        public GameView()
        {
            InitializeComponent();
            CreateChessboard();
        }

        private void CreateChessboard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Border border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Width = 50,
                        Height = 50
                    };

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                    ChessGrid.Children.Add(border);

                    if ((row + col) % 2 == 0)
                    {
                        border.Background = Brushes.Brown;
                    }
                    else
                    {
                        border.Background = Brushes.Beige;
                    }

                    string pieceCode = chessPieces[row, col];
                    Image chessPieceImage = new Image();

                    if (pieceCode != "0")
                    {
                        string imagePath = GetImagePath(pieceCode);
                        chessPieceImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    }

                    border.Child = chessPieceImage;
                }
            }
        }

        private string GetImagePath(string pieceCode)
        {
            switch (pieceCode)
            {
                case "[1,1]": return "/assets/white_pawn.png";
                case "[2,1]": return "/assets/white_rook.png";
                case "[3,1]": return "/assets/white_knight.png";
                case "[4,1]": return "/assets/white_bishop.png";
                case "[5,1]": return "/assets/white_queen.png";
                case "[6,1]": return "/assets/white_king.png";
                case "[7,2]": return "/assets/black_pawn.png";
                case "[8,2]": return "/assets/black_rook.png";
                case "[9,2]": return "/assets/black_knight.png";
                case "[10,2]": return "/assets/black_bishop.png";
                case "[11,2]": return "/assets/black_queen.png";
                case "[12,2]": return "/assets/black_king.png";
                default: return "";
            }
        }
    }
}

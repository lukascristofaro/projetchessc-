using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using chess.ViewModel;
using System.IO;
using System;
using chess.Views;

namespace chess.ViewModel
{
    static public class GameViewModel
    {
        static private string[,] chessPieces = new string[8, 8]
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

        static private Border selectedBorder = null;

        static public Grid ChessGrid { get; private set; }

        static public void CreateChessboard(Grid chessGrid)
        {
            ChessGrid = chessGrid;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Border border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Width = 50,
                        Height = 50,
                        Background = (row + col) % 2 == 0 ? Brushes.Brown : Brushes.Beige
                    };

                    Image chessPieceImage = new Image();

                    string pieceCode = chessPieces[row, col];

                    string imagePath = GetImagePath(pieceCode);
                    
                    chessPieceImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    border.Child = chessPieceImage;

                    // Ajoute la gestion des clics sur les pièces
                    border.MouseDown += ChessPiece_Click;

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                    ChessGrid.Children.Add(border);
                }
            }
        }

        static private void ChessPiece_Click(object sender, RoutedEventArgs e)
        {
            Border clickedBorder = (Border)sender;
            int row = Grid.GetRow(clickedBorder);
            int col = Grid.GetColumn(clickedBorder);

            ChessGameSaver.SaveChessPieces(chessPieces);
            RefreshChessboard();

            if (selectedBorder != null)
            {
                MovePieces.DeplaceChessPiece(chessPieces, Grid.GetRow(selectedBorder), Grid.GetColumn(selectedBorder), row, col);
                RefreshChessboard();
            }

            if (chessPieces[row, col] != "0")
            {
                if (selectedBorder == clickedBorder)
                {
                    // Désélectionne la case jaune si elle est déjà sélectionnée
                    selectedBorder.Background = (row + col) % 2 == 0 ? Brushes.Brown : Brushes.Beige;
                    selectedBorder = null;
                    
                    RemoveGreenBackground();
                }
                else
                {
                    if (selectedBorder != null)
                    {
                        // Désélectionne la case jaune précédemment sélectionnée
                        selectedBorder.Background = (Grid.GetRow(selectedBorder) + Grid.GetColumn(selectedBorder)) % 2 == 0 ? Brushes.Brown : Brushes.Beige;
                        
                        RemoveGreenBackground();
                    }

                    // Sélectionne la nouvelle case jaune
                    selectedBorder = clickedBorder;
                    selectedBorder.Background = Brushes.Yellow;

                    // Affiche les déplacements possibles
                    ChessValidMoves.ValidMoves(row, col, ChessGrid);
                }
            }
        }

        static private void RemoveGreenBackground()
        {
            foreach (UIElement element in ChessGrid.Children)
            {
                if (element is Border border && border.Background == Brushes.Green)
                {
                    border.Background = (Grid.GetRow(border) + Grid.GetColumn(border)) % 2 == 0 ? Brushes.Brown : Brushes.Beige;
                }
            }
        }

        static public string GetImagePath(string pieceCode)
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

        public static void RefreshChessboard()
        {
            // Efface le contenu actuel du plateau
            ChessGrid.Children.Clear();

            // Recrée le plateau avec les pièces à jour
            CreateChessboard(ChessGrid);
        }
    }
}

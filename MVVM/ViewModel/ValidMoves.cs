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
    public class ChessValidMoves : UserControl
    {

        static public Grid ChessGrid { get; private set; }
        static public string[,] chessPieces = new string[8, 8];

        public static void ValidMoves(int row, int col, Grid chessGrid) {

            ChessGrid = chessGrid;
            chessPieces = ChessGameSaver.LoadChessPieces();

            if (chessPieces[row, col] == "[1,1]" || chessPieces[row, col] == "[7,2]")
            {
                PawnValidMove(row, col);                        
            }
            else if (chessPieces[row, col] == "[3,1]" || chessPieces[row, col] == "[9,2]")
            {
                KnightValidMove(row, col);
            }
            else if (chessPieces[row, col] == "[4,1]" || chessPieces[row, col] == "[10,2]")
            {
                BishopValidMove(row, col);
            }
            else if (chessPieces[row, col] == "[2,1]" || chessPieces[row, col] == "[8,2]")
            {
                RookValidMove(row, col);
            }
            else if (chessPieces[row, col] == "[5,1]" || chessPieces[row, col] == "[11,2]")
            {
                QueenValidMove(row, col);
            }
            else if (chessPieces[row, col] == "[6,1]" || chessPieces[row, col] == "[12,2]")
            {
                KingValidMove(row, col);
            }
        }

        static private void PawnValidMove(int row, int col)
        {
            int direction = (chessPieces[row, col] == "[1,1]") ? 1 : -1; // Détermine la direction du mouvement

            // Déplacement d'un pion
            if (IsValidMove(row + direction, col))
                AddGreenBackground(row + direction, col);

            if (row == 1 || row == 6) // Si le pion est sur sa position initiale
            {
                if (IsValidMove(row + 2 * direction, col)) {
                    AddGreenBackground(row + 2 * direction, col);
                }
            }
        }

        static private void KnightValidMove(int row, int col)
        {
            // Déplacement d'un cavalier
            int[,] knightValidMoves = { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { -1, 2 }, { 1, -2 }, { -1, -2 } };

            foreach (int moveIndex in Enumerable.Range(0, knightValidMoves.GetLength(0)))
            {
                int newRow = row + knightValidMoves[moveIndex, 0];
                int newCol = col + knightValidMoves[moveIndex, 1];

                if (IsValidMove(newRow, newCol)) 
                    AddGreenBackground(newRow, newCol);
            }
        }

        static private void BishopValidMove(int row, int col)
        {
            // Déplacement d'un fou
            for (int i = 1; i < 8; i++)
            {
                if (IsValidMove(row + i, col + i))
                    AddGreenBackground(row + i, col + i);
                else
                    break;

                if (IsValidMove(row + i, col - i))
                    AddGreenBackground(row + i, col - i);
                else
                    break;

                if (IsValidMove(row - i, col + i))
                    AddGreenBackground(row - i, col + i);
                else
                    break;

                if (IsValidMove(row - i, col - i))
                    AddGreenBackground(row - i, col - i);
                else
                    break;
            }
        }

        static private void RookValidMove(int row, int col)
        {
            // Déplacement d'une tour
            for (int i = 1; i < 8; i++)
            {
                if (IsValidMove(row + i, col))
                    AddGreenBackground(row + i, col);
                else
                    break;

                if (IsValidMove(row - i, col))
                    AddGreenBackground(row - i, col);
                else
                    break;

                if (IsValidMove(row, col + i))
                    AddGreenBackground(row, col + i);
                else
                    break;

                if (IsValidMove(row, col - i))
                    AddGreenBackground(row, col - i);
                else
                    break;
            }
        }

        static private bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8 && chessPieces[row, col] == "0";
        }

        static private void QueenValidMove(int row, int col)
        {
            RookValidMove(row, col);
            BishopValidMove(row, col);
        }

        static private void KingValidMove(int row, int col)
        {
            // Déplacement d'un roi
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (IsValidMove(row + i, col + j)) {
                        AddGreenBackground(row + i, col + j);
                    }
                }
            }
        }

        static private void AddGreenBackground(int row, int col)
{
    if (row >= 0 && row < 8 && col >= 0 && col < 8)
    {
        // Filter out non-Border elements before casting
        var border = ChessGrid.Children
            .OfType<Border>()
            .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

        if (border != null)
        {
            border.Background = Brushes.Green;
        }
    }
}

    }
}

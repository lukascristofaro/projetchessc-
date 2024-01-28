using System;
using System.IO;
using System.Windows.Controls;
using chess.ViewModel;

namespace chess.ViewModel
{
    public class MovePieces : UserControl
    {
        public static void DeplaceChessPiece(string[,] chessPieces, int fromRow, int fromCol, int toRow, int toCol)
        {
            string piece = chessPieces[fromRow, fromCol];
            chessPieces[fromRow, fromCol] = "0";
            chessPieces[toRow, toCol] = piece;

            ChessGameSaver.SaveChessPieces(chessPieces);
        }
    }
}

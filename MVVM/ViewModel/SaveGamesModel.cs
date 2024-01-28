using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Controls;

namespace chess.ViewModel
{
    public class ChessGameSaver : UserControl
    {
        public static void SaveChessPieces(string[,] chessPieces)
        {
            // Convert the array to JSON
            string jsonContent = JsonConvert.SerializeObject(chessPieces, Formatting.Indented);

            // Save the JSON to a file
            File.WriteAllText("ChessPieces.json", jsonContent);
        }

        public static string[,] LoadChessPieces()
        {
            // Load the JSON from a file
            string jsonContent = File.ReadAllText("ChessPieces.json");

            // Convert the JSON to an array
            string[,] chessPieces = JsonConvert.DeserializeObject<string[,]>(jsonContent);

            return chessPieces;
        }
    }
}

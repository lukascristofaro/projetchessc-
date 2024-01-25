using System.ComponentModel;
using Newtonsoft.Json;


namespace chess.Models
{
    public class createGame

    {
        private string[,] chessPieces = new string[8, 8]
        {
            {"2,1", "3,1", "4,1", "5,1", "6,1", "4,1", "3,1", "2,1"},
            {"1,1", "1,1", "1,1", "1,1", "1,1", "1,1", "1,1", "1,1"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "0", "0", "0", "0", "0"},
            {"7,2", "7,2", "7,2", "7,2", "7,2", "7,2", "7,2", "7,2"},
            {"8,2", "9,2", "10,2", "11,2", "12,2", "10,2", "9,2", "8,2"}
        };

        public string[,] ChessPieces
        {
            get { return chessPieces; }
            set { chessPieces = value; }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }




        

}

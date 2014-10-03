using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Game
{
    public class Move
    {
        public int row { get; set; }
        public int column { get; set; }
        public string symbol { get; set; }

        public Move(int row, int column, string symbol)
        {
            this.row = row;
            this.column = column;
            this.symbol = symbol;
        }

    }
}

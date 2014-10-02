using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Pages
{
    class Game
    {
        enum Result { WIN, LOST, DRAW };

        private string UserSymbol;
        private string ComputerSymbol;
        private string[,] board;

        public Game(string symbol)
        {
            // TODO: Complete member initialization
            this.UserSymbol = symbol;
            this.ComputerSymbol = makeComputerSymbol(symbol);
            this.board = new string[3, 3];
        }

        private string makeComputerSymbol(string symbol)
        {
            if (symbol.Equals('X')) return "O";
            return "X";

        }

        public Boolean addElement(int row, int column, string element)
        {
            if (board[row, column] == null)
            {
                board[row, column] = element;
                return true;
            }
            return false;
        }

        public Boolean isFinished()
        {
            foreach (string i in board)
            {
                System.Console.Write(i);
            }
            return false;

        }
    }
}

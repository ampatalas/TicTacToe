using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Pages
{
    class Game
    {
        public enum Result { WIN, LOST, DRAW, PLAY };

        private string UserSymbol;
        string ComputerSymbol { get; set; }
        private string[,] board;

        public Game(string symbol)
        {
            // TODO: Complete member initialization
            this.UserSymbol = symbol;
            this.ComputerSymbol = makeComputerSymbol(symbol);
            this.board = new string[3, 3] { {"", "", ""}, {"", "", ""}, {"", "", ""} };
        }

        private string makeComputerSymbol(string symbol)
        {
            if (symbol.Equals("X")) return "O";
            return "X";

        }

        public Boolean addElement(int row, int column, string element)
        {
            if (board[row, column].Equals(""))
            {
                board[row, column] = element;
                return true;
            }
            return false;
        }

        public Result getResult()
        {
            if(Winner().Equals("none")){
                if(isDraw()) return Result.DRAW;
                else return Result.PLAY;
            }
            else
            {
                if (Winner().Equals(UserSymbol)) return Result.WIN;
                else return Result.LOST;
            }
        }

        public Move computerMove()
        {
            Boolean set = false;
            Random rnd = new Random();
            int row = -1;
            int column = -1;
            while (!set)
            {
                row = rnd.Next(3);
                column = rnd.Next(3);
                System.Diagnostics.Debug.WriteLine(row + " " + column);
                set = addElement(row, column, ComputerSymbol);
            }
            return new Move(row, column, ComputerSymbol);
        }

        private string Winner()
        {
            //through
            if (board[0, 0].Equals(board[1, 1]) && board[0, 0].Equals(board[2, 2]) && !board[0,0].Equals("")) return board[0, 0];
            //rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0].Equals(board[i, 1]) && board[i, 0].Equals(board[i, 2]) && !board[i, 0].Equals("")) return board[i, 0];
            }
            //columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i].Equals(board[1, i]) && board[0, i].Equals(board[2, i]) && !board[0, i].Equals("")) return board[0, i];
            }
            return "none";
        }

        private Boolean isDraw()
        {
            foreach(string input in board){
                if (input.Equals("")) return false;
            }
            return true;
        }
    }
}

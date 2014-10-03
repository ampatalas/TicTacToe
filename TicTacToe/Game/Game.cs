using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Game
{
    public class Game
    {
        public enum Result { WIN, LOST, DRAW, PLAY };

        private string UserSymbol;
        string ComputerSymbol { get; set; }
        private string[,] board;

        public Game(string playerSymbol)
        {
            this.UserSymbol = playerSymbol;
            this.ComputerSymbol = makeComputerSymbol(playerSymbol);
            this.board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
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

        public Move computerSmartMove()
        {
            Move moveMade = null;
            Random rnd = new Random();

            int row = -1;
            int column = -1;

            moveMade = makeWinningMove();
            if (moveMade == null) moveMade = makeStoppingMove();
            if (moveMade == null)
            {
                while (moveMade == null)
                {
                    row = rnd.Next(3);
                    column = rnd.Next(3);
                    bool success = addElement(row, column, ComputerSymbol);
                    if (success) moveMade = new Move(row, column, ComputerSymbol);
                }
            }
            addElement(moveMade.row, moveMade.column, ComputerSymbol);
            return moveMade;
        }

        private Move makeStoppingMove()
        {
            return fillingRowMove(UserSymbol);
        }

        private Move makeWinningMove()
        {
            return fillingRowMove(ComputerSymbol);
        }

        private Move fillingRowMove(string fillingSymbol)
        {
            //through
            if (board[1, 1].Equals(fillingSymbol) && board[2, 2].Equals(fillingSymbol) && board[0, 0].Equals("")) return new Move(0, 0, ComputerSymbol);
            if (board[0, 0].Equals(fillingSymbol) && board[2, 2].Equals(fillingSymbol) && board[1, 1].Equals("")) return new Move(1, 1, ComputerSymbol);
            if (board[0, 0].Equals(fillingSymbol) && board[1, 1].Equals(fillingSymbol) && board[2, 2].Equals("")) return new Move(2, 2, ComputerSymbol);

            if (board[0, 2].Equals(fillingSymbol) && board[1, 1].Equals(fillingSymbol) && board[2, 0].Equals("")) return new Move(2, 0, ComputerSymbol);
            if (board[0, 2].Equals(fillingSymbol) && board[2, 0].Equals(fillingSymbol) && board[1, 1].Equals("")) return new Move(1, 1, ComputerSymbol);
            if (board[2, 0].Equals(fillingSymbol) && board[1, 1].Equals(fillingSymbol) && board[0, 2].Equals("")) return new Move(0, 2, ComputerSymbol);

            //rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 1].Equals(fillingSymbol) && board[i, 2].Equals(fillingSymbol) && board[i, 0].Equals("")) return new Move(i, 0, ComputerSymbol);
                if (board[i, 0].Equals(fillingSymbol) && board[i, 2].Equals(fillingSymbol) && board[i, 1].Equals("")) return new Move(i, 1, ComputerSymbol);
                if (board[i, 1].Equals(fillingSymbol) && board[i, 0].Equals(fillingSymbol) && board[i, 2].Equals("")) return new Move(i, 2, ComputerSymbol);
            }
            //columns
            for (int i = 0; i < 3; i++)
            {
                if (board[1, i].Equals(fillingSymbol) && board[2, i].Equals(fillingSymbol) && board[0, i].Equals("")) return new Move(0, i, ComputerSymbol);
                if (board[0, i].Equals(fillingSymbol) && board[2, i].Equals(fillingSymbol) && board[1, i].Equals("")) return new Move(1, i, ComputerSymbol);
                if (board[1, i].Equals(fillingSymbol) && board[0, i].Equals(fillingSymbol) && board[2, i].Equals("")) return new Move(2, i, ComputerSymbol);
            }
            return null;
        }

        private string Winner()
        {
            //through
            if (board[0, 0].Equals(board[1, 1]) && board[0, 0].Equals(board[2, 2]) && !board[0,0].Equals("")) return board[0, 0];
            if (board[0, 2].Equals(board[1, 1]) && board[0, 2].Equals(board[2, 0]) && !board[0, 2].Equals("")) return board[0, 2];
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

        internal void CleanBoard()
        {
            board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Game;
using System.Diagnostics;

namespace TicTacToeTest
{
    [TestClass]
    public class GameTest
    {
        //WINNING

        [TestMethod]
        public void MakesWinningMoveThroughOnLastPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(1, 1, "X");
            
            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 2);
            Assert.AreEqual(computerMove.row, 2);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveThroughOnFirstPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(1, 1, "X");
            game.addElement(2, 2, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveThrough2OnLastPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(2, 0, "X");
            game.addElement(1, 1, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 2);
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveThrough2OnMiddlePosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 2, "X");
            game.addElement(2, 0, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 1);
            Assert.AreEqual(computerMove.row, 1);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveThroughOnMiddlePosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(2, 2, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 1);
            Assert.AreEqual(computerMove.row, 1);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveInAColumnBottom()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(0, 1, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.column, 2);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveInAColumnMiddle()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(0, 2, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.column, 1);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveInALastRow()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(1, 0, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 2);
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void MakesWinningMoveInAMiddleRow()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(2, 0, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 1);
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        // BLOCKING

        [TestMethod]
        public void BlocksPlayerThroughOnLastPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(1, 1, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 2);
            Assert.AreEqual(computerMove.row, 2);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerThroughOnFirstPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(1, 1, "O");
            game.addElement(2, 2, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerThroughOnMiddlePosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(2, 2, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.column, 1);
            Assert.AreEqual(computerMove.row, 1);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerInAColumnBottom()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(0, 1, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.column, 2);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerInAColumnMiddle()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(0, 2, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 0);
            Assert.AreEqual(computerMove.column, 1);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerInALastRow()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(1, 0, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 2);
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        [TestMethod]
        public void BlocksPlayerInAMiddleRow()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(2, 0, "O");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.AreEqual(computerMove.row, 1);
            Assert.AreEqual(computerMove.column, 0);
            Assert.AreEqual(computerMove.symbol, "X");
        }

        // MAKES ANY MOVE
        [TestMethod]
        public void MakesAnyMove()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(2, 0, "X");

            //when
            Move computerMove = game.computerSmartMove();

            //then
            Assert.IsNotNull(computerMove);
        }

        [TestMethod]
        public void DoNotAddOnTakenPosition()
        {
            //given
            string playerSymbol = "O";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            

            //when
            bool added = game.addElement(0, 0, "X");

            //then
            Assert.IsFalse(added);
        }

        // RESULTS
        [TestMethod]
        public void ShouldAnnounceWinning()
        {
            //given
            string playerSymbol = "X";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "X");
            game.addElement(0, 1, "X");
            game.addElement(0, 2, "X");

            //when
            Game.Result result = game.getResult();

            //then
            Assert.AreEqual(result, Game.Result.WIN);
        }

        [TestMethod]
        public void ShouldAnnounceLosing()
        {
            //given
            string playerSymbol = "X";
            Game game = new Game(playerSymbol);
            game.addElement(0, 0, "O");
            game.addElement(0, 1, "O");
            game.addElement(0, 2, "O");

            //when
            Game.Result result = game.getResult();

            //then
            Assert.AreEqual(result, Game.Result.LOST);
        }

        [TestMethod]
        public void ShouldAnnounceDraw()
        {
            //given
            string playerSymbol = "X";
            Game game = new Game(playerSymbol);

            //first row
            game.addElement(0, 0, "O");
            game.addElement(0, 1, "X");
            game.addElement(0, 2, "O");
            //second row
            game.addElement(1, 0, "O");
            game.addElement(1, 1, "O");
            game.addElement(1, 2, "X");
            //thrid row
            game.addElement(2, 0, "X");
            game.addElement(2, 1, "O");
            game.addElement(2, 2, "X");


            //when
            Game.Result result = game.getResult();

            //then
            Assert.AreEqual(result, Game.Result.DRAW);
        }

        [TestMethod]
        public void ShouldAnnouncePlay()
        {
            //given
            string playerSymbol = "X";
            Game game = new Game(playerSymbol);

            //first row
            game.addElement(0, 0, "O");
            game.addElement(0, 1, "X");
            game.addElement(0, 2, "O");
            //second row
            game.addElement(1, 0, "O");
            game.addElement(1, 1, "O");
            game.addElement(1, 2, "X");
            //thrid row
            game.addElement(2, 0, "X");
            game.addElement(2, 1, "O");


            //when
            Game.Result result = game.getResult();

            //then
            Assert.AreEqual(result, Game.Result.PLAY);
        }

    }
}

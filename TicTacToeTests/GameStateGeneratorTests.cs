using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.Model;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameStateGeneratorTests
    {
        [Test]
        public void GenerateBoard_setzt_Zellenwerte_richtig()
        {
            var moveList = new List<Move>();
            moveList.Add(new Move(1, 1, CellState.X));
            moveList.Add(new Move(0, 1, CellState.O));

            var board = GameStateGenerator.GenerateBoard(moveList);

            Assert.AreEqual(CellState.X, board.Single(c => c.X == 1 && c.Y == 1).CellState);
            Assert.AreEqual(CellState.O, board.Single(c => c.X == 0 && c.Y == 1).CellState);

            var numberOfUnselectedCells = board.Count(c => c.CellState == CellState.none);

            Assert.That(7, Is.EqualTo(numberOfUnselectedCells));
        }

        [Test]
        [TestCase(0, ExpectedResult = Status.TurnX)]
        [TestCase(2, ExpectedResult = Status.TurnX)]
        [TestCase(3, ExpectedResult = Status.TurnO)]
        [TestCase(4, ExpectedResult = Status.TurnX)]
        [TestCase(99, ExpectedResult = Status.TurnO)]
        public Status DetermineNextPlayer_setzt_nächsten_Spieler_richtig(int moveCount)
        {
            var moveList = new Move[moveCount].ToList();

            var nextPlayerStatus = GameLogic.DetermineNextPlayer(moveList);

            return nextPlayerStatus;
        }
    }
}
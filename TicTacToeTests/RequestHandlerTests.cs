using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class RequestHandlerTests
    {
        [Test]
        public void GenerateGameState_setzt_Zellenwerte_richtig()
        {
            var turnList = new List<(int x, int y)>();
            turnList.Add((1, 1));
            turnList.Add((0, 1));

            var sut = new RequestHandler(turnList);
            var gameState = sut.GenerateGameState();

            Assert.AreEqual(CellState.X, gameState.Board.Single(c => c.X == 1 && c.Y == 1).CellState);
            Assert.AreEqual(CellState.O, gameState.Board.Single(c => c.X == 0 && c.Y == 1).CellState);

            var numberOfUnselectedCells = gameState.Board.Count(c => c.CellState == CellState.none);

            Assert.That(7, Is.EqualTo(numberOfUnselectedCells));
        }


        //public Status GenerateGameState_setzt_nächsten_Spieler_richtig(List<(int x, int y)> turnList)
        [Test]
        public void GenerateGameState_setzt_nächsten_Spieler_richtig()
        {
            var turnList = new List<(int x, int y)>();
            turnList.Add((1, 1));
            turnList.Add((0, 1));
            
            var sut = new RequestHandler(turnList);
            var gameState = sut.GenerateGameState();

            Assert.That(gameState.Status, Is.EqualTo(Status.TurnX));

            turnList.Add((0, 0));
            sut = new RequestHandler(turnList);

            gameState = sut.GenerateGameState();

            Assert.That(gameState.Status, Is.EqualTo(Status.TurnO));
        }
    }
}

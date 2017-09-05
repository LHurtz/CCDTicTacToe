using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class RequestHandler
    {
        private List<(int x, int y)> turnList = new List<(int, int)>();

        public RequestHandler() : this(new List<(int, int)>())
        {
        }

        internal RequestHandler(List<(int x, int y)> turnList)
        {
            this.turnList = turnList;
        }

        public GameState StartProgram()
        {
            var gameState = StartNewGame();
            return gameState;
        }

        public GameState StartNewGame()
        {
            turnList.Clear();
            var gameState = GenerateGameState();
            return gameState;
        }

        public GameState PlayTurn((int x, int y) coordinates)
        {
            RegisterTurn(coordinates);
            var nextGameState = GenerateGameState();

            return nextGameState;
        }

        private void RegisterTurn((int x, int y) coordinates)
        {
            turnList.Add((coordinates.x, coordinates.y));
        }

        internal GameState GenerateGameState()
        {
            var initGameState = GameState.Init();
            var cells = initGameState.Board;

            foreach (var turn in turnList)
            {
                var cellStateToSet = GetCellStateToSet(turn);

                cells.Single(c => c.X == turn.x && c.Y == turn.y).CellState = cellStateToSet;
            }

            var nextPlayer = GetNextPlayer(turnList.Count());

            return new GameState(cells, nextPlayer);
        }

        private CellState GetCellStateToSet(ValueTuple<int, int> turn)
        {
            var cellStateToSet = CellState.none;

            var index = turnList.IndexOf(turn);
            var mod = index % 2;

            if (mod == 0)
            {
                cellStateToSet = CellState.X;
            }
            else if (mod == 1)
            {
                cellStateToSet = CellState.O;
            }
            return cellStateToSet;
        }

        private Status GetNextPlayer(int count)
        {
            var status = Status.TurnX;

            var mod = count % 2;

            if (mod == 0)
            {
                status = Status.TurnX;
            }
            else if (mod == 1)
            {
                status = Status.TurnO;
            }
            return status;
        }
    }
}

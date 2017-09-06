using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Model;

namespace TicTacToe
{
    public class RequestHandler
    {
        internal static GameState StartProgram()
        {
            var gameState = StartNewGame();
            return gameState;
        }

        internal static GameState StartNewGame()
        {
            GameLogic.ClearList();
            MoveLog.StartNewLog();

            var moveList = GameLogic.MoveList;
            var gameState = GenerateGameState(moveList);
            return gameState;
        }

        internal static GameState PlayTurn((int x, int y) coordinates)
        {
            GameLogic.RegisterMove(coordinates);
            MoveLog.WriteMove(coordinates);

            var moveList = GameLogic.MoveList;
            var nextGameState = GenerateGameState(moveList);

            return nextGameState;
        }

        internal static GameState GenerateGameState(List<Move> moveList)
        {
            var cells = GameStateGenerator.GenerateBoard(moveList);
            var nextStatus = GameLogic.DetermineNextStatus(moveList);

            return new GameState(cells, nextStatus);
        }

        internal static Status DetermineNextPlayer(int count)
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

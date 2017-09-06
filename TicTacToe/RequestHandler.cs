using System;
using System.Collections.Generic;
using System.Linq;

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
            var moveList = GameLogic.MoveList;
            var gameState = GenerateGameState(moveList);
            return gameState;
        }

        internal static GameState PlayTurn((int x, int y) coordinates)
        {
            GameLogic.RegisterTurn(coordinates);
            MoveLog.WriteMove(coordinates);

            var moveList = GameLogic.MoveList;
            var nextGameState = GenerateGameState(moveList);

            return nextGameState;
        }

        internal static GameState GenerateGameState(List<(int x, int y)> moveList)
        {
            var cells = GameStateGenerator.GenerateBoard(moveList);
            var nextPlayer = GameStateGenerator.DetermineNextPlayer(moveList.Count);

            return new GameState(cells, nextPlayer);
        }

        


        
    }
}

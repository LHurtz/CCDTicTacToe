using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Model;
using TicTacToe.Providers;

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

        internal static (GameState gameState, ReplayState replayState) LoadReplay(string fileName)
        {
            List<(int x, int y)> coordinates = LogReader.ReadReplayFile(fileName);
            List<Move> allReplayMoves = GameLogic.TransformCoordinatesToMoves(coordinates);
            (ReplayState replayState, Move firstReplayMove) initialReplayStep =
                ReplayStateGenerator.InitializeReplayState(allReplayMoves);

            var replayState = initialReplayStep.replayState;
            var gameState = GenerateGameState(new List<Move> {initialReplayStep.firstReplayMove});

            return (gameState, replayState);
        }
    }
}
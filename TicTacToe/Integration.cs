using System;

namespace TicTacToe
{
    public static class Integration
    {
        public static GameState StartNewGame()
        {
            var gameState = GameState.Init();
            return gameState;
        }
    }
}

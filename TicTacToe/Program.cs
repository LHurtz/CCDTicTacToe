using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form1();

            var gameState = RequestHandler.StartProgram();
            form.DisplayGameState(gameState);

            form.NewGameClicked += () =>
            {
                var newGameState = RequestHandler.StartNewGame();
                form.DisplayGameState(newGameState);
            };

            form.CellClicked += coordinates =>
            {
                var nextGameState = RequestHandler.PlayTurn(coordinates);
                form.DisplayGameState(nextGameState);
            };

            Application.Run(form);
        }
    }
}

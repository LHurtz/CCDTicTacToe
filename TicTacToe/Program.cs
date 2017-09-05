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
            var requestHandler = new RequestHandler();

            var gameState = requestHandler.StartProgram();
            form.DisplayGameState(gameState);

            form.NewGameClicked += () =>
            {
                var newGameState = requestHandler.StartNewGame();
                form.DisplayGameState(newGameState);
            };

            form.CellClicked += coordinates =>
            {
                var nextGameState = requestHandler.PlayTurn(coordinates);
                form.DisplayGameState(nextGameState);
            };

            Application.Run(form);
        }
    }
}

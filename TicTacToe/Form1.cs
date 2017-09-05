using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public void DisplayGameState(GameState gameState)
        {
            foreach (var cell in gameState.Board)
            {
                var cellButton = GetCellButtonByCoordinates(cell.X, cell.Y);
                SetCellStatus(cellButton, cell.CellState);
            }

            SetStatus(gameState.Status);
        }
        

        private void SetCellStatus(Button cellButton, CellState cellState)
        {
            switch (cellState)
            {
                case CellState.none:
                    cellButton.Text = string.Empty;
                    break;
                case CellState.X:
                    cellButton.Text = "X";
                    break;
                case CellState.O:
                    cellButton.Text = "O";
                    break;
            }

        }

        private Button GetCellButtonByCoordinates(int cellX, int cellY)
        {
            var button = (Button)tableLayoutPanel1.GetControlFromPosition(cellX, cellY);
            return button;
        }

        private void SetStatus(Status gameStateStatus)
        {
            switch (gameStateStatus)
            {
                case Status.OWin:
                case Status.XWin:
                    //Show victory screen
                    break;
                case Status.Tie:
                    //Show tie screen
                    break;
                case Status.TurnO:
                    break;
                case Status.TurnX:
                    break;
            }


        }
    }
}

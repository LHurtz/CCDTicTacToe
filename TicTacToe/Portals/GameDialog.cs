using System;
using System.Windows.Forms;
using TicTacToe.Model;

namespace TicTacToe.Portals
{
    public partial class GameDialog : Form
    {
        public event Action<(int x, int y)> CellClicked;
        public event Action NewGameClicked;


        public GameDialog()
        {
            InitializeComponent();
            SetUpButtonClickEvents();
        }

        private void SetUpButtonClickEvents()
        {
            button1.Click += OnCellClicked;
            button2.Click += OnCellClicked;
            button3.Click += OnCellClicked;
            button4.Click += OnCellClicked;
            button5.Click += OnCellClicked;
            button6.Click += OnCellClicked;
            button7.Click += OnCellClicked;
            button8.Click += OnCellClicked;
            button9.Click += OnCellClicked;

            btnNewGame.Click += OnNewGameClicked;
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

            cellButton.Enabled = cellButton.Text == string.Empty;
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
                    lblPlayerIndication.Text = "Unentschieden";
                    break;
                case Status.TurnO:
                    lblPlayerIndication.Text = "Spieler O ist an der Reihe.";
                    break;
                case Status.TurnX:
                    lblPlayerIndication.Text = "Spieler X ist an der Reihe.";
                    break;
            }
        }

        private void OnCellClicked(object sender, EventArgs eventArgs)
        {
            var x = tableLayoutPanel1.GetColumn((Control)sender);
            var y = tableLayoutPanel1.GetRow((Control)sender);

            if (CellClicked != null) CellClicked((x, y));
        }

        private void OnNewGameClicked(object sender, EventArgs e)
        {
            if (NewGameClicked != null) NewGameClicked();
        }
    }
}

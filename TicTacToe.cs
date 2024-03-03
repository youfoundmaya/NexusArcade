using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexus_Arcade
{
    public partial class TicTacToe : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int computerWinCount = 0;

        List<Button> buttons;

        public TicTacToe()
        {
            InitializeComponent();
            RestartGame();
        }

        private void ComputerMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.PaleVioletRed;
                buttons.RemoveAt(index);
                CheckGame();
                timer1.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Violet;
            button.ForeColor = Color.White;
            buttons.Remove(button);
            CheckGame();
            timer1.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if ( button1.Text=="X" && button2.Text=="X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                )
            {
                timer1.Stop();
                MessageBox.Show("Player wins!!!","Game has ended.");
                playerWinCount++;
                label1.Text = "Player wins: " + playerWinCount;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                )
            {
                timer1.Stop();
                MessageBox.Show("Computer wins!!!", "Game has ended.");
                computerWinCount++;
                label2.Text = "Computer wins: " + computerWinCount;
                RestartGame();
            }
            else if (button1.Text!="?" && button2.Text != "?" && button3.Text != "?" && button4.Text != "?" && button5.Text != "?" &&
                button6.Text != "?" && button7.Text != "?" && button8.Text != "?" && button9.Text != "?")
            {
                timer1.Stop();
                MessageBox.Show("It's a draw.", "Game has ended.");
                RestartGame();
            }
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button b in buttons)
            {
                b.Enabled = true;
                b.Text = "?";
                b.BackColor = Color.Plum;
                b.ForeColor = Color.Black;
            }
        }
    }
}

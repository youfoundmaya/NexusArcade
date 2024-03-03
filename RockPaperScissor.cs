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
    public partial class RockPaperScissor : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] ComputerChoiceList = { "rock", "paper", "scissors", "paper", "scissor", "rock"};

        int randomNumber = 0;
        Random random = new Random();

        string ComputerChoice;
        string PlayerChoice;

        int playerScore;
        int ComputerScore;

        public RockPaperScissor()
        {
            InitializeComponent();
            picturePlayer.Image = Properties.Resources.default1;
            pictureComputer.Image = Properties.Resources.default1;
            countDownTimer.Enabled = true;
            PlayerChoice = "none";
            txtcountdown.Text = "5";
        }

        private void rock_Click(object sender, EventArgs e)
        {
            picturePlayer.Image = Properties.Resources.rock;
            PlayerChoice = "rock";
        }

        private void paper_Click(object sender, EventArgs e)
        {
            picturePlayer.Image = Properties.Resources.paper;
            PlayerChoice = "paper";
        }

        private void scissors_Click(object sender, EventArgs e)
        {
            picturePlayer.Image = Properties.Resources.scissors;
            PlayerChoice = "scissors";
        }

        private void restart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            ComputerScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + playerScore + "\nComputer Score: " + ComputerScore;
            PlayerChoice = "none";
            countDownTimer.Enabled = true;
            picturePlayer.Image = Properties.Resources.default1;
            pictureComputer.Image = Properties.Resources.default1;
            gameOver = false;

        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtcountdown.Text = timerPerRound.ToString();
            txtRound.Text = "Rounds: " + rounds;

            if(timerPerRound < 1)
            {
                
                    countDownTimer.Enabled = false;
                    timerPerRound = 6;
                    randomNumber = random.Next(0, ComputerChoiceList.Length);
                    ComputerChoice = ComputerChoiceList[randomNumber];

                    switch (ComputerChoice)
                    {
                        case "rock":
                            pictureComputer.Image = Properties.Resources.rock;
                            break;
                        case "paper":
                            pictureComputer.Image = Properties.Resources.paper;
                            break;
                        case "scissors":
                            pictureComputer.Image = Properties.Resources.scissors;
                            break;
                    }

                if (rounds > 1)
                {
                    checkGame();
                }
                else
                {
                    if (playerScore > ComputerScore)
                    {
                        txtScore.Text = "Player: " + playerScore + "\nComputer Score: " + ComputerScore;
                        MessageBox.Show("Player has won the game!\nClick Restart to play again!", "Result");
                        gameOver = true;
                        countDownTimer.Enabled = false;
                        return;
                    }
                    else
                    {
                        txtScore.Text = "Player: " + playerScore + "\nComputer Score: " + ComputerScore;
                        MessageBox.Show("Computer has won the game!\nClick Restart to play again!", "Result");
                        gameOver = true;
                        countDownTimer.Enabled = false;
                        return;
                    }
                }
            }
        }
        private void checkGame()
        {
            if (PlayerChoice == "rock" && ComputerChoice == "paper")
            {
                ComputerScore += 1;
                rounds -= 1;
                MessageBox.Show("Paper Covers Rock!", "Computer Wins");
            }
            else if (PlayerChoice == "scissors" && ComputerChoice == "rock")
            {
                ComputerScore += 1;
                rounds -= 1;
                MessageBox.Show("Rock breaks Scissor!", "Computer Wins");
            }
            else if (PlayerChoice == "paper" && ComputerChoice == "scissors")
            {
                ComputerScore += 1;
                rounds -= 1;
                MessageBox.Show("Scissor cuts Paper!", "Computer Wins");
            }
            else if (PlayerChoice == "paper" && ComputerChoice == "rock")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Paper Covers Rock!", "Player Wins");
            }
            else if (PlayerChoice == "rock" && ComputerChoice == "scissors")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Rock breaks Scissor!", "Player Wins");
            }
            else if (PlayerChoice == "scissors" && ComputerChoice == "paper")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Scissor cuts Paper!", "Player Wins");
            }
            else if (PlayerChoice == "none")
            {
                MessageBox.Show("Dear Player,\nKindly make a move to continue the game.", "No options selected");
            } 
            else if (PlayerChoice == "scissors" && ComputerChoice == "scissors"
                || PlayerChoice == "paper" && ComputerChoice == "paper"
                || PlayerChoice == "rock" && ComputerChoice == "rock"
                )
            {
                MessageBox.Show("The current round is a Draw!","Draw");
            }
            else
            {
                MessageBox.Show("Sorry the request has been not processed because of processing issues.");
            }
            startNextRound();
        }

        private void startNextRound()
        {
            if (gameOver)
            {
                return;
            }

            txtScore.Text = "Player: " + playerScore + "\nComputer Score: " + ComputerScore;
            PlayerChoice = "none";
            countDownTimer.Enabled = true;
            picturePlayer.Image = Properties.Resources.default1;
            pictureComputer.Image = Properties.Resources.default1;

        }

        private void FormIsClosed(object sender, FormClosedEventArgs e)
        {
            countDownTimer.Stop();
        }
    }
}

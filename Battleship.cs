using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nexus_Arcade
{
    public partial class Battleship : Form
    {

        List<Button> playerPositionButtons;
        List<Button> enemyPositionButtons;

        Random random = new Random();

        int totalShips = 3;
        int round = 32;
        int playerScore;
        int enemyScore;

        public Battleship()
        {
            InitializeComponent();
            RestartGame();
        }

        private void EnemyPlayTimerEvent(object sender, EventArgs e)
        {
            if(playerPositionButtons.Count > 0 && round > 0)
            {
                round -= 1;
                txtRounds.Text = "Round: " + round;
                int index = random.Next(playerPositionButtons.Count);
                if ((string)playerPositionButtons[index].Tag == "playerShip")
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.sunk;
                    enemyMove.Text = "Enemy Move: " +playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].Text = string.Empty;
                    playerPositionButtons.RemoveAt(index);
                    enemyScore += 1;
                    txtEnemy.Text = "Enemy: " + enemyScore.ToString();
                    EnemyPlayerTimer.Stop();
                }
                else
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.cross;
                    enemyMove.Text = "Enemy Move: " +playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].Text = string.Empty;
                    playerPositionButtons.RemoveAt(index);
                    EnemyPlayerTimer.Stop();
                }
            }

            if (round < 1 || enemyScore > 2 || playerScore > 2)
            {
                if (playerScore > enemyScore)
                {
                    MessageBox.Show("Player Wins!", "Won");
                    RestartGame();
                }
                else if (enemyScore > playerScore)
                {
                    MessageBox.Show("Enemy Wins!", "Lost");
                    RestartGame();
                }
                else if (enemyScore == playerScore)
                {
                    MessageBox.Show("The current game is a draw", "Draw");
                    RestartGame();
                }
            }
            
        }

        private void AttackButtonEvent(object sender, EventArgs e)
        {
            if(EnemyLocationListBox.Text != string.Empty)
            {
                string attackPosition = EnemyLocationListBox.Text.ToLower();
                int index = enemyPositionButtons.FindIndex(a => a.Name == attackPosition);
                if (enemyPositionButtons[index].Enabled && round > 0)
                {
                    round -= 1;
                    txtRounds.Text = "Round: " + round;

                    if ((string)enemyPositionButtons[index].Tag == "enemyShip")
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.sunk;
                        enemyPositionButtons[index].BackColor = Color.Gray;
                        enemyPositionButtons[index].Text = string.Empty;
                        playerScore += 1;
                        txtPlayer.Text = "Player: " + playerScore.ToString();
                        EnemyPlayerTimer.Start();
                    }
                    else
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.cross;
                        enemyPositionButtons[index].BackColor = Color.Gray;
                        enemyPositionButtons[index].Text = string.Empty;
                        EnemyPlayerTimer.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose a location from the drop down first.", "Information");
            }
        }

        private void PlayerPositionButtonsEvent(object sender, EventArgs e)
        {
            if (totalShips > 0)
            {
                Button button = (Button)sender;
                button.Enabled = false;
                button.Tag = "playerShip";
                button.BackColor = Color.Plum;
                totalShips -= 1;
            }
            if (totalShips == 0)
            {
                txtAttack.Enabled = true;
                txtAttack.BackColor = Color.Silver;

                txtHelp.Text = "2) Pick an enemy position to attack from the dropdown.";
            }
        }

        private void RestartGame()
        {
            playerPositionButtons = new List<Button>{w1, w2, w3, w4, x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4};
            enemyPositionButtons = new List<Button> { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4};
            EnemyLocationListBox.Items.Clear();
            EnemyLocationListBox.Text = null;
            txtHelp.Text = "1) Hide your ship on 3 tiles to start the game";
            for(int i = 0; i < enemyPositionButtons.Count; i++)
            {
                enemyPositionButtons[i].Enabled = true;
                enemyPositionButtons[i].Tag = null;
                enemyPositionButtons[i].BackColor = Color.White;
                enemyPositionButtons[i].BackgroundImage = null;
                enemyPositionButtons[i].Text = enemyPositionButtons[i].Name.ToUpper();
                EnemyLocationListBox.Items.Add(enemyPositionButtons[i].Text);
            }
            for(int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].Enabled = true;
                playerPositionButtons[i].Tag = null;
                playerPositionButtons[i].BackColor = Color.White;
                playerPositionButtons[i].BackgroundImage = null;
                playerPositionButtons[i].Text = playerPositionButtons[i].Name.ToUpper();
            }

            playerScore = 0;
            enemyScore = 0;
            round = 30;
            totalShips = 3;
            
            txtPlayer.Text = "Player: " + playerScore.ToString();
            txtEnemy.Text = "Enemy: " + enemyScore.ToString();
            enemyMove.Text = "Enemy Move: A1";

            txtAttack.Enabled = false;
            EnemyLocationPicker();
        }

        private void EnemyLocationPicker()
        {
            List<int> selectedButtonIndices = new List<int>();
            while (selectedButtonIndices.Count < 3)
            {
                
                int index = random.Next(enemyPositionButtons.Count);
                
                if (enemyPositionButtons[index].Enabled && (string)enemyPositionButtons[index].Tag == null)
                {
                    enemyPositionButtons[index].Tag = "enemyShip";
                    Debug.WriteLine("Enemy Position: " + enemyPositionButtons[index].Text);
                    selectedButtonIndices.Add(index);
                    if (selectedButtonIndices.Count == 3)
                    {
                        break;
                    }
                }
                else
                {
                    index = random.Next(enemyPositionButtons.Count);
                }
            }

        }
    }
}

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
    public partial class BrickOut : Form
    {

        bool goLeft;
        bool goRight;
        bool isGameOver;

        int score;
        int ballx;
        int bally;
        int playerSpeed;

        Random random = new Random();

        PictureBox[] blockArray;

        public BrickOut()
        {
            InitializeComponent();
            PlaceBlocks();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if(goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 690)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;
            if (ball.Left < 0 || ball.Left > 772)
            {
                ballx = -ballx;
            }
            if (ball.Top < 0)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = random.Next(5, 12) * -1;
                if (ballx < 0)
                {
                    ballx = random.Next(5,12) * -1;
                }
                else
                {
                    ballx = random.Next(5, 12);
                }
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        bally = -bally;
                        this.Controls.Remove(x);
                    }
                }
            }

            if(score == 15)
            {
                GameOver("You Win! Press Enter to play again.");
            }

            if (ball.Top > 580)
            {
                GameOver("You Lose! Press Enter to play again.");
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RemoveBlocks();
                PlaceBlocks();
            }
        }

        private void setupGame()
        {
            isGameOver = false;
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 14;
            txtScore.Text = "Score: " + score;

            ball.Left = 344;
            ball.Top = 355;

            player.Left = 375;

            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                }
            }
        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text = "Score: " + score + "      " + message;
        }

        private void PlaceBlocks()
        {
            blockArray = new PictureBox[15];
            int a = 0;
            int top = 50;
            int left = 100;

            for (int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.White;

                if (a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }
                if (a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }
            }

            setupGame();
        }

        private void RemoveBlocks()
        {
            foreach(PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }
    }
}

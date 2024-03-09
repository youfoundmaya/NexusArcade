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
    public partial class PacMan : Form
    {

        bool goUp, goDown, goLeft, goRight, isGameOver;
        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;


        public PacMan()
        {
            InitializeComponent();
            RestartGame();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
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
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
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
                RestartGame();
            }
        }

        private void GameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            if (goLeft == true)
            {
                pic_pacman.Left -= playerSpeed;
                pic_pacman.Image = Properties.Resources.left;
            }
            if(goRight == true)
            {
                pic_pacman.Left += playerSpeed;
                pic_pacman.Image = Properties.Resources.right;
            }
            if (goDown == true)
            {
                pic_pacman.Top += playerSpeed;
                pic_pacman.Image = Properties.Resources.down;
            }
            if (goUp == true)
            {
                pic_pacman.Top -= playerSpeed;
                pic_pacman.Image = Properties.Resources.Up;
            }

            if (pic_pacman.Left < 0)
            {
                pic_pacman.Left = 500;
            }
            if (pic_pacman.Left > 500)
            {
                pic_pacman.Left = 0;
            }

            if (pic_pacman.Top < 0)
            {
                pic_pacman.Top = 450;
            }
            if (pic_pacman.Top > 450)
            {
                pic_pacman.Top = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if(pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                    if ((string)x.Tag == "wall")
                    {
                        if (pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You Lose!");
                        }

                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }
                    if((string)x.Tag == "ghost"){
                        if (pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You Lose!");
                        }
                    }
                }
            }

            redGhost.Left += redGhostSpeed;
            if(redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGhostSpeed;
            if (yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;
            if (pinkGhost.Top < 0 || pinkGhost.Top > 400)
            {
                pinkGhostY = -pinkGhostY;
            }
            if (pinkGhost.Left < 0 || pinkGhost.Left > 480)
            {
                pinkGhostX  = -pinkGhostX;
            }



            if (score == 50)
            {
                GameOver("You Win!");
            }
        }

        private void RestartGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            playerSpeed = 8;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;

            isGameOver = false;

            pic_pacman.Left = 12;
            pic_pacman.Top = 56;

            redGhost.Left = 166;
            redGhost.Top = 49;

            pinkGhost.Left = 400;
            pinkGhost.Top = 200;

            yellowGhost.Left = 330;
            yellowGhost.Top = 355;


            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text = "Score: " + score + Environment.NewLine + message + Environment.NewLine + "\nPress\nenter\nto\nrestart!";
            
        }
    }
}

﻿using System;
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
    public partial class Mario : Form
    {
        bool goLeft, goRight, jumping, hasKey;
        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        int playerSpeed = 10;
        int backgroundSpeed = 8;

        public Mario()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            player.Top += jumpSpeed;
            if (goLeft == true && player.Left > 60)
            {
                player.Left -= playerSpeed;
            }
            if(goRight == true && player.Left +  (player.Width +60) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }
            if(goLeft == true && background.Left < 0)
            {
                background.Left += backgroundSpeed;
                MoveGameElements("forward");
            }
            if(goRight == true && background.Left > -1059)
            {
                background.Left -= backgroundSpeed;
                MoveGameElements("back");
            }

            if (jumping == true)
            {
                jumpSpeed -= 12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }


            if(jumping == true && force < 0)
            {
                jumping = false;
            }
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "platform")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }
                    x.BringToFront();
                }

                if (x is PictureBox &&(string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;
                    }
                }
            }
            if (player.Bounds.IntersectsWith(key.Bounds))
            {
                key.Visible = false;
                hasKey = true;
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && hasKey == true)
            {
                door.Image = Properties.Resources.door_open;
                GameTimer.Stop();
                DialogResult rs = MessageBox.Show("Well done, your journey has been completed!\nDo you want to continue?","Game Over: You Won.",MessageBoxButtons.YesNo);
                if (DialogResult.Yes == rs)
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }
            }
            if (player.Top + player.Height > this.ClientSize.Height)
            {
                GameTimer.Stop();
                DialogResult rs = MessageBox.Show("You died!\nDo you want to continue?", "Game Over: You Lost.", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == rs)
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }
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
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
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
            if (jumping == true)
            {
                jumping = false;
            }
        }

        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RestartGame()
        {
            Mario mario = new Mario();
            mario.Show();
            this.Hide();
        }

        private void MoveGameElements(string direction)
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "key" || x is PictureBox && (string)x.Tag == "door")
                {
                    if(direction == "back")
                    {
                        x.Left -= backgroundSpeed;
                    }
                    if (direction == "forward")
                    {
                        x.Left += backgroundSpeed;
                    }
                }
            }
        }
    }
}

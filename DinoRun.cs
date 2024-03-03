using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexus_Arcade
{
    public partial class DinoRun : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 15;
        int score = 0;
        int obstacleSpeed = 11;

        Random random = new Random();

        int position;
        bool isGameOver = false;

        public DinoRun()
        {
            InitializeComponent();
            GameReset();
        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            dino.Top += jumpSpeed;
            txtScore.Text = "Score: " + score;

            if(jumping == true && force < 0)
            {
                jumping = false;
            }

            if(jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(dino.Top > 349 && jumping == false)
            {
                force = 12;
                dino.Top = 350;
                jumpSpeed = 0;
            }

                        
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left + x.Width < -100)
                    {
                        x.Left = this.ClientSize.Width + random.Next(10, 50) + (x.Width * 15);
                        score++;
                    }

                    if (dino.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        dino.Image = Properties.Resources.dead;
                        txtScore.Text += "      Press R to restart the game!";
                        isGameOver = true;
                    }
                    
                }
            }
            

            if (score > 80)
            {
                obstacleSpeed = 50;
            }
            else if (score > 70)
            {
                obstacleSpeed = 45;
            }
            else if (score > 60)
            {
                obstacleSpeed = 40;
            }
            else if (score > 50)
            {
                obstacleSpeed = 35;
            }
            else if (score > 40)
            {
                obstacleSpeed = 30;
            }
            else if (score > 30)
            {
                obstacleSpeed = 25;
            }
            else if (score > 20)
            {
                obstacleSpeed = 20;
            }
            else if (score > 10)
            {
                obstacleSpeed = 15;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.R && isGameOver == true) 
            {
                GameReset();
            }
        }

        private void GameReset()
        {
            force = 15;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 11;
            txtScore.Text = "Score: " + score;
            dino.Image = Properties.Resources.running;
            isGameOver = false;
            dino.Top = 350;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + random.Next(500, 1000) + (x.Width * 20);
                    x.Left = position;
                }
            }
            gameTimer.Start();
        }
    }
}

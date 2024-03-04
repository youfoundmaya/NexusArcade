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
    public partial class SaveTheEggs : Form
    {
        bool goLeft, goRight;
        int speed = 8;
        int score = 0;
        int missed = 0;

        Random randomX = new Random();
        Random randomY = new Random();

        PictureBox splash = new PictureBox();

        public SaveTheEggs()
        {
            InitializeComponent();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            txtMissed.Text = "Missed: " + missed;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= 12;
                player.Image = Properties.Resources.chicken_normal2;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += 12;
                player.Image = Properties.Resources.chicken_normal;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top += speed;
                    if (x.Top + x.Height > this.ClientSize.Height)
                    {
                        splash.Image = Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;
                        this.Controls.Add(splash);

                        x.Top = randomY.Next(80,300) * -1;
                        x.Left = randomX.Next(5, this.ClientSize.Width - x.Width);

                        missed += 1;
                        player.Image = Properties.Resources.chicken_hurt;
                    }

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randomY.Next(80, 300) * -1;
                        x.Left = randomX.Next(5, this.ClientSize.Width - x.Width);
                        score += 1;
                    }
                }
            }

            if (score > 30)
            {
                speed = 15;
            }
            else if(score > 20)
            {
                speed = 13;
            }
            else if (score > 15)
            {
                speed = 12;
            }
            else if (score > 10)
            {
                speed = 10;
            }
            else if (score > 5)
            {
                speed = 9;
            }

            if(missed >= 10)
            {
                GameTimer.Stop();
                DialogResult r = MessageBox.Show("Player has lost with a score: " + score + "\nDo you want to retry?", "Game Over", MessageBoxButtons.YesNo);
                if(DialogResult.Yes == r)
                {
                    RestartGame();
                }
                else
                {
                    GameTimer.Stop();
                    this.Close();
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
        }

        private void FormIsClosed(object sender, FormClosedEventArgs e)
        {
            GameTimer.Stop();
        }

        private void RestartGame()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top = randomY.Next(80, 300) * -1;
                    x.Left = randomX.Next(5, this.ClientSize.Width - x.Width);
                }
            }

            player.Left = this.ClientSize.Width / 2;
            player.Image = Properties.Resources.chicken_normal;

            score = 0;
            missed = 0;
            speed = 8;
            goLeft = false;
            goRight = false;

            GameTimer.Start();

        }
    }
}

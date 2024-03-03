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
    public partial class SnakeGame : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        Label caption = new Label();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random random = new Random();

        bool goLeft, goRight, goUp, goDown;

        public SnakeGame()
        {
            InitializeComponent();
            new Settings();
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
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
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            for(int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for(int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            pictureCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColor;
            for(int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColor, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height));
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height,
                    Settings.Width, Settings.Height));
        }


        private void RestartGame()
        {
            if (easyRadio.Checked)
            {
                gameTimer.Interval = 60;
            }
            else if (mediumRadio.Checked)
            {
                gameTimer.Interval = 50;
            }
            else if (hardRadio.Checked)
            {
                gameTimer.Interval = 40;
            }

            easyRadio.Enabled = false;
            mediumRadio.Enabled = false;
            hardRadio.Enabled = false;
            

            maxWidth = pictureCanvas.Width / Settings.Width - 1;
            maxHeight = pictureCanvas.Height / Settings.Height - 1;

            Snake.Clear();
            caption.Visible = false;
            button1.Enabled = false;
            score = 0;
            txtScore.Text = "Current\nScore: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);
            for(int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = random.Next(2, maxWidth), Y = random.Next(2, maxHeight)};
            gameTimer.Start();
        }

        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Current\nScore: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            food = new Circle { X = random.Next(2, maxWidth), Y = random.Next(2, maxHeight) };
            gameTimer.Interval -= 1;
        }

        private void GameOver()
        {
            gameTimer.Stop();
            button1.Enabled = true;
            easyRadio.Enabled = true;
            mediumRadio.Enabled = true;
            hardRadio.Enabled = true;
            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High\nScore: " + highScore;
            }

            caption.Visible = true;
            caption.Text = "Click Start to play again!";
            caption.ForeColor = Color.Purple;
            caption.Height = 30;
            caption.Width = pictureCanvas.Width;
            caption.AutoSize = false;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            pictureCanvas.Controls.Add(caption);
        }
    }
}

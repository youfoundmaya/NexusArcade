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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TicTacToe t = new TicTacToe();
            t.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SnakeGame sg = new SnakeGame();
            sg.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RockPaperScissor rps = new RockPaperScissor();
            rps.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DinoRun dr = new DinoRun();
            dr.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Battleship bs = new Battleship();
            bs.ShowDialog();   
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Pong pong = new Pong();
            pong.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SaveTheEggs eggs=new SaveTheEggs();
            eggs.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            BrickOut brick = new BrickOut();
            brick.ShowDialog();
        }
    }
}

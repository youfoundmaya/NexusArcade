namespace Nexus_Arcade
{
    partial class RockPaperScissor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RockPaperScissor));
            this.rock = new System.Windows.Forms.Button();
            this.paper = new System.Windows.Forms.Button();
            this.scissors = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.picturePlayer = new System.Windows.Forms.PictureBox();
            this.pictureComputer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtcountdown = new System.Windows.Forms.Label();
            this.txtRound = new System.Windows.Forms.Label();
            this.countDownTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureComputer)).BeginInit();
            this.SuspendLayout();
            // 
            // rock
            // 
            this.rock.BackColor = System.Drawing.Color.Plum;
            this.rock.Location = new System.Drawing.Point(43, 96);
            this.rock.Name = "rock";
            this.rock.Size = new System.Drawing.Size(123, 37);
            this.rock.TabIndex = 0;
            this.rock.Text = "Rock";
            this.rock.UseVisualStyleBackColor = false;
            this.rock.Click += new System.EventHandler(this.rock_Click);
            // 
            // paper
            // 
            this.paper.BackColor = System.Drawing.Color.Plum;
            this.paper.Location = new System.Drawing.Point(43, 154);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(123, 37);
            this.paper.TabIndex = 0;
            this.paper.Text = "Paper";
            this.paper.UseVisualStyleBackColor = false;
            this.paper.Click += new System.EventHandler(this.paper_Click);
            // 
            // scissors
            // 
            this.scissors.BackColor = System.Drawing.Color.Plum;
            this.scissors.Location = new System.Drawing.Point(43, 215);
            this.scissors.Name = "scissors";
            this.scissors.Size = new System.Drawing.Size(123, 37);
            this.scissors.TabIndex = 0;
            this.scissors.Text = "Scissors";
            this.scissors.UseVisualStyleBackColor = false;
            this.scissors.Click += new System.EventHandler(this.scissors_Click);
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.Plum;
            this.restart.Location = new System.Drawing.Point(624, 349);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(150, 37);
            this.restart.TabIndex = 1;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // picturePlayer
            // 
            this.picturePlayer.Image = ((System.Drawing.Image)(resources.GetObject("picturePlayer.Image")));
            this.picturePlayer.Location = new System.Drawing.Point(224, 96);
            this.picturePlayer.Name = "picturePlayer";
            this.picturePlayer.Size = new System.Drawing.Size(150, 150);
            this.picturePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePlayer.TabIndex = 2;
            this.picturePlayer.TabStop = false;
            this.picturePlayer.UseWaitCursor = true;
            // 
            // pictureComputer
            // 
            this.pictureComputer.Image = ((System.Drawing.Image)(resources.GetObject("pictureComputer.Image")));
            this.pictureComputer.Location = new System.Drawing.Point(624, 96);
            this.pictureComputer.Name = "pictureComputer";
            this.pictureComputer.Size = new System.Drawing.Size(150, 150);
            this.pictureComputer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureComputer.TabIndex = 3;
            this.pictureComputer.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Computer";
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(428, 90);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(144, 54);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Player: 0\r\nComputer: 0\r\n";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcountdown
            // 
            this.txtcountdown.AutoSize = true;
            this.txtcountdown.Location = new System.Drawing.Point(489, 200);
            this.txtcountdown.Name = "txtcountdown";
            this.txtcountdown.Size = new System.Drawing.Size(24, 27);
            this.txtcountdown.TabIndex = 4;
            this.txtcountdown.Text = "5";
            // 
            // txtRound
            // 
            this.txtRound.AutoSize = true;
            this.txtRound.Location = new System.Drawing.Point(450, 297);
            this.txtRound.Name = "txtRound";
            this.txtRound.Size = new System.Drawing.Size(108, 27);
            this.txtRound.TabIndex = 4;
            this.txtRound.Text = "Round: 3";
            // 
            // countDownTimer
            // 
            this.countDownTimer.Interval = 1000;
            this.countDownTimer.Tick += new System.EventHandler(this.countDownTimerEvent);
            // 
            // RockPaperScissor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(890, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRound);
            this.Controls.Add(this.txtcountdown);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureComputer);
            this.Controls.Add(this.picturePlayer);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.scissors);
            this.Controls.Add(this.paper);
            this.Controls.Add(this.rock);
            this.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RockPaperScissor";
            this.Text = "Rock Paper Scissor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIsClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureComputer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rock;
        private System.Windows.Forms.Button paper;
        private System.Windows.Forms.Button scissors;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.PictureBox picturePlayer;
        private System.Windows.Forms.PictureBox pictureComputer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtcountdown;
        private System.Windows.Forms.Label txtRound;
        private System.Windows.Forms.Timer countDownTimer;
    }
}
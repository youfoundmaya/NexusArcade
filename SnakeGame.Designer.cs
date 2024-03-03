namespace Nexus_Arcade
{
    partial class SnakeGame
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.easyRadio = new System.Windows.Forms.RadioButton();
            this.mediumRadio = new System.Windows.Forms.RadioButton();
            this.hardRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(601, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.StartGame);
            // 
            // pictureCanvas
            // 
            this.pictureCanvas.BackColor = System.Drawing.Color.Silver;
            this.pictureCanvas.Location = new System.Drawing.Point(12, 12);
            this.pictureCanvas.Name = "pictureCanvas";
            this.pictureCanvas.Size = new System.Drawing.Size(580, 680);
            this.pictureCanvas.TabIndex = 1;
            this.pictureCanvas.TabStop = false;
            this.pictureCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.txtScore.Location = new System.Drawing.Point(596, 509);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(108, 54);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Current\r\nScore: 0\r\n";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.txtHighScore.Location = new System.Drawing.Point(598, 577);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(108, 54);
            this.txtHighScore.TabIndex = 2;
            this.txtHighScore.Text = "High\r\nScore: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 55;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hardRadio);
            this.groupBox1.Controls.Add(this.mediumRadio);
            this.groupBox1.Controls.Add(this.easyRadio);
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(601, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 183);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // easyRadio
            // 
            this.easyRadio.AutoSize = true;
            this.easyRadio.Checked = true;
            this.easyRadio.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.easyRadio.Location = new System.Drawing.Point(7, 43);
            this.easyRadio.Name = "easyRadio";
            this.easyRadio.Size = new System.Drawing.Size(77, 29);
            this.easyRadio.TabIndex = 0;
            this.easyRadio.TabStop = true;
            this.easyRadio.Text = "Easy";
            this.easyRadio.UseVisualStyleBackColor = true;
            // 
            // mediumRadio
            // 
            this.mediumRadio.AutoSize = true;
            this.mediumRadio.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.mediumRadio.Location = new System.Drawing.Point(7, 87);
            this.mediumRadio.Name = "mediumRadio";
            this.mediumRadio.Size = new System.Drawing.Size(99, 29);
            this.mediumRadio.TabIndex = 1;
            this.mediumRadio.TabStop = true;
            this.mediumRadio.Text = "Medium";
            this.mediumRadio.UseVisualStyleBackColor = true;
            // 
            // hardRadio
            // 
            this.hardRadio.AutoSize = true;
            this.hardRadio.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.hardRadio.Location = new System.Drawing.Point(7, 137);
            this.hardRadio.Name = "hardRadio";
            this.hardRadio.Size = new System.Drawing.Size(77, 29);
            this.hardRadio.TabIndex = 2;
            this.hardRadio.TabStop = true;
            this.hardRadio.Text = "Hard";
            this.hardRadio.UseVisualStyleBackColor = true;
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(746, 717);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.pictureCanvas);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SnakeGame";
            this.Text = "SnakeGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton easyRadio;
        private System.Windows.Forms.RadioButton mediumRadio;
        private System.Windows.Forms.RadioButton hardRadio;
    }
}
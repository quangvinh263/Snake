namespace Snake
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.playbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.butRanking = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butLeft = new System.Windows.Forms.Button();
            this.butRight = new System.Windows.Forms.Button();
            this.labelMode = new System.Windows.Forms.Label();
            this.butLeft2 = new System.Windows.Forms.Button();
            this.butRight2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFood = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backpic = new System.Windows.Forms.PictureBox();
            this.butLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backpic)).BeginInit();
            this.SuspendLayout();
            // 
            // playbtn
            // 
            this.playbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.playbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playbtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playbtn.ForeColor = System.Drawing.Color.Maroon;
            this.playbtn.Location = new System.Drawing.Point(446, 461);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(107, 39);
            this.playbtn.TabIndex = 1;
            this.playbtn.Text = "PLAY";
            this.playbtn.UseVisualStyleBackColor = false;
            this.playbtn.Click += new System.EventHandler(this.playbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.exitbtn.FlatAppearance.BorderSize = 0;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.Color.Black;
            this.exitbtn.Location = new System.Drawing.Point(968, -2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(40, 35);
            this.exitbtn.TabIndex = 2;
            this.exitbtn.Text = "x";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // butRanking
            // 
            this.butRanking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butRanking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRanking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRanking.ForeColor = System.Drawing.Color.Maroon;
            this.butRanking.Location = new System.Drawing.Point(446, 518);
            this.butRanking.Name = "butRanking";
            this.butRanking.Size = new System.Drawing.Size(107, 39);
            this.butRanking.TabIndex = 4;
            this.butRanking.Text = "RANKING";
            this.butRanking.UseVisualStyleBackColor = false;
            this.butRanking.Click += new System.EventHandler(this.butRanking_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // butLeft
            // 
            this.butLeft.Location = new System.Drawing.Point(400, 362);
            this.butLeft.Name = "butLeft";
            this.butLeft.Size = new System.Drawing.Size(32, 25);
            this.butLeft.TabIndex = 9;
            this.butLeft.Text = "<";
            this.butLeft.UseVisualStyleBackColor = true;
            this.butLeft.Click += new System.EventHandler(this.butLeft_Click);
            // 
            // butRight
            // 
            this.butRight.Location = new System.Drawing.Point(566, 363);
            this.butRight.Name = "butRight";
            this.butRight.Size = new System.Drawing.Size(32, 25);
            this.butRight.TabIndex = 10;
            this.butRight.Text = ">";
            this.butRight.UseVisualStyleBackColor = true;
            this.butRight.Click += new System.EventHandler(this.butRight_Click);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelMode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.ForeColor = System.Drawing.Color.Red;
            this.labelMode.Location = new System.Drawing.Point(476, 364);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(51, 24);
            this.labelMode.TabIndex = 11;
            this.labelMode.Text = "Easy";
            // 
            // butLeft2
            // 
            this.butLeft2.Location = new System.Drawing.Point(400, 415);
            this.butLeft2.Name = "butLeft2";
            this.butLeft2.Size = new System.Drawing.Size(32, 25);
            this.butLeft2.TabIndex = 12;
            this.butLeft2.Text = "<";
            this.butLeft2.UseVisualStyleBackColor = true;
            this.butLeft2.Click += new System.EventHandler(this.butLeft2_Click);
            // 
            // butRight2
            // 
            this.butRight2.Location = new System.Drawing.Point(566, 415);
            this.butRight2.Name = "butRight2";
            this.butRight2.Size = new System.Drawing.Size(32, 25);
            this.butRight2.TabIndex = 13;
            this.butRight2.Text = ">";
            this.butRight2.UseVisualStyleBackColor = true;
            this.butRight2.Click += new System.EventHandler(this.butRight2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(255, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chọn độ khó";
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelFood.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFood.ForeColor = System.Drawing.Color.Red;
            this.labelFood.Location = new System.Drawing.Point(249, 419);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(124, 21);
            this.labelFood.TabIndex = 16;
            this.labelFood.Text = "Chọn thức ăn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox2.Location = new System.Drawing.Point(480, 415);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(731, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // backpic
            // 
            this.backpic.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.backpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backpic.Location = new System.Drawing.Point(0, 0);
            this.backpic.Name = "backpic";
            this.backpic.Size = new System.Drawing.Size(1008, 640);
            this.backpic.TabIndex = 0;
            this.backpic.TabStop = false;
            // 
            // butLogout
            // 
            this.butLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLogout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLogout.ForeColor = System.Drawing.Color.Maroon;
            this.butLogout.Location = new System.Drawing.Point(446, 577);
            this.butLogout.Name = "butLogout";
            this.butLogout.Size = new System.Drawing.Size(107, 39);
            this.butLogout.TabIndex = 18;
            this.butLogout.Text = "LOG OUT";
            this.butLogout.UseVisualStyleBackColor = false;
            this.butLogout.Click += new System.EventHandler(this.butLogout_Click);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 640);
            this.Controls.Add(this.butLogout);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.butRight2);
            this.Controls.Add(this.butLeft2);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.butRight);
            this.Controls.Add(this.butLeft);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butRanking);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.playbtn);
            this.Controls.Add(this.backpic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backpic;
        private System.Windows.Forms.Button playbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button butRanking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butLeft;
        private System.Windows.Forms.Button butRight;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Button butLeft2;
        private System.Windows.Forms.Button butRight2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Button butLogout;
    }
}


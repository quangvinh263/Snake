using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Media;
using System.Diagnostics.Eventing.Reader; // add this for the JPG compressor

namespace Snake
{

    public partial class Home : Form
    {
        public List<Image> images=new List<Image>();
        
        public int ind = 0;
        public Home()
        {
            InitializeComponent();
            images.Add(Properties.Resources.apple);
            images.Add(Properties.Resources.banana);
            images.Add(Properties.Resources.kiwi);
            images.Add(Properties.Resources.grapes);
            images.Add(Properties.Resources.orange);
            images.Add(Properties.Resources.peach);
            images.Add(Properties.Resources.strawberry);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            exitbtn.Parent = backpic;
            label1.Parent = backpic;
            Settings.Instance.soundHome.PlayLooping();
            pictureBox2.Image = Settings.Instance.food;
            
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playbtn_Click(object sender, EventArgs e)
        {
            Settings.Instance.soundHome.Stop();
            if(labelMode.Text == "Easy")
            {
                Settings.Instance.GameMode = labelMode.Text;
                this.Hide();
                EasyMap easyMap = new EasyMap();
                easyMap.ShowDialog();
                this.Close();
            }
            else
            {
                Settings.Instance.GameMode = labelMode.Text;
                this.Hide();
                HardMap hardMap = new HardMap();
                hardMap.ShowDialog();
                this.Close();
            }
        }

        private void butRanking_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ranking ranking = new Ranking();
            ranking.ShowDialog();
        }
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = "Welcome to Snake Game " + Settings.Instance.TenTK + "!";
        }

        private void butRight_Click(object sender, EventArgs e)
        {
            if(labelMode.Text == "Hard")
            {
                labelMode.Text = "Easy";
            }
            else
            {
                labelMode.Text = "Hard";
            }
        }

        private void butLeft_Click(object sender, EventArgs e)
        {
            if(labelMode.Text == "Easy")
            {
                labelMode.Text = "Hard";
            }
            else
            {
                labelMode.Text = "Easy";
            }
        }

        private void butRight2_Click(object sender, EventArgs e)
        {
            if (ind == images.Count - 1) ind = -1;
            Settings.Instance.food = images[++ind];
            pictureBox2.Image = Settings.Instance.food;
        }

        private void butLeft2_Click(object sender, EventArgs e)
        {
            if (ind == 0) ind = images.Count;
            Settings.Instance.food = images[--ind];
            pictureBox2.Image = Settings.Instance.food;
        }

        private void butLogout_Click(object sender, EventArgs e)
        {
            Settings.Instance.soundHome.Stop();
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
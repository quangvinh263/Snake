using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Instance.GameOver.Stop();
            this.Hide();
            if (Settings.Instance.GameMode == "Hard")
            {
                HardMap hard = new HardMap();
                hard.ShowDialog();
            }
            else
            {
                EasyMap easy = new EasyMap();
                easy.ShowDialog();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Instance.GameOver.Stop();
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = "Your Score: " + Settings.Instance.Score;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            Settings.Instance.GameOver.PlayLooping();
        }
    }
}

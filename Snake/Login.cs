﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.LightGreen;
            panel1.BackColor = Color.LightGreen;
            panel2.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.LightGreen;
            panel2.BackColor = Color.LightGreen;
            panel1.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ForgotPassword().Show();
            this.Hide();
        }
    }
}
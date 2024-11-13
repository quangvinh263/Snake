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
            txtBoxTK.BackColor = Color.LightGreen;
            panel1.BackColor = Color.LightGreen;
            panel2.BackColor = SystemColors.Control;
            txtBoxMK.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtBoxMK.BackColor = Color.LightGreen;
            panel2.BackColor = Color.LightGreen;
            panel1.BackColor = SystemColors.Control;
            txtBoxTK.BackColor = SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ForgotPassword().ShowDialog();
            this.Close();
        }

        Modify modify = new Modify();

        private void button1_Click(object sender, EventArgs e)
        {
            string tenTK = txtBoxTK.Text;
            string MatKhau = txtBoxMK.Text;
            if (tenTK.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }
            else if(MatKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                string query = "SELECT * FROM TaiKhoan WHERE TenTK = '" + tenTK + "' AND MatKhau = '" + MatKhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

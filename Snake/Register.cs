using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Snake
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public bool CheckAccount(string TenTK) // check TenTK
        {
            return Regex.IsMatch(TenTK, "^[a-zA-Z0-9]{6,}$");
        }
        public bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
            
        }

        Modify modify = new Modify();

        private void butRegister_Click(object sender, EventArgs e)
        {
            string TenTK = txtUser.Text;
            string MatKhau = txtPass.Text;
            string Confirm = txtConfirm.Text;
            string Email = txtEmail.Text;
            if(!CheckAccount(TenTK))
            {
                MessageBox.Show("Tên tài khoản phải từ 6 ký tự trở lên, không chứa các ký tự đặc biệt");
                return;
            }
            if(!CheckAccount(MatKhau))
            {
                MessageBox.Show("Mật khẩu phải từ 6 ký tự trở lên, không chứa các ký tự đặc biệt");
                return;
            }
            if(MatKhau != Confirm)
            {
                MessageBox.Show("Mật khẩu không trùng khớp, vui lòng xác nhận mật khẩu chính xác!");
                return;
            }
            if (!CheckEmail(Email))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ");
                return;
            }
            if(modify.TaiKhoans("SELECT * FROM TaiKhoan WHERE Email = '" + Email + "'").Count != 0)
            {
                MessageBox.Show("Email đã được đăng ký! Vui lòng đăng ký email khác");
                return;
            }
            try
            {
                string query = "INSERT INTO TaiKhoan VALUES ('" + TenTK + "', '" + MatKhau + "', '" + Email + "', 0, 0)";
                modify.Command(query);
                MessageBox.Show("Đăng ký thành công!");
                this.Hide();
                new Login().ShowDialog();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã tồn tại! Vui lòng chọn tên tài khoản khác");
            }
            new Login().Show();
            this.Hide();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtConfirm.Clear();
            txtEmail.Clear();
        }
    }
}

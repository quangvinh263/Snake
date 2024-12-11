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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
            label3.Text = "";
        }

        Modify modify = new Modify();

        private void butExit_Click(object sender, EventArgs e)
        {
           this.Hide();
           new Login().ShowDialog();
           this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text;
            if (email.Trim() == "") // check email có trống không
            {
                MessageBox.Show("Vui lòng nhập email đã đăng ký:");
            }
            else
            {
                string query = "SELECT * FROM TaiKhoan WHERE Email = '" + email + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    label3.ForeColor = Color.Green;
                    label3.Text = "Mật khẩu của bạn là: " + modify.TaiKhoans(query)[0].MK;
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Email này chưa được đăng ký!";
                }
            }
        }
    }
}

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
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
            
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            
            this.taiKhoanTableAdapter.Fill(this.database1DataSet.TaiKhoan);
            // TODO: This line of code loads data into the 'database1DataSet.TaiKhoan' table. You can move, or remove it, as needed.
            string query = "SELECT * FROM TaiKhoan" ; // Truy vấn bảng dữ liệu Ranking
            Modify modify = new Modify();

            try
            {
                DataTable dt = modify.GetData(query); // Lấy dữ liệu từ database
                dgvRanking.DataSource = dt; // dgvRanking là DataGridView để hiển thị dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.dgvRanking.Sort(this.dgvRanking.Columns[1], ListSortDirection.Descending);
            this.dgvRanking.Sort(this.dgvRanking.Columns[2], ListSortDirection.Descending);
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
            this.Close();
        }
    }
}

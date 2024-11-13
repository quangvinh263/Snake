using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Snake
{
    public class Modify
    {
        public Modify()
        {
        }
        SqlCommand sqlCommand; // dùng để truy vấn dữ liệu
        SqlDataReader DataReader; // dùng để đọc dữ liệu
        public List<TaiKhoan> TaiKhoans (string query) // check tài khoản
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                DataReader = sqlCommand.ExecuteReader();
                while(DataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(DataReader.GetString(0), DataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public void Command(string query) // dùng để đăng ký 
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); // thực hiện câu truy vấn
                sqlConnection.Close();
            }
        }
    }
}

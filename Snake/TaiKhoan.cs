using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class TaiKhoan
    {
        private string TenTK;
        private string MatKhau;
        private string Email;
        private long Point;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenTK, string mK)
        {
            this.TenTK = tenTK;
            this.MatKhau = mK;
        }
        public string tenTK { get => TenTK; set => TenTK = value; }
        public string MK { get => MatKhau; set => MatKhau = value; }
        public string email { get => Email; set => Email = value; }
        public long point { get => Point; set => Point = value; }
    }
}

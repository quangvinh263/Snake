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
        private int EasyPoint;
        private int HardPoint;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string tenTK, string mK, int easyPoint, int hardPoint)
        {
            this.TenTK = tenTK;
            this.MatKhau = mK;
            this.EasyPoint = easyPoint;
            this.HardPoint = hardPoint;
        }
        public string tenTK { get => TenTK; set => TenTK = value; }
        public string MK { get => MatKhau; set => MatKhau = value; }
        public string email { get => Email; set => Email = value; }
        public int easyPoint { get => EasyPoint; set => EasyPoint = value; }
        public int hardPoint { get => HardPoint; set => HardPoint = value; }
    }
}

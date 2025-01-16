using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap1
{
    public class QuanLy:NhanVien
    {
        public string Phong { get; set; }
        public QuanLy()
        {

        }

        public QuanLy(string diachi, string ten, int tuoi, decimal luong, string maNhanVien, string viTri,string phong):base(diachi,ten,tuoi,luong,maNhanVien,viTri)
        {
            phong = Phong;
        }
        public QuanLy(Nguoi nguoi)
        {
            base.Ten = nguoi.Ten;
            base.DiaChi = nguoi.DiaChi;
            base.Tuoi = nguoi.Tuoi;
            Luong = 0;
            MaNhanVien = "";
            ViTri = "";
            Phong = "";
        }

        public QuanLy(NhanVien nhanVien):this(nhanVien as Nguoi)
        {
            MaNhanVien = nhanVien.MaNhanVien;
            ViTri = nhanVien.ViTri;
            Luong = nhanVien.Luong;
            Phong = "";
        }

        public QuanLy(string line) : base(line)
        {
            string[] str = line.Split(',');
            Phong = str[7];
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(this);
        }


        public override string ToString()
        {
            return base.ToString() + string.Format($"{Phong,-10}");
        }
    }
}

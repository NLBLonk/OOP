using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap1
{
    public class NhanVien:Nguoi
    {
        public decimal Luong { get; set; }
        public string MaNhanVien { get; set; }
        public string ViTri { get; set; }

        public NhanVien()
        {

        }
        public NhanVien(string diaChi, string ten, int tuoi, decimal luong, string maNhanVien, string viTri) : base(diaChi, ten, tuoi)
        {
            Luong = luong;
            MaNhanVien = maNhanVien;
            ViTri = viTri;
        }

        public NhanVien(string line) : base(line)
        {
            string[] str = line.Split(',');
            Luong = int.Parse(str[4]);
            MaNhanVien = str[5];
            ViTri = str[6];
        }
        public override void HienThiThongTin()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return base.ToString()+string.Format($"{Luong,-10}|{MaNhanVien,-12}|{ViTri,-10}|");
        }
    }
}

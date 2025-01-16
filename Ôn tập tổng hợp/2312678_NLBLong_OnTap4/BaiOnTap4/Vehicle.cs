using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class Vehicle:IVehicle
    {
        public string  Ten { get; set; }
        public int TocDo { get; set; }
        public double NhienLieu { get; set; }
        public int QuangDuong { get; set; }
        public string NhaSX { get; set; }
        public int NamSX { get; set; }
        public Vehicle() { }
        public Vehicle(string ten, int tocDo, double nhienLieu, int quangDuong, string nhaSX, int namSX)
        {
            Ten = ten;
            TocDo = tocDo;
            NhienLieu = nhienLieu;
            QuangDuong = quangDuong;
            NhaSX = nhaSX;
            NamSX = namSX;
        }

        public Vehicle(string line)
        {
            string[] str = line.Split(',');
            Ten= str[1];
            TocDo = int.Parse(str[2]);
            NhienLieu = double.Parse(str[3]);
            QuangDuong = int.Parse(str[4]);
            NhaSX = str[5];
            NamSX = int.Parse(str[6]);
        }

     

        public void TangToc(int giaTang)
        {
            TocDo += giaTang;
        }

        public void DoNhienLieu(double nhienLieuMoi)
        {
            NhienLieu += nhienLieuMoi;
        }

        public override string ToString()
        {
            return string.Format($"{Ten,-20}{TocDo,-10}{NhienLieu,-10}{QuangDuong,-15}{NhaSX,-20}{NamSX,-10}");
        }

    }
}

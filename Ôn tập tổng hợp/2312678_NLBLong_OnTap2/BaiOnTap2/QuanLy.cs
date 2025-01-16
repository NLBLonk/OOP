using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap2
{
    public class QuanLy:INguoi,INhanVien,IKhaNangQuanLy,IQuanLyLuong
    {
        public string Ho {  get; set; }
        public string Ten { get; set; }
        public int NhanVienID { get; set; }
        public string Phong {  get; set; }
        public double Luong { get; set; }
        public string NhiemVu { get; set; }
        public double PhanTram { get; set; }
        public double tangLuong { get; set; }
        public QuanLy()
        {
            
        }

        public QuanLy(string ho, string ten, int nhanVienID, string phong,string nhiemVu, double luong)
        {
            Ho = ho;
            Ten = ten;
            NhanVienID = nhanVienID;
            Phong = phong;
            Luong = luong;
            NhiemVu = nhiemVu;
        }

        public QuanLy(string line)
        {
            string[] str = line.Split(',');
            NhanVienID = int.Parse(str[0]);
            Ho = str[1];
            Ten = str[2];
            Phong = str[3];
            NhiemVu = str[4];
            Luong = int.Parse(str[5]);
            PhanTram = double.Parse(str[6]);

        }

        public string LayTenDayDu()
        {
            return $"{Ho} {Ten}";
        }

        public string LayThongTinChiTiet()
        {
            return $"{NhanVienID} {Phong}";
        }
        public string GanNhiemVu(string nhiemVu)
        {
            NhiemVu = nhiemVu;
            return $"{nhiemVu}";
        }
        public double TangLuong(double phantram)
        {
            PhanTram = phantram;
            return tangLuong =Luong + Luong * phantram / 100;
           
        }
        public override string ToString()
        {
            return string.Format($"{NhanVienID,-12}{Ho,-20}{Ten,-10}{Phong,-10}{GanNhiemVu(NhiemVu),-20}{Luong,-8}{PhanTram,-15}{TangLuong(PhanTram),-15}");
        }
        
    }
}

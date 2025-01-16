using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    public class NhanVien
    {
        public int MANV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public int MaCN { get; set; }
        public string HoTen
        {
            get { return $"{Ho} {Ten}"; }
        }
        public int SoNamLamViec
        {
            get { return DateTime.Now.Year - NgayVaoLam.Year; }
        }
        public NhanVien(int mANV, string ho, string ten, DateTime ngaySinh, DateTime ngayVaoLam, int maCN)
        {
            MANV = mANV;
            Ho = ho;
            Ten = ten;
            NgaySinh = ngaySinh;
            NgayVaoLam = ngayVaoLam;
            MaCN = maCN;
        }

        public NhanVien() { }
        public override string ToString()
        {
            return string.Format($"|{MANV,-10}|{Ho,-15}|{Ten,-7}|{NgaySinh,-25}|{NgayVaoLam,-25}|{MaCN,-5}|");
        }
    }
}

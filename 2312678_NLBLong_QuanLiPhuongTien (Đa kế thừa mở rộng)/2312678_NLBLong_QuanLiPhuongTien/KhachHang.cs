using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public class KhachHang
    {
        public string CCCD { get; set; }
        public string hoTen {  get; set; }
        public string DiaChi {  get; set; }
        public string ThanhPho {  get; set; }
        public string Tinh { get; set; }
        public List<IVehicle> soHuuXe {  get; set; }

        public KhachHang(string cCCD, string hoTen, string diaChi, string thanhPho, string tinh)
        {
            CCCD = cCCD;
            this.hoTen = hoTen;
            DiaChi = diaChi;
            ThanhPho = thanhPho;
            Tinh = tinh;
        }


        public override string ToString()
        {
            return string.Format($"CCCD:{CCCD}\n Họ Tên:{hoTen}\nĐịa chỉ:{DiaChi}-{ThanhPho}-{Tinh}");
        }


    }
}

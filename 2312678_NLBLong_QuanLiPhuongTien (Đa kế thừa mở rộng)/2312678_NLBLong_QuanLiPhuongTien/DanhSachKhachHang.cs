using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public class DanhSachKhachHang
    {
        List<KhachHang> collection = new List<KhachHang>();
        List<IVehicle> dsxe = new List<IVehicle>();

        public void Them(KhachHang kh)
        {
            collection.Add(kh);
        }

        public void NhapTuFile()
        {
            string tenFile = "data.txt";
            StreamReader sr = new StreamReader(tenFile);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string cccd = s[0];
                string hoTen = s[1];
                string diaChi = s[2];
                string thanhPho = s[3];
                string tinh = s[4];
                Them(new KhachHang(cccd, hoTen, diaChi,thanhPho,tinh));

            }
        }

         public override string ToString()
         {
            StringBuilder sb = new StringBuilder();
            
            foreach (var i in collection)
                sb.AppendLine(i +"\n");
            
            return sb.ToString();
         }

        
    }
}

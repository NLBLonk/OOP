using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    class Program
    {
        enum Menu
        {
            NhapTuFile=1,
            DemSoLuongTheoLoaiKetHop,
            TimPhuongTienTheoLoaiKetHop,
            TimCarCoSCNMaxVaMotorcycleCoTocDoMin,
            TimCarCoSCNMinVaMotorcycleCoTocDoMin,
            TimCarCoSCNMinVaMotorcycleCoTocDoMax,
            SapXep,
            TimPTCoGiaTriMAXMIN,
            Thoat
        }
        enum MenuSX
        { 
            TangDan =1,
            GiamDan
        }
        enum MenuLoaiDK
        {
            TheoTen=1,
            TheoSoChoNgoi,
            TheoTocDo,
            TheoTenVaTocDo,
            TheoTenVaSoChoNgoi,
            TheoTocDoVaSoChoNgoi,
            TheoTenTocDoVaSoChoNgoi
        }
        enum MenuLoaiPT
        {
            Motorcycle = 1,
            Car,
            AllVehicle,
            CarAndMotorcycle
        }
        enum MenuLoaiKH
        {
            LoaiPhuongTien=1,
            LoaiDieuKien,
            LoaiSosanh,
        }
        enum MenuMAXMIN
        { 
            Max=1, Min
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachKhachHang ds = new DanhSachKhachHang();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("===================Menu==================");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập danh sách khách hàng từ File");
                Console.WriteLine($"{(int)Menu.Thoat}.Thoát");
                Console.WriteLine("=========================================");
                Console.Write("Vui lòng nhập menu:");
                Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case Menu.NhapTuFile:
                        ds.NhapTuFile();
                        Console.WriteLine(ds);
                        break;
                   

                    default:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }    
        }
    }
}

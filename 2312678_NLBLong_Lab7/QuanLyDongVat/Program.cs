using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongVat
{
    class Program
    {
        enum Menu
        {
            NhapTuFile=1,
            DemSoLuongDongVat,
            DemSLBietBayVaKhongBietBay
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachDongVat ds = new DanhSachDongVat();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("======================MENU======================");
                Console.WriteLine($"{(int)Menu.NhapTuFile}. Nhập từ file");
                Console.WriteLine($"{(int)Menu.DemSoLuongDongVat}.Đếm số lượng động vật");
                Console.WriteLine($"{(int)Menu.DemSLBietBayVaKhongBietBay}.Đếm số lượng động vật biết bay và không biết bay");
                Console.WriteLine("================================================");
                Console.Write("Vui lòng nhập menu:");
                Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case Menu.NhapTuFile:
                        ds.DocFile();
                        Console.WriteLine(ds);
                        break;
                    case Menu.DemSoLuongDongVat:
                        ds.DocFile();
                        Console.WriteLine(ds);
                        Console.WriteLine("Số Lượng Dơi:" +ds.DemSoLuongDoi());
                        Console.WriteLine("Số Lượng Chim:" + ds.DemSoLuongChim());
                        Console.WriteLine("Số Lượng Sư Tử:" + ds.DemSoLuongSuTu());
                        break;
                    case Menu.DemSLBietBayVaKhongBietBay:
                        ds.DocFile();
                        Console.WriteLine(ds);
                        Console.WriteLine("Số Lượng động vật BIẾT BAY: "+ds.DemSoLuongBAY());
                        Console.WriteLine("Số Lượng động vật KO BIẾT BAY: " + ds.DemSoLuongKoBietBAY());
                        break;
                    default:
                        return;
                }
                Console.ReadKey();
            }
            
        }
    }
}

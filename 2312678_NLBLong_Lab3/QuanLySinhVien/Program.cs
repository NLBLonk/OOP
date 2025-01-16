using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            //SinhVien a1 = new SinhVien("001", "Bui Xuan Huan", 8.0, true, "CTK47A");
            //Console.WriteLine(a1);
            //SinhVien a2 = new SinhVien("210,Dang Hit Le, 6 ,Nam,CTK47B");
            //Console.WriteLine(a2);
            //SinhVien a3 = new SinhVien();
            //Console.WriteLine(a3);
            //SinhVien a4 = new SinhVien("619", "Le Thi Dinh Hieu", 8.0, false, "CTK47A");
            //Console.WriteLine(a4);
            //SinhVien a5 = new SinhVien("100", "Phuong My Chi", 9.5, false, "CTK47C");
            //Console.WriteLine(a5);
            //DanhSachSinhVien ds = new DanhSachSinhVien();
            //SinhVien sv = new SinhVien();
            //ds.NhapTuFile();
            ChayCT();
            Console.ReadKey();

        }
        public static void ChayCT()
        {
            DanhSachSinhVien ds= new DanhSachSinhVien();
            int chon,soMenu = 12;
            Menu menu = new Menu();

            do
            {
                Console.Clear();
                menu.XuatMenu();
                chon = menu.ChonMenu(soMenu);
                menu.XuLyMenu(chon);
            }while(chon!=0);
        }
    }
}

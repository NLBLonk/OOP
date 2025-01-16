using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class Menu
    {
        public void XuatMenu()
        {
            Console.WriteLine("==========================MENU===========================================");
            Console.WriteLine("0.Thoat chuong trinh");
            Console.WriteLine("1.Dem So Luong Sinh Vien Nam trong lop");
            Console.WriteLine("2.Dem so luong sinh vien Nu trong lop");
            Console.WriteLine("3.Hien thi danh sach sinh vien theo chieu tang, giam cua diem trung binh");
            Console.WriteLine("4.Tim danh sach sinh vien co diem trung binh cao nhat");
            Console.WriteLine("5.Tim lop co sinh vien co diem trung binh cao nhat");
            Console.WriteLine("6.Tim lop sinh vien KHONG co diem trung binh cao nhat");
            Console.WriteLine("7.Xep hang sinh vien theo lop");
            Console.WriteLine("8.Tim lop khong co sinh vien nam");
            Console.WriteLine("9.Tim lop khong co sinh vien nu");
            Console.WriteLine("10.Dem so luong sinh vien theo lop");
            Console.WriteLine("11. Xoa tat ca sinh vien cua lop nao do");
            Console.WriteLine("12. Xep loai sinh vien dua tren diem trung binh");
            Console.WriteLine("=========================================================================");
        }
        public int ChonMenu(int soMenu)
        {
            int chon;
            do
            {
                Console.Write("Chon chuc nang [0..."+ soMenu+"]=");
                chon = Convert.ToInt32(Console.ReadLine());
                if(0<=chon&&chon<=soMenu)
                    return chon;
            } while (true);
        }
        public void XuLyMenu(int chon)
        {
            Console.Clear();
            DanhSachSinhVien ds= new DanhSachSinhVien();
            SinhVien sv = new SinhVien();
            List<SinhVien> ds1 = new List<SinhVien>();
            List<string> kq;
            switch(chon)
            {
                
                case 1:
                    Console.WriteLine("1.Dem so luong sinh vien Nam trong lop");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    Console.Write("Nhap lop:");
                    sv.Lop = Console.ReadLine();
                    Console.WriteLine("So luong sv nam la:" + ds.DemSoLuongSVNam(sv.Lop));
                    break;
                case 2:
                    Console.WriteLine("2.Dem so luong sinh vien Nu trong lop");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    Console.Write("Nhap lop:");
                    sv.Lop = Console.ReadLine();
                    Console.WriteLine("So luong sv nu la:" + ds.DemSoLuongSVNu(sv.Lop));
                    break;
                case 3:
                    Console.WriteLine("3.Hien thi danh sach sinh vien theo chieu tang, giam cua diem trung binh");
                    Console.WriteLine("\n Danh sach truoc khi sap xep:");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    Console.WriteLine("\nDanh sach sau khi sap xep");
                    Console.WriteLine("\n Sap xep theo chieu tang cua diem trung binh:");
                    ds.SapXepTangTheoDTB();
                    Console.WriteLine(ds);
                    Console.WriteLine("\n Sap xep theo chieu giam cua diem trung binh:");
                    ds.SapXepGiamTheoDTB();
                    Console.WriteLine(ds);
                    break;
                case 4:
                    Console.WriteLine("4.Tim danh sach sinh vien co diem trung binh cao nhat");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    DanhSachSinhVien DTBCaoNhat = ds.TimDSSVCoDTBCaoNhat();
                    Console.WriteLine("\nSinh vien co DTB cao nhat:" + DTBCaoNhat);
                    break;
                case 5:
                    Console.WriteLine("5.Tim lop co sinh vien co diem trung binh cao nhat");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    kq = ds.TimLopCoDTBCaoNhat();
                    foreach (var i in kq)
                    {
                        Console.Write("Lop co DTB cao nhat:" + i);
                    }
                    break;
                case 6:
                    Console.WriteLine("6.Tim lop sinh vien KHONG co diem trung binh cao nhat");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    kq = ds.TimLopKhongCoDTBCaoNhat();
                    foreach (var i in kq)
                    {
                        Console.WriteLine("Lop ko co DTB cao nhat:" + i);
                    }
                    break;
                case 7:
                    Console.WriteLine("7.Xep hang sinh vien theo lop");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    Console.Write("Vui long nhap lop:");
                    sv.Lop = Console.ReadLine();
                    ds1 = ds.XepHangTheoLop(sv.Lop);
                    if (ds1.Count == 0)
                    {
                        Console.WriteLine("\nDanh sach lop {0} khong ton tai", sv.Lop);
                    }
                    else
                    {
                        Console.WriteLine("\nDanh sach lop {0} sau khi xep hang sinh vien theo lop la:", sv.Lop);
                        ds.Xuat();
                    }
                    break;
                case 8:
                    Console.WriteLine("8.Tim lop khong co sinh vien nam");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    var LopKoNam = ds.LopKoCoSVNam();
                    if (LopKoNam.Count == 0)
                        Console.WriteLine("Khong co lop nao khong co sinh vien nam");
                    else
                    {
                        Console.Write("Cac lop khong co sinh vien nam la: ");
                        foreach (var i in LopKoNam)
                        {
                            Console.Write($"{i} ");
                        }
                    }
                    break;
                case 9:
                    Console.WriteLine("9.Tim lop khong co sinh vien nu");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    var LopKoNu = ds.LopKoCoSVNu();
                    if (LopKoNu.Count == 0)
                        Console.WriteLine("Khong co lop nao khong co sinh vien nu");
                    else
                    {
                        Console.Write("Cac lop khong co sinh vien nu la: ");
                        foreach (var i in LopKoNu)
                        {
                            Console.Write($"{i} ");
                        }
                    }
                    break;
                case 10:
                    Console.WriteLine("10.Dem so luong sinh vien theo lop");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    var lops = ds.DanhSachSVTheoLop();
                    var soLuongSV = ds.DemSoLuongSVTheoLop();
                    for (int i = 0; i < lops.Count; i++)
                    {
                        Console.WriteLine($"Lop {lops[i]} co {soLuongSV[i]} sinh vien.");
                    }
                    break;
                case 11:
                    Console.WriteLine("11. Xoa tat ca sinh vien cua lop nao do");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    Console.Write("Nhap ten lop can xoa: ");
                    sv.Lop = Console.ReadLine();
                    ds.XoaSVCuaLop(sv.Lop);
                    Console.WriteLine($"Da xoa tat ca sinh vien cua lop {sv.Lop}");
                    Console.WriteLine(ds);
                    break;
                case 12:
                    Console.WriteLine("12. Xep loai sinh vien dua tren diem trung binh");
                    ds.NhapTuFile();
                    Console.WriteLine(ds);
                    ds.HienThiXepLoaiSinhVien();
                    break;
                default:
                    Console.WriteLine("Thoat chuong trinh");
                    Environment.Exit(0);
                    break;
            }
            Console.ReadKey();
        }
    }
}

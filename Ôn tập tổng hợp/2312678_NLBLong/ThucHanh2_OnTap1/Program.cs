using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_OnTap1
{
    enum Menu
    {
        NhapTuFile=1,
        NhapThuCong,
        TimTheoTuaDe,TimTheoTacgia,XoaTheoTuaDe,XoaTheoTacGia,
        TimTheoTap,TimTheoSo,XoaTheoTap,XoaTheoSo,
        TimTheoNam,TimTheoNXB,XoaTheoNam,XoaTheoNXB,
        TimTheoISBN,XoaTheoISBN,
        TangTheoTuaDe,GiamTheoTuaDe,
        TangTheoNam,GiamTheoNam,
        TangTheoNXB,GiamTheoNXB,
        TangTheoTap,GiamTheoTap,
        TangTheoSo,GiamTheoSo,
        TangTheoISBN,GiamTheoISBN,
        TangTheoTacGia,GiamTheoTacGia,
        Thoat =0
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = new UTF8Encoding();
            Console.OutputEncoding = new UTF8Encoding();
            DanhSachAnPham ds = new DanhSachAnPham();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("================MENU==============");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập Từ File");
                Console.WriteLine($"{(int)Menu.NhapThuCong}.Nhập Thủ Công");
                Console.WriteLine($"{(int)Menu.TimTheoTuaDe}.Tìm kiếm theo TỰA ĐỀ");
                Console.WriteLine($"{(int)Menu.TimTheoTacgia}.Tìm kiếm theo TÁC GIẢ");
                Console.WriteLine($"{(int)Menu.XoaTheoTuaDe}.Xóa theo TỰA ĐỀ");
                Console.WriteLine($"{(int)Menu.XoaTheoTacGia}.Xóa theo TÁC GIẢ");
                Console.WriteLine($"{(int)Menu.TimTheoTap}.Tìm kiếm theo TẬP");
                Console.WriteLine($"{(int)Menu.TimTheoSo}.Tìm kiếm theo SỐ");
                Console.WriteLine($"{(int)Menu.XoaTheoTap}.Xóa theo TẬP");
                Console.WriteLine($"{(int)Menu.XoaTheoSo}.Xóa theo SỐ");
                Console.WriteLine($"{(int)Menu.TimTheoNam}.Tìm kiếm theo Năm");
                Console.WriteLine($"{(int)Menu.TimTheoNXB}.Tìm kiếm theo NXB");
                Console.WriteLine($"{(int)Menu.XoaTheoNam}.Xóa theo Năm");
                Console.WriteLine($"{(int)Menu.XoaTheoNXB}.Xóa theo NXB");
                Console.WriteLine($"{(int)Menu.TimTheoISBN}.Tìm kiếm theo ISBN");
                Console.WriteLine($"{(int)Menu.XoaTheoISBN}.Xóa theo ISBN");
                Console.WriteLine($"{(int)Menu.TangTheoTuaDe}.Tăng theo tựa đề");
                Console.WriteLine($"{(int)Menu.GiamTheoTuaDe}.Giảm theo tựa đề");
                Console.WriteLine($"{(int)Menu.TangTheoNam}.Tăng theo năm");
                Console.WriteLine($"{(int)Menu.GiamTheoNam}.Giảm theo năm");
                Console.WriteLine($"{(int)Menu.TangTheoNXB}.Tăng theo NXB");
                Console.WriteLine($"{(int)Menu.GiamTheoNXB}.Giảm theo NXB");
                Console.WriteLine($"{(int)Menu.TangTheoTap}.Tăng theo Tập");
                Console.WriteLine($"{(int)Menu.GiamTheoTap}.Giảm theo Tập");
                Console.WriteLine($"{(int)Menu.TangTheoSo}.Tăng theo Số");
                Console.WriteLine($"{(int)Menu.GiamTheoSo}.Giảm theo Số");
                Console.WriteLine($"{(int)Menu.TangTheoISBN}.Tăng theo ISBN");
                Console.WriteLine($"{(int)Menu.GiamTheoISBN}.Giảm theo ISBN");
                Console.WriteLine($"{(int)Menu.TangTheoTacGia}.Tăng theo Tác giả");
                Console.WriteLine($"{(int)Menu.GiamTheoTacGia}.Giảm theo Tác giả");
                Console.WriteLine($"{(int)Menu.Thoat}.Thoát");
                Console.WriteLine("===================================");
                Console.Write("Vui lòng nhập số trong menu:"); Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case Menu.NhapTuFile:
                        ds.NhapTuFile();
                        Console.WriteLine(ds);
                        break;
                    case Menu.NhapThuCong:
                        ds.NhapThuCong();
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoTuaDe:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập tựa đề cần tìm:");
                        string tuaDe = Console.ReadLine();
                        Console.WriteLine(ds.TimTheoTen(tuaDe));
                        break;
                    case Menu.TimTheoTacgia:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tác giả cần tìm:");
                        string tacGia = Console.ReadLine();
                        Console.WriteLine(ds.TimTheoTacGia(tacGia));
                        break;
                    case Menu.XoaTheoTuaDe:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập tựa đề cần XÓA:");
                        tuaDe = Console.ReadLine();
                        ds.XoaTheoTuaDe(tuaDe);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.XoaTheoTacGia:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tác Gỉa cần XÓA:");
                        tacGia = Console.ReadLine();
                        ds.XoaTheoTacGia(tacGia);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoTap:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tập cần tìm:");
                        int Tap = int.Parse(Console.ReadLine());
                        Console.WriteLine(ds.TimTheoTap(Tap));
                        break;
                    case Menu.XoaTheoTap:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tập cần XÓA:");
                        Tap = int.Parse(Console.ReadLine());
                        ds.XoaTheoTap(Tap);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoSo:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần tìm:");
                        int so = int.Parse(Console.ReadLine());
                        Console.WriteLine(ds.TimTheoSo(so));
                        break;
                    case Menu.XoaTheoSo:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần XÓA:");
                        so = int.Parse(Console.ReadLine());
                        ds.XoaTheoSo(so);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoNam:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tập cần tìm:");
                        int nam = int.Parse(Console.ReadLine());
                        Console.WriteLine(ds.TimTheoNam(nam));
                        break;
                    case Menu.XoaTheoNam:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập Tập cần XÓA:");
                        nam = int.Parse(Console.ReadLine());
                        ds.XoaTheoNam(nam);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoNXB:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần tìm:");
                        string NXB = Console.ReadLine();
                        Console.WriteLine(ds.TimTheoNXB(NXB));
                        break;
                    case Menu.XoaTheoNXB:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần XÓA:");
                        NXB = Console.ReadLine();
                        ds.XoaTheoNXB(NXB);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimTheoISBN:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần tìm:");
                        string ISBN = Console.ReadLine();
                        Console.WriteLine(ds.TimTheoISBN(ISBN));
                        break;
                    case Menu.XoaTheoISBN:
                        Console.WriteLine(ds);
                        Console.Write("Vui lòng nhập SỐ cần XÓA:");
                        ISBN = Console.ReadLine();
                        ds.XoaTheoISBN(ISBN);
                        Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                        Console.WriteLine(ds);
                        break;
                    case Menu.TangTheoTuaDe:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoTuaDe(); Console.WriteLine(ds);
                        break;
                    case Menu.GiamTheoTuaDe:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTuaDe(); Console.WriteLine(ds);
                        break;
                    case Menu.TangTheoNam:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoNam(); Console.WriteLine(ds);
                        break;
                    case Menu.GiamTheoNam:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoNam(); Console.WriteLine(ds);
                        break;
                    case Menu.TangTheoNXB:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoNXB(); Console.WriteLine(ds);
                        break;
                    case Menu.GiamTheoNXB:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoNXB(); Console.WriteLine(ds); break;
                    case Menu.TangTheoTap:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi()); 
                        Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoTap(); Console.WriteLine(ds.LayDSTapChi());
                        break;
                    case Menu.GiamTheoTap:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi());
                        Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTap(); Console.WriteLine(ds.LayDSTapChi());
                        break;
                    case Menu.TangTheoSo:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi());
                        Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoSo(); Console.WriteLine(ds.LayDSTapChi());
                        break;
                    case Menu.GiamTheoSo:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi());
                        Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoSo(); Console.WriteLine(ds.LayDSTapChi());
                        break;
                    case Menu.TangTheoISBN:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDScuaSach());
                        Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoISBN(); Console.WriteLine(ds.LayDScuaSach());
                        break;
                    case Menu.GiamTheoISBN:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi());
                        Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoISBN(); Console.WriteLine(ds.LayDScuaSach());
                        break;
                    case Menu.TangTheoTacGia:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDScuaSach());
                        Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoISBN(); Console.WriteLine(ds.LayDScuaSach());
                        break;
                    case Menu.GiamTheoTacGia:
                        Console.WriteLine("Trước khi sắp xếp"); Console.WriteLine(ds.LayDSTapChi());
                        Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoISBN(); Console.WriteLine(ds.LayDScuaSach());
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

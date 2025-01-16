using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    internal class Program
    {
        enum Menu
        {
            TruyVanLuaChon = 1,
            TruyVanLong,
            TruyVanGom,
            CapNhatDuLieu,
            Thoat
        }
        enum TruyVanLuaChon
        {
            HienThi = 1,
            LietKeTheoChiNhanh,
            LietKeNhanVienWord,
            LietKeLeAnhTuan,
            Thoat
        }
        enum TruyVanLong
        {
            LietKeNhanVienThanhThaoExcelCaoNhat = 1,
            LietKeNhanVienWordVaExcel,
            LietKeNhanVienThanhThaoNhatCuaTungKyNang,
            LietKeChiNhanhMaMoiNhanVienBietWord,
            Thoat
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachNhanVien ds = new DanhSachNhanVien();
            ds.NhapTuFile();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================MENU=================");
                Console.WriteLine($"Nhập {(int)Menu.TruyVanLuaChon} để vào menu truy vấn lựa chọn ");
                Console.WriteLine($"Nhập {(int)Menu.TruyVanLong} để vào menu truy vấn lồng");
                Console.WriteLine($"Nhập {(int)Menu.TruyVanGom} để vào menu gom nhóm dữ liệu");
                Console.WriteLine($"Nhập {(int)Menu.CapNhatDuLieu} để vào menu cập nhật");
                Console.WriteLine($"Nhập {(int)Menu.Thoat} để thoát");
                Console.WriteLine("======================================");
                Console.Write("Chọn menu: ");
                Menu chon = (Menu)int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (chon)
                {
                    case Menu.TruyVanLuaChon:
                        Console.Clear();
                        Console.WriteLine("================================MENU================================");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.HienThi} để hiển thị mã số nhân viên, họ tên, số năm làm việc");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.LietKeTheoChiNhanh} để liệt kê các thông tin về nhân viên");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.LietKeNhanVienWord} để liệt kê các thông tin về nhân viên biết sử dụng word");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.LietKeLeAnhTuan} để liệt kê các kỹ năng mà nhân viên Lê Anh Tuấn biết sử dụng");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.Thoat} để thoát");
                        Console.WriteLine("====================================================================");
                        Console.Write("Chọn menu: ");
                        TruyVanLuaChon chon1 = (TruyVanLuaChon)int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        switch (chon1)
                        {
                            case TruyVanLuaChon.HienThi:
                                Console.WriteLine(ds);
                                Console.WriteLine("Danh sách sau khi hiển thị là: ");
                                Console.WriteLine(ds.HienThiNhanVien());
                                break;

                            case TruyVanLuaChon.LietKeTheoChiNhanh:
                                Console.WriteLine(ds);
                                Console.Write("Nhập mã chi nhánh: ");
                                int maCN = int.Parse(Console.ReadLine());
                                Console.WriteLine($"\nDanh sách sau khi liệt kê mã chi nhánh {maCN} là: ");
                                Console.WriteLine(ds.TimTheoChiNhanh(maCN));
                                break;

                            case TruyVanLuaChon.LietKeNhanVienWord:
                                Console.WriteLine(ds);
                                Console.WriteLine("\nDanh sách sau khi liệt kê nhân viên biết sử dụng Word là: ");
                                Console.WriteLine(ds.LietKeNhanVienWord());
                                break;

                            case TruyVanLuaChon.LietKeLeAnhTuan:
                                Console.WriteLine(ds);
                                Console.WriteLine("\nNhững kỹ năng mà nhân viên 'Le Anh Tuan' biết sử dụng là: ");
                                ds.LietKeKyNangLeAnhTuan();
                                break;

                            default:
                                return;
                        }
                        break;

                    case Menu.TruyVanLong:
                        Console.Clear();
                        Console.WriteLine("================================MENU================================");
                        Console.WriteLine($"Nhập {(int)TruyVanLong.LietKeNhanVienThanhThaoExcelCaoNhat} để liệt kê nhân viên thành thạo excel nhất trong công ty");
                        Console.WriteLine($"Nhập {(int)TruyVanLong.LietKeNhanVienWordVaExcel} để liệt kê nhân viên vừa biết sử dụng Word vừa biết sử dụng Excel");
                        Console.WriteLine($"Nhập {(int)TruyVanLong.LietKeNhanVienThanhThaoNhatCuaTungKyNang} để liệt kê nhân viên thành thạo nhất của từng kỹ năng");
                        Console.WriteLine($"Nhập {(int)TruyVanLong.LietKeChiNhanhMaMoiNhanVienBietWord} để liệt kê chi nhánh mà mọi nhân viên biết sử dụng Word");
                        Console.WriteLine($"Nhập {(int)TruyVanLuaChon.Thoat} để thoát");
                        Console.WriteLine("====================================================================");
                        Console.Write("Chọn menu: ");
                        TruyVanLong chon2 = (TruyVanLong)int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        switch (chon2)
                        {
                            case TruyVanLong.LietKeNhanVienThanhThaoExcelCaoNhat:
                                Console.WriteLine(ds);
                                Console.WriteLine("\nCác nhân viên có mức độ thành thạo về Excel cao nhất trong công ty với mức độ thành thạo là: " + ds.MucDoExcelCaoNhat());
                                Console.WriteLine(ds.TimNhanVienMucDoExcelCaoNhat());
                                break;

                            case TruyVanLong.LietKeNhanVienWordVaExcel:
                                Console.WriteLine(ds);
                                Console.WriteLine("\nDanh sách liệt kê nhưng nhân viên biết sử dụng cả Word là Excel:");
                                Console.WriteLine(ds.LietKeNhanVienWordAndExcel());
                                break;

                            case TruyVanLong.LietKeNhanVienThanhThaoNhatCuaTungKyNang:
                                Console.WriteLine(ds);
                                Console.WriteLine("Danh sách liệt kê nhưng nhân viên thành thạo nhất theo từng kỹ năng");
                                ds.LietKeNhanVienKyNangMax();
                                break;

                            case TruyVanLong.LietKeChiNhanhMaMoiNhanVienBietWord:
                                Console.WriteLine(ds);
                                break;

                            default:
                                return;
                        }
                        break;
                    case Menu.TruyVanGom:
                        break;
                    case Menu.CapNhatDuLieu:
                        break;
                    default:
                        return;
                }
                Console.WriteLine("\nBấm 1 phím bất kỳ để thoát");
                Console.ReadKey();
            }
        }
    }
}
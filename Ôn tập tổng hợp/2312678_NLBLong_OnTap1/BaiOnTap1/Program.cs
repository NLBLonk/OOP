using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap1
{
    enum SX { Giam=1,Tang }
    enum LoaiDieuKien
    {
        TheoTen=1,
        TheoDiaChi,
        TheoTuoi,
        TheoLuong,
        TheoMaNVQL,
        TheoViTri,
        TheoPhong
    }

    enum Menu
    {
        NhapThuCong=1,
        NhapTuFile,
        TimKiem,
        Xoa,
        SapXep,
        Them,
        Thoat=0
    }
    class Program
    {
        static void Main(string[] args)
        {
          Console.OutputEncoding = new UTF8Encoding();
          Console.InputEncoding = new UTF8Encoding();
          QuanLyNhanVien ds = new QuanLyNhanVien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================MENU=====================");
                Console.WriteLine($"{(int)Menu.NhapThuCong}.Nhập Thủ Công");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập Từ File");
                Console.WriteLine($"{(int)Menu.TimKiem}.Tìm kiếm");
                Console.WriteLine($"{(int)Menu.Xoa}.Xóa");
                Console.WriteLine($"{(int)Menu.SapXep}.Sắp Xếp");
                Console.WriteLine($"{(int)Menu.Them}.Thêm");
                Console.WriteLine($"{(int)Menu.Thoat}.Thoát");
                Console.WriteLine("==============================================");
                Console.Write("Vui lòng nhập số:");
                Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case Menu.NhapTuFile:
                        ds.NhapTuFile();
                        Console.WriteLine(ds);
                        break;
                    case Menu.NhapThuCong:
                        Console.Clear();
                        ds.NhapThuCong();
                        Console.WriteLine(ds);
                        break;
                    case Menu.TimKiem:
                        Console.Clear();
                        Console.WriteLine("======================Tìm kiếm==================");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Tìm theo tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoDiaChi}.Tìm theo Địa chỉ");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTuoi}.Tìm theo tuổi");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Tìm theo lương");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoMaNVQL}.Tìm theo Mã");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoViTri}.Tìm theo vị trí");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Tìm theo phòng");
                        Console.WriteLine("================================================");
                        Console.WriteLine("Danh Sách"); Console.WriteLine(ds);
                        Console.Write("Nhập số:"); LoaiDieuKien chonsearch = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        switch (chonsearch)
                        {
                            case LoaiDieuKien.TheoTen:
                                Console.Write("Vui lòng nhập tên:");
                                string ten = Console.ReadLine();
                                Console.WriteLine(ds.TimTheoTen(ten));
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.Write("Vui lòng nhập Lương:");
                                decimal luong = decimal.Parse(Console.ReadLine());
                                Console.WriteLine(ds.TimTheoLuong(luong));
                                break;
                            case LoaiDieuKien.TheoDiaChi:
                                Console.Write("Vui lòng nhập địa chỉ:");
                                string diachi = Console.ReadLine();
                                Console.WriteLine(ds.TimTheoDiaChi(diachi));
                                break;
                            case LoaiDieuKien.TheoTuoi:
                                Console.Write("Vui lòng nhập tuổi:");
                                int tuoi = int.Parse(Console.ReadLine());
                                Console.WriteLine(ds.TimTheoTuoi(tuoi));
                                break;
                            case LoaiDieuKien.TheoMaNVQL:
                                Console.Write("Vui lòng nhập mã:");
                                string ma = Console.ReadLine();
                                Console.WriteLine(ds.TimTheoMa(ma));
                                break;
                            case LoaiDieuKien.TheoViTri:
                                Console.Write("Vui lòng nhập Vị trí:");
                                string vitri = Console.ReadLine();
                                Console.WriteLine(ds.TimTheoViTri(vitri));
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.Write("Vui lòng nhập phòng:");
                                string phòng = Console.ReadLine();
                                Console.WriteLine(ds.TimTheoPhong(phòng));
                                break;
                        }
                        break;
                    case Menu.Xoa:
                        Console.Clear();
                        Console.WriteLine("=======================Xóa======================");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Tìm theo tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoDiaChi}.Tìm theo Địa chỉ");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTuoi}.Tìm theo tuổi");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Tìm theo lương");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoMaNVQL}.Tìm theo Mã");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoViTri}.Tìm theo vị trí");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Tìm theo phòng");
                        Console.WriteLine("================================================");
                        Console.WriteLine("Danh Sách"); Console.WriteLine(ds);
                        Console.Write("Nhập số:"); LoaiDieuKien xoa = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        switch (xoa)
                        {
                            case LoaiDieuKien.TheoTen:
                                Console.Write("Nhập tên cần xóa:");
                                string ten = Console.ReadLine();
                                Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                                ds.XoaTheoTen(ten); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoDiaChi:
                                Console.Write("Vui lòng nhập địa chỉ cần xóa:");
                                string diachi = Console.ReadLine();
                                Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                                ds.XoaTheoDiaChi(diachi); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoTuoi:
                                Console.Write("Vui lòng nhập tuổi cần xóa:");
                                int tuoi = int.Parse(Console.ReadLine());
                                Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                                ds.XoaTheoTuoi(tuoi); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.Write("Vui lòng nhập Lương cần xóa:");
                                decimal luong = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("KẾT QUẢ: ĐÃ XÓA");
                                ds.XoaTheoLuong(luong); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoMaNVQL:
                                Console.Write("Vui lòng nhập mã cần xóa:");
                                string ma = Console.ReadLine();
                                ds.XoaTheoMa(ma); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoViTri:
                                Console.Write("Vui lòng nhập Vị trí cần xóa:");
                                string vitri = Console.ReadLine();
                                ds.XoaTheoViTri(vitri); Console.WriteLine(ds);
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.Write("Vui lòng nhập phòng cần xóa:");
                                string phòng = Console.ReadLine();
                                ds.XoaTheoPhong(phòng); Console.WriteLine(ds);
                                break;

                        }
                        break;
                    case Menu.SapXep:
                        Console.Clear();
                        Console.WriteLine("=======================Sắp Xếp==================");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Tìm theo tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoDiaChi}.Tìm theo Địa chỉ");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTuoi}.Tìm theo tuổi");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Tìm theo lương của nhân viên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoMaNVQL}.Tìm theo Mã của nhân viên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoViTri}.Tìm theo vị trí nhân viên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Tìm theo phòng");
                        Console.WriteLine("================================================");
                        Console.WriteLine("Danh Sách trước khi sắp xếp"); Console.WriteLine(ds);
                        Console.Write("Nhập số:");
                        LoaiDieuKien sx = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        switch (sx)
                        {

                            case LoaiDieuKien.TheoTen:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); SX tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch(tanggiam)
                                {
                                    case SX.Tang:
                                        Console.WriteLine("Sau khi sắp xếp:"); ds.TangTheoTen(); Console.WriteLine(ds); break;
                                    case SX.Giam:
                                        Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTen(); Console.WriteLine(ds); break;
                                }    
                                break;
                            case LoaiDieuKien.TheoDiaChi:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch(tanggiam)
                                {   
                                    case SX.Tang: Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoDiaChi(); Console.WriteLine(ds); break;
                                    case SX.Giam: Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoDiaChi(); Console.WriteLine(ds); break;
                                }
                                break;
                            case LoaiDieuKien.TheoTuoi:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch (tanggiam)
                                {
                                    case SX.Tang: Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoTuoi(); Console.WriteLine(ds); break;
                                    case SX.Giam: Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTuoi(); Console.WriteLine(ds); break;
                                }
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch (tanggiam)
                                {
                                    case SX.Tang: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoLuongCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                    case SX.Giam: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoLuongCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                }
                                break;
                            case LoaiDieuKien.TheoMaNVQL:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch (tanggiam)
                                {
                                    case SX.Tang: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoMaCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                    case SX.Giam: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoMaCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                }
                                break;
                            case LoaiDieuKien.TheoViTri:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch (tanggiam)
                                {
                                    case SX.Tang: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoViTriCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                    case SX.Giam: Console.WriteLine(ds.DSNhanVien()); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoViTriCuaNhanVien(); Console.WriteLine(ds.DSNhanVien()); break;
                                }
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.WriteLine("=================");
                                Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                                Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                                Console.WriteLine("=================");
                                Console.Write("Vui lòng nhập số để chọn sắp xếp:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                                switch (tanggiam)
                                {
                                    case SX.Tang: Console.WriteLine(ds.DSQuanLy()); Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoPhong(); Console.WriteLine(ds.DSQuanLy()); break;
                                    case SX.Giam: Console.WriteLine(ds.DSQuanLy()); Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoPhong(); Console.WriteLine(ds.DSQuanLy()); break;
                                }
                                break;

                        }

                        break;
                    case Menu.Them:
                        Console.WriteLine(ds);
                        Console.Write("Bạn có muốn thêm nhân viên vào vị trí cụ thể không? (y/n): ");
                        string traLoi = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        if (traLoi == "y")
                        {
                            Console.Write("Nhập thể loại(Nguoi/NhanVien/QuanLy): ");
                            string loai = Console.ReadLine().ToLower();
                            Nguoi nguoi = null;
                            if (loai == "nguoi")
                            {
                                Console.Write("Nhập địa chỉ: ");
                                string diachi = Console.ReadLine();
                                Console.Write("Nhập tên: ");
                                string ten = Console.ReadLine();
                                Console.Write("Nhập tuổi: ");
                                int tuoi = int.Parse(Console.ReadLine());
                                nguoi = new Nguoi(diachi, ten, tuoi);
                            }
                            else if (loai == "nhanvien")
                            {
                                Console.Write("Nhập địa chỉ: ");
                                string diachi = Console.ReadLine();
                                Console.Write("Nhập tên: ");
                                string ten = Console.ReadLine();
                                Console.Write("Nhập tuổi: ");
                                int tuoi = int.Parse(Console.ReadLine());
                                Console.Write("Nhập lương: ");
                                decimal luong = decimal.Parse(Console.ReadLine());
                                Console.Write("Nhập mã số nhân viên: ");
                                string maso = Console.ReadLine();
                                Console.Write("Nhập vị trí: ");
                                string vitri = Console.ReadLine();
                                nguoi = new NhanVien(diachi, ten, tuoi, luong, maso, vitri);
                            }
                            else if (loai == "quanly")
                            {
                                Console.Write("Nhập địa chỉ: ");
                                string diachi = Console.ReadLine();
                                Console.Write("Nhập tên: ");
                                string ten = Console.ReadLine();
                                Console.Write("Nhập tuổi: ");
                                int tuoi = int.Parse(Console.ReadLine());
                                Console.Write("Nhập lương: ");
                                decimal luong = decimal.Parse(Console.ReadLine());
                                Console.Write("Nhập mã số nhân viên: ");
                                string maso = Console.ReadLine();
                                Console.Write("Nhập vị trí: ");
                                string vitri = Console.ReadLine();
                                Console.Write("Nhập phòng: ");
                                string phong = Console.ReadLine();
                                nguoi = new QuanLy(diachi, ten, tuoi, luong, maso, vitri, phong);
                            }
                            else
                            {
                                Console.WriteLine($"Loại {loai} không hợp lệ! ");
                            }

                            if (nguoi != null)
                            {
                                Console.Write("\nNhập vị trí muốn thêm: ");
                                int viTri = int.Parse(Console.ReadLine());
                                ds.ThemVaoViTri(nguoi, viTri);
                            }
                        }
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

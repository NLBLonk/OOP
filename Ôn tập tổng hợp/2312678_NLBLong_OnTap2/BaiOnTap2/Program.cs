using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap2
{
    internal class Program
    {
        enum Menu { NhapTuFile=1,NhapThuCong,TimKiem,SapXep,Them,Xoa,TinhTongSoLuongCuaNhanVien,CapNhat,Thoat=0}
        enum LoaiDieuKien { TheoID=1,TheoTen,TheoPhong,TheoLuong}
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachNhanVien ds = new DanhSachNhanVien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============MENU==============");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập từ file");
                Console.WriteLine($"{(int)Menu.NhapThuCong}.Nhập thủ công");
                Console.WriteLine($"{(int)Menu.TimKiem}.Tìm kiếm");
                Console.WriteLine($"{(int)Menu.SapXep}.Sắp xếp");
                Console.WriteLine($"{(int)Menu.Them}.Thêm vào vị trí");
                Console.WriteLine($"{(int)Menu.Xoa}.Xóa");
                Console.WriteLine($"{(int)Menu.TinhTongSoLuongCuaNhanVien}.Tính tổng số lương của nhân viên");
                Console.WriteLine($"{(int)Menu.CapNhat}.Cập Nhật");
                Console.WriteLine($"{(int)Menu.Thoat}.Thoát");
                Console.WriteLine("================================");
                Console.Write("Chọn số trong menu:"); Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case Menu.NhapTuFile:
                        ds.DocTuFile();
                        ds.Xuat();
                        break;
                    case Menu.NhapThuCong:
                        ds.NhapThuCong();
                        ds.Xuat();
                        break;
                    case Menu.TimKiem:
                        Console.WriteLine("============TÌM KIẾM===========");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoID}.Theo ID");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Theo Tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Theo phòng");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Theo lương");
                        Console.WriteLine("================================");
                        Console.WriteLine("Vui lòng nhập số: "); LoaiDieuKien timkiem = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        ds.Xuat();
                        switch(timkiem)
                        {
                            case LoaiDieuKien.TheoID:
                                Console.Write("Vui lòng nhập ID cần tìm: ");
                                int id = int.Parse(Console.ReadLine());
                                var kq = ds.TimTheoID(id); kq.Xuat();
                                break;
                            case LoaiDieuKien.TheoTen:

                                Console.Write("Vui lòng nhập tên cần tìm: ");
                                string ten = Console.ReadLine();
                                kq = ds.TimTheoTen(ten); kq.Xuat();
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.Write("Vui lòng nhập phòng cần tìm: ");
                                string phong = Console.ReadLine();
                                kq = ds.TimTheoPhong(phong); kq.Xuat();
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.Write("Vui lòng nhập lương cần tìm: ");
                                double luong = double.Parse(Console.ReadLine());
                                kq = ds.TimTheoLuong(luong); kq.Xuat();
                                break;
                        }    
                        break;
                    case Menu.SapXep:
                        Console.WriteLine("============SẮP XẾP===========");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoID}.Theo ID");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Theo Tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Theo phòng");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Theo lương");
                        Console.WriteLine("================================");
                        Console.WriteLine("Vui lòng nhập số: "); LoaiDieuKien tanggiam = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        Console.WriteLine("Trước khi sắp sếp"); ds.Xuat();
                        switch (tanggiam)
                        {
                            case LoaiDieuKien.TheoID:
                                Console.WriteLine("Sau khi sắp xếp"+"\n"); Console.WriteLine("Sắp xếp Tăng dần theo ID"); ds.TangTheoTen(); ds.Xuat();
                                Console.WriteLine("Sắp xếp Giảm dần theo ID"); ds.GiamTheoID(); ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoTen:
                                Console.WriteLine("Sau khi sắp xếp" + "\n"); Console.WriteLine("Sắp xếp Tăng dần theo tên"); ds.TangTheoTen(); ds.Xuat();
                                Console.WriteLine("Sắp xếp Giảm dần theo tên"); ds.GiamTheoTen(); ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.WriteLine("Sau khi sắp xếp" + "\n"); Console.WriteLine("Sắp xếp Tăng dần theo phòng"); ds.TangTheoPhong(); ds.Xuat();
                                Console.WriteLine("Sắp xếp Giảm dần theo phòng"); ds.GiamTheoPhong(); ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.WriteLine("Sau khi sắp xếp" + "\n"); Console.WriteLine("Sắp xếp Tăng dần theo lương"); ds.TangTheoLuong(); ds.Xuat();
                                Console.WriteLine("Sắp xếp Giảm dần theo lương"); ds.GiamTheoLuong(); ds.Xuat();
                                break;

                        }
                        break;
                    case Menu.Xoa:
                        Console.WriteLine("==============XÓA===============");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoID}.Theo ID");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoTen}.Theo Tên");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoPhong}.Theo phòng");
                        Console.WriteLine($"{(int)LoaiDieuKien.TheoLuong}.Theo lương");
                        Console.WriteLine("================================");
                        ds.Xuat();
                        Console.WriteLine("Vui lòng nhập số: "); LoaiDieuKien xoa = (LoaiDieuKien)int.Parse(Console.ReadLine());
                        switch (xoa)
                        {
                            case LoaiDieuKien.TheoID:
                                Console.Write("Vui lòng nhập ID cần xóa: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Kết quả: Đã xóa {id}");
                                ds.XoaTheoID(id);   ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoTen:
                                Console.Write("Vui lòng nhập tên cần xóa: ");
                                string ten = Console.ReadLine();
                                Console.WriteLine($"Kết quả: Đã xóa {ten}");
                                ds.XoaTheoTen(ten); ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoPhong:
                                Console.Write("Vui lòng nhập phòng cần xóa: ");
                                string phong = Console.ReadLine();
                                Console.WriteLine($"Kết quả: Đã xóa {phong}");
                                ds.XoaTheoPhong(phong); ds.Xuat();
                                break;
                            case LoaiDieuKien.TheoLuong:
                                Console.Write("Vui lòng nhập lương cần xóa: ");
                                double luong = double.Parse(Console.ReadLine());
                                Console.WriteLine($"Kết quả: Đã xóa {luong}");
                                ds.XoaTheoLuong(luong); ds.Xuat();
                                break;
                        }
                        break;
                    case Menu.TinhTongSoLuongCuaNhanVien:
                        ds.Xuat();
                        Console.WriteLine("Tổng số Lương của Nhân viên là "+ds.TinhTongLuong());
                        Console.WriteLine("Tổng số Lương đã tăng cho Nhân viên là "+ds.TinhTongLuongDaTang());
                        break;
                    case Menu.Them:
                        ds.Xuat(); Console.Write("Nhập vị trí muốn thêm: ");
                        int viTri = int.Parse(Console.ReadLine());
                        if (ds.KiemTra(viTri))
                        {
                            Console.Write("\nNhập ID của nhân viên: ");
                            int ma = int.Parse(Console.ReadLine());
                            Console.Write("Nhập họ: ");
                            string ho = Console.ReadLine();
                            Console.Write("Nhập tên: ");
                            string ten = Console.ReadLine();
                            Console.Write("Nhập phòng: ");
                            string phong = Console.ReadLine();
                            Console.Write("Nhập công việc nhiệm vụ: ");
                            string nhiemvu = Console.ReadLine();
                            Console.Write("Nhập lương: ");
                            double luong = double.Parse(Console.ReadLine());
                            var NguoiMoi = new QuanLy(ho, ten, ma, phong, nhiemvu, luong);
                            ds.Them(viTri, NguoiMoi);
                            Console.WriteLine("\nDanh sách sau khi thêm là :");
                            ds.Xuat();
                        }
                        break;
                    case Menu.CapNhat:
                        ds.Xuat();
                        Console.Write("Nhập ID cần cập nhật: ");
                        int ID = int.Parse(Console.ReadLine());
                        ds.CapNhat(ID);
                        Console.WriteLine("\nDanh sách sau khi cập nhật: ");
                        ds.Xuat();
                        break;

                    default: return;

                }    
                Console.ReadKey();
            }

        }
    }
}

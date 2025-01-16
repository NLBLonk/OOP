using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    internal class Program
    {
        enum Menu 
        { 
            NhapTuFile = 1,NhapThuCong,TimPTTheoLoai,SXTheoTen,TinhTongNhienLieu,DemSLTheoLoai,TimPTCoSpeedMax,
            TimPTCoMucNhienMin,SXPTTheoTocDo,SXPTTheoMucNhienLieu,TimPTCoTocDoMinTheoLoai,TimPTTheoTen,XoaTatcaPT, 
            TinhTongSLPT,TinhTBSpeed,TimPTNhanhNhatTheoLoai,TimPTCoMucNhienLieuMaxTheoLoai,TinhTongSoKM,
            TimPTCoQuangDuongMax,DSPTCanBaoTri,KiemTraTonTai,TinhTongMucNhienLieuTrongMoiLoai,TangToc,DoNhienLieu,HienThiHanhVi,
            NhomTheoNhaSX,LocTheoNamSX,LocTheoTocDoMin,LocTheoMucNhienLieuMin,DanhSachPTDuocSXBoiMotNhaSXCuThe
        }

        enum Loai { LoaiPT=1,LoaiDieuKien }
        enum LoaiPT { Car=1,Ship,Submarine,Seaplane}
        enum LoaiDieuKien { CoTheBay=1,CoTheLai,CoTheNoi,CoTheLan }
        enum SX { Tang=1,Giam}
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding=Encoding.UTF8;
            DanhSachPhuongTien ds = new DanhSachPhuongTien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================MENU============================");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập từ file");
                Console.WriteLine($"{(int)Menu.NhapThuCong}.Nhập thủ công");
                Console.WriteLine($"{(int)Menu.TimPTTheoLoai}.Tìm kiếm phương tiện theo loại");
                Console.WriteLine($"{(int)Menu.SXTheoTen}.Sắp xếp theo tên");
                Console.WriteLine($"{(int)Menu.TinhTongNhienLieu}.Tính tổng nhiên liệu của tất cả các phương tiện");
                Console.WriteLine($"{(int)Menu.DemSLTheoLoai}.Đếm số lượng phương tiện theo loại");
                Console.WriteLine($"{(int)Menu.TimPTCoSpeedMax}.Tìm phương tiện có tốc độ cao nhất");
                Console.WriteLine($"{(int)Menu.TimPTCoMucNhienMin}.Tìm phương tiện có mức nhiên liệu thấp nhất");
                Console.WriteLine($"{(int)Menu.SXPTTheoTocDo}.Sắp xếp phương tiện theo tốc độ");
                Console.WriteLine($"{(int)Menu.SXPTTheoMucNhienLieu}.Sắp xếp phương tiện theo mức nhiên liệu");
                Console.WriteLine($"{(int)Menu.TimPTCoTocDoMinTheoLoai}.Tìm phương tiện có tốc độ thấp nhất theo loại");
                Console.WriteLine($"{(int)Menu.TimPTTheoTen}.Tìm kiếm phương tiện theo tên");
                Console.WriteLine($"{(int)Menu.XoaTatcaPT}.Xóa tất cả phương tiện");
                Console.WriteLine($"{(int)Menu.TinhTongSLPT}.Tính tổng số lượng phương tiện");
                Console.WriteLine($"{(int)Menu.TinhTBSpeed}.Tính trung bình tốc đô của phương tiện");
                Console.WriteLine($"{(int)Menu.TimPTNhanhNhatTheoLoai}.Tìm phương tiện nhanh nhất theo loại");
                Console.WriteLine($"{(int)Menu.TimPTCoMucNhienLieuMaxTheoLoai}.Tìm phương tiện có mức nhiên liệu cao nhất theo loại.");
                Console.WriteLine($"{(int)Menu.TinhTongSoKM}.Tính tổng số km đã đi của tất cả các phương tiện");
                Console.WriteLine($"{(int)Menu.TimPTCoQuangDuongMax}.Tìm phương tiện đã đi được quãng đường dài nhất");
                Console.WriteLine($"{(int)Menu.DSPTCanBaoTri}.Tạo danh sách các phương tiện cần bảo trì (ví dụ: đã đi được trên 10.000 km).");
                Console.WriteLine($"{(int)Menu.KiemTraTonTai}.Kiểm tra nếu phương tiện có tồn tại trong danh sách");
                Console.WriteLine($"{(int)Menu.TinhTongMucNhienLieuTrongMoiLoai}.Tính tổng mức nhiên liệu của các phương tiện trong mỗi loại.");
                Console.WriteLine($"{(int)Menu.TangToc}.Tăng tốc cho tất cả");
                Console.WriteLine($"{(int)Menu.DoNhienLieu}.Đổ nhiên liệu cho tất cả");
                Console.WriteLine($"{(int)Menu.HienThiHanhVi}.Hiển thị hành vi tất cả phương tiện");
                Console.WriteLine($"{(int)Menu.NhomTheoNhaSX}.Nhóm theo nhà sản xuất");
                Console.WriteLine($"{(int)Menu.LocTheoNamSX}.Lọc theo năm sản xuất");
                Console.WriteLine($"{(int)Menu.LocTheoTocDoMin}.Lọc theo tốc độ tối thiểu");
                Console.WriteLine($"{(int)Menu.LocTheoMucNhienLieuMin}.Lọc theo mức nhiên liệu tối thiểu");
                Console.WriteLine($"{(int)Menu.DanhSachPTDuocSXBoiMotNhaSXCuThe}.Tạo danh sách các phương tiện được sản xuất bởi một nhà sản xuất cụ thể");
                Console.WriteLine("===============================================================");
                Console.Write("Chọn số trong menu:"); Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case Menu.NhapTuFile:
                        ds.DocTuFile(); ds.Xuat(); break;
                    case Menu.NhapThuCong:
                        ds.NhapThuCong(); ds.Xuat();
                        break;
                    case Menu.TimPTTheoLoai:
                        Console.Clear();
                        Console.WriteLine("============Tìm kiếm phương tiện theo loại ==============");
                        Console.WriteLine($"{(int)Loai.LoaiPT}.Loại Phương tiện");
                        Console.WriteLine($"{(int)Loai.LoaiDieuKien}.Loại điều kiện");
                        Console.WriteLine("=========================================================");
                        Console.Write("Nhập số: "); Loai timkiem = (Loai)int.Parse(Console.ReadLine());
                        switch (timkiem)
                        {
                            case Loai.LoaiPT:
                                Console.WriteLine("=========Tìm kiếm phương tiện theo loại phương tiện========");
                                Console.WriteLine($"{(int)LoaiPT.Car}.Car"); Console.WriteLine($"{(int)LoaiPT.Ship}.Ship");
                                Console.WriteLine($"{(int)LoaiPT.Submarine}.Submarine"); Console.WriteLine($"{(int)LoaiPT.Seaplane}.Seaplane");
                                Console.WriteLine("===========================================================");
                                Console.Write("Vui lòng nhập số: "); LoaiPT timkiem1 = (LoaiPT)int.Parse(Console.ReadLine());
                                switch(timkiem1)
                                {
                                    case LoaiPT.Car:
                                        Console.WriteLine(ds.TimPTTheoLoai<Car>()); break;
                                    case LoaiPT.Ship:
                                        Console.WriteLine(ds.TimPTTheoLoai<Ship>()); break;
                                    case LoaiPT.Submarine:
                                        Console.WriteLine(ds.TimPTTheoLoai<Submarine>()); break;
                                    case LoaiPT.Seaplane:
                                        Console.WriteLine(ds.TimPTTheoLoai<Seaplane>()); break;
                                }    
                                break;
                            case Loai.LoaiDieuKien:
                                Console.WriteLine("==========Tìm kiếm phương tiện theo loại điều kiện=========");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheBay}.Có thể bay");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheLai}.Có thể lái");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheNoi}.Có thể nổi");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheLan}.Có thể lặn");
                                Console.WriteLine("===========================================================");
                                Console.Write("Vui lòng nhập số: "); LoaiDieuKien timkiem2 = (LoaiDieuKien)int.Parse(Console.ReadLine());
                                switch (timkiem2)
                                {
                                    case LoaiDieuKien.CoTheBay:
                                        Console.WriteLine(ds.TimPTTheoLoai<IFlyable>()); break;
                                    case LoaiDieuKien.CoTheLai:
                                        Console.WriteLine(ds.TimPTTheoLoai<IDrivable>()); break;
                                    case LoaiDieuKien.CoTheNoi:
                                        Console.WriteLine(ds.TimPTTheoLoai<IFloatable>()); break;
                                    case LoaiDieuKien.CoTheLan:
                                        Console.WriteLine(ds.TimPTTheoLoai<ISinkable>()); break;
                                }
                                break;
                        } 
                        break;
                    case Menu.SXTheoTen:
                        Console.WriteLine("Trước khi sắp xếp"); ds.Xuat();
                        Console.WriteLine("===============");
                        Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                        Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                        Console.WriteLine("===============");
                        Console.Write("Vui lòng nhập số:"); SX tanggiam = (SX)int.Parse(Console.ReadLine());
                        switch (tanggiam)
                        {
                            case SX.Tang:
                                Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoTen(); ds.Xuat();
                                break;
                            case SX.Giam:
                                Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTen(); ds.Xuat();
                                break;
                        }

                        break;
                    case Menu.TinhTongNhienLieu:
                        ds.Xuat();
                        Console.WriteLine("Tổng nhiên liệu là:"+ds.TinhTongNhienLieu()); 
                        break;
                    case Menu.TimPTCoSpeedMax:
                        ds.Xuat();
                        Console.WriteLine("Kết quả:");
                        var kq = ds.TimPTCoTocDoMax(); kq.Xuat();
                        break;
                    case Menu.TimPTCoMucNhienMin:
                        ds.Xuat();
                        Console.WriteLine("Kết quả:");
                        kq=ds.TimPTCoMucNhienLieuMin(); kq.Xuat();
                        break;
                    case Menu.SXPTTheoMucNhienLieu:
                        Console.WriteLine("Trước khi sắp xếp"); ds.Xuat();
                        Console.WriteLine("===============");
                        Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                        Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                        Console.WriteLine("===============");
                        Console.Write("Vui lòng nhập số:");  tanggiam = (SX)int.Parse(Console.ReadLine());
                        switch (tanggiam)
                        {
                            case SX.Tang:
                                Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoMucNhienLieu(); ds.Xuat();
                                break;
                            case SX.Giam:
                                Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoMucNhienLieu(); ds.Xuat();
                                break;
                        }
                        break;
                    case Menu.SXPTTheoTocDo:
                        Console.WriteLine("Trước khi sắp xếp"); ds.Xuat();
                        Console.WriteLine("===============");
                        Console.WriteLine($"{(int)SX.Tang}.Tăng dần");
                        Console.WriteLine($"{(int)SX.Giam}.Giảm dần");
                        Console.WriteLine("===============");
                        Console.Write("Vui lòng nhập số:"); tanggiam = (SX)int.Parse(Console.ReadLine());
                        switch (tanggiam)
                        {
                            case SX.Tang:
                                Console.WriteLine("Sau khi sắp xếp"); ds.TangTheoTocDo(); ds.Xuat();
                                break;
                            case SX.Giam:
                                Console.WriteLine("Sau khi sắp xếp"); ds.GiamTheoTocDo(); ds.Xuat();
                                break;
                        }
                        break;
                    case Menu.DemSLTheoLoai:
                        Console.Clear();
                        Console.WriteLine("============Đêm số lượng phương tiện theo loại ==========");
                        Console.WriteLine($"{(int)Loai.LoaiPT}.Loại Phương tiện");
                        Console.WriteLine($"{(int)Loai.LoaiDieuKien}.Loại điều kiện");
                        Console.WriteLine("=========================================================");
                        Console.Write("Nhập số: "); Loai demsl = (Loai)int.Parse(Console.ReadLine());
                        switch (demsl)
                        { 
                            case Loai.LoaiPT:
                                Console.WriteLine("========Đêm số lượng phương tiện theo loại phương tiện=====");
                                Console.WriteLine($"{(int)LoaiPT.Car}.Car"); Console.WriteLine($"{(int)LoaiPT.Ship}.Ship");
                                Console.WriteLine($"{(int)LoaiPT.Submarine}.Submarine"); Console.WriteLine($"{(int)LoaiPT.Seaplane}.Seaplane");
                                Console.WriteLine("===========================================================");
                                ds.Xuat();
                                Console.Write("Vui lòng nhập số: "); LoaiPT demsl1 = (LoaiPT)int.Parse(Console.ReadLine());      
                                switch (demsl1)
                                {
                                    case LoaiPT.Car:
                                        Console.WriteLine("Số lượng: "+ds.DemSLTheoLoai<Car>()); break;
                                    case LoaiPT.Ship:
                                        Console.WriteLine("Số lượng: "+ds.DemSLTheoLoai<Ship>()); break;
                                    case LoaiPT.Submarine:
                                        Console.WriteLine("Số lượng: " + ds.DemSLTheoLoai<Submarine>()); break;
                                    case LoaiPT.Seaplane:
                                        Console.WriteLine("Số lượng: "+ds.DemSLTheoLoai<Seaplane>()); break;
                                }
                                break;
                            case Loai.LoaiDieuKien:
                                Console.Clear();
                                Console.WriteLine("============Đếm số lượng phương tiện theo loại ==============");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheBay}.Có thể bay");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheLai}.Có thể lái");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheNoi}.Có thể nổi");
                                Console.WriteLine($"{(int)LoaiDieuKien.CoTheLan}.Có thể lặn");
                                Console.WriteLine("===========================================================");
                                ds.Xuat();
                                Console.Write("Vui lòng nhập số: "); LoaiDieuKien demloai = (LoaiDieuKien)int.Parse(Console.ReadLine());
                                switch (demloai)
                                {
                                    case LoaiDieuKien.CoTheBay:
                                        Console.WriteLine("Số lượng:" + ds.DemSLTheoLoai<IFlyable>());
                                        break;
                                    case LoaiDieuKien.CoTheLai:
                                        Console.WriteLine("Số lượng:" + ds.DemSLTheoLoai<IDrivable>());
                                        break;
                                    case LoaiDieuKien.CoTheNoi:
                                        Console.WriteLine("Số lượng:" + ds.DemSLTheoLoai<IFloatable>());
                                        break;
                                    case LoaiDieuKien.CoTheLan:
                                        Console.WriteLine("Số lượng:" + ds.DemSLTheoLoai<ISinkable>());
                                        break;
                                }
                                break;

                        }
                        break;             
                    case Menu.TimPTTheoTen:
                        ds.Xuat();
                        Console.Write("Nhập tên cần tìm kiếm:"); string ten = Console.ReadLine();
                        kq = ds.TimPTTheoTen(ten); kq.Xuat();
                        break;
                    case Menu.XoaTatcaPT:
                        ds.XoaTatCaPT();
                        Console.WriteLine("Đã xóa hết phương tiện");
                        break;
                    case Menu.TinhTongSLPT:
                        ds.Xuat();
                        Console.WriteLine("Tổng số lượng phương tiện là:"+ds.TinhTongSLPT());
                        break;
                    case Menu.TinhTBSpeed:
                        ds.Xuat();
                        Console.WriteLine("Trung bình tốc độ:"+ds.TinhTrungBinhTocDo());
                        break;
                    case Menu.TimPTNhanhNhatTheoLoai:
                        ds.Xuat();
                        Console.Write("Nhập loại muốn tìm phương tiện nhanh nhất (Car,Ship,Seaplane,Submarine): ");
                        string loaiTimKiem = Console.ReadLine();
                        Console.WriteLine($"\nPhương tiện nhanh nhất trong loại {loaiTimKiem} là:");
                        Console.WriteLine(ds.TimPhuongTienNhanhNhatTheoLoai(loaiTimKiem));
                        break;
                    case Menu.TimPTCoTocDoMinTheoLoai:
                        ds.Xuat();
                        Console.Write("Nhập loại muốn tìm phương tiện có tốc độ thấp nhất nhất (Car,Ship,Seaplane,Submarine): ");
                        loaiTimKiem = Console.ReadLine();
                        Console.WriteLine($"\nPhương tiện tốc độ thấp nhất trong loại {loaiTimKiem} là:");
                        Console.WriteLine(ds.TimPTCoTocDoMinTheoLoai(loaiTimKiem));
                        break;
                    case Menu.TimPTCoMucNhienLieuMaxTheoLoai:
                        ds.Xuat();
                        Console.Write("Nhập loại muốn tìm phương tiện có nhiên liệu cao nhất nhất (Car,Ship,Seaplane,Submarine): ");
                        loaiTimKiem = Console.ReadLine();
                        Console.WriteLine($"\nPhương tiện nhiên liệu cao nhất trong loại {loaiTimKiem} là:");
                        Console.WriteLine(ds.TimPTCoMucNhienLieuMaxTheoLoai(loaiTimKiem));
                        break;
                    case Menu.TinhTongSoKM:
                        ds.Xuat();
                        Console.WriteLine("Tổng số km đã đi của tất cả các phương tiện là:" + ds.TinhTongNhienLieu());
                        break;
                    case Menu.TimPTCoQuangDuongMax:
                        ds.Xuat();
                        Console.WriteLine("Phương tiện đã đi được quãng đường dài nhất là");
                        kq = ds.TimPTCoQuangDuongMax(); kq.Xuat();
                        break;
                    case Menu.DSPTCanBaoTri:
                        ds.Xuat();
                        Console.WriteLine("\nDanh sách các phương tiện cần bảo trì (quãng đường > 10000) là: ");
                        kq=ds.DanhSachPTCanBaoTri(); kq.Xuat();
                        break;
                    case Menu.KiemTraTonTai:
                        ds.Xuat();
                        Console.Write("Nhập tên phương tiện cần kiểm tra: ");
                        string tenPT = Console.ReadLine();
                        if (ds.KiemTraTonTai(tenPT))
                            Console.WriteLine($"Phương tiện {tenPT} tồn tại trong danh sách.");
                        else
                            Console.WriteLine($"Phương tiện {tenPT} KHÔNG tồn tại trong danh sách.");
                        break;
                    case Menu.TinhTongMucNhienLieuTrongMoiLoai:
                        ds.Xuat();
                        Console.WriteLine("Tổng mức nhiên liệu của các xe hơi là: " + ds.TinhTongMucNhienLieuTheoLoai<Car>());
                        Console.WriteLine("Tổng mức nhiên liệu của các thuyền là: " + ds.TinhTongMucNhienLieuTheoLoai<Ship>());
                        Console.WriteLine("Tổng mức nhiên liệu của các tàu ngầm là: " + ds.TinhTongMucNhienLieuTheoLoai<Submarine>());
                        Console.WriteLine("Tổng mức nhiên liệu của các thủy phi cơ là: " + ds.TinhTongMucNhienLieuTheoLoai<Seaplane>());
                        break;
                    case Menu.TangToc:
                        ds.Xuat();
                        Console.Write("Nhập mức tăng tốc: ");
                        int giaTang = int.Parse(Console.ReadLine());
                        ds.TangTocChoTatCa(giaTang);
                        ds.Xuat();
                        break;
                    case Menu.DoNhienLieu:
                        ds.Xuat();
                        Console.Write("Nhập loại nhiên liệu mới: ");
                        double nhienLieuMoi = double.Parse(Console.ReadLine());
                        ds.DoNhienLieuChoTatCa(nhienLieuMoi);
                        ds.Xuat();
                        break;
                    case Menu.HienThiHanhVi:
                        ds.Xuat();
                        Console.WriteLine(ds.HienThiHanhViTatCa());
                        break;
                    case Menu.NhomTheoNhaSX:
                        Console.WriteLine(ds);
                        var nhomTheoNhaSX = ds.NhomTheoNhaSX();
                        foreach (var NhaSX in nhomTheoNhaSX.Keys)
                        {
                            Console.WriteLine($"\nNhà sản xuất: {NhaSX}");
                            Console.WriteLine("Tên".PadRight(20) + "Tốc độ".PadRight(10) + "Mức NL".PadRight(10) + "Quãng đường".PadRight(15)+"Hãng sản xuất".PadRight(20)+"Năm SX".PadRight(10));
                            Console.WriteLine("============================================================================");
                            foreach (var pt in nhomTheoNhaSX[NhaSX])
                                Console.WriteLine(pt);
                            Console.WriteLine("============================================================================");
                        }
                        break;
                    case Menu.LocTheoNamSX:
                        ds.Xuat();
                        Console.Write("Nhập năm sản xuất cần lọc: ");
                        int namSX = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sách phương tiện sản xuất năm {namSX}:");
                        Console.WriteLine(ds.LocTheoNamSX(namSX));
                        break;
                    case Menu.LocTheoTocDoMin:
                        ds.Xuat();
                        Console.Write("Nhập mức độ tối thiểu: ");
                        int tocDoToiThieu = int.Parse(Console.ReadLine());
                        DanhSachPhuongTien dsLoc = ds.LocTheoTocDoToiThieu(tocDoToiThieu);
                        Console.WriteLine($"\nDanh sách sau khi lọc các phương tiện có mức độ tối thiểu là {tocDoToiThieu}:");
                        Console.WriteLine(dsLoc);
                        break;
                    case Menu.LocTheoMucNhienLieuMin:
                        Console.WriteLine(ds);
                        Console.Write("Nhập mức nhiên liệu tối thiểu: ");
                        int mucNhienLieuToiThieu = int.Parse(Console.ReadLine());
                        dsLoc = ds.LocTheoMucNhienLieuToiThieu(mucNhienLieuToiThieu);
                        Console.WriteLine($"\nDanh sách sau khi lọc các phương tiện có mức nhiên liệu tối thiểu là {mucNhienLieuToiThieu}:");
                        Console.WriteLine(dsLoc);
                        break;
                    case Menu.DanhSachPTDuocSXBoiMotNhaSXCuThe:
                        ds.Xuat();
                        string nhaSX = "Toyota";
                        Console.WriteLine($"Danh sách các phương tiện được sản xuất bởi {nhaSX} là:");
                        Console.WriteLine(ds.TimPhuongTienTheoNhaSX(nhaSX));
                        break;
                    default:
                        return;
                }    

                Console.ReadKey();
            }

        }
    }
}

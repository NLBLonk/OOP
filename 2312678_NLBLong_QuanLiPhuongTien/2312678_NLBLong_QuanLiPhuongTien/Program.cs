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
            DanhSachXe ds = new DanhSachXe();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("===================Menu==================");
                Console.WriteLine($"{(int)Menu.NhapTuFile}.Nhập từ File");
                Console.WriteLine($"{(int)Menu.DemSoLuongTheoLoaiKetHop}.Đếm số lượng theo loài kết hợp");
                Console.WriteLine($"{(int)Menu.TimPhuongTienTheoLoaiKetHop}.Tìm phương tiện theo loại kết hợp");
                Console.WriteLine($"{(int)Menu.TimCarCoSCNMaxVaMotorcycleCoTocDoMin}.Tìm các Car có số chỗ ngồi cao nhất và Motorcycle có tốc độ thấp nhất");
                Console.WriteLine($"{(int)Menu.TimCarCoSCNMinVaMotorcycleCoTocDoMin}.Tìm các Car có số chỗ ngồi thấp nhất và Motorcycle có tốc độ thấp nhất");
                Console.WriteLine($"{(int)Menu.TimCarCoSCNMinVaMotorcycleCoTocDoMax}.Tìm các Car có số chỗ ngồi thấp nhất và Motorcycle có tốc độ cao nhất");
                Console.WriteLine($"{(int)Menu.SapXep}.Sắp xếp thứ tự phương tiện theo loại kết hợp");
                Console.WriteLine($"{(int)Menu.TimPTCoGiaTriMAXMIN}.Tìm phương tiện theo loại phương tiện có giá trị lớn nhất, nhỏ nhất và theo loại điều kiện ");
                Console.WriteLine($"{(int)Menu.Thoat}.Thoát");
                Console.WriteLine("=========================================");
                Console.Write("Vui lòng nhập menu:");
                Menu chon = (Menu)int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case Menu.NhapTuFile:
                        ds.DocFile();
                        ds.Xuat();
                        break;
                    case Menu.DemSoLuongTheoLoaiKetHop:
                        Console.Clear();
                        Console.WriteLine("Đếm số lượng theo...");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiPhuongTien}.Loại phương tiện");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiDieuKien}.Loại điều kiện");

                        Console.Write("Vui lòng nhập số trong menu:");
                        MenuLoaiKH chon1 = (MenuLoaiKH)int.Parse(Console.ReadLine());
                        switch (chon1)
                        {
                            case MenuLoaiKH.LoaiPhuongTien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiPT.Motorcycle}.Motorcycle");
                                Console.WriteLine($"{(int)MenuLoaiPT.Car}.Car");
                                Console.WriteLine($"{(int)MenuLoaiPT.AllVehicle}.Car,Motorcycle");
                                Console.Write("\nHãy chọn loại xe:");
                                MenuLoaiPT loaipt = (MenuLoaiPT)int.Parse(Console.ReadLine());
                                switch (loaipt)
                                {
                                    case MenuLoaiPT.Motorcycle:
                                        ds.Xuat();
                                        Console.WriteLine("Số Lượng Xe Máy,Xe Môtô(Motorcycle) là:" + ds.DemSoLuongXe(LoaiXe.Motorcycle));
                                        break;
                                    case MenuLoaiPT.Car:
                                        ds.Xuat();
                                        Console.WriteLine("Số Lượng Xe Hơi là:" + ds.DemSoLuongXe(LoaiXe.Car));
                                        break;
                                    case MenuLoaiPT.AllVehicle:
                                        ds.Xuat();
                                        Console.WriteLine("Số lượng xe hơi và xe máy là:" + ds.DemSoLuongXe(LoaiXe.AllVehicle));
                                        break;
                                    default: return;
                                }
                                break;
                            case MenuLoaiKH.LoaiDieuKien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTen}.Theo tên");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoSoChoNgoi}.Theo Số Chỗ Ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDo}.Theo tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaTocDo}.Theo tên,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaSoChoNgoi}.Theo tên,số chỗ ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDoVaSoChoNgoi}.Theo số chỗ ngồi,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenTocDoVaSoChoNgoi}.Theo tên,số chỗ ngồi,tốc độ");
                                Console.Write("\nHãy nhập số trong loại điều kiện:");
                                MenuLoaiDK loaidk = (MenuLoaiDK)int.Parse(Console.ReadLine());
                                switch (loaidk)
                                {
                                    case MenuLoaiDK.TheoTen:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten = Console.ReadLine();
                                        Console.WriteLine("Số lượng Tên mà bạn cần tìm là:" + ds.DemSoLuongTheoTen(ten));
                                        break;
                                    case MenuLoaiDK.TheoSoChoNgoi:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int x = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng chỗ ngồi cần tìm là:" + ds.DemSoLuongTheoSoChoNgoi(x));
                                        break;
                                    case MenuLoaiDK.TheoTocDo:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng theo tốc độ cần tìm là:" + ds.DemSoLuongTheoTocDo(tocdo));
                                        break;
                                    case MenuLoaiDK.TheoTenVaTocDo:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten1 = Console.ReadLine();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng theo tên và tốc độ:" + ds.DemSoLuongTheoTenVaTocDo(ten1, tocdo1));
                                        break;
                                    case MenuLoaiDK.TheoTenVaSoChoNgoi:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten2 = Console.ReadLine();
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng theo tên và số chỗ ngồi cần tìm là:" + ds.DemSoLuongTheoTenVaSoChoNgoi(ten2, sochongoi));
                                        break;
                                    case MenuLoaiDK.TheoTocDoVaSoChoNgoi:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo2 = int.Parse(Console.ReadLine());
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng theo số chỗ ngồi và tốc độ cần tìm là:" + ds.DemSoLuongTheoSoChoNgoiVaTocDo(sochongoi1, tocdo2));
                                        break;
                                    case MenuLoaiDK.TheoTenTocDoVaSoChoNgoi:
                                        Console.WriteLine(ds);
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten3 = Console.ReadLine();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo3 = int.Parse(Console.ReadLine());
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi2 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Số lượng theo tên, số chỗ ngồi và tốc độ cần tìm là:" + ds.DemSoLuongTheoTenSoChoNgoiVaTocDo(ten3, tocdo3, sochongoi2));
                                        break;
                                }
                                break;
                            default: return;
                        }
                        break;
                    case Menu.TimPhuongTienTheoLoaiKetHop:
                        Console.Clear();
                        Console.WriteLine("Tìm phương tiện theo...");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiPhuongTien}.Loại phương tiện");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiDieuKien}.Loại điều kiện");

                        Console.Write("Vui lòng nhập số trong menu:");
                        MenuLoaiKH chon2 = (MenuLoaiKH)int.Parse(Console.ReadLine());
                        switch (chon2)
                        {
                            case MenuLoaiKH.LoaiPhuongTien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiPT.Motorcycle}.Motorcycle");
                                Console.WriteLine($"{(int)MenuLoaiPT.Car}.Car");
                                Console.WriteLine($"{(int)MenuLoaiPT.AllVehicle}.Car hoặc Motorcycle");
                                Console.WriteLine($"{(int)MenuLoaiPT.CarAndMotorcycle}.Car và Motorcycle");
                                Console.Write("\nHãy chọn loại xe:");
                                MenuLoaiPT loaipt = (MenuLoaiPT)int.Parse(Console.ReadLine());
                                switch (loaipt)
                                {
                                    case MenuLoaiPT.Motorcycle:
                                        ds.Xuat();
                                        Console.WriteLine(ds.TimPT<Motorcycle>());
                                        break;
                                    case MenuLoaiPT.Car:
                                        ds.Xuat();
                                        Console.WriteLine(ds.TimPT<Car>());
                                        break;
                                    case MenuLoaiPT.AllVehicle:
                                        //Console.WriteLine(ds.TimPT<Vehicle>());
                                        Console.WriteLine(ds.TimPTCarHoacMotorcycle());
                                        break;
                                    case MenuLoaiPT.CarAndMotorcycle:
                                        Console.WriteLine(ds.TimPTCarVaMotorcycle());
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case MenuLoaiKH.LoaiDieuKien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTen}.Theo tên");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoSoChoNgoi}.Theo Số Chỗ Ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDo}.Theo tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaTocDo}.Theo tên,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaSoChoNgoi}.Theo tên,số chỗ ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDoVaSoChoNgoi}.Theo số chỗ ngồi,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenTocDoVaSoChoNgoi}.Theo tên,số chỗ ngồi,tốc độ");
                                Console.Write("\nHãy nhập số trong loại điều kiện:");
                                MenuLoaiDK loaidk = (MenuLoaiDK)int.Parse(Console.ReadLine());
                                switch (loaidk)
                                {
                                    case MenuLoaiDK.TheoTen:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten = Console.ReadLine();
                                        Console.WriteLine(ds.TimPTTheoTen(ten));
                                        break;
                                    case MenuLoaiDK.TheoSoChoNgoi:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int x = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoSoChoNgoi(x));
                                        break;
                                    case MenuLoaiDK.TheoTocDo:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoTocDo(tocdo));
                                        break;
                                    case MenuLoaiDK.TheoTenVaTocDo:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten1 = Console.ReadLine();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoTenVaTocDo(ten1, tocdo1));
                                        break;
                                    case MenuLoaiDK.TheoTenVaSoChoNgoi:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten2 = Console.ReadLine();
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoTenVaSoChoNgoi(ten2, sochongoi));
                                        break;
                                    case MenuLoaiDK.TheoTocDoVaSoChoNgoi:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo2 = int.Parse(Console.ReadLine());
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoTocDoVaSoChoNgoi(tocdo2, sochongoi1));
                                        break;
                                    case MenuLoaiDK.TheoTenTocDoVaSoChoNgoi:
                                        ds.Xuat();
                                        Console.Write("Hãy nhập Tên mà bạn cần tìm: ");
                                        string ten3 = Console.ReadLine();
                                        Console.Write("Hãy nhập tốc độ càn tìm (km/h):");
                                        int tocdo3 = int.Parse(Console.ReadLine());
                                        Console.Write("Hãy nhập số chỗ ngồi cần tìm: ");
                                        int sochongoi2 = int.Parse(Console.ReadLine());
                                        Console.WriteLine(ds.TimPTTheoTenTocDoVaSoChoNgoi(ten3, tocdo3, sochongoi2));
                                        break;
                                }
                                break;

                        }
                        break;
                    case Menu.TimCarCoSCNMaxVaMotorcycleCoTocDoMin:
                        ds.Xuat();
                        Console.WriteLine("Car có số chỗ ngồi CAO NHẤT:" + ds.TimCarCoCSNMax());
                        Console.WriteLine("Motorcycle có tốc độ THẤP NHẤT:" + ds.TimMotorcycleCoMinSpeed());
                        break;
                    case Menu.TimCarCoSCNMinVaMotorcycleCoTocDoMin:
                        ds.Xuat();
                        Console.WriteLine("Car có số chỗ ngồi THẤP NHẤT:" + ds.TimCarCoCSNMin());
                        Console.WriteLine("Motorcycle có tốc độ THẤP NHẤT:" + ds.TimMotorcycleCoMinSpeed());
                        break;
                    case Menu.TimCarCoSCNMinVaMotorcycleCoTocDoMax:
                        ds.Xuat();
                        Console.WriteLine("Car có số chỗ ngồi THẤP NHẤT:" + ds.TimCarCoCSNMin());
                        Console.WriteLine("Motorcycle có tốc độ CAO NHẤT:" + ds.TimMotorcycleCoMaxSpeed());
                        break;
                    case Menu.SapXep:
                        Console.Clear();
                        Console.WriteLine("SẮP XẾP PHƯƠNG TIỆN THEO...");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiPhuongTien}.Loại phương tiện");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiDieuKien}.Loại điều kiện");

                        Console.Write("Vui lòng nhập số trong menu:");
                        MenuLoaiKH chon3 = (MenuLoaiKH)int.Parse(Console.ReadLine());
                        switch (chon3)
                        {
                            case MenuLoaiKH.LoaiPhuongTien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiPT.Motorcycle}.Motorcycle");
                                Console.WriteLine($"{(int)MenuLoaiPT.Car}.Car");
                                Console.WriteLine($"{(int)MenuLoaiPT.AllVehicle}.Car,Motorcycle");
                                Console.Write("\nHãy chọn loại xe:");
                                MenuLoaiPT loaipt = (MenuLoaiPT)int.Parse(Console.ReadLine());
                                switch (loaipt)
                                {
                                    case MenuLoaiPT.Motorcycle:
                                        break;
                                    case MenuLoaiPT.Car:
                                        break;
                                    case MenuLoaiPT.AllVehicle:
                                        break;
                                }
                                break;
                            case MenuLoaiKH.LoaiDieuKien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTen}.Theo tên");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoSoChoNgoi}.Theo Số Chỗ Ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDo}.Theo tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaTocDo}.Theo tên,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaSoChoNgoi}.Theo tên,số chỗ ngồi");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDoVaSoChoNgoi}.Theo số chỗ ngồi,tốc độ");
                                Console.WriteLine($"{(int)MenuLoaiDK.TheoTenTocDoVaSoChoNgoi}.Theo tên,số chỗ ngồi,tốc độ");
                                Console.Write("\nHãy nhập số trong loại điều kiện:");
                                MenuLoaiDK loaidk = (MenuLoaiDK)int.Parse(Console.ReadLine());
                                switch (loaidk)
                                {
                                    case MenuLoaiDK.TheoTen:
                                        Console.Clear();
                                        Console.WriteLine("Trước khi sắp xếp:"); Console.WriteLine(ds);
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"|{(int)MenuSX.TangDan}.Sắp xếp TĂNG dần|"); Console.WriteLine($"|{(int)MenuSX.GiamDan}.Sắp xếp GIẢM dần|");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuSX theoten = (MenuSX)int.Parse(Console.ReadLine());
                                        switch (theoten)
                                        {
                                            case MenuSX.TangDan:
                                                Console.WriteLine("Sau khi sắp xếp"); ds.SapXepTheoTen(DanhSachXe.TangGiam.Tang); Console.WriteLine(ds);
                                                break;
                                            case MenuSX.GiamDan:
                                                Console.WriteLine("Sau khi sắp xếp"); ds.SapXepTheoTen(DanhSachXe.TangGiam.Giam); Console.WriteLine(ds);
                                                break;
                                        }
                                        break;
                                    case MenuLoaiDK.TheoSoChoNgoi:
                                        Console.Clear();
                                        Console.WriteLine("Trước khi sắp xếp:"); Console.WriteLine(ds);
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"|{(int)MenuSX.TangDan}.Sắp xếp TĂNG dần|"); Console.WriteLine($"|{(int)MenuSX.GiamDan}.Sắp xếp GIẢM dần|");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuSX theoCSN = (MenuSX)int.Parse(Console.ReadLine());
                                        switch (theoCSN)
                                        {
                                            case MenuSX.TangDan:
                                                //ds.TimPT<Car>();
                                                Console.WriteLine("Sau khi sắp xếp"); Console.WriteLine(ds.SapXepSCN(DanhSachXe.KieuSapXep.TangTheoSCN));
                                                break;
                                            case MenuSX.GiamDan:
                                                Console.WriteLine("Sau khi sắp xếp"); Console.WriteLine(ds.SapXepSCN(DanhSachXe.KieuSapXep.GiamTheoSCN));
                                                break;
                                        }
                                        break;
                                    case MenuLoaiDK.TheoTocDo:
                                        Console.Clear();
                                        Console.WriteLine("Trước khi sắp xếp:"); Console.WriteLine(ds);
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"|{(int)MenuSX.TangDan}.Sắp xếp TĂNG dần|"); Console.WriteLine($"|{(int)MenuSX.GiamDan}.Sắp xếp GIẢM dần|");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuSX theospeed = (MenuSX)int.Parse(Console.ReadLine());
                                        switch (theospeed)
                                        {
                                            case MenuSX.TangDan:
                                                Console.WriteLine("Sau khi sắp xếp"); ds.SapXepTheoSpeed(DanhSachXe.TangGiam.Tang); Console.WriteLine(ds);
                                                break;
                                            case MenuSX.GiamDan:
                                                Console.WriteLine("Sau khi sắp xếp"); ds.SapXepTheoSpeed(DanhSachXe.TangGiam.Giam); Console.WriteLine(ds);
                                                break;
                                        }


                                        break;
                                    case MenuLoaiDK.TheoTenVaTocDo:
                                        Console.Clear();
                                        Console.WriteLine("========THEO TÊN VÀ TỐC ĐỘ==============");
                                        Console.WriteLine("Trước khi sắp xếp:"); Console.WriteLine(ds);
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"|{(int)MenuSX.TangDan}.Sắp xếp TĂNG dần|"); Console.WriteLine($"|{(int)MenuSX.GiamDan}.Sắp xếp GIẢM dần|");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuSX theotenvaspeed = (MenuSX)int.Parse(Console.ReadLine());
                                        switch (theotenvaspeed)
                                        {
                                            case MenuSX.TangDan:
                                                Console.WriteLine("Sau khi sắp xếp"); 
                                                ds.SapXepTangTheoTenVaTocDo();
                                                Console.WriteLine(ds);
                                                break;
                                            case MenuSX.GiamDan:
                                                Console.WriteLine("Sau khi sắp xếp");
                                                ds.SapXepGiamTheoTenVaTocDo();
                                                Console.WriteLine(ds);
                                                break;
                                        }
                                        break;
                                    case MenuLoaiDK.TheoTenVaSoChoNgoi:
                                        Console.Clear();
                                        Console.WriteLine("========THEO TÊN VÀ SỐ CHỖ NGỒI==============");
                                        Console.WriteLine("Trước khi sắp xếp:"); Console.WriteLine(ds);
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"|{(int)MenuSX.TangDan}.Sắp xếp TĂNG dần|"); Console.WriteLine($"|{(int)MenuSX.GiamDan}.Sắp xếp GIẢM dần|");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuSX theotenvascn = (MenuSX)int.Parse(Console.ReadLine());
                                        switch (theotenvascn)
                                        {
                                            case MenuSX.TangDan:
                                                Console.WriteLine("Sau khi sắp xếp");
                                                Console.WriteLine(ds.SapXepTangTheoTenVaSoChoNgoi());
                                                break;
                                            case MenuSX.GiamDan:
                                                Console.WriteLine("Sau khi sắp xếp");
                                                Console.WriteLine(ds.SapXepGiamTheoTenVaSoChoNgoi());
                                                break;
                                        }
                                        break;
                                    case MenuLoaiDK.TheoTocDoVaSoChoNgoi: break;
                                    case MenuLoaiDK.TheoTenTocDoVaSoChoNgoi: break;
                                    default: return;
                                }
                                break;
                        }
                        break;
                    case Menu.TimPTCoGiaTriMAXMIN:
                        Console.Clear();
                        Console.WriteLine("TÌM PHƯƠNG TIỆN THEO CÓ GIÁ TRỊ THEO...");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiPhuongTien}.Loại phương tiện");
                        Console.WriteLine($"{(int)MenuLoaiKH.LoaiDieuKien}.Loại điều kiện");

                        Console.Write("Vui lòng nhập số trong menu:");
                        MenuLoaiKH maxmin = (MenuLoaiKH)int.Parse(Console.ReadLine());
                        switch(maxmin)
                        {
                            case MenuLoaiKH.LoaiPhuongTien:
                                Console.Clear();
                                Console.WriteLine($"{(int)MenuLoaiPT.Motorcycle}.Motorcycle");
                                Console.WriteLine($"{(int)MenuLoaiPT.Car}.Car");
                                Console.WriteLine($"{(int)MenuLoaiPT.AllVehicle}.Car,Motorcycle");
                                Console.Write("\nHãy chọn loại xe:");
                                MenuLoaiPT loaipt = (MenuLoaiPT)int.Parse(Console.ReadLine());
                                switch (loaipt)
                                {
                                    case MenuLoaiPT.Motorcycle:
                                        Console.Clear();
                                        Console.WriteLine("Loại phương tiện: MOTORCYCLE");
                                        Console.WriteLine(ds.TimPT<Motorcycle>());
                                        Console.WriteLine("=====================================");
                                        Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                        Console.WriteLine("=====================================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuMAXMIN maxminpt = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                        switch (maxminpt)
                                        {
                                            case MenuMAXMIN.Max:
                                                Console.WriteLine("Motorcycle có giá trị MAX(theo tên):");
                                                Console.WriteLine(ds.TimDSMotorcycleMax());
                                                break;
                                            case MenuMAXMIN.Min:
                                                Console.WriteLine("Motorcycle có giá trị MIN(theo tên):");
                                                Console.WriteLine(ds.TimDSMotorcycleMin());
                                                break;
                                        }                                     
                                        break;
                                    case MenuLoaiPT.Car:
                                        Console.Clear();
                                        Console.WriteLine("Loại phương tiện: CAR");
                                        Console.WriteLine(ds.TimPT<Car>());
                                        Console.WriteLine("=====================================");
                                        Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                        Console.WriteLine("=====================================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuMAXMIN maxminpt2 = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                        switch (maxminpt2)
                                        {
                                            case MenuMAXMIN.Max:
                                                Console.WriteLine("Car có giá trị MAX(theo tên):");
                                                Console.WriteLine(ds.TimDSCarMax());
                                                break;
                                            case MenuMAXMIN.Min:
                                                Console.WriteLine("Car có giá trị MIN(theo tên):");
                                                Console.WriteLine(ds.TimDSCarMin());
                                                break;
                                        }
                                        break;
                                    case MenuLoaiPT.AllVehicle:
                                        ds.Xuat();
                                        Console.Clear();
                                        Console.WriteLine("Loại phương tiện: CAR,MOTORCYCLE");
                                        Console.WriteLine(ds.TimPT<Vehicle>());
                                        Console.WriteLine("=====================================");
                                        Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                        Console.WriteLine("=====================================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuMAXMIN maxminpt3 = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                        switch(maxminpt3)
                                        {
                                            case MenuMAXMIN.Max:
                                                Console.WriteLine("Vehicle (Car,Motorcycle) có giá trị MAX(theo tên):");
                                                Console.WriteLine(ds.TimDSVehicleMax());
                                                break;
                                            case MenuMAXMIN.Min:
                                                Console.WriteLine("Vehicle (Car,Motorcycle) có giá trị MIN(theo tên):");
                                                Console.WriteLine(ds.TimDSVehicleMin());
                                                break;
                                        }    
                                        break;
                                    default: return;
                                }    
                                break;
                                case MenuLoaiKH.LoaiDieuKien:
                                    Console.Clear();
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTen}.Theo tên");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoSoChoNgoi}.Theo Số Chỗ Ngồi");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDo}.Theo tốc độ");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaTocDo}.Theo tên,tốc độ");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTenVaSoChoNgoi}.Theo tên,số chỗ ngồi");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTocDoVaSoChoNgoi}.Theo số chỗ ngồi,tốc độ");
                                    Console.WriteLine($"{(int)MenuLoaiDK.TheoTenTocDoVaSoChoNgoi}.Theo tên,số chỗ ngồi,tốc độ");
                                    Console.Write("\nHãy nhập số trong loại điều kiện:");
                                    MenuLoaiDK loaidk = (MenuLoaiDK)int.Parse(Console.ReadLine());
                                    switch(loaidk)
                                    {
                                        case MenuLoaiDK.TheoTen:
                                            Console.Clear();
                                            ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theoten = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theoten)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có tên DÀI NHẤT:"); Console.WriteLine(ds.TimPTCoTenDaiNhat());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có tên NGẮN NHẤT:"); Console.WriteLine(ds.TimPTCoTenNganNhat());
                                                    break;
                                            }
                                            break;
                                        case MenuLoaiDK.TheoSoChoNgoi:
                                            Console.Clear();
                                            ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theoCSN = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theoCSN)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có số chỗ ngồi NHIỀU NHẤT:"); Console.WriteLine(ds.TimPTCoCSNMax());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có  số chỗ ngồi ÍT NHẤT:"); Console.WriteLine(ds.TimPTCoCSNMin());
                                                    break;
                                            }
                                            break;
                                        case MenuLoaiDK.TheoTocDo:
                                            Console.Clear();
                                            ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theospeed = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theospeed)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có tốc độ CAO NHẤT:"); Console.WriteLine(ds.TimPTCoTocDoMax());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có tốc độ THẤP NHẤT:"); Console.WriteLine(ds.TimPTCoTocDoMin());
                                                    break;
                                            }


                                            break;
                                        case MenuLoaiDK.TheoTenVaTocDo:
                                            Console.Clear();
                                            ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theotenvaspeed = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theotenvaspeed)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có tên DÀI NHẤT & tốc độ CAO NHẤT:"); Console.WriteLine(ds.TimPTCoTenVaSpeedMax());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có tên NGẮN NHẤT & tốc độ THẤP NHẤT:"); Console.WriteLine(ds.TimPTCoTenVaSpeedMin());
                                                    break;
                                            }
                                            break;
                                        case MenuLoaiDK.TheoTenVaSoChoNgoi:
                                            Console.Clear();
                                        Console.WriteLine(ds.TimPT<Car>());
                                            //ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theotenvaCSN = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theotenvaCSN)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có tên DÀI NHẤT & số chỗ ngồi NHIỀU NHẤT:"); Console.WriteLine(ds.TimPTCoTenVaCSNMax());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có tên NGẮN NHẤT & số chỗ ngồi ÍT NHẤT:"); Console.WriteLine(ds.TimPTCoTenVaCSNMin());
                                                    break;
                                            }
                                        break;
                                        case MenuLoaiDK.TheoTocDoVaSoChoNgoi:
                                            Console.Clear();
                                            ds.Xuat();
                                            Console.WriteLine("====================");
                                            Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                            Console.WriteLine("====================");
                                            Console.Write("Vui lòng nhập số:");
                                            MenuMAXMIN theoSpeedvaCSN = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                            switch (theoSpeedvaCSN)
                                            {
                                                case MenuMAXMIN.Max:
                                                    Console.WriteLine("Phương tiện có tốc độ CAO NHẤT & số chỗ ngồi NHIỀU NHẤT:"); Console.WriteLine(ds.TimPTCoTocDoVaCSNMax());
                                                    break;
                                                case MenuMAXMIN.Min:
                                                    Console.WriteLine("Phương tiện có tốc độ THẤP NHẤT & số chỗ ngồi ÍT NHẤT:"); Console.WriteLine(ds.TimPTCoTocDoVaCSNMin());
                                                    break;
                                            }
                                        break;
                                    case MenuLoaiDK.TheoTenTocDoVaSoChoNgoi:
                                        Console.Clear();
                                        ds.Xuat();
                                        Console.WriteLine("====================");
                                        Console.WriteLine($"{(int)MenuMAXMIN.Max}.Giá trị lớn nhất"); Console.WriteLine($"{(int)MenuMAXMIN.Min}.Giá trị nhỏ nhất");
                                        Console.WriteLine("====================");
                                        Console.Write("Vui lòng nhập số:");
                                        MenuMAXMIN theoTenSpeedvaCSN = (MenuMAXMIN)int.Parse(Console.ReadLine());
                                        switch (theoTenSpeedvaCSN)
                                        {
                                            case MenuMAXMIN.Max:
                                                Console.WriteLine("Phương tiện có tên DÀI NHẤT, tốc độ CAO NHẤT & số chỗ ngồi NHIỀU NHẤT:"); Console.WriteLine(ds.TimPTCoTenTocDoVaCSNMax());
                                                break;
                                            case MenuMAXMIN.Min:
                                                Console.WriteLine("Phương tiện có tên NGẮN NHẤT, tốc độ THẤP NHẤT & số chỗ ngồi ÍT NHẤT:"); Console.WriteLine(ds.TimPTCoTenTocDoVaCSNMin());
                                                break;
                                        }
                                        break;
                                        default: return;
                                    }    
                                    break;
                        }    
                        
                        
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

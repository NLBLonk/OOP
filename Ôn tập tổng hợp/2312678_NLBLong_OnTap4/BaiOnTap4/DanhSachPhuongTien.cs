using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class DanhSachPhuongTien
    {
        List<IVehicle>collection=new List<IVehicle>();

        public void Them(IVehicle xe)
        {
            collection.Add(xe);
        }

        public void DocTuFile()
        {

            string filename = "Data.txt";
            StreamReader sr = new StreamReader(filename);
            var line = "";    
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split(',');
                string loai = str[0];
                switch(loai)
                {
                    case "Car":
                        Them(new Car(line));
                        break;
                    case "Submarine":
                        Them(new Submarine(line));
                        break;
                    case "Seaplane":
                        Them(new Seaplane(line));
                        break;
                    case "Ship":
                        Them(new Ship(line));
                        break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tên".PadRight(20) + "Tốc độ".PadRight(10) + "Mức NL".PadRight(10)+"Quãng đường".PadRight(15) + "Hãng sản xuất".PadRight(20) + "Năm SX".PadRight(10));
            sb.AppendLine("=================================================================================================");
            foreach (var i in collection)
            {
                sb.AppendLine(i.ToString());
            }
            sb.Append("=================================================================================================");
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }

        public void NhapThuCong()
        {
            Console.Clear();
            Console.Write("Vui lòng chọn loại phương tiện (Car/Ship/Submarine/Seaplane): ");
            string chon = Console.ReadLine();
            switch (chon)
            {
                case "Car":
                    Console.Write("Nhập tên:"); string ten = Console.ReadLine();
                    Console.Write("Nhập tốc độ:");  int tocdo = int.Parse(Console.ReadLine());
                    Console.Write("Nhập mức nhiên liệu:"); double nhienlieu = double.Parse(Console.ReadLine());
                    Console.Write("Nhập quãng đường đã đi"); int quangDuong = int.Parse(Console.ReadLine());
                    Console.Write("Nhập hãng sản xuất"); string nhaSX = Console.ReadLine();
                    Console.Write("Nhập năm sản xuất"); int namSX = int.Parse(Console.ReadLine());
                    Them(new Car(ten, tocdo, nhienlieu, quangDuong, nhaSX, namSX));
                    break;
                case "Ship":
                    Console.Write("Nhập tên:");  ten = Console.ReadLine();
                    Console.Write("Nhập tốc độ:");  tocdo = int.Parse(Console.ReadLine());
                    Console.Write("Nhập mức nhiên liệu:"); nhienlieu = double.Parse(Console.ReadLine());
                    Console.Write("Nhập quãng đường đã đi:"); quangDuong = int.Parse(Console.ReadLine());
                    Console.Write("Nhập hãng sản xuất");  nhaSX = Console.ReadLine();
                    Console.Write("Nhập năm sản xuất");  namSX = int.Parse(Console.ReadLine());
                    Them(new Ship(ten, tocdo, nhienlieu, quangDuong, nhaSX, namSX));
                    break;
                case "Seaplane":
                    Console.Write("Nhập tên:"); ten = Console.ReadLine();
                    Console.Write("Nhập tốc độ:"); tocdo = int.Parse(Console.ReadLine());
                    Console.Write("Nhập mức nhiên liệu:"); nhienlieu = double.Parse(Console.ReadLine());
                    Console.Write("Nhập quãng đường đã đi"); quangDuong = int.Parse(Console.ReadLine());
                    Console.Write("Nhập hãng sản xuất"); nhaSX = Console.ReadLine();
                    Console.Write("Nhập năm sản xuất"); namSX = int.Parse(Console.ReadLine());
                    Them(new Seaplane(ten, tocdo, nhienlieu, quangDuong, nhaSX, namSX));
                    break;
                case "Submarine":
                    Console.Write("Nhập tên:"); ten = Console.ReadLine();
                    Console.Write("Nhập tốc độ:"); tocdo = int.Parse(Console.ReadLine());
                    Console.Write("Nhập mức nhiên liệu:"); nhienlieu = double.Parse(Console.ReadLine());
                    Console.Write("Nhập quãng đường đã đi"); quangDuong = int.Parse(Console.ReadLine());
                    Console.Write("Nhập hãng sản xuất"); nhaSX = Console.ReadLine();
                    Console.Write("Nhập năm sản xuất"); namSX = int.Parse(Console.ReadLine());
                    Them(new Submarine(ten, tocdo, nhienlieu, quangDuong, nhaSX, namSX));
                    break;
            }
        }


        #region Tìm kiếm pt theo loại
        public DanhSachPhuongTien TimPTTheoLoai<Loai>()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach(var i in collection)
            {
                if (i is Loai) 
                    kq.Them(i);
            }
            return kq;
        }

        //public DanhSachPhuongTien TimPTCoTheLaiDuoc()
        //{
        //    DanhSachPhuongTien kq = new DanhSachPhuongTien();
        //    foreach (var i in collection)
        //    {
        //        if (i is IDrivable) kq.Them(i);
        //    }
        //    return kq;
        //}








        #endregion

        #region Sắp xếp theo tên
        void HoanVi(int i,int j)
        {
            var temp = collection[i];
            collection[i]= collection[j];
            collection[j]= temp;
        }
        public void TangTheoTen()
        {
            for(int i = 0;i< collection.Count-1; i++)
                for(int j=i+1;j<collection.Count;j++)
                {
                    if (collection[i].Ten.CompareTo(collection[j].Ten)>0)  HoanVi(i,j);
                }
        }


        public void GiamTheoTen()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].Ten.CompareTo(collection[j].Ten) < 0) HoanVi(i, j);
                }
        }




        #endregion

        #region Tính tổng nhiên liệu
        public double TinhTongNhienLieu()
        {
            double tong = 0;
            foreach (var i in collection)
            {
               tong = tong + i.NhienLieu;
            }
            return tong;
        }

        #endregion

        #region Đếm Số lượng phương tiện theo loại
        public int DemSLTheoLoai<Loai>()
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Loai) dem++;
            }    
            return dem;
        }



        #endregion

        #region Tìm phương tiện có tốc độ cao nhất
        public int TimTocDoMax()
        {
            int max = int.MinValue;
            foreach (var i in collection)
            {
                if (i.TocDo > max)
                    max = i.TocDo;
            }
            return max;
        }

        public DanhSachPhuongTien TimPTCoTocDoMax()
        {
            int max = TimTocDoMax();
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
            {
                if (i.TocDo == max) 
                    kq.Them(i);
            }
            return kq;
        }

        #endregion

        #region Tìm phương tiện có mức nhiên liệu thấp nhất
        public double TimMucNhienLieuMin()
        {
            double min = double.MaxValue;
            foreach (var i in collection)
            {
                if (i.NhienLieu < min)   
                    min = i.NhienLieu;
            }
            return min;
        }

        public DanhSachPhuongTien TimPTCoMucNhienLieuMin()
        {
            double min = TimMucNhienLieuMin();
            DanhSachPhuongTien kq = new DanhSachPhuongTien(); 
            foreach(var i in collection)
            {
                if (i.NhienLieu == min) kq.Them(i);
            }    
            return kq;
        }

        #endregion

        #region Sắp xếp phương tiện theo mức nhiên liệu

        public void TangTheoMucNhienLieu()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].NhienLieu.CompareTo(collection[j].NhienLieu) > 0) HoanVi(i, j);
                }
        }


        public void GiamTheoMucNhienLieu()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].NhienLieu.CompareTo(collection[j].NhienLieu) < 0) HoanVi(i, j);
                }
        }

        #endregion

        #region Sắp xếp phương tiện theo tốc độ

        public void TangTheoTocDo()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].TocDo.CompareTo(collection[j].TocDo) > 0) HoanVi(i, j);
                }
        }


        public void GiamTheoTocDo()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].TocDo.CompareTo(collection[j].TocDo) < 0) HoanVi(i, j);
                }
        }

        #endregion

        #region Tìm phương tiện có tốc độ thấp nhất theo loại

        public DanhSachPhuongTien TimPTCoTocDoMinTheoLoai(string loai)
        {
            int min = int.MaxValue;
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
            {
                if (i.GetType().Name == loai && i.TocDo<min)
                {
                    kq.collection.Clear();
                    kq.collection.Add(i);
                    min = i.TocDo;
                }
            }
            return kq;
        }
        #endregion

        #region Tìm kiếm phương tiện theo tên
        public DanhSachPhuongTien TimPTTheoTen(string ten)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
            {
                if (i.Ten == ten) kq.Them(i);
            }
            return kq;
        }
        #endregion

        #region Tính tổng số lượng phương tiện
        public int TinhTongSLPT()
        {
            return collection.Count;
        }
        #endregion

        #region Xóa tất cả phương tiện
        public void XoaTatCaPT()
        {
            collection.Clear();
        }
        #endregion

        #region Tính trung bình tốc độ
        public double TinhTrungBinhTocDo()
        {
            if (collection.Count == 0) return 0;
            int tongTocDo = 0;
            foreach (var i in collection)
                tongTocDo += i.TocDo;
            return (double)tongTocDo / collection.Count;
        }
        #endregion

        #region Tìm phương tiện nhanh nhất theo loại
        public DanhSachPhuongTien TimPhuongTienNhanhNhatTheoLoai(string loai)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            int tocDoMax = int.MinValue;
            foreach (var i in collection)
                if (i.GetType().Name == loai && i.TocDo > tocDoMax)
                {
                    kq.collection.Clear();
                    kq.collection.Add(i);
                    tocDoMax = i.TocDo;
                }
            return kq;
        }




        #endregion

        #region Tìm phương tiện có mức nhiên liệu cao nhất theo loại

        public DanhSachPhuongTien TimPTCoMucNhienLieuMaxTheoLoai(string loai)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            double max = double.MinValue;
            foreach (var i in collection)
                if (i.GetType().Name == loai && i.NhienLieu > max)
                {
                    kq.collection.Clear();
                    kq.collection.Add(i);
                    max = i.NhienLieu;
                }
            return kq;
        }
        #endregion

        #region Tính tổng số km đã đi của tất cả các phương tiện
        public int TinhTongSoKM()
        {
            int tong = 0;
            foreach (var i in collection)
            {
                tong = tong + i.QuangDuong;
            }    
            return tong;  
        }


        #endregion

        #region Tìm phương tiện đã đi được quãng đường dài nhất
        public int TimQDMax()
        {
            int max = int.MinValue;
            foreach (var i in collection)
                if (i.QuangDuong>max) max = i.QuangDuong;
            return max;
        }

        public DanhSachPhuongTien TimPTCoQuangDuongMax()
        {
            int max = TimQDMax();
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.QuangDuong == max) kq.Them(i);
            return kq;
        }
        #endregion

        #region Tìm phương tiện cần bảo trì
        public DanhSachPhuongTien DanhSachPTCanBaoTri()
        {
            DanhSachPhuongTien dsBaotri = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.QuangDuong > 10000)
                    dsBaotri.Them(i);
            return dsBaotri;
        }
        #endregion

        #region Kiểm tra phương tiện có tồn tại hay không
        public bool KiemTraTonTai(string tenPT)
        {
            foreach (var i in collection)
                if (i.Ten == tenPT)
                    return true;
            return false;
        }
        #endregion

        #region Tính tổng mức nhiên liệu của các phương tiện trong mỗi loại
        public double TinhTongMucNhienLieuTheoLoai<Loai>()
        {
            double tong= 0;
            foreach (var i in collection)
                if (i is Loai)
                    tong += i.NhienLieu;
            return tong;
        }
        #endregion

        #region Đổ nhiên liệu , Tăng tốc
        public void TangTocChoTatCa(int giaTang)
        {
            foreach (var pt in collection)
            {
                pt.TangToc(giaTang);
            }
        }
        public void DoNhienLieuChoTatCa(double nhienLieuMoi)
        {
            foreach (var pt in collection)
            {
                pt.DoNhienLieu(nhienLieuMoi);
            }
        }
        #endregion

        #region Thể hiện Hành vi tất cả phương tiện
        public string HienThiHanhViTatCa()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var i in collection)
			{
				sb.Append($"Phương tiện: {i.Ten}\n");
				if (i is IFlyable flyable) sb.Append($" - Hành vi bay: {flyable.Fly()}\n");
				if (i is IDrivable drivable) sb.Append($" - Hành vi lái: {drivable.Drive()}\n");
				if (i is IFloatable floatable) sb.Append($" - Hành vi nổi: {floatable.Float()}\n");
				if (i is ISinkable submersible) sb.Append($" - Hành vi lặn: {submersible.Sink()}\n");
			}
			return sb.ToString();
		}
        #endregion

        #region Nhóm theo nhà sản xuất
        public Dictionary<string, List<IVehicle>> NhomTheoNhaSX()
        {
            Dictionary<string, List<IVehicle>> nhomNhaSX = new Dictionary<string, List<IVehicle>>();
            foreach (var pt in collection)
            {
                if (!nhomNhaSX.ContainsKey(pt.NhaSX))
                    nhomNhaSX[pt.NhaSX] = new List<IVehicle>();
                nhomNhaSX[pt.NhaSX].Add(pt);
            }
            return nhomNhaSX;
        }
        #endregion

        #region Lọc
        public DanhSachPhuongTien LocTheoNamSX(int namSX)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.NamSX == namSX)
                    kq.Them(i);
            return kq;
        }

        public DanhSachPhuongTien LocTheoTocDoToiThieu(int tocDoMin)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.TocDo >= tocDoMin)
                    kq.Them(i);
            return kq;
        }
        public DanhSachPhuongTien LocTheoMucNhienLieuToiThieu(int mucNhienLieuToiThieu)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.NhienLieu >= mucNhienLieuToiThieu)
                    kq.Them(i);
            return kq;
        }
        #endregion


        #region Tìm Phương tiện theo nhà Sản xuất
        public DanhSachPhuongTien TimPhuongTienTheoNhaSX(string nhaSX)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.NhaSX == nhaSX)
                    kq.Them(i);
            return kq;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap2
{
    public class DanhSachNhanVien
    {
        List<INhanVien> collection = new List<INhanVien>();

        public void Them(INhanVien nvql)
        {
            collection.Add(nvql);
        }

        public void DocTuFile()
        {
            
            string filename = "Data.txt";
            StreamReader sr = new StreamReader(filename);
            var line="";
            string[] str = line.Split(',');
            while ((line = sr.ReadLine()) != null)
            {
                   Them(new QuanLy(line));     
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID".PadRight(12)+"Họ".PadRight(20)+"Tên".PadRight(10)+"Phòng".PadRight(10)+"Công việc".PadRight(20)+"Lương".PadRight(8)+"Phần trăm (%)".PadRight(15)+"Tăng lương".PadRight(12));
            sb.AppendLine("========================================================================================================================");
            foreach (var i in collection)
            {
                sb.AppendLine(i.ToString());
            }
            sb.AppendLine("========================================================================================================================");
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }

        public void NhapThuCong()
        {
            Console.Write("Nhập Họ: ");
            string ho = Console.ReadLine();
            Console.Write("Nhập Tên: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập ID của nhân viên: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhập Phòng: ");
            string phong = Console.ReadLine();
            Console.Write("Nhập công việc nhiệm vụ: "); 
            string nhiemvu = Console.ReadLine();
            Console.Write("Nhập Lương: ");
            int luong = int.Parse(Console.ReadLine());
            Them(new QuanLy(ho,ten,id,phong,nhiemvu,luong));
        }
        #region Tìm kiếm
        public DanhSachNhanVien TimTheoID(int id)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var i in collection)
                if (i.NhanVienID == id)
                    kq.Them(i);
            return kq;
        }
        public DanhSachNhanVien TimTheoTen(string ten)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var i in collection)
                if (i is QuanLy ql && ql.Ten == ten)
                    kq.Them(i);
            return kq;
        }
        public DanhSachNhanVien TimTheoPhong(string phong)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var i in collection)
                if (i.Phong == phong)
                    kq.Them(i);
            return kq;
        }
        public DanhSachNhanVien TimTheoLuong(double luong)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var i in collection)
                if (i is QuanLy ql && ql.Luong == luong)
                    kq.Them(i);
            return kq;
        }
       
        #endregion

        #region Sắp Xếp
        void HoanVi(int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
        public void TangTheoID()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].NhanVienID.CompareTo(collection[j + 1].NhanVienID) > 0)
                        HoanVi(j, j + 1);
        }
        public void GiamTheoID()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].NhanVienID.CompareTo(collection[j + 1].NhanVienID) < 0)
                        HoanVi(j, j + 1);
        }
        public void TangTheoTen()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                {
                    var nv1 = collection[j] as QuanLy;
                    var nv2 = collection[j + 1] as QuanLy;
                    if (nv1 != null && nv2 != null)
                    {
                        if (nv1.Ten.CompareTo(nv2.Ten) > 0)
                            HoanVi(j, j + 1);
                    }
                }
        }
        public void GiamTheoTen()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                {
                    var nv1 = collection[j] as QuanLy;
                    var nv2 = collection[j + 1] as QuanLy;
                    if (nv1 != null && nv2 != null)
                    {
                        if (nv1.Ten.CompareTo(nv2.Ten) < 0)
                            HoanVi(j, j + 1);
                    }
                }
        }
        public void TangTheoPhong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].Phong.Length.CompareTo(collection[j + 1].Phong.Length) > 0)
                        HoanVi(j, j + 1);
        }
        public void GiamTheoPhong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].Phong.Length.CompareTo(collection[j + 1].Phong.Length) < 0)
                        HoanVi(j, j + 1);
        }
        public void TangTheoLuong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                {
                    var nv1 = collection[j] as QuanLy;
                    var nv2 = collection[j + 1] as QuanLy;
                    if (nv1 != null && nv2 != null)
                    {
                        if (nv1.Luong.CompareTo(nv2.Luong) > 0)
                            HoanVi(j, j + 1);
                    }
                }
        }
        public void GiamTheoLuong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = 0; j < collection.Count - 1 - i; j++)
                {
                    var nv1 = collection[j] as QuanLy;
                    var nv2 = collection[j + 1] as QuanLy;
                    if (nv1 != null && nv2 != null)
                    {
                        if (nv1.Luong.CompareTo(nv2.Luong) < 0)
                            HoanVi(j, j + 1);
                    }
                }
        }
        #endregion

        #region Xóa

        public void XoaTheoID(int id)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i].NhanVienID == id)
                    collection.RemoveAt(i);
        }
        public void XoaTheoTen(string ten)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if ((collection[i] as QuanLy).Ten == ten)
                    collection.RemoveAt(i);
        }
        public void XoaTheoPhong(string phong)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is QuanLy nv && nv.Phong == phong)
                    collection.RemoveAt(i);
        }
        public void XoaTheoLuong(double luong)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is QuanLy nv && nv.Luong == luong)
                    collection.RemoveAt(i);
        }
        #endregion

        #region Thêm vào vị trí
        public bool KiemTra(int id)
        {
            if (id < 0 && id > collection.Count)
            {
                Console.WriteLine($"Vị trí {id} không tồn tại");
                return false;
            }
            return true;
        }
        public void Them(int vt, QuanLy nguoiMoi)
        {
            if (vt < 0 || vt > collection.Count - 1)
            {
                Console.WriteLine("Vị trí không hợp lệ");
            }     
            collection.Insert(vt, nguoiMoi);

        }
        #endregion

        #region Tính tổng số lương của tất cả nhân viên

        public double TinhTongLuong()
        {
            double tong = 0;
            foreach (var i in collection)
            {
                if (i is QuanLy ql)
                    tong += ql.Luong;
            }
            return tong;
        }

        public double TinhTongLuongDaTang()
        {
            double tong = 0;
            foreach (var i in collection)
            {
                if (i is QuanLy ql)
                    tong += ql.tangLuong;
            }
            return tong;
        }


        #endregion


        #region Cập nhât
        public void CapNhat(int id)
        {
            foreach (var i in collection)
            {
                if (i.NhanVienID == id)
                {
                    Console.WriteLine(i);
                    var NguoiMoi = i;
                    Console.Write("\nNhập phòng: ");
                    NguoiMoi.Phong = Console.ReadLine();
                    Console.Write("Nhập công việc nhiệm vụ: ");
                    (NguoiMoi as QuanLy).NhiemVu = Console.ReadLine();
                    Console.Write("Nhập lương: ");
                    (NguoiMoi as QuanLy).Luong = int.Parse(Console.ReadLine());
                }
            }
        }
        #endregion

    }
}

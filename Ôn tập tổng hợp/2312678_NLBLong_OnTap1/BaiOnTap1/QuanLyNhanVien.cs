using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.CodeDom;

namespace BaiOnTap1
{

    public class QuanLyNhanVien
    {
        List<Nguoi> collection = new List<Nguoi>();
        public void Them(Nguoi nguoi)
        {
            collection.Add(nguoi);
        }

        public void NhapTuFile()
        {
            string tenFile = "Data.txt";
            StreamReader sr = new StreamReader(tenFile);
            string line = "";
            Nguoi a = new Nguoi();
            while ((line = sr.ReadLine()) != null)
            {

                string[] s = line.Split(',');
                string loai = s[0];
                switch (loai)
                {
                    case "Nguoi":
                        a = new Nguoi(line);
                        break;
                    case "NhanVien":
                        a = new NhanVien(line);
                        break;
                    case "QuanLy":
                        a = new QuanLy(line);
                        break;
                }
                Them(a);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|" + "Địa Chỉ".PadRight(20) + "|" + "Tên".PadRight(20) + "|" + "Tuổi".PadRight(10) + "|" + "Lương".PadRight(10) + "|" + "Mã Nhân Viên".PadRight(10) + "|" + "Vị Trí".PadRight(10) + "|" + "Phòng".PadRight(10) + "\n");
            sb.Append("|====================|====================|==========|==========|============|==========|==========" + "\n");
            foreach (var i in collection)
            {
                if (!(i is QuanLy || i is NhanVien))
                {
                    var doiTuong = new QuanLy(i);
                    sb.AppendLine(doiTuong.ToString());
                }
                else sb.AppendLine(i.ToString());
            }
            sb.Append("|====================|====================|==========|==========|============|==========|==========" + "\n");
            return sb.ToString();
        }
        public void NhapThuCong()
        {
            Console.WriteLine("Nhập loại người(Người/Quản Lý/Nhân Viên:)");
            string chon = Console.ReadLine();
            switch (chon)
            {
                case "Người":
                    Console.Write("Nhập địa chỉ:"); string diachi = Console.ReadLine(); Console.Write("Nhập họ và tên:"); string ten = Console.ReadLine();
                    Console.WriteLine("Nhập tuổi:"); int tuoi = int.Parse(Console.ReadLine()); Them(new Nguoi(diachi, ten, tuoi));
                    break;
                case "Nhân Viên":
                    Console.Write("Nhập địa chỉ:"); diachi = Console.ReadLine(); Console.Write("Nhập họ và tên:"); ten = Console.ReadLine();
                    Console.WriteLine("Nhập tuổi:"); tuoi = int.Parse(Console.ReadLine()); Console.Write("Nhập Lương:"); decimal luong = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập mã nhân viên:"); string manv = Console.ReadLine(); string vitri = "Nhân Viên"; Them(new NhanVien(diachi, ten, tuoi, luong, manv, vitri));
                    break;
                case "Quản Lý":
                    Console.Write("Nhập địa chỉ:"); diachi = Console.ReadLine(); Console.Write("Nhập họ và tên:"); ten = Console.ReadLine();
                    Console.Write("Nhập tuổi:"); tuoi = int.Parse(Console.ReadLine()); Console.Write("Nhập Lương:"); luong = decimal.Parse(Console.ReadLine());
                    Console.Write("Nhập mã nhân viên:"); manv = Console.ReadLine(); vitri = "Nhân Viên"; Console.Write("Nhập phòng:"); string phong = Console.ReadLine(); Them(new QuanLy(diachi, ten, tuoi, luong, manv, vitri, phong));
                    break;
            }
        }

        #region Tìm Kiếm
        public QuanLyNhanVien TimTheoTen(string ten)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i.Ten == ten)
                {
                    kq.Them(i);
                }
            }
            return kq;
        }
        public QuanLyNhanVien TimTheoDiaChi(string diachi)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i.DiaChi == diachi)
                {
                    kq.Them(i);
                }
            }
            return kq;
        }
        public QuanLyNhanVien TimTheoTuoi(int tuoi)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i.Tuoi == tuoi)
                {
                    kq.Them(i);
                }
            }
            return kq;
        }
        public QuanLyNhanVien TimTheoLuong(decimal luong)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i is NhanVien nv && nv.Luong == luong) kq.Them(i);
                else if (i is QuanLy ql && ql.Luong == luong) kq.Them(i);
            }
            return kq;
        }
        public QuanLyNhanVien TimTheoMa(string ma)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i is NhanVien nv && nv.MaNhanVien == ma) kq.Them(i);
                else if (i is QuanLy ql && ql.MaNhanVien == ma) kq.Them(i);
            }
            return kq;
        }
        public QuanLyNhanVien TimTheoViTri(string vitri)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i is NhanVien nv && nv.ViTri == vitri) kq.Them(i);
                else if (i is QuanLy ql && ql.ViTri == vitri) kq.Them(i);
            }
            return kq;
        }

        public QuanLyNhanVien TimTheoPhong(string phong)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
            {
                if (i is QuanLy ql && ql.Phong == phong) kq.Them(i);
            }
            return kq;
        }
        #endregion

        #region DS Loại Người
        public QuanLyNhanVien DSNhanVien()
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var nguoi in collection)
                if (nguoi.GetType() == typeof(NhanVien))
                    kq.Them(nguoi);
            return kq;
        }

        public QuanLyNhanVien DSQuanLy()
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var i in collection)
                if (i is QuanLy) kq.Them(i);
            return kq;
        }

        #endregion

        #region Xóa
        public void XoaTheoTen(string ten)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].Ten == ten)
                    collection.RemoveAt(i);
            }
        }


        public void XoaTheoDiaChi(string diaChi)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].DiaChi == diaChi) collection.RemoveAt(i);
            }
        }
        public void XoaTheoTuoi(int tuoi)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].Tuoi == tuoi) collection.RemoveAt(i);
            }
        }

        public void XoaTheoLuong(decimal luong)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i] is NhanVien nv && nv.Luong == luong) collection.RemoveAt(i);
                else if (collection[i] is QuanLy ql && ql.Luong == luong) collection.RemoveAt(i);
            }
        }

        public void XoaTheoMa(string ma)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i] is NhanVien nv && nv.MaNhanVien == ma) collection.RemoveAt(i);
                else if (collection[i] is QuanLy ql && ql.MaNhanVien == ma) collection.RemoveAt(i);
            }
        }

        public void XoaTheoViTri(string vitri)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i] is NhanVien nv && nv.ViTri == vitri) collection.RemoveAt(i);
                else if (collection[i] is QuanLy ql && ql.ViTri == vitri) collection.RemoveAt(i);
            }
        }

        public void XoaTheoPhong(string phong)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i] is QuanLy ql && ql.Phong == phong) collection.RemoveAt(i);
            }
        }
        #endregion

        #region Sắp Xếp
        void HoanVi(int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        public void TangTheoTen()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].Ten.CompareTo(collection[j].Ten) > 0) HoanVi(i, j);
                }
        }

        public void GiamTheoTen()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                    if (collection[i].Ten.CompareTo(collection[j].Ten) < 0) HoanVi(i, j);
        }

        public void TangTheoDiaChi()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                    if (collection[i].DiaChi.CompareTo(collection[j].DiaChi) > 0) HoanVi(i,j);
        }

        public void GiamTheoDiaChi()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                    if (collection[i].DiaChi.CompareTo(collection[j].DiaChi) < 0) HoanVi(i, j);
        }

        public void TangTheoTuoi()
        {
               for(int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                if (collection[i].Tuoi.CompareTo(collection[j].Tuoi) > 0) HoanVi(i,j);
        }

        public void GiamTheoTuoi()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                    if (collection[i].Tuoi.CompareTo(collection[j].Tuoi) < 0) HoanVi(i,j);
        }

        public void TangTheoLuongCuaNhanVien()
        {
            for (int i = 0; i < collection.Count-1; i++)
                for (int j = i+1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if(nv1.Luong.CompareTo(nv2.Luong)>0)
                                HoanVi(i, j);
                }  
        }

        public void GiamTheoLuongCuaNhanVien()
        {
            for (int i = 0; i < collection.Count-1; i++)
                for (int j = i+1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if (nv1.Luong.CompareTo(nv2.Luong) < 0)
                            HoanVi(i,j);
                }    
        }

        public void TangTheoViTriCuaNhanVien()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if (nv1.ViTri.CompareTo(nv2.ViTri) > 0)
                            HoanVi(i, j);
                }
        }

        public void GiamTheoViTriCuaNhanVien()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if (nv1.ViTri.CompareTo(nv2.ViTri) < 0)
                            HoanVi(i, j);
                }
        }

        public void TangTheoMaCuaNhanVien()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if (nv1.MaNhanVien.CompareTo(nv2.MaNhanVien) > 0)
                            HoanVi(i, j);
                }
        }

        public void GiamTheoMaCuaNhanVien()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var nv1 = collection[i] as NhanVien;
                    var nv2 = collection[j] as NhanVien;
                    if (nv1 != null && nv2 != null)
                        if (nv1.MaNhanVien.CompareTo(nv2.MaNhanVien) < 0)
                            HoanVi(i, j);
                }
        }

        public void TangTheoPhong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var ql1 = collection[i] as QuanLy;
                    var ql2 = collection[j] as QuanLy;
                    if (ql1 != null && ql2 != null)
                        if (ql1.Phong.CompareTo(ql2.Phong) > 0)
                            HoanVi(i, j);
                }
        }

        public void GiamTheoPhong()
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var ql1 = collection[i] as QuanLy;
                    var ql2 = collection[j] as QuanLy;
                    if (ql1 != null && ql2 != null)
                        if (ql1.Phong.CompareTo(ql2.Phong) < 0)
                            HoanVi(i, j);
                }
        }
        #endregion

        #region Thêm
        public void ThemVaoViTri(Nguoi nguoi, int viTri)
        {
            if (viTri < 0 || viTri > collection.Count + 1)
            {
                Console.WriteLine("Vị trí không hợp lệ.");
                return;
            }
            collection.Insert(viTri, nguoi);
        }
        #endregion

    }
}




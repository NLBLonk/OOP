using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace QuanLySinhVien
{
    internal class DanhSachSinhVien
    {
        List<SinhVien> ds = new List<SinhVien>();
        List<SinhVien> kq = new List<SinhVien>();
        public void Xuat()
        {
            Console.WriteLine("MSSV".PadRight(6) + "Ho Ten".PadRight(21) + "DTB".PadRight(6) + "Gioi Tinh".PadRight(12) + "Lop".PadRight(10));
            foreach (var sv in kq)
                Console.WriteLine(sv);
        }
        public void Them(SinhVien sv)
        {
            ds.Add(sv);
        }
        public void NhapTuFile()
        {
            var fileName = "data.txt";
            StreamReader sr = new StreamReader(fileName);
            var line = "";
            while((line=sr.ReadLine()) != null)
            {
                Them(new SinhVien(line));
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MSSV".PadRight(6) + "Ho Ten".PadRight(24) + "DTB".PadRight(6) + "Gioi Tinh" + " Lop \n".PadLeft(6));
            foreach(var sv in ds)
            {
                sb.Append(sv + "\n");
            }
            return sb.ToString();
        }

        public double TimDTBCaoNhat()
        {
            return ds.Max(x => x.dTB);
        }

        public DanhSachSinhVien TimDSSVCoDTBCaoNhat()
        {
            DanhSachSinhVien kq = new DanhSachSinhVien();
            double max = TimDTBCaoNhat();
            foreach (var item in ds)
            {
                if (item.dTB == max)
                    kq.Them(item);
            }
            return kq;
        }
        private int DemSoLuongSVTheoGioiTinhvaLop(bool GT, string lop)
        {
            return ds.Count(x => x.gioiTinh == GT && x.Lop == lop);
        }
        public int DemSoLuongSVNam(string lop)
        {
            return DemSoLuongSVTheoGioiTinhvaLop(true, lop);
        }
        public int DemSoLuongSVNu(string lop)
        {
            return DemSoLuongSVTheoGioiTinhvaLop(false, lop);
        }
        public List<string> LayDSLop()
        {
            List<string> kq = new List<string>();
            foreach(var sv in ds)
            {
                if(!kq.Contains(sv.Lop))
                    kq.Add(sv.Lop);
            }
            return kq;
        }
        public enum KieuSapXep
        { 
            TangDTB,
            GiamDTB
        }
        void SapXep(KieuSapXep kieu)
        {
            if (kieu== KieuSapXep.TangDTB)
                ds.Sort((sv1,sv2)=>sv1.dTB.CompareTo(sv2.dTB));
            if (kieu == KieuSapXep.GiamDTB)
                ds.Sort((sv1,sv2)=>-sv1.dTB.CompareTo(sv2.dTB));
        }
        public void SapXepTangTheoDTB()
        {
            SapXep(KieuSapXep.TangDTB);
        }
        public void SapXepGiamTheoDTB()
        {
            SapXep(KieuSapXep.GiamDTB);
        }
        public List<string> TimLopCoDTBCaoNhat()
        {
            List<string> lopDiemCao = new List<string>();
            double max = TimDTBCaoNhat();
            foreach(var i in ds)
            {
                if (i.dTB==max&& !lopDiemCao.Contains(i.Lop))
                {
                    lopDiemCao.Add(i.Lop);
                }
            }
            return lopDiemCao;
        }

        public List<string>TimLopKhongCoDTBCaoNhat()
        {
            List<string> lopDiemCao = TimLopCoDTBCaoNhat();
            List<string> lopKoCao= new List<string>();
            foreach (var i in ds)
            {
                if (!lopDiemCao.Contains(i.Lop) && !lopKoCao.Contains(i.Lop))
                {
                    lopKoCao.Add(i.Lop);
                }
            }
            return lopKoCao;
        }

        int TimViThuSV(SinhVien sv)
        {
            int vt = -1;
            foreach(var i in ds)
            {
                if (sv.Lop == i.Lop && sv.dTB < i.dTB)
                    vt++;
            }
            return vt;
        }

        private List<SinhVien> TimTheoLop(string lop)
        {
            foreach (var sv in ds)
                if (sv.Lop == lop)
                    kq.Add(sv);
            return kq;
        }
        public List<SinhVien> XepHangTheoLop(string lop)
        {
            kq = TimTheoLop(lop);
            kq.Sort((sv1, sv2) => -sv1.dTB.CompareTo(sv2.dTB));
            return kq;
        }

        public List<string> LopKoCoSVNam()
        {
            var lopKoCoSVNam = ds.Where(sv => sv.gioiTinh != true).Select(sv => sv.Lop).Distinct().ToList();
            return lopKoCoSVNam;
        }

        public List<string> LopKoCoSVNu()
        {
            var lopKoCoSVNu = ds.Where(sv => sv.gioiTinh != false).Select(sv => sv.Lop).Distinct().ToList();
            return lopKoCoSVNu;
        }

        public List<string> DanhSachSVTheoLop()
        {
            return ds.Select(sv => sv.Lop).Distinct().ToList();
        }
        public List<int> DemSoLuongSVTheoLop()
        {
            var soLuongSV = new List<int>();
            var lops = DanhSachSVTheoLop();
            foreach (var lop in lops)
            {
                int count = ds.Count(sv => sv.Lop == lop);
                soLuongSV.Add(count);
            }
            return soLuongSV;
        }
        public void XoaSVCuaLop(string x)
        {
            ds.RemoveAll(sv => sv.Lop == x);
        }

        public string XepLoai(double diem)
        {
            if (diem >= 8.0)
                return "Gioi";
            else if (diem >= 6.5)
                return "Kha";
            else if (diem >= 5.0)
                return "Trung binh";
            else
                return "Yeu";
        }
        public void HienThiXepLoaiSinhVien()
        {
            foreach (var sv in ds)
            {
                string xepLoai = XepLoai(sv.dTB);
                Console.WriteLine($"Sinh vien: {sv.hoten}   || Diem trung binh: {sv.dTB}  Xep loai: {xepLoai}");
            }
        }
    }
}

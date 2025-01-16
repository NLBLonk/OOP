using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    public class DanhSachNhanVien
    {

        List<NhanVien> NV = new List<NhanVien>();
        List<ChiNhanh> CN = new List<ChiNhanh>();
        List<KyNang> KN = new List<KyNang>();
        List<NhanVienKyNang> NVKN = new List<NhanVienKyNang>();
        public void Them<T>(T kq)
        {
            if (typeof(T) == typeof(ChiNhanh))
            {
                CN.Add(kq as ChiNhanh);
            }
            else if (typeof(T) == typeof(NhanVien))
            {
                NV.Add(kq as NhanVien);
            }
            else if (typeof(T) == typeof(KyNang))
            {
                KN.Add(kq as KyNang);
            }
            else
            {
                NVKN.Add(kq as NhanVienKyNang);
            }
        }
        public void NhapTuFile()
        {
            string filename = "Data.txt";
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                string[] s = line.Split(',');
                if (s[0] == nameof(ChiNhanh))
                {
                    Them<ChiNhanh>(new ChiNhanh { MSCN = int.Parse(s[1]), TenCN = s[2].Trim() });
                }
                else if (s[0] == nameof(NhanVien))
                {
                    Them<NhanVien>(new NhanVien { MANV = int.Parse(s[1]), Ho = s[2].Trim(), Ten = s[3].Trim(), NgaySinh = DateTime.ParseExact(s[4], "dd/MM/yyyy", CultureInfo.InvariantCulture), NgayVaoLam = DateTime.ParseExact(s[5], "dd/MM/yyyy", CultureInfo.InvariantCulture), MaCN = int.Parse(s[6]) });
                }
                else if (s[0] == nameof(KyNang))
                {
                    Them<KyNang>(new KyNang { MSKN = int.Parse(s[1]), TenKN = s[2].Trim() });
                }
                else if (s[0] == nameof(NhanVienKyNang))
                {
                    Them<NhanVienKyNang>(new NhanVienKyNang { MSNV = int.Parse(s[1]), MSKN = int.Parse(s[2]), MucDo = int.Parse(s[3]) });
                }
                else
                {
                    Console.WriteLine("Dữ liệu không phù hợp với file! ");
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|Mã NV".PadRight(11) + "|" + "Họ".PadRight(15) + "|" + "Tên".PadRight(7) + "|" + "Ngày sinh".PadRight(25) + "|" + "Ngày vào làm".PadRight(25) + "|" + "MaCN".PadRight(5) + "|" + "\n");
            sb.Append("|==========|===============|=======|=========================|=========================|=====|" + "\n");
            foreach (var nguoi in NV)
                sb.AppendLine(nguoi.ToString());
            sb.Append("|==========|===============|=======|=========================|=========================|=====|" + "\n");
            return sb.ToString();
        }
        public string HienThiNhanVien()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|MSNV".PadRight(11) + "|" + "Họ Tên".PadRight(21) + "|" + "Số năm làm việc".PadRight(15) + "|" + "\n");
            sb.Append("|==========|=====================|===============|" + "\n");
            foreach (var nv in NV)
                sb.Append($"|{nv.MANV,-10}|{nv.HoTen,-21}|{nv.SoNamLamViec,-15}|" + "\n");
            sb.Append("|==========|=====================|===============|" + "\n");
            return sb.ToString();
        }
        public DanhSachNhanVien TimTheoChiNhanh(int maCN)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var nv in NV)
                if (nv.MaCN == maCN)
                    kq.Them(nv);
            return kq;
        }
        private bool CoKyNang(int msnv, int mskn)
        {
            foreach (var nvkn in NVKN)
                if (nvkn.MSNV == msnv && nvkn.MSKN == mskn)
                    return true;
            return false;
        }
        private string DinhDangThongTinNhanVien(NhanVien nv)
        {
            int soNamLamViec = DateTime.Now.Year - nv.NgayVaoLam.Year;
            if (DateTime.Now.DayOfYear < nv.NgayVaoLam.DayOfYear)
                soNamLamViec--;
            return $"|{nv.MANV,-10}|{(nv.Ho + " " + nv.Ten),-21}|{soNamLamViec,-15}|";
        }
        private void HienThiTieuDe(StringBuilder sb)
        {
            sb.Append("|MSNV".PadRight(11) + "|" + "Họ Tên".PadRight(21) + "|" + "Số năm làm việc".PadRight(15) + "|" + "\n");
            sb.Append("|==========|=====================|===============|" + "\n");
        }
        private void HienThiNhanVienCoKyNangWord(StringBuilder sb)
        {
            foreach (var nv in NV)
            {
                if (CoKyNang(nv.MANV, 1))
                {
                    sb.AppendLine(DinhDangThongTinNhanVien(nv));
                }
            }
        }
        private void HienThiChanTrang(StringBuilder sb)
        {
            sb.Append("|==========|=====================|===============|" + "\n");
        }
        public string LietKeNhanVienWord()
        {
            StringBuilder sb = new StringBuilder();
            HienThiTieuDe(sb);
            HienThiNhanVienCoKyNangWord(sb);
            HienThiChanTrang(sb);
            return sb.ToString();
        }
        public void HienThiKyNangLeAnhTuan(StringBuilder sb)
        {
            foreach (var nv in NV)
            {
                if (nv.Ho == "Le Anh" && nv.Ten == "Tuan")
                {
                    foreach (var nvkn in NVKN)
                    {
                        if (nvkn.MSNV == nv.MANV)
                        {
                            var kynang = KN.Find(kn => kn.MSKN == nvkn.MSKN);
                            if (kynang != null)
                            {
                                sb.AppendLine($"|{kynang.TenKN,-21}|{nvkn.MucDo,-13}|");
                            }
                        }
                    }
                }
            }
        }
        public void LietKeKyNangLeAnhTuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|TenKN                |MucDo        |");
            sb.AppendLine("|=====================|=============|");
            HienThiKyNangLeAnhTuan(sb);
            sb.AppendLine("|=====================|=============|");
            Console.WriteLine(sb.ToString());
        }
        public int MucDoExcelCaoNhat()
        {
            int mucDoMax = int.MinValue;
            foreach (var i in NVKN)
                if (i.MucDo > mucDoMax)
                    mucDoMax = i.MucDo;
            return mucDoMax;
        }
        public DanhSachNhanVien TimNhanVienMucDoExcelCaoNhat()
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            int mucDoMax = MucDoExcelCaoNhat();
            foreach (var i in NV)
                if (i.MANV == mucDoMax)
                    kq.Them(i);
            return kq;
        }
        private void HienNhanVienCoKyNangWordVaExcel(StringBuilder sb)
        {
            foreach (var i in NV)
            {
                if (CoKyNang(i.MANV, 1) & CoKyNang(i.MANV, 2))
                {
                    var j = CN.FirstOrDefault(x => x.MSCN == i.MaCN);
                    sb.AppendLine(LietKeNVWordAndExcel(i, j));
                }
            }
        }
        private void HienThiTieuDe2(StringBuilder sb)
        {
            sb.Append("|MSNV".PadRight(11) + "|" + "Họ Tên".PadRight(21) + "|" + "Tên Chi Nhánh".PadRight(15) + "|" + "\n");
            sb.Append("|==========|=====================|===============|" + "\n");
        }
        private string LietKeNVWordAndExcel(NhanVien nv, ChiNhanh cn)
        {
            return $"|{nv.MANV,-10}|{nv.HoTen,-21}|{cn.TenCN,-15}| ";
        }
        public string LietKeNhanVienWordAndExcel()
        {
            StringBuilder sb = new StringBuilder();
            HienThiTieuDe2(sb);
            HienNhanVienCoKyNangWordVaExcel(sb);
            HienThiChanTrang(sb);
            return sb.ToString();
        }
        public void LietKeNhanVienKyNangMax()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("| MANV | HoTen               | TenCN       | TenKN        | MucDo |");
            sb.AppendLine("|------|---------------------|-------------|--------------|-------|");
            foreach (var skill in KN)
            {
                var maxSkillLevel = NVKN.Where(nvkn => nvkn.MSKN == skill.MSKN).Max(nvkn => nvkn.MucDo);
                var topEmployees = NVKN.Where(nvkn => nvkn.MSKN == skill.MSKN && nvkn.MucDo == maxSkillLevel).Select(nvkn => new
                {
                    nvkn.MSNV,
                    nvkn.MucDo
                });
                foreach (var topEmployee in topEmployees)
                {
                    var employee = NV.FirstOrDefault(e => e.MANV == topEmployee.MSNV);
                    var branch = CN.FirstOrDefault(b => b.MSCN == employee.MANV);
                    if (employee != null && branch != null)
                        sb.AppendLine($"| {employee.MANV} | {employee.Ho} {employee.Ten,-16} | {branch.TenCN,-11} | {skill.TenKN,-12} | {topEmployee.MucDo,-5} |");
                }
            }
        }
    }
}

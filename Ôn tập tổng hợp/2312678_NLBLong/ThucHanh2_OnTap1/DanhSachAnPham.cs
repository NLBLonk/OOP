using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ThucHanh2_OnTap1
{
    public class DanhSachAnPham
    {
        List<AnPham> collection = new List<AnPham>();
        private void Them(AnPham anpham)
        {
            collection.Add(anpham);
        }

        public void NhapTuFile()
        {
            string filename = "Data.txt";
            StreamReader sr = new StreamReader(filename);
            string line = "";
            AnPham ap = new AnPham();
            while((line=sr.ReadLine()) != null)
            {
                string[] str = line.Split(',');
                string loai = str[0];
                switch (loai)
                {
                    case "AnPham":
                        ap = new AnPham(line);
                        break;
                    case "TapChi":
                        ap = new TapChi(line);
                        break;
                    case "Sach":
                        ap = new Sach(line);
                        break;
                }
                Them(ap);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nam".PadRight(10)+"|"+"Nhà Xuất Bản".PadRight(15)+"|"+"Tựa Đề".PadRight(15)+"|"+"So".PadRight(10)+"|"+"Tap".PadRight(10)+"|"+"ISBN".PadRight(15)+"|"+"Tác Giả".PadRight(15) + "\n");
            sb.Append("=============================================================================================" + "\n");
            foreach(var i in collection)
            {
                if (!(i is TapChi) && (!(i is Sach)))
                {
                    var doiTuong = new Sach(i);
                    sb.AppendLine(doiTuong.ToString());
                }
                else
                    sb.AppendLine(i.ToString());
            }    
            sb.Append("=============================================================================================");
            return sb.ToString();
        }

        public void NhapThuCong()
        {
            Console.Clear();
            Console.Write("Vui lòng chọn loại Ấn Phẩm (AnPham/Sach/Tapchi)");
            string chon = Console.ReadLine();
            switch(chon)
            {
                case "AnPham":
                    Console.Write("Nhập năm:"); int nam = int.Parse(Console.ReadLine());
                    Console.Write("Nhập NXB:"); string nhaXuatBan = Console.ReadLine();
                    Console.Write("Nhập Tựa Đề:"); string tuaDe = Console.ReadLine();
                    Them(new AnPham(nam, nhaXuatBan, tuaDe));
                    break;
                case "TapChi":
                    Console.Write("Nhập năm:");  nam = int.Parse(Console.ReadLine());
                    Console.Write("Nhập NXB:");  nhaXuatBan = Console.ReadLine();
                    Console.Write("Nhập Tựa Đề:"); tuaDe = Console.ReadLine();
                    Console.Write("Nhập số:"); int so = int.Parse(Console.ReadLine()); Console.Write("Nhập tập:"); int tap = int.Parse(Console.ReadLine());
                    Them(new TapChi(nam,nhaXuatBan,tuaDe,so,tap));
                    break;
                case "Sach":
                    Console.Write("Nhập năm:"); nam = int.Parse(Console.ReadLine());
                    Console.Write("Nhập NXB:"); nhaXuatBan = Console.ReadLine();
                    Console.Write("Nhập Tựa Đề:"); tuaDe = Console.ReadLine();
                    Console.Write("Nhập ISBN:"); string ISBN = Console.ReadLine(); Console.Write("Nhập tác giả:"); string tacGia = Console.ReadLine();
                    Them(new Sach(nam, nhaXuatBan, tuaDe,ISBN,tacGia));
                    break;
            }    
        }
        #region LẤY DANH SÁCH
        public DanhSachAnPham LayDSTapChi()
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is TapChi) kq.Them(i);

            }
            return kq;
        }

        public DanhSachAnPham LayDScuaSach()
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is Sach) kq.Them(i);

            }
            return kq;
        }
        #endregion

        #region TÌM KIẾM
        public DanhSachAnPham TimTheoTen(string tuaDe)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach(var i in collection)
            {
                if (i.TuaDe == tuaDe) kq.Them(i);
            }    
            return kq;
        }
        public DanhSachAnPham TimTheoNXB(string NXB)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i.NhaXuatBan == NXB) kq.Them(i);
            }
            return kq;
        }

        public DanhSachAnPham TimTheoISBN(string ISBN)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is Sach sach && sach.ISBN == ISBN) kq.Them(i);
            }
            return kq;
        }
        public DanhSachAnPham TimTheoTacGia(string tacGia)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is Sach sach && sach.TacGia == tacGia) kq.Them(i);
            }
            return kq;
        }

        public DanhSachAnPham TimTheoTap(int tap)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is TapChi tc && tc.Tap==tap) kq.Them(i);
            }
            return kq;
        }
        public DanhSachAnPham TimTheoSo(int so)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i is TapChi tc && tc.So == so) kq.Them(i);
            }
            return kq;
        }

        public DanhSachAnPham TimTheoNam(int nam)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var i in collection)
            {
                if (i.Nam == nam) kq.Them(i);
            }
            return kq;
        }

        #endregion

        #region XÓA
        public void XoaTheoTuaDe(string tuaDe)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i].TuaDe == tuaDe)
                    collection.RemoveAt(i);
        }

        public void XoaTheoNXB(string NXB)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i].NhaXuatBan == NXB)
                    collection.RemoveAt(i);
        }

        public void XoaTheoTacGia(string tacGia)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is Sach sach && sach.TacGia == tacGia)
                    collection.RemoveAt(i);
        }
        public void XoaTheoISBN(string ISBN)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is Sach sach && sach.ISBN == ISBN)
                    collection.RemoveAt(i);
        }
        public void XoaTheoNam(int nam)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i].Nam == nam)
                    collection.RemoveAt(i);
        }
        public void XoaTheoTap(int tap)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is TapChi tc && tc.Tap == tap)
                    collection.RemoveAt(i);
        }

        public void XoaTheoSo(int so)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                if (collection[i] is TapChi tc && tc.So == so)
                    collection.RemoveAt(i);
        }
        #endregion

        #region SẮP XẾP

        void HoanVi(int i,int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
        public void TangTheoNam()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].Nam.CompareTo(collection[j + 1].Nam) > 0)
                        HoanVi(j, j + 1);
            }
        }

        public void GiamTheoNam()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].Nam.CompareTo(collection[j + 1].Nam) < 0)
                        HoanVi(j, j + 1);
            }
        }

        public void TangTheoNXB()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].NhaXuatBan.CompareTo(collection[j + 1].NhaXuatBan) > 0)
                        HoanVi(j, j + 1);
            }
        }

        public void GiamTheoNXB()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].NhaXuatBan.CompareTo(collection[j + 1].NhaXuatBan) < 0)
                        HoanVi(j, j + 1);
            }
        }
        public void TangTheoTuaDe()
        {
            for(int i= 0; i<collection.Count-1;i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].TuaDe.CompareTo(collection[j + 1].TuaDe) > 0)
                        HoanVi(j, j+1);
            }   
        }

        public void GiamTheoTuaDe()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - 1 - i; j++)
                    if (collection[j].TuaDe.CompareTo(collection[j + 1].TuaDe) < 0)
                        HoanVi(j, j + 1);
            }
        }

        
        public void TangTheoTap()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i+1; j < collection.Count; j++)
                {
                    var tapchi1 = collection[i] as TapChi;
                    var tapchi2 = collection[j] as TapChi;
                    if (tapchi1 != null && tapchi2 != null)
                        if (tapchi1.Tap>tapchi2.Tap) 
                            HoanVi(i, j);
                }            
            }
        }
        public void GiamTheoTap()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var tapchi1 = collection[i] as TapChi;
                    var tapchi2 = collection[j] as TapChi;
                    if (tapchi1 != null && tapchi2 != null)
                        if (tapchi1.Tap < tapchi2.Tap)
                            HoanVi(i, j);
                }
            }
        }
        public void TangTheoSo()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var tapchi1 = collection[i] as TapChi;
                    var tapchi2 = collection[j] as TapChi;
                    if (tapchi1 != null && tapchi2 != null)
                        if (tapchi1.So > tapchi2.So)
                            HoanVi(i, j);
                }
            }
        }
        public void GiamTheoSo()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var tapchi1 = collection[i] as TapChi;
                    var tapchi2 = collection[j] as TapChi;
                    if (tapchi1 != null && tapchi2 != null)
                        if (tapchi1.So < tapchi2.So)
                            HoanVi(i, j);
                }
            }
        }

        public void TangTheoISBN()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var s1 = collection[i] as Sach;
                    var s2 = collection[j] as Sach;
                    if (s1 != null && s2 != null)
                        if (s1.ISBN.CompareTo(s2.ISBN)>0)
                            HoanVi(i, j);
                }
            }
        }
        public void GiamTheoISBN()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var s1 = collection[i] as Sach;
                    var s2 = collection[j] as Sach;
                    if (s1 != null && s2 != null)
                        if (s1.ISBN.CompareTo(s2.ISBN) < 0)
                            HoanVi(i, j);
                }
            }
        }

        public void TangTheoTacGia()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var s1 = collection[i] as Sach;
                    var s2 = collection[j] as Sach;
                    if (s1 != null && s2 != null)
                        if (s1.TacGia.CompareTo(s2.TacGia) > 0)
                            HoanVi(i, j);
                }
            }
        }
        public void GiamTheoTacGia()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var s1 = collection[i] as Sach;
                    var s2 = collection[j] as Sach;
                    if (s1 != null && s2 != null)
                        if (s1.TacGia.CompareTo(s2.TacGia) < 0)
                            HoanVi(i, j);
                }
            }
        }
        #endregion

    }
}

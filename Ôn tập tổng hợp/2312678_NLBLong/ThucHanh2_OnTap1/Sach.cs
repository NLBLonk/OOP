using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_OnTap1
{
    public class Sach:AnPham
    {
        public string ISBN { get; set; }
        public string TacGia { get; set; }

        public Sach()
        {

        }
        public Sach(int nam, string nhaXuatBan, string tuaDe,string iSBN, string tacGia):base(nam,nhaXuatBan,tuaDe)
        {
            ISBN = iSBN;
            TacGia = tacGia;
        }

        public Sach(string line) : base(line)
        {
            string[] str = line.Split(',');
            //str[4] = "";
            //str[5] = "";
            ISBN = str[6];
            TacGia = str[7];
        }

        public Sach(AnPham anpham)
        {
            base.Nam = anpham.Nam;
            base.NhaXuatBan = anpham.NhaXuatBan;
            base.TuaDe = anpham.TuaDe;
            ISBN = "";
            TacGia = "";
        }

        public Sach(TapChi tapChi):this(tapChi as AnPham)
        {
            tapChi.So = 0;
            tapChi.Tap = 0;
        }
        

        public override void HienThiThongTin()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return base.ToString()+string.Format($"{"",10}|{"",10}|{ISBN,-15}|{TacGia,-15}");
        }

    }
}

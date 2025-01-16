using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_OnTap1
{
    public class TapChi:AnPham
    {
        public int So { get; set; }
        public int Tap { get; set; }
        public TapChi()
        {

        }
        public TapChi(int nam,string nhaXuatBan,string tuaDe,int so, int tap):base(nam,nhaXuatBan,tuaDe)
        {
            So = so;
            Tap = tap;
        }
        public TapChi(AnPham anPham)
        {
            base.Nam = anPham.Nam;
            base.NhaXuatBan = anPham.NhaXuatBan;
            base.TuaDe = anPham.TuaDe;
            So = 0;
            Tap = 0;

        }

        public TapChi(string line):base(line)
        {
            string[] str = line.Split(',');
            So = int.Parse(str[4]);
            Tap = int.Parse(str[5]);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($"{So,-10}|{Tap,-10}|{"",15}|");
        }
    }
}

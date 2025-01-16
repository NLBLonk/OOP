using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap1
{
    public class Nguoi
    {
        public string DiaChi { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public Nguoi()
        {

        }
        public Nguoi(string diaChi, string ten, int tuoi)
        {
            DiaChi = diaChi;
            Ten = ten;
            Tuoi = tuoi;
        }
        public Nguoi(string line)
        {
            string[] str = line.Split(',');
            DiaChi = str[1];
            Ten = str[2];
            Tuoi = int.Parse(str[3]);
        }
        public virtual void HienThiThongTin()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return string.Format($"|{DiaChi,-20}|{Ten,-20}|{Tuoi,-10}|");
        }
    }
}

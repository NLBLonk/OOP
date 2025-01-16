using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public class Motorcycle:Vehicle,IMotorcycle
    {
        public Motorcycle()
        {
              
        }
        public Motorcycle(string ten,int tocDo)
        {
            Ten = ten;
            TocDo = tocDo;
        }
        public void GiamToc()
        {
            Console.WriteLine("Dang tang toc...");
        }
        public void TangToc()
        {
            Console.WriteLine("Dang giam toc...");
        }

        public override string ToString()
        {
            return string.Format($"{"Motorcycle",10}|{Ten,15}|{TocDo,10}|               |");
        }
    }
}

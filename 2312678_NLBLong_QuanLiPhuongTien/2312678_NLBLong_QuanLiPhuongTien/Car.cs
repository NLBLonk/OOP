using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public class Car:Vehicle,ICar
    {
        public int SoChoNgoi { get; set; }

        public Car()
        {

        }
        public Car(string ten, int tocDo,int sochongoi)
        {
            Ten = ten;
            TocDo = tocDo;
            SoChoNgoi = sochongoi;
        }

        public void MoCua()
        {
            Console.WriteLine("Xe da mo cua...");
        }

        public void DongCua()
        {
            Console.WriteLine("Xe da dong cua...");
        }

        public override string ToString()
        {
            return string.Format($"{"Car",10}|{Ten,15}|{TocDo,10}|{SoChoNgoi,15}|");
        }
    }
}

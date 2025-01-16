using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public class Vehicle:IVehicle
    {
 
        public string Ten { get; set; }
        public int TocDo { get; set; }

        public void Chay()
        {
            Console.WriteLine("Xe dang khoi dong va chay...");
        }
        public void Dung()
        {
            Console.WriteLine("Xe dang dung...");
        }
    }
}

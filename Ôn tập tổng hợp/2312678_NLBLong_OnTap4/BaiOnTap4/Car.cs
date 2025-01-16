using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class Car:Vehicle,IDrivable
    {
   
        public Car()
        {
            
        }
        public Car(string ten, int tocDo,double nhienLieu,int quangDuong,string nhaSX,int namSX):base(ten,tocDo,nhienLieu,quangDuong,nhaSX,namSX)
        {
           
        }

        public Car(string line):base(line) 
        {
            
        }



        public string Drive()
        {
           return"...Lái xe...";
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

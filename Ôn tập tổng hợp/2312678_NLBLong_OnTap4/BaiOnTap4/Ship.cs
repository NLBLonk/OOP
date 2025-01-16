using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class Ship:Vehicle,IFloatable
    {
        public Ship()
        {
            
        }

        public Ship(string ten, int tocDo, double nhienLieu,int quangDuong,string nhaSX,int namSX):base(ten, tocDo, nhienLieu, quangDuong, nhaSX, namSX)
        {
           
        }
        public Ship(string line):base(line) 
        {

        }
        public string Float()
        {
            return "...Thuyền đang nổi...";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

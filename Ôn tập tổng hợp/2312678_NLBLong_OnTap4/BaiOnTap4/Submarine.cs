using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class Submarine : Vehicle,ISinkable,IFloatable
    {
       
        public Submarine()
        {
            
        }

        public Submarine(string ten, int tocDo, double nhienLieu, int quangDuong, string nhaSX, int namSX) : base(ten, tocDo, nhienLieu, quangDuong, nhaSX, namSX)
        {

        }

        public Submarine(string line):base(line) 
        {

        }

        public string Sink()
        {
            return"...Đang lặn chìm...";
        }

        public string Float()
        {
            return "...Đang nổi...";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

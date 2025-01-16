using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public class Seaplane:Vehicle,IFlyable,IFloatable
    {
        public Seaplane()
        {

        }

        public Seaplane(string ten, int tocDo, double nhienLieu, int quangDuong, string nhaSX, int namSX) : base(ten, tocDo, nhienLieu, quangDuong, nhaSX, namSX)
        {
        }

        public Seaplane(string line):base(line) 
        {

        }
        public string Fly()
        {
            return "...Bay lượn...";
        }

        public string Float() 
        { 
            return "..Đang nổi..."; 
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public interface IVehicle
    {
        string Ten { get; set; }
        int TocDo { get; set; }

        void Chay();
        void Dung();
    }
}

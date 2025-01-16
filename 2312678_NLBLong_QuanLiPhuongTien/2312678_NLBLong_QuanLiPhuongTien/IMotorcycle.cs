using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    public interface IMotorcycle
    {
        string Ten { get; set; }
        int TocDo { get; set; }

        void GiamToc();
        void TangToc();
    }
}

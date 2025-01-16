using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap4
{
    public interface IVehicle
    {
        string Ten { get; set; }
        int TocDo { get; set; }
        double NhienLieu { get; set; }
        int QuangDuong { get; set; }

        string NhaSX { get; set; }
        int NamSX {  get; set; }

        void TangToc(int giaTang);
        void DoNhienLieu(double nhienLieuMoi);

    }
}

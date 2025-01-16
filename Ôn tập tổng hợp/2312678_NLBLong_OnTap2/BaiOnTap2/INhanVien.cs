using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap2
{
    public interface INhanVien
    {
        int NhanVienID { get; set; }
        string Phong { get; set; }
        double Luong { get; set; }
        string LayThongTinChiTiet();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    public class NhanVienKyNang
    {
        public int MSNV { get; set; }
        public int MSKN { get; set; }
        public int MucDo { get; set; }
        public NhanVienKyNang() { }
        public NhanVienKyNang(int mSNV, int mSKN, int mucDo)
        {
            MSNV = mSNV;
            MSKN = mSKN;
            MucDo = mucDo;
        }
        public override string ToString()
        {
            return string.Format($"Mã nhân viên: {MSNV}  Mã số kỹ năng: {MSKN}  Mức độ thành thạo: {MucDo}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    public class KyNang
    {
        public int MSKN { get; set; }
        public string TenKN { get; set; }
        public KyNang(int mSKN, string tenKN)
        {
            MSKN = mSKN;
            TenKN = tenKN;
        }

        public KyNang() { }
        public override string ToString()
        {
            return string.Format($"Mã số kỹ năng: {MSKN}  Tên kỹ năng: {TenKN}");
        }
    }
}

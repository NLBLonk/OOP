using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap3
{
    public class ChiNhanh
    {
        public int MSCN { get; set; }
        public string TenCN { get; set; }
        public ChiNhanh(int mSCN, string tenCN)
        {
            MSCN = mSCN;
            TenCN = tenCN;
        }
        public ChiNhanh() { }
        public override string ToString()
        {
            return string.Format($"Mã số chi nhánh: {MSCN}  Tên chi nhánh: {TenCN}");
        }


    }
}

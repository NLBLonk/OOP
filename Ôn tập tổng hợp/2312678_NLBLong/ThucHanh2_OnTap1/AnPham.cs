using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_OnTap1
{
    public class AnPham
    {
        public int Nam { get; set; }
        public string NhaXuatBan { get; set; }
        public string TuaDe { get; set; }

        public AnPham()
        {

        }
        public AnPham(int nam, string nhaXuatBan, string tuaDe)
        {
            Nam = nam;
            NhaXuatBan = nhaXuatBan;
            TuaDe = tuaDe;
        }

        public AnPham(string line)
        {
            string[] str = line.Split(',');
            Nam = int.Parse(str[1]);
            NhaXuatBan = str[2];
            TuaDe = str[3];
        }


        public virtual void HienThiThongTin()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return string.Format($"{Nam,-10}|{NhaXuatBan,-15}|{TuaDe,-15}|");
        }
    }
}

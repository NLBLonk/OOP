using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
        internal class SinhVien
        {
            
            //khai bao kdl ma sinh vien -> string
            public string maSv;
            //khai bao ho ten ->  string
            public string hoten;
            //khai bao diem trung binh -> double
            public double dTB;
            //khai bao gioi tinh  -> boolean
            public Boolean gioiTinh;
            //khai bao lop-> string trong pham vi private (rieng tu)
            private string lop;

            
            public string Lop
            {
                //get, set giup ta truy cap và thao tac với "lop"
                get { return lop; }
                set { lop = value.Trim(); }
            }

            //phuong thuc tao lap mac dinh cua lop sinh vien khong co tham so
            public SinhVien()
            {
                // gan chuoi 010 cho thuoc tinh maSv
                maSv = "010";
                // gan gia tri chuoi "Nguyen Le Bao Long" cho thuoc tinh hoten
                hoten = "Nguyen Le Bao Long";
                // gan gia tri thuc 8.3 cho thuoc tinh dTB 
                dTB = 8.3;
                // gan gia tri true (Nam) cho thuoc tinh gioiTinh
                gioiTinh = true;
                // gan chuoi CTK47A cho thuoc tinh lop
                lop = "CTK47A";
            }

        //phuong thuc tao lap mac dinh cua lop sinh vien co tham so
        public SinhVien(string ma, string ho, double dtb, bool gt, string lop)
            {
                maSv = ma;
                hoten = ho;
                dTB = dtb;
                gioiTinh = gt;
                this.lop = lop;
            }
            public SinhVien(string line)
            {
                //001, Nguyen Van A, 8.0, CTK43
                //them dau "," sau moi bien
                string[] str = line.Split(',');
                maSv = str[0];
                hoten = str[1];
                dTB = double.Parse(str[2]);
                gioiTinh = str[3] == "Nam" ? true : false;
                lop = str[4];
            }

        //Tat ca cac lop thay phuong thuc SinhVien bang phuong thuc ToString
        //Tra ve mot chuoi bieu thi trang thai cua đoi tuong
        public override string ToString()
            {
                return string.Format("{0,2} {1,10} {2,5} {3,6} {4,10}", maSv, hoten, dTB, gioiTinh == true ? "Nam" : "Nu", lop);
            }
        }
}

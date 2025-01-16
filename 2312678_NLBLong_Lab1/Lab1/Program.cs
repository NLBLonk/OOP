using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            List<int> a = new List<int>();
            int x;
            NhapNgauNhien(a); 
            //NhapTuBanPhim(a);
            //NhapTuFile(a);
            //XuatRaFile(a);
            Xuat(a);
            Console.Write("Nhap x: ");
            x = int.Parse(Console.ReadLine());
            //GTLN(a);
            //GTNN(a);
            //DemPTCuaX(a);
            //TongCacPhanTu(a);
            //TrungBinh(a);
            //DemSoChan(a);
            //DemSoLe(a);
            //SXTangDan(a);
            //SXGiamDan(a);
            //KiemTra(a,x);
            //Console.WriteLine("\nTong Am:"+TongAm(a));
            //Console.WriteLine("\n Tong Duong:" + TongDuong(a));
            //TimTatCaSoChan(a);
            //TimTatCaSoLe(a);
            /*int kq=TimVT(a, x);
            if (kq == -1)
                Console.WriteLine("Khong thay");
            else
                Console.WriteLine($"{x} o vi tri thu {kq}");*/
            //Console.WriteLine($"{x} nam o vi tri:" +TimVTCuoiCung(a,x));
            //Console.WriteLine($"{x} nam o vi tri:" + TimVTDauTien(a, x));
        }

        //DINH NGHIA HAM
        static void NhapNgauNhien(List<int> a)
        {
            int length = 0;
            Console.WriteLine(" Nhap vao chieu dai mang ");
            length = int.Parse(Console.ReadLine());
            Random r = new Random();
            for (int i = 0; i < length; i++)
                a.Add(r.Next(10));
        }

        static void NhapTuBanPhim(List<int> a)
        {
            int length = 0;
            int d;
            Console.WriteLine(" Nhap vao chieu dai mang ");
            length = int.Parse(Console.ReadLine());
            for (int i=0; i<length;i++)
            {
                Console.Write(" Nhap a[{0}] :  ",i);
                d = int.Parse(Console.ReadLine());
                a.Add(d);
            }
        }

        static void NhapTuFile(List<int>a)
        {
            string s;
            StreamReader sr = new StreamReader("a.txt");
            while((s=sr.ReadLine()) != null)
            {
                a.Add(int.Parse(s));
            }
        }

        static void XuatRaFile(List<int>a)
        {
            StreamWriter sw = new StreamWriter("b.txt");
            foreach (int i in a)
                sw.WriteLine($"{i}");
            sw.Flush();
            sw.Close();
        }

        static int TongCacPhanTu(List<int>a)
        {
            int tong = 0;
            for (int i = 0; i < a.Count; i++) 
            {
                tong = tong + a[i];
            }
            Console.Write($"\nTong: {tong} ");
            return tong;
        }

        static float TrungBinh(List<int>a)
        {
            float TB;
            float tong = 0;
            for (int i = 0; i < a.Count; i++)
            {
                tong = tong + a[i];
            }
            TB = tong / a.Count;
            Console.Write($"\nTrung binh: {TB} ");
            return TB;
        }
        static int GTLN(List<int>a)
        {
            int max = 0;
            for (int i = 0; i < a.Count; i++)
                if (max < a[i])
                {
                    max = a[i];
                }
            Console.WriteLine($"Gia tri lon nhat cua mang la:{max}");
            return max;
        }

        static int GTNN(List<int> a)
        {
            int min = 0;
            for (int i = 0; i < a.Count; i++)
                if (min > a[i])
                {
                    min = a[i];
                }
            Console.WriteLine($"Gia tri nho nhat cua mang la:{min}");
            return min;
        }

        static void DemPTCuaX(List<int> a,int x)
        {
            int dem = 0;
            for (int i=0; i<a.Count;i++)
            {
                if (a[i]==x)
                {
                    dem++;
                }
            }
            Console.WriteLine($"{x} xuat hien {dem} lan");
        }

        static void DemSoChan(List<int>a)
        {
            int demC = 0;
            for (int i=0;i<a.Count;i++)
            {
                if (a[i]%2==0)
                {
                    demC++;
                }
            }
            Console.WriteLine($"So le da dem la: {demC}");
        }

        static void DemSoLe(List<int> a)
        {
            int demL = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] % 2 != 0)
                {
                    demL++;
                }
            }
            Console.WriteLine($"So chan da dem la: {demL}");
        }

        static void KiemTra(List<int> a,int x)
        {
            int dem = 0;
            Console.WriteLine("Nhap x:");
            x = int.Parse(Console.ReadLine());
            for (int i = 0; i < a.Count; i++) {
                if (a[i] == x) {
                    dem++; }
            }
            if (dem == 0)
                Console.WriteLine($"Phan tu {x} khong xuat hien trong danh sach");
            else
                Console.WriteLine($"{x} xuat hien {dem} lan");
        }
        static void SXTangDan(List<int> a)
        {
            int temp;
            for(int i=0; i<a.Count;i++) {
                for(int j=i+1;j<a.Count;j++) {
                    if (a[j] < a[i]) {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sau khi sap xep: ");
            for (int i=0; i<a.Count;i++) {
                Console.Write($" {a[i]}");
            }
        }

        static void SXGiamDan(List<int> a)
        {
            int temp;
            for (int i = 0; i < a.Count; i++) {
                for (int j = i + 1; j < a.Count; j++) {
                    if (a[j] > a[i]) {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp; }
                }
            }
            Console.WriteLine("Sau khi sap xep: ");
            for (int i = 0; i < a.Count; i++) {
                Console.Write($" {a[i]}");
            }
        }

        static void Xuat(List<int> a)
        {
            foreach (int i in a)
                Console.Write($" {i}");
            Console.WriteLine();
        }

        static int TongAm(List<int> a)
        {
            int tong = 0;
            foreach(int i in a)
            {
                if (i<0)
                {
                    tong += i;
                }
            }
            return tong;
        }

        static int TongDuong(List<int> a)
        {
            int tong = 0;
            foreach (int i in a)
            {
                if (i > 0)
                {
                    tong += i;
                }
            }
            return tong;
        }

        static void TimTatCaSoChan(List<int>a)
        {
            Console.WriteLine("So chan:");
            for (int i = 0;i < a.Count;i++)
            {
                if (a[i]%2==0)
                {
                    Console.WriteLine($"\t {a[i]}");
                }
            }
           
        }

        static void TimTatCaSoLe(List<int> a)
        {
            Console.WriteLine("So le:");
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] % 2 != 0)
                {
                    Console.WriteLine($"\t {a[i]}");
                }
            }
        }

        static int TimVT(List<int>a,int x)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (x == a[i])
                    return i+1;
            }
            return -1;
        }

        static int TimVTCuoiCung(List<int>a,int x)
        {
            for (int i = a.Count-1;i>=0;i--)
            {
                if (a[i] == x)
                    return i+1;
            }
            return -1;
        }

        static int TimVTDauTien(List<int>a,int x)
        {
            int vt = 0;
            for (int i =0; i <a.Count; i++)
            {
                if (a[i] == x)
                    return i + 1;
            }
            return vt;
        }
    
    }
}


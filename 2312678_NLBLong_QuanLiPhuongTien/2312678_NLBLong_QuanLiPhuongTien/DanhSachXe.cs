using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _2312678_NLBLong_QuanLiPhuongTien
{
    enum LoaiXe
    {
        AllVehicle,
        Car,
        Motorcycle
    }
    public class DanhSachXe
    {
        List<IVehicle> collection = new List<IVehicle>();
        private void Them(IVehicle xe)
        {
            collection.Add(xe);
        }

        public void DocFile()
        {
            string tenFile = "data.txt";
            StreamReader sr = new StreamReader(tenFile);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string loai = s[0];
                string ten = s[1];
                int tocDo = int.Parse(s[2]);
                int sochongoi = int.Parse(s[3]);
                switch (loai)
                {
                    case "Car":
                        Them(new Car(ten, tocDo,sochongoi));
                        break;
                    case "Motorcycle":
                        Them(new Motorcycle(ten, tocDo));
                        break;
                    
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Loại Xe".PadRight(10) + "|" + "Tên".PadRight(15) + "|" + "Tốc Độ".PadRight(10) + "|" + "Số Chỗ Ngồi".PadRight(15) +"|" + "\n");
            sb.Append("==========|===============|==========|===============|" + "\n");
            foreach (var i in collection)
                sb.AppendLine(i.ToString());
            sb.Append("==========|===============|==========|===============|" + "\n");
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine("Loại Xe".PadRight(10) + "|" + "Tên".PadRight(15) + "|" + "Tốc Độ".PadRight(10) + "|" + "Số Chỗ Ngồi".PadRight(15) + "|" );
            Console.WriteLine("==========|===============|==========|===============|" );
            foreach (var i in collection)
                Console.WriteLine(i.ToString());
            Console.WriteLine("==========|===============|==========|===============|" + "\n");
        }

        #region ĐẾM SỐ LƯỢNG XE THEO LOẠI KẾT HỢP
        public int DemSoLuongXe(Enum Loai)
        {
            if(Loai is LoaiXe)
            switch(Loai)
            {
                    case LoaiXe.Car:
                        return collection.Count(x => x is Car);
                    case LoaiXe.Motorcycle:
                        return collection.Count(x => x is Motorcycle);
                    case LoaiXe.AllVehicle:
                        return collection.Count(x => x is Vehicle);
                    default:
                        return 0;
            }
            return 0;
        }
        public int DemSoLuongTheoSoChoNgoi(int SoChoNgoi)
        {
            int dem = 0;
            foreach(var i in collection)
            {
                if (i is Car && ((Car)i).SoChoNgoi == SoChoNgoi) dem++;   
            }
            return dem;
        }

        public int DemSoLuongTheoTen(string ten)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Vehicle && ten == ((Vehicle)i).Ten) dem++;
            }
            return dem;
        }

        public int DemSoLuongTheoTocDo(int tocdo)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Vehicle && tocdo == ((Vehicle)i).TocDo) dem++;   
            }
            return dem;
        }

        public int DemSoLuongTheoTenVaTocDo(string ten,int tocdo)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Vehicle && tocdo == ((Vehicle)i).TocDo && ten == ((Vehicle)i).Ten) dem++;
            }
            return dem;
        }

        public int DemSoLuongTheoTenVaSoChoNgoi(string ten, int sochongoi)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Motorcycle && ((Motorcycle)i).Ten == ten) dem++;
                if (i is Car && ten == ((Car)i).Ten  && sochongoi == ((Car)i).SoChoNgoi) dem++;
            }
            return dem;
        }

        public int DemSoLuongTheoSoChoNgoiVaTocDo(int sochongoi, int tocdo)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Motorcycle && ((Motorcycle)i).TocDo == tocdo) dem++;
                if (i is Car && tocdo == ((Car)i).TocDo && sochongoi == ((Car)i).SoChoNgoi) dem++;
            }
            return dem;
        }

        public int DemSoLuongTheoTenSoChoNgoiVaTocDo(string ten, int tocdo, int sochongoi)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is Motorcycle && ((Motorcycle)i).Ten == ten && ((Motorcycle)i).TocDo == tocdo)
                { dem++; }
                else if (i is Car && ten == ((Car)i).Ten && tocdo == ((Car)i).TocDo && sochongoi == ((Car)i).SoChoNgoi)
                {
                    dem++;
                }
            }
            return dem;
        }
        #endregion

        #region TÌM PHƯƠNG TIỆN THEO LOẠI KẾT HỢP
        public DanhSachXe TimPT<T>()
        {
            DanhSachXe kq = new DanhSachXe();
            foreach(var i in collection)
            {
                if (i is T)
                    kq.Them(i);
            }   return kq; 
        }

        public DanhSachXe TimPTCarVaMotorcycle()
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Car && i is Motorcycle)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCarHoacMotorcycle()
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Car || i is Motorcycle)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoTen(string ten)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i.Ten==ten)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoSoChoNgoi(int sochongoi)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Car && ((Car)i).SoChoNgoi==sochongoi)
                    kq.Them(i);
            }
            return kq;
        }
        public DanhSachXe TimPTTheoTocDo(int tocdo)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i.TocDo==tocdo)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoTenVaSoChoNgoi(string ten,int sochongoi)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Motorcycle && ((Motorcycle)i).Ten == ten) kq.Them(i);
                if (i is Car && ten == ((Car)i).Ten && sochongoi == ((Car)i).SoChoNgoi)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoTenVaTocDo(string ten, int tocdo)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Vehicle && ten == ((Vehicle)i).Ten && tocdo == ((Vehicle)i).TocDo)
                    kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoTocDoVaSoChoNgoi(int tocdo,int sochongoi)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Vehicle && tocdo == ((Vehicle)i).TocDo)
                    if( ((Vehicle)i) is Car && sochongoi == ((Car)i).SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTTheoTenTocDoVaSoChoNgoi(string ten, int tocdo, int sochongoi)
        {
            DanhSachXe kq = new DanhSachXe();
            foreach (var i in collection)
            {
                if (i is Motorcycle && ((Motorcycle)i).Ten == ten && ((Motorcycle)i).TocDo == tocdo) kq.Them(i);
                else if (i is Car && ten == ((Car)i).Ten && tocdo == ((Car)i).TocDo && sochongoi == ((Car)i).SoChoNgoi)
                {
                    kq.Them(i);
                }
            }
            return kq;
        }

        #endregion

        #region TÌM CAR VÀ MOTORCYCLE (MAX,MIN)
        public int TimCarCoCSNMax()
        {
            int max = 0;
            foreach(var i in collection)
                if(i is Car && ((Car)i).SoChoNgoi >max)
                    max = ((Car)i).SoChoNgoi;
            return max;
        }

        public int TimCarCoCSNMin()
        {
            int min = int.MaxValue;
            foreach (var i in collection)
                if (i is Car && ((Car)i).SoChoNgoi < min)
                    min = ((Car)i).SoChoNgoi;
            return min;
        }

        public int TimMotorcycleCoMaxSpeed()
        {
            int max = 0;
            foreach (var i in collection)
                if (i is Motorcycle && ((Motorcycle)i).TocDo > max)
                    max = ((Motorcycle)i).TocDo;
            return max;
        }

        public int TimMotorcycleCoMinSpeed()
        {
            int min = int.MaxValue;
            foreach (var i in collection)
                if (i is Motorcycle && ((Motorcycle)i).TocDo < min)
                    min = ((Motorcycle)i).TocDo;
            return min;
        }
        #endregion

        #region SẮP XẾP
        public enum TangGiam
        { 
            Tang,
            Giam
        }
        public enum KieuSapXep
        {
            TangTheoSpeed,
            GiamTheoSpeed,
            TangTheoTen,
            GiamTheoTen,
            TangTheoSCN,
            GiamTheoSCN

        }
        void SapXep(KieuSapXep kieu)
        {
            if (kieu == KieuSapXep.TangTheoTen) collection.Sort((xe1, xe2) => xe1.Ten.CompareTo(xe2.Ten));
            if (kieu == KieuSapXep.GiamTheoTen) collection.Sort((xe1, xe2) => -xe1.Ten.CompareTo(xe2.Ten));
            if (kieu == KieuSapXep.TangTheoSpeed) collection.Sort((xe1, xe2) => xe1.TocDo.CompareTo(xe2.TocDo));
            if (kieu == KieuSapXep.GiamTheoSpeed) collection.Sort((xe1, xe2) => -xe1.TocDo.CompareTo(xe2.TocDo));
        }
        public DanhSachXe SapXepSCN(KieuSapXep kieu)
        {
            List<Car> cars = collection.OfType<Car>().ToList();
            DanhSachXe kq = new DanhSachXe();
            if (kieu==KieuSapXep.TangTheoSCN) cars.Sort((xe1, xe2) => xe1.SoChoNgoi.CompareTo(xe2.SoChoNgoi));
            if (kieu == KieuSapXep.GiamTheoSCN) cars.Sort((xe1, xe2) => -xe1.SoChoNgoi.CompareTo(xe2.SoChoNgoi));
            foreach (var pt in cars)
                kq.Them(pt);
            return kq;
        }

        public void SapXepTheoSpeed(TangGiam x)
        {
            switch (x)
            {
                    case TangGiam.Tang:
                        SapXep(KieuSapXep.TangTheoSpeed);
                        break;
                    case TangGiam.Giam:
                        SapXep(KieuSapXep.GiamTheoSpeed);
                        break;
            }    
        }
        public void SapXepTheoTen(TangGiam x)
        {
            switch (x)
            {
                case TangGiam.Tang:
                    SapXep(KieuSapXep.TangTheoTen);
                    break;
                case TangGiam.Giam:
                    SapXep(KieuSapXep.GiamTheoTen);
                    break;
            }
        }
        
        public void SapXepTangTheoTenVaTocDo()
        {
            collection.Sort((xe1, xe2) =>
            {
                int ten = xe1.Ten.CompareTo(xe2.Ten);
                if (ten == 0)
                    return xe1.TocDo.CompareTo(xe2.TocDo);
                return ten;
            });
        }

        public void SapXepGiamTheoTenVaTocDo()
        {
            collection.Sort((xe1, xe2) =>
            {
                int ten = -xe1.Ten.CompareTo(xe2.Ten);
                if (ten == 0)
                    return -xe1.TocDo.CompareTo(xe2.TocDo);
                return ten;
            });
        }

        public DanhSachXe SapXepTangTheoTenVaSoChoNgoi()
        {
            List<Car> cars = collection.OfType<Car>().ToList();
            DanhSachXe kq = new DanhSachXe();
            cars.Sort((xe1, xe2) =>
            {
                int ten = xe1.Ten.CompareTo(xe2.Ten);
                if (ten == 0)
                    return xe1.SoChoNgoi.CompareTo(xe2.SoChoNgoi);
                return ten;
            });
            foreach (var i in cars)
                kq.Them(i);
            return kq;
        }

        public DanhSachXe SapXepGiamTheoTenVaSoChoNgoi()
        {
            List<Car> cars = collection.OfType<Car>().ToList();
            DanhSachXe kq = new DanhSachXe();
            cars.Sort((xe1, xe2) =>
            {
                int ten = -xe1.Ten.CompareTo(xe2.Ten);
                if (ten == 0)
                    return -xe1.SoChoNgoi.CompareTo(xe2.SoChoNgoi);
                return ten;
            });
            foreach (var i in cars)
                kq.Them(i);
            return kq;
        }
        #endregion

        #region TÌM PHƯƠNG TIỆN CÓ GIÁ TRỊ MAX,MIN
        public DanhSachXe TimDSVehicleMin()
        {
            DanhSachXe kq = new DanhSachXe();
            int min = collection.Min(x => x.Ten.Length);
            foreach (var i in collection)
            {
                if (i is Vehicle && i.Ten.Length == min) kq.Them(i);
            }
            return kq;
        }
        public DanhSachXe TimDSVehicleMax()
        {
            DanhSachXe kq = new DanhSachXe();
            int max = collection.Max(x => x.Ten.Length);
            foreach (var i in collection)
            {
                if (i is Vehicle && i.Ten.Length == max) kq.Them(i);
            }    
            return kq; 
        }

        public int TimCarMax()
        {
            List<Car> car = collection.OfType<Car>().ToList();
            return car.Max(x => x.Ten.Length);
        }

        public DanhSachXe TimDSCarMax()
        {
            DanhSachXe kq = new DanhSachXe();
            int max = TimCarMax();
            foreach (var i in collection)
            {
                if (i is Car && i.Ten.Length == max) kq.Them(i);
            }
            return kq;
        }
        public int TimCarMin()
        {
            List<Car> car = collection.OfType<Car>().ToList();
            return car.Min(x => x.Ten.Length);
        }

        public DanhSachXe TimDSCarMin()
        {
            DanhSachXe kq = new DanhSachXe();
            int min = TimCarMin();
            foreach (var i in collection)
            {
                if (i is Car && i.Ten.Length == min) kq.Them(i);
            }
            return kq;
        }
        public int TimMotorcycleMin()
        {
            List<Motorcycle> motorcycles = collection.OfType<Motorcycle>().ToList();
            return motorcycles.Min(x => x.Ten.Length);
        }

        public DanhSachXe TimDSMotorcycleMin()
        {
            DanhSachXe kq = new DanhSachXe();
            int min = TimMotorcycleMin();
            foreach (var i in collection)
            {
                if (i is Motorcycle && i.Ten.Length == min) kq.Them(i);
            }
            return kq;
        }

        public int TimMotorcycleMax()
        {
            List<Motorcycle> motorcycles = collection.OfType<Motorcycle>().ToList();
            return motorcycles.Max(x => x.Ten.Length);
        }    

        public DanhSachXe TimDSMotorcycleMax()
        {
            DanhSachXe kq = new DanhSachXe();
            int max = TimMotorcycleMax();
            foreach (var i in collection)
            {
                if (i is Motorcycle && i.Ten.Length == max) kq.Them(i);
            }
            return kq;
        }
          public DanhSachXe TimPTCoTocDoMax()
          {
            DanhSachXe kq = new DanhSachXe();
            int max = collection.Max(x => x.TocDo);
            foreach (var i in collection)
            {
                if (i.TocDo == max) kq.Them(i); 
            }    
            return kq;
          }

           public DanhSachXe TimPTCoTocDoMin()
           {
                DanhSachXe kq = new DanhSachXe();
                int min = collection.Min(x => x.TocDo);
                foreach (var i in collection)
                {
                    if (i.TocDo == min) kq.Them(i);
                }
                return kq;
           }

        public DanhSachXe TimPTCoTenDaiNhat()
        {
            DanhSachXe kq = new DanhSachXe();
            int max = collection.Max(x => x.Ten.Length);
            foreach (var i in collection)
            {
                if (i.Ten.Length == max) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenNganNhat()
        {
            DanhSachXe kq = new DanhSachXe();
            int min = collection.Min(x => x.Ten.Length);
            foreach (var i in collection)
            {
                if (i.Ten.Length == min) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoCSNMax()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int max = cars.Max(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.SoChoNgoi == max) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoCSNMin()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int min = cars.Min(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.SoChoNgoi == min) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenVaSpeedMax()
        {
            DanhSachXe kq = new DanhSachXe();
            int max = collection.Max(x => x.Ten.Length); int maxspeed = collection.Max(x=> x.TocDo);
            foreach (var i in collection)
            {
                if (i.Ten.Length == max && maxspeed == i.TocDo) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenVaSpeedMin()
        {
            DanhSachXe kq = new DanhSachXe();
            int min = collection.Min(x => x.Ten.Length); int minspeed = collection.Max(x => x.TocDo);
            foreach (var i in collection)
            {
                if (i.Ten.Length == min && minspeed == i.TocDo) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenVaCSNMax()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int max = cars.Max(x => x.Ten.Length);
            int maxsit = cars.Max(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.Ten.Length == max && maxsit == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenVaCSNMin()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int min = cars.Min(x => x.Ten.Length);
            int minseat = cars.Min(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.Ten.Length == min && minseat == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTocDoVaCSNMax()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int max = cars.Max(x => x.TocDo);
            int maxseat = cars.Max(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.TocDo == max && maxseat == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTocDoVaCSNMin()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int min = cars.Min(x => x.TocDo);
            int minseat = cars.Min(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.TocDo == min && minseat == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenTocDoVaCSNMax()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int maxten = cars.Max(x => x.Ten.Length);
            int max = cars.Max(x => x.TocDo);
            int maxseat = cars.Max(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.Ten.Length==maxten && i.TocDo == max && maxseat == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        public DanhSachXe TimPTCoTenTocDoVaCSNMin()
        {
            DanhSachXe kq = new DanhSachXe();
            List<Car> cars = collection.OfType<Car>().ToList();
            int minten = cars.Min(x => x.Ten.Length);
            int min = cars.Min(x => x.TocDo);
            int minseat = cars.Min(x => x.SoChoNgoi);
            foreach (var i in cars)
            {
                if (i.Ten.Length == minten && i.TocDo == min && minseat == i.SoChoNgoi) kq.Them(i);
            }
            return kq;
        }

        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QuanLyDongVat
{
    public class DanhSachDongVat
    {
        List<IAnimal> collection = new List<IAnimal>();

        private void Them(IAnimal x)
        {
            collection.Add(x);
        }

        public void DocFile()
        {
            string tenFile = "Data.txt";
            StreamReader sr = new StreamReader(tenFile);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string loai = s[0];
                string name = s[1];
                int age = int.Parse(s[2]);
                switch (loai)
                {
                    case "Lion":
                        Them(new Lion(name,age));
                        break;
                    case "Bird":
                        Them(new Bird(name, age));
                        break;
                    case "Bat":
                        Them(new Bat(name, age));
                        break;
                }
            }    
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Động Vật".PadRight(10) + "|" + "Tuổi".PadRight(10) + "|" + "Tiếng Kêu".PadRight(15) + "|" + "Bay".PadRight(16)+"|"+"\n");
            sb.Append("==========|==========|===============|================|"+"\n");
            foreach (var i in collection)
                sb.AppendLine(i.ToString());
            sb.Append("==========|==========|===============|================|" + "\n");
            return sb.ToString();
        }

        public int DemSoLuongDoi()
        {
            return collection.Count(x => x is Bat);
        }

        public int DemSoLuongChim()
        {
            return collection.Count(x => x is Bird);
        }
        public int DemSoLuongSuTu()
        {
            return collection.Count(x => x is Lion);
        }

        public int DemSoLuongBAY()
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is IAnimal && i is IFlyable)
                    dem++;
            }
            return dem;
        }

        public int DemSoLuongKoBietBAY()
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i is NonFlyable)
                    dem++;
            }
            return dem;
        }
    }
}

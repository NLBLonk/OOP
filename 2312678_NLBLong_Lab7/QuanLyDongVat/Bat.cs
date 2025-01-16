using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongVat
{
    public class Bat:IAnimal,IFlyable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Bat()
        {

        }

        public Bat(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Speak()
        {
           return "Chít Chít...";
        }

        public string Fly()
        {
            return "Đang bay lượn...";
        }

        public override string ToString()
        {
            return string.Format("{0,10}|{1,10}|{2,15}|{3,10}|", Name, Age, Speak(), Fly());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongVat
{
    public class Bird:IFlyable,IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Bird()
        {

        }

        public Bird(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Speak()
        {
            return "Hót...";
        }
        public string Fly()
        {
            return "Đang bay lượn...";
        }
        public override string ToString()
        {
            return string.Format("{0,10}|{1,10}|{2,15}|{3,10}|", Name, Age, Speak(),Fly());
        }
    }
}

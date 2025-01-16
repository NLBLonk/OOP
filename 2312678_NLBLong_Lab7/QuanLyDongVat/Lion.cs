using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongVat
{
    public class Lion:IAnimal,NonFlyable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Lion()
        {

        }

        public Lion(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Speak()
        {
            return "Grum...";

        }

        public override string ToString()
        {
            return string.Format("{0,10}|{1,10}|{2,15}|                |", Name, Age,Speak());
        }
    }
}

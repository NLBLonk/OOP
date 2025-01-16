using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua_QLHinhHoc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Shape hTron = new Circle(5);
			Shape hChuNhat = new Rectangle(4, 6);
			Shape hTamGiac = new Triangle(2, 3, 4);

			Console.WriteLine("Diện tích hình tròn là: " + hTron.Area());
			Console.WriteLine("Chu vi hình tròn là: " + hTron.Perimeter());
			hTron.Draw();
            Console.WriteLine();

            Console.WriteLine("Diện tích hình chữ nhật là: " + hChuNhat.Area());
			Console.WriteLine("Chu vi hình chữ nhật là: " + hChuNhat.Perimeter());
			hChuNhat.Draw();
			Console.WriteLine();

			Console.WriteLine("Diện tích hình tam giác là: " + hTamGiac.Area());
			Console.WriteLine("Chu vi hình tam giác là: " + hTamGiac.Perimeter());
			hTamGiac.Draw();
			Console.WriteLine();

			Console.ReadKey();
		}
	}
}

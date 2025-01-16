using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua_QLHinhHoc
{
	public class Rectangle : Shape
	{
		private double length;
		private double width;
		public Rectangle(double length,double width)
		{
			this.length = length;
			this.width = width;
		}
		public override double Area()
		{
			return length * width;
		}
		public override double Perimeter()
		{
			return 2 * length + 2 * width;
		}
		public override void Draw()
		{
			Console.WriteLine("Vẽ hình chữ nhật...");
        }
	}
}

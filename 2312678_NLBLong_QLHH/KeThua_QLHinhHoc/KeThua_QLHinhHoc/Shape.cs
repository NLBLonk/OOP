using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua_QLHinhHoc
{
	public abstract class Shape
	{
		public abstract double Area();
		public abstract double Perimeter();

		//Phương thức cụ thể
		public virtual void Draw()
		{
			Console.WriteLine("Vẽ hình...");
		}
	}
}

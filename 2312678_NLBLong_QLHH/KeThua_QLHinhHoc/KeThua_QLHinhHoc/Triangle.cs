using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua_QLHinhHoc
{
	internal class Triangle:Shape
	{
		public double CanhA;
		public double CanhB;
		public double CanhC;

		public Triangle(double CanhA,double CanhB,double CanhC)
		{
			this.CanhA = CanhA;
			this.CanhB = CanhB;
			this.CanhC = CanhC;
		}
		public override double Area()
		{
			double p = (CanhA + CanhB + CanhC) / 2;
			return Math.Sqrt(p * (p - CanhA) * (p - CanhB) * (p - CanhC));
		}
		public override double Perimeter()
		{
			return CanhA + CanhB + CanhC;
		}
		public override void Draw()
		{
			Console.WriteLine("Vẽ hình tam giác...");
		}
		}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Feladat_00
{
	public class MathFunctions
	{
		public static int Sum(int firstAttend, int secondAttend)
		{
			int sum = firstAttend + secondAttend;
			return sum;
		}
		public static double Sum(double firstAttend, double secondAttend)
		{
			double sum = firstAttend + secondAttend;
			return sum;
		}
		public static float Sum(float firstAttend, float secondAttend)
		{
			float sum = firstAttend + secondAttend;
			return sum;
		}
		public static int Sum(int firstAttend, int secondAttend, int thirdAttend)
		{
			int sum = firstAttend + secondAttend + thirdAttend;
			return sum;
		}
	}
}

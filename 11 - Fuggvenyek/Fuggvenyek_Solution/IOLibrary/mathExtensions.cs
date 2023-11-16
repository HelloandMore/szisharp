using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static partial class Math
{
	public static double CelsiusToKelvin(double celsius) => celsius + 273.15;

	public static double CelsiusToFahrenheit(double celsius) => (9 / 5) * celsius + 32;
}

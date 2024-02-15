using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomLibrary;

public static partial class MathExtensions
{
	public static double CelsiusToKelvin(double celsius) => celsius + 273.15;
	public static double CelsiusToFahrenheit(double celsius) => (9 / 5) * celsius + 32;
	public static double Pythagoras(double xLenght, double yLenght) => Math.Sqrt(Math.Pow(xLenght, 2) + Math.Pow(yLenght, 2));
	public static double BmiIndex(double weight, double height) => weight / (height * height);
}

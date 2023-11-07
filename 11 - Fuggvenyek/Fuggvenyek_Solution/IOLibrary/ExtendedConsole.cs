using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IOLibrary;

public static class ExtendedConsole
{
	public static int ReadInteger()
	{
		bool isNumber = false;
		int number = 0;
		do
		{
			string text = Console.ReadLine();
			isNumber = int.TryParse(text, out number);
		} while (!isNumber);
		
		return number;
	}
	public static double ReadDouble()
	{
		bool isNumber = false;
		double number = 0;
		do
		{
			string text = Console.ReadLine();
			isNumber = double.TryParse(text, new CultureInfo("en-US"), out number);
		} while (!isNumber);
		
		return number;
	}
}

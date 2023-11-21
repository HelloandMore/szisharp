using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Drawing;

namespace IOLibrary;

public static class ExtendedConsole
{
	public static int ReadInteger(string prompt, int max)
	{
		bool isNumber = false;
		int number = 0;

		do
		{
			Console.WriteLine(prompt);

			string text = Console.ReadLine();
			isNumber = int.TryParse(text, out number);

			if (number > max)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"A megadott szám nem lehet nagyobb mint {max}");

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("A folytatáshoz nyomjon meg bármely gombot");
				Console.ReadKey();
				Console.ResetColor();

			} 
			else if (!isNumber)
			{
				Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SZÁMOT adj meg!!");

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("A folytatáshoz nyomjon meg bármely gombot");
				Console.ReadKey();
				Console.ResetColor();
			}
		} while (!isNumber || number > max);
		return number;
	}
	public static double ReadDouble(string prompt)
	{
		bool isNumber = false;
		double number = 0;
		do
		{
            Console.Write(prompt);
            string text = Console.ReadLine();
			isNumber = double.TryParse(text, new CultureInfo("en-US"), out number);
		} while (!isNumber);

		return number;
	}
	public static string ReadString(string prompt)
	{
		string text = string.Empty;

		do
		{
            Console.Write(prompt);
            text = Console.ReadLine().Trim();
		} while (string.IsNullOrWhiteSpace(text));

		return text;
	}
}
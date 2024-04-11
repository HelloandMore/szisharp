namespace Custom.Library.ConsoleExtensions;

public static class ExtendedConsole
{
    public static int ReadInteger(string prompt)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(prompt);

            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);
        }
        while (!isNumber);

        return number;
    }

    public static int ReadInteger(string promt, int max)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(promt);

            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);

            if(number > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szam nem lehet nagyobb mint {max}");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"A folytatashoz nyomja meg barmely gombot!");
                
                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        while (!isNumber || number > max);

        return number;
    }

    public static int ReadInteger(string promt, int min, int max)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(promt);

            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);

            if (number > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szam nem lehet nagyobb mint {max}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"A folytatashoz nyomja meg barmely gombot!");

                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        while (!isNumber || number < min || number > max);

        return number;
    }

    public static int ReadPositiveInteger(string promt)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(promt);

            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);

            if (number < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szam nem lehet kisebb mint 0");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"A folytatashoz nyomja meg barmely gombot!");

                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        while (!isNumber || number < 0);

        return number;
    }

    public static double ReadDouble(string promt)
    {
        bool isNumber = false;
        double number = 0;

        do
        {
            Console.WriteLine(promt);

            string text = Console.ReadLine();
            isNumber = double.TryParse(text, new CultureInfo("en-EN"), out number);
        }
        while (!isNumber);

        return number;
    }

    public static string ReadString(string promt)
    {
        string text = string.Empty;

        do
        {
            Console.Write(promt);
            text = Console.ReadLine()
                          .Trim();
        }
        while (string.IsNullOrWhiteSpace(text));

        return text;
    }

    public static char ReadChar(string promt, ICollection<char> chars)
    {
        char character;
        do
        {
            Console.Write(promt);
            character = Console.ReadKey().KeyChar;
        }
        while (!chars.Contains(character));

        return character;
	}
}

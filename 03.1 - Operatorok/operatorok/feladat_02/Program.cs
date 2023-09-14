Console.WriteLine("Kérni fogok három számot egy egyszerű műveletre");
Console.Write("Az első szám: ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("A második szám: ");
int secondNumber = int.Parse(Console.ReadLine());

Console.Write("A harmadik szám: ");
int thirdNumber = int.Parse(Console.ReadLine());

int sumResult = (firstNumber + secondNumber) - thirdNumber;

Console.WriteLine("A művelet a következő volt: ({0} + {1}) - {2}", firstNumber, secondNumber, thirdNumber);
Console.WriteLine("aminek az eredménye {0} lett", sumResult);
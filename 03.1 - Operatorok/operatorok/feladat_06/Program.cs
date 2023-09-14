Console.Write("Add meg az első számot > ");
double firstNumber = double.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
double secondNumber = double.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
double thirdNumber = double.Parse(Console.ReadLine());

double result = ((firstNumber + 0.5) / (secondNumber - 0.7)) % thirdNumber;
Console.WriteLine($"A művelet a következő volt: (({firstNumber} + 0.5) / ({secondNumber} - 0.7)) % {thirdNumber}");
Console.WriteLine($"Ennek az eredménye: {result}");
Console.Write("Add meg az első számot > ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int secondNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
int thirdNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a negyedik számot > ");
double fourthNumber = double.Parse(Console.ReadLine());

double result = (firstNumber + secondNumber) / (thirdNumber - fourthNumber);
Console.WriteLine($"A művelet a következő: ({firstNumber} + {secondNumber}) / ({thirdNumber} - {fourthNumber})");
Console.WriteLine($"Ennek eredménye: {result}");
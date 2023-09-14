Console.Write("Add meg az első számot > ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int secondNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
double thirdNumber = double.Parse(Console.ReadLine());

double result = (firstNumber * secondNumber) / thirdNumber;

Console.WriteLine("A művelet a következő volt: ({0} * {1}) / {2}", firstNumber, secondNumber, thirdNumber);
Console.WriteLine("Ennek az eredménye: {0}", result);
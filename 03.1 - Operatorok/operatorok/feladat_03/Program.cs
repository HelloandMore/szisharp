Console.Write("Add meg az első számot > ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int secondNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
double thirdNumber = double.Parse(Console.ReadLine());

Console.WriteLine("A következő művelet eredménye (({0} * {1}) / {2}):", firstNumber, secondNumber, thirdNumber);
double sumResult = (firstNumber - secondNumber) * thirdNumber;
Console.WriteLine(sumResult);
// kecske approved
using Feladat_00;
using IOLibrary;
using System.Runtime.CompilerServices;

//int Sum(int firstAddend, int secondAddend) => firstAddend + secondAddend;

var sum = MathFunctions.Sum(3.3f, 5.38);
var sum1 = MathFunctions.Sum(secondAttend: 1, thirdAttend: 3, firstAttend: 1);

Console.ReadKey();

Console.Write("Adj meg egy számot > ");
int number = ExtendedConsole.ReadInteger();

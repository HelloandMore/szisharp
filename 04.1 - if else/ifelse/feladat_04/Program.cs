Console.Write("Add meg a két vizsgálandó szám közül az elsőt > ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Add meg a másodikat > ");
int secondNumber = int.Parse(Console.ReadLine());

if (firstNumber == secondNumber)
{
    Console.WriteLine($"A kettő szám egyenlő ({firstNumber} = {secondNumber})");
}
else if (firstNumber > secondNumber)
{
    Console.WriteLine($"Az első szám ({firstNumber} > {secondNumber}) a nagyobb a kettő közül");
}
else if (secondNumber > firstNumber)
{
    Console.WriteLine($"A második szám ({secondNumber} < {firstNumber}) a nagyobb a kettő közül");
}
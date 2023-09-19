Console.Write("Add meg az első számot > ");
int numberOne = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int numberTwo = int.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
int numberThree = int.Parse(Console.ReadLine());

if (numberOne % numberTwo == 0)
{
    Console.WriteLine("Az első szám OSZTHATÓ a másodikkal");
}
else if (numberOne % numberTwo != 0)
{
    Console.WriteLine("Az első szám NEM osztható a másodikkal");
}

if (numberThree % numberOne == 0 && numberThree % numberTwo == 0)
{
    Console.WriteLine("A HARMADIK szám OSZTHATÓ mindkét másikkal!");
}
else
{
    Console.WriteLine("A HARMADIK szám NEM osztható mindkét másik számmal (legalábbis az egyikkel)");
}
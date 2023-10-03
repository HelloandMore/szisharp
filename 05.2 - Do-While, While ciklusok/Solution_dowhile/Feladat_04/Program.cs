int altogether = 0;
int numofNumbers = 0;
int currentNum = -1;

do
{
    numofNumbers++;
    Console.WriteLine($"A számok összege: {altogether}");
    Console.WriteLine("Írd egészen addig a számokat, míg azok összege el nem éri a 100-at!");
    Console.Write($"{numofNumbers}. szám > ");
    currentNum = int.Parse(Console.ReadLine());
    altogether += currentNum;
} while ( altogether < 100 );
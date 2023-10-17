Random rnd = new Random();
int evenNumber  = 0;
int oddNumber = 0;
bool isNumber = false;
int random = 0;
double average  = 0;
int canBeSharedWith4 = 0;
double arithmeticMean = 0;

do
{
    Console.Write("Kérek egy páros számot: ");
     string input = Console.ReadLine();

    isNumber = int.TryParse(input, out evenNumber );

}
while ( !isNumber || evenNumber % 2 != 0);

do
{
    Console.Write("Kérek egy páratlan számot: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out oddNumber);

}
while (!isNumber || oddNumber % 2 == 0 || oddNumber < evenNumber);

random = rnd.Next(evenNumber, oddNumber);

arithmeticMean = evenNumber + ((oddNumber - evenNumber)/2);

if(random < arithmeticMean)
{
    Console.WriteLine($"A {random} a páratlan számtól van messzebb.");
}
else if(random > arithmeticMean)
{
    Console.WriteLine($"A {random} a páros számtól van messzebb");
}
else
{
    Console.WriteLine("Pontosan a két szám között van.");
}

average = (double)(oddNumber + evenNumber) / 2;

for (int i = evenNumber; i < oddNumber; i++)
{
    if (i % 4 == 0)
    {
        canBeSharedWith4++;
    }
}

Console.WriteLine($"A két szám átlaga: {average}\nA két szám között {canBeSharedWith4} db szám osztható 4-el");
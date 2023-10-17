int number = 0;
int numberOfTries = 0;
int result = 0;
bool isNumber = false;


while (!isNumber || result < 100) 
{
    numberOfTries++;

    Console.Write("Kérek egy számot: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);

    result += number;

    Console.WriteLine($"Jelenleg {numberOfTries} leütésnél tart és a jelenlegi összeg {result}");
}


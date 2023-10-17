Console.WriteLine("1 - Fanta\n2 - Coca Cola\n3 - Sprite\n4 - Szentkirályi\n5 - Márka\n6 - Nestea\n7 - gyümölcslé");

int number = 0;
bool isNumber = false;
string result = "";

while (!isNumber) 
{
    Console.Write("Kérek egy számot a listából: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);
}


result = number switch
{
    1 => "Fanta",
    2 => "Coca Cola",
    3 => "Sprite",
    4 => "Szentkirályi",
    5 => "Márka",
    6 => "Nestea",
    7 => "gyümölcslé",
    _ => "Nem létező üdítő"
};
Console.WriteLine($"Az ön választása: {result}.");
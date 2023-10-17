int age = 0;
string classification = "";
bool isNumber = false;

while (!isNumber || (age < 0 || age > 99)) 

{
    Console.Write("Kérek egy életkort 0 és 99 év között: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out age);

}

classification = age switch
{
    >= 0 and <= 6 => "gyerek",
    >= 7 and <= 18 => "iskolás",
    >= 19 and <= 65 => "dolgozó",
    > 65 => "nyugdíjas",
};

Console.WriteLine($"Az életkor besorolása: {classification}");
using IOLibrary;

Random randomNumber = new Random();
int firstRandom = randomNumber.Next(0, 9);
int secondRandom = randomNumber.Next(40, 50);
int theNumber = randomNumber.Next(firstRandom, secondRandom);
int tries = guessingTheRightNumber(theNumber, firstRandom, secondRandom);

static int guessingTheRightNumber(int theNumber, int firstRandom, int secondRandom)
{
	int numberOfGuesses = 0;
	int theGuess;

	Console.WriteLine($"Találd ki a számot {firstRandom}-{secondRandom} között");
	do
	{
		numberOfGuesses += 1;
        Console.WriteLine($"Próba száma: {numberOfGuesses}");
        theGuess = ExtendedConsole.ReadInteger("Tipped > ", secondRandom, firstRandom);
		if (theGuess < theNumber)
		{
            Console.WriteLine("A megadott szám NAGYOBB!");
        } else if (theNumber < theGuess)
		{
            Console.WriteLine("A megadott szám KISEBB!");
        }
	} while (theGuess != theNumber);
    
	Console.WriteLine("\nA tipped HELYES!!!!!");

    return numberOfGuesses;
}
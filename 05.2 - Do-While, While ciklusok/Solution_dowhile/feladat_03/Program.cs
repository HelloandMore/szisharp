using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

Random rnd = new Random();
int randomsetNumber = rnd.Next(0, 10);
int numofTriesRemaining = 5;
int numofTries = 0;
int guess = -1;

do
{
    numofTries++;
    numofTriesRemaining--;
    Console.WriteLine($"\nTaláld ki a random számot 0 és 10 között {numofTriesRemaining} próbából");
	Console.Write($"Próba {numofTries} > ");
    guess = int.Parse(Console.ReadLine());
} while( guess != randomsetNumber && numofTriesRemaining > 0);

if (guess == randomsetNumber)
{
	Console.WriteLine("\nSIKER!!44!!!!");
}
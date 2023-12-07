Random rnd = new Random();

int[] array = await getInArrayAsync(10); //await bevárjuk, hogy a függvény lefusson

Console.WriteLine("Generated array");
printArrayToConsole(array);

int sum = getArraySum(array);
Console.WriteLine($"\nSum of array: {sum}");

double average = (double)sum / array.Length;
Console.WriteLine($"\nAverage of the array: {average:F2}");

int[] evenArray = getEvenNumbersfromArray(array);
Console.WriteLine($"\nEven elements of the array: ");
printArrayToConsole(evenArray);

int twoDigitArray = getTwoDigitNums(array);
Console.WriteLine($"\nAmount of numbers greater, than 9 in the array: {twoDigitArray}");

int oneDigitArray = getSingleDigitNums(array);
Console.WriteLine($"\nAmount of one digit numbers in array: {oneDigitArray}");

int sumOfOddNums = getOddnumsSumOfArray(array);
Console.WriteLine($"\nSum of odd numbers in array: {sumOfOddNums}");

int zeroEndedNum = numsEndingWithZero(array);
Console.WriteLine($"\nNumbers ending with the digit 0: {zeroEndedNum}");

orderArrayAscending(array);
Console.WriteLine($"\nNumbers in ascending order:");
reversePrintArray(array);

Console.ReadKey();

/*
 async - async függvény (a függvény lefutása bevárható, mivel nem fejeződik be rögtön)
Task <int[]> - az async függvény eredménye egy feladat (task)
				egy int típusú több lesz amikor befejeződik
 */

async Task<int[]> getInArrayAsync(int arraySize)
{
	int[] array = new int[arraySize];

	for (int i = 0; i < arraySize; i++)
	{
		array[i] = rnd.Next(0, 100);
		await Task.Delay(100);
	}
	return array;
}

void printArrayToConsole(int[] arrayToPrint)
{
	for (int i = arrayToPrint.Length - 1; i >= 0; i--)
	{
		Console.Write($"[{i + 1}] = {arrayToPrint[i]}\n");
	}
}

void reversePrintArray(int[] arrayToPrint)
{
	for (int i = 0; i >= arrayToPrint.Length - 1; i++)
	{
		Console.Write($"[{i - 1}] = {arrayToPrint[i]}\n");
	}
}

int getArraySum(int[] array)
{
	int sum = 0;

	foreach (int item in array)
	{
		sum += item;
	}
	return sum;
}

int[] getEvenNumbersfromArray(int[] array)
{
	int[] evenNumbers = array.Where(x => x % 2 == 0).ToArray();
	return evenNumbers;
}

int getTwoDigitNums(int[] array) => array.Count(x => x > 9 && x < 100);

int getSingleDigitNums(int[] array) => array.Count(x => x < 10);

int getOddnumsSumOfArray(int[] array) => array.Where(x => x % 2 == 1).Sum(x => x);

int numsEndingWithZero(int[] array) => array.Count(x => x % 10 == 0);

void orderArrayAscending(int[] array)
{
	for(int i = 0; i < array.Length - 1; i++)
	{
		int temp = 0;
		for(int j = 0; j < array.Length; j++)
		{
			if (array[j] < array[i])
			{
				temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			}
		}
	}
}